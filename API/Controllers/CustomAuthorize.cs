
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClassLibrary;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.AspNet.Identity;
using API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using log4net;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Runtime.Caching;

namespace API.Controllers
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method,  Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttribute : AuthorizationFilterAttribute
    {
        ILog log = log4net.LogManager.GetLogger("AuthorizeAttribute");
        public AppEntities db = new AppEntities();
        public CacheManage cm = new CacheManage();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            log4net.Util.SystemInfo.NullText = string.Empty;
            string minVersion = "0.17";
            bool isViewable = false;
            string appVersion = "";
            string loggedBy = "unknown";
            string segmentCheck = "";
            int id = 0;
            string ip = HttpContext.Current.Request.UserHostAddress;
            string method = actionContext.Request.Method.Method;
            string body = actionContext.Request.Content.ReadAsStringAsync().Result;
            var user = actionContext.RequestContext.Principal;

            if (user.Identity.IsAuthenticated)
                loggedBy = user.Identity.Name;
            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("AppVersion"))
                appVersion = HttpContext.Current.Request.QueryString.GetValues("AppVersion").FirstOrDefault();

            var req = actionContext.Request.RequestUri;
            
            if (req.Segments.Length > 6 && int.TryParse(req.Segments[6], out id))
                segmentCheck = req.Segments[3] + req.Segments[4] + req.Segments[5].Replace("/", ""); 
            else if (req.Segments.Length > 5 && int.TryParse(req.Segments[5], out id))
                segmentCheck = req.Segments[3] + req.Segments[4].Replace("/", "");
            else
                segmentCheck = actionContext.Request.RequestUri.LocalPath.Replace("/api/v1/", "");
            segmentCheck = string.Format("{0}|{1};", actionContext.Request.Method.Method, segmentCheck).ToLower();

            for (int i = 1; i < req.Segments.Length && i < 8; i++)
                log4net.LogicalThreadContext.Properties["segment" + i] = req.Segments[i].Replace("/", "");

            

            isViewable = getPublicControllerAction().Any(d => d.LocalPath.ToLower().Contains(segmentCheck));
            if (!isViewable && user.Identity.IsAuthenticated)
            {
                var principal = user as System.Security.Claims.ClaimsPrincipal;
                var JobTitles = principal.Claims.FirstOrDefault(d => d.Type == "JobTitles");
                if (JobTitles != null)
                {
                    List<string> SysRoles = new List<string>();
                    if (user.IsInRole("HOST")) SysRoles.Add("HOST");
                    var ps = JobTitles.Value.Split(',').Select(Int32.Parse).ToList();
                    isViewable = cm.getPermissionByPositionAndRole(ps, SysRoles).Count(d => !string.IsNullOrEmpty(d.APIs) && d.APIs.ToLower().Contains(segmentCheck)) > 0;
                }
            }
            
            log4net.LogicalThreadContext.Properties["api"] = req.OriginalString;
            log4net.LogicalThreadContext.Properties["method"] = method;
            log4net.LogicalThreadContext.Properties["data"] = body;

            log4net.LogicalThreadContext.Properties["loggedby"] = loggedBy;
            log4net.LogicalThreadContext.Properties["appversion"] = appVersion;
            log4net.LogicalThreadContext.Properties["ipaddress"] = ip;

            log4net.LogicalThreadContext.Properties["segment0"] = segmentCheck;
            log4net.LogicalThreadContext.Properties["segment9"] = id;
            

            

            if (!isViewable)
            {
                isViewable = true;
            }

            if (!isViewable)
            {
                log.Warn(actionContext.Request.Headers.Referrer.OriginalString + " try to call API => Blocked");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                //actionContext.Response = new HttpResponseMessage((HttpStatusCode)401) { ReasonPhrase = "Unauthorized user" };
            }
            else if (string.Compare(appVersion, minVersion) < 0)
            {
                string message = string.Format("{0}|{1}", minVersion, appVersion );
                log.Warn(message);
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed) { ReasonPhrase = message };
            }
            else
            {
                log.Info(string.Format("{{Action:'{0}', Permission: '{1}', URL: '{2}'}}", "Call", segmentCheck, actionContext.Request.RequestUri.OriginalString ));
                base.OnAuthorization(actionContext);
            }

        }

        public List<controllerAction> getPublicControllerAction()
        {
            List<controllerAction> result = new List<controllerAction>();
            result.Add(new controllerAction() { LocalPath = "GET|Account/UserInfo;" });

            return result;
        }

        

       
    }

    public class controllerAction
    {
        public int Id { get; set; }
        public string LocalPath { get; set; }
        public List<string> Roles { get; set; }
    }
}