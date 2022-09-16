//------------------------------------------------------------------------------
// 
//    www.codeart.vn
//    hungvq@live.com
//    (+84)908.061.119
// 
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Helpers;
using System.Web.Http.Description;
using ClassLibrary;
using DTOModel;
using BaseBusiness;
using System.Text.RegularExpressions;
using API.Models;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace API.Controllers.JOBS
{

    [RoutePrefix("api/JOBS")]
    public class JOBSController : CustomApiController
    {
        //[Route("SynSAPBEO")]
        //public IHttpActionResult GetSapBEO(DateTime FromDate, DateTime ToDate)
        //{

        //    //string apiURL =  "http://localhost/PQCOP-WS-Test/Help/Api/GET-api-BEO_FromDate_ToDate";
        //    string apiURL = "http://hungvq-w10.local:54009/Uploads/sampleBEO.json";

        //    string json = GetURLContent(apiURL);
        //    dynamic data = System.Web.Helpers.Json.Decode(json);

           

        //    for (int i = 0; i < data.Length; i++)
        //    {
                
        //        int docEntry = data[i].DocEntry;
        //        bool isNew = false;

        //        tbl_SAP_BEO b = db.tbl_SAP_BEO.Where(d => d.DocEntry == docEntry).FirstOrDefault();
        //        if (b == null)
        //        {
        //            b = new tbl_SAP_BEO();
        //            b.DocEntry = docEntry;
        //            isNew = true;

        //            b.CreatedBy = "import";
        //            b.CreatedDate = DateTime.Now;
        //        }

        //        if (b.IsDisabled)
        //        {
        //            continue;
        //        }

        //        b.Code = data[i].CardCode;
        //        b.EventDate = DateTime.Parse(data[i].NgaySuKien.ToString());

        //        b.Name = data[i].CustomerName;
        //        b.Floor = data[i].U_VenueInfor;
        //        b.Remark = System.Web.Helpers.Json.Encode(data[i]);

        //        b.ModifiedBy = "import";
        //        b.ModifiedDate = DateTime.Now;


        //        if (isNew)
        //        {
        //            db.tbl_SAP_BEO.Add(b);
        //        }
        //        db.SaveChanges();

        //    }

           

            


        //    return Ok(data.Length);
        //}

        public string GetURLContent(string url)
        {
            string result = null;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "");
                var data = client.DownloadData(url);
                result = Encoding.UTF8.GetString(data);
            }

            return result;

        }

        [AllowAnonymous]
        public IHttpActionResult Post_Test([FromBody] dynamic data)
        {
            Dictionary<string, object> values = ((object)data).GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(data));

            return data;
        }

        [AllowAnonymous]
        public IHttpActionResult Put_Test()
        {

            Task<string> content = Request.Content.ReadAsStringAsync();
            string body = content.Result;
            dynamic data = System.Web.Helpers.Json.Decode(body);
            string lat = "";


            if (DynamicUtil.HasMember(data, "Addresses"))
            {
                foreach (var add in data["Addresses"])
                {
                    if (DynamicUtil.HasMember(add, "Province"))
                    {
                        lat = add["Province"];
                    }


                }
            }

            
            return Ok(lat);
        }


        

    }
}
