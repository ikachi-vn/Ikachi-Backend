using API.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ikachi_New_Server.Controllers.CustomAPI
{

    [RoutePrefix("api/IKACHI")]
    public class CustomAPI2Controller : CustomApiController
    {
        
        [Route("AppointmentList", Name = "GetAppointmentList")]
        public IHttpActionResult GetAppointmentList(DateTime fromDate, DateTime toDate, int branchID)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_rptAppointmentList", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                cmd.Parameters.Add(new SqlParameter("@branchID", branchID));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("GroupSaleInvoice", Name = "GetGroupSaleInvoice")]
        public IHttpActionResult GetGroupSaleInvoice(DateTime fromDate, DateTime toDate, int branchID)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_rptGroupSaleInvoice", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                cmd.Parameters.Add(new SqlParameter("@branchID", branchID));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("GroupService", Name = "GetGroupService")]
        public IHttpActionResult GetGroupService(DateTime fromDate, DateTime toDate, int branchID)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_rptGroupService", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                cmd.Parameters.Add(new SqlParameter("@branchID", branchID));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("PatientService", Name = "GetPatientService")] /*PatientID, >> phone,  >> Tên*/
        public IHttpActionResult GetPatientService(int PatientID, string Phone, string FullName)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_SearchPatient", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PatientID", PatientID));
                cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                cmd.Parameters.Add(new SqlParameter("@FullName", FullName));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("PatientIDService", Name = "GetPatientIDService")] /*PatientID, >> phone,  >> Tên*/
        public IHttpActionResult GetPatientIDService(int PatientID)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_SearchPatient", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PatientID", PatientID));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("PatientPhoneService", Name = "GetPatientPhoneService")] /*PatientID, >> phone,  >> Tên*/
        public IHttpActionResult GetPatientPhoneService(string Phone)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_SearchPatient", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("PatientFullNameService", Name = "GetPatientFullNameService")] /*PatientID, >> phone,  >> Tên*/
        public IHttpActionResult GetPatientFullNameService(string FullName)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_SearchPatient", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FullName", FullName));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("IkachiApprovalProcess", Name = "GetIkachiApprovalProcess")] /*Truyền Vào ObjectID + ObjectType >> Xử lý >> Trả về ActionLog*/
        public IHttpActionResult GetIkachiApprovalProcess(int ID, int ActionType, string ApprovedBy , string ApproveNote)
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["eHospitalNDCConnection"].ConnectionString))
            using (var cmd = new SqlCommand("st_web_ApprovalProcess", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                cmd.Parameters.Add(new SqlParameter("@ActionType", ActionType));
                cmd.Parameters.Add(new SqlParameter("@ApprovedBy", ApprovedBy));
                cmd.Parameters.Add(new SqlParameter("@ApproveNote", ApproveNote));
                da.Fill(table);
            }

            return Ok(table);
        }
    }
}
