using API.Models;
using ClassLibrary;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace API.Controllers
{
    [MyActionFilter]
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class CustomApiController : ApiController
    {
        public CustomApiController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();

            //log.Debug("Debug message");
            //log.Warn("Warn message");
            //log.Error("Error message");
            //log.Fatal("Fatal message");
            
        }

        public ILog log = log4net.LogManager.GetLogger("API Logs");

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AppEntities db = new AppEntities();

        public CacheManage cm = new CacheManage();

        protected ApplicationDbContext ApplicationDbContext { get; set; }
        
        public string Username
        {
            get
            {
                return User.Identity.Name;
            }
        }

        int _IDBranch = -1;
        public int IDBranch {
            get {
                if (!User.Identity.IsAuthenticated)
                {
                    return 0;
                }
                else
                {
                    if(_IDBranch != -1)
                    {
                        return _IDBranch;
                    }

                    _IDBranch = 0;

                    //User.Identity.Claims.FirstOrDefault(d => d.Type == "JobTitles");

                    if (User.IsInRole("HOST") && QueryStrings.Any(d => d.Key == "IDBranch"))
                    {
                        var strValue = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value;
                        if (int.TryParse(strValue, out int i))
                        {
                            _IDBranch = i;
                            return _IDBranch;
                        }
                    }
                    else if (QueryStrings.Any(d => d.Key == "IDBranch"))
                    {
                        var IDList = QueryStrings.FirstOrDefault(d => d.Key == "IDBranch").Value.Replace("[", "").Replace("]", "").Split(',');
                        List<int?> IDs = new List<int?>();
                        foreach (var item in IDList)
                            if (int.TryParse(item, out int branch))
                                IDs.Add(branch);
                        if (IDs.Count > 0)
                        {
                            int tempBranchID = IDs[0].GetValueOrDefault();

                            var allowBranchIds = cm.branchRecursiveIds(1);
                            if (allowBranchIds.Any(d=>d.Value== tempBranchID))
                            {
                                _IDBranch = tempBranchID;
                            }
                            
                            return _IDBranch;
                        }
                    }


                    var req = HttpContext.Current.Request.InputStream;
                    string body = new StreamReader(req).ReadToEnd();
                    dynamic stuff =  JsonConvert.DeserializeObject(body);

                    if(stuff!= null && stuff.IDBranch != null)
                    {
                        _IDBranch = stuff.IDBranch;
                        return _IDBranch;
                    }

                    return _IDBranch;
                }
            }
        }
        public int StaffID
        {
            get
            {
                int id = 0;
                var userId = User.Identity.GetUserId();
                var user = UserManager.FindById(userId);

                if (user != null)
                {
                    id = user.StaffID;
                }
                return id;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        bool _isGetQueryString = false;
        Dictionary<string, string> _QueryStrings = new Dictionary<string, string>();
        public Dictionary<string, string> QueryStrings
        {
            get
            {
                if (_isGetQueryString)
                {
                    return _QueryStrings;
                }
                _isGetQueryString = true;
                _QueryStrings = Request.GetQueryNameValuePairs().Distinct().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
                return _QueryStrings;
            }

        }


        //public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        //{
        //    //string localPath = controllerContext.Request.RequestUri.LocalPath;
        //    //log.Info(localPath);
        //    return base.ExecuteAsync(controllerContext, cancellationToken);
        //}

        private bool checkUserRole()
        {
            string id = User.Identity.GetUserId();
            UserManager.GetRoles(id);
            return false;
        }
        //public IList<string> Roles
        //{
        //    get
        //    {
        //        var user = UserManager.FindById(User.Identity.GetUserId());
        //        if (user != null)
        //        {
        //            var roleList = db.tbl_SYS_Role.Where(d => d.tbl_HRM_Staff_In_Role.Any(s => s.Id == user.StaffID));
        //            if (roleList.Count() > 0)
        //            {
        //                foreach (var ro in roleList)
        //                {
        //                    user.Roles.Add(new IdentityUserRole() { RoleId = ro.Code });
        //                }
        //            }
        //            if (user.Roles.Count == 0)
        //            {
        //                user.Roles.Add(new IdentityUserRole() { RoleId = "GUEST" });
        //            }
        //        }

        //        return user.Roles.Select(s => s.RoleId).ToList();
        //    }
        //}
        //public DTO_AppRole AppRole {
        //    get
        //    {
        //        DTO_AppRole result = new DTO_AppRole();

        //        var user = UserManager.FindById(User.Identity.GetUserId());
        //        if (user != null)
        //        {

        //            var CUSRoles = db.tbl_SYS_Role.Where(d => d.tbl_HRM_Staff_In_Role.Any(s => s.Id == user.StaffID));

        //            result.CUSRoles = new List<DTO_CUSRole>();
        //            foreach (var ro in CUSRoles)
        //            {
        //                result.CUSRoles.Add( new DTO_CUSRole() { IDBranch = ro.IDBranch, IDRole = ro.Id, Name = ro.Name });
        //            }

        //            result.SYSRoles = new List<string>();
        //            foreach (var ro in user.Roles)
        //            {
        //                result.SYSRoles.Add(ro.RoleId);
        //            }
        //        }


        //        if (result.SYSRoles.Count == 0 && result.CUSRoles.Count == 0) {
        //            result.SYSRoles.Add("GUEST");
        //        }


        //        return result;
        //    }
        //}

        [ApiExplorerSettings(IgnoreApi = true)]
        public ExcelPackage GetTemplateWorkbook(string fileTemplate, string SaveName, out string fileurl)
        {
            string templateFilePath = "Uploads/FileTemplate/" + fileTemplate;
            string fileName = SaveName;
            string mapPath = HttpContext.Current.Server.MapPath("~/");
            string uploadPath = "/Uploads/" + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/");
            string strDirectoryPath = mapPath + uploadPath;
            string strFilePath = strDirectoryPath + "/" + fileName;
            fileurl = uploadPath + "/" + fileName;

            recheck:
            FileInfo templateFile = new FileInfo(mapPath + templateFilePath);
            if (!templateFile.Exists)
            {
                templateFilePath = "Uploads/FileTemplate/" + "_Template.xlsx"; //Default template file
                goto recheck;
            }

            FileInfo exportFile = new FileInfo(strFilePath);

            if (!System.IO.Directory.Exists(strDirectoryPath))
                System.IO.Directory.CreateDirectory(strDirectoryPath);

            if (exportFile.Exists)
            {
                exportFile.Delete();
                exportFile = new FileInfo(strFilePath);
            }

            var package = new ExcelPackage(templateFile);
            package.SaveAs(exportFile);
            return package;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage saveAndDownloadFile(string fileurl, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            HttpResponseMessage response;
            response = Request.CreateResponse(statusCode);
            response.Content = new StringContent(fileurl);

            return response;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage downloadExcelFile(ExcelPackage package, string fileName)
        {
            
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(package.GetAsByteArray());
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return response;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public ExcelPackage SaveImportedFile(out string fileurl)
        {
            fileurl = "";
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return null;
            }
            

            #region upload file
            var postedFile = httpRequest.Files[0];


            string mapPath = HttpContext.Current.Server.MapPath("~/");
            string fileName = "Validate_" + Path.GetFileName(postedFile.FileName);
            string uploadPath = "/Uploads/" + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/");
            string strDirectoryPath = mapPath + uploadPath;
            string strFilePath = strDirectoryPath + "/" + fileName;

            fileurl = uploadPath + "/" + fileName;

            FileInfo existingFile = new FileInfo(strFilePath);

            if (!System.IO.Directory.Exists(strDirectoryPath))
                System.IO.Directory.CreateDirectory(strDirectoryPath);
            if (existingFile.Exists)
            {
                existingFile.Delete();
                existingFile = new FileInfo(strFilePath);
            }

            postedFile.SaveAs(strFilePath);
            #endregion

            return new ExcelPackage(existingFile);
        }

    }


}


//public(.*) (.*)(?([^\r\n])\s)(.*)(?([^\r\n])\s)({.*})
//$3 = s.$3,