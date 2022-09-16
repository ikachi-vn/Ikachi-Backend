//------------------------------------------------------------------------------
// 
//    www.codeart.vn
//    hungvq@live.com
//    (+84)908.061.119
// 
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace API.Controllers.SAP
{

	[RoutePrefix("api/SAP/RPT")]
    public class RPTSAPController : CustomApiController
    {
		//[Route("")]
  //      public IQueryable<DTO_SAP_BEO> Get()
  //      {
		//	//return BS_SAP_BEO.get_SAP_BEO(db, IDBranch, QueryStrings);

  //          var query = BS_SAP_BEO._queryBuilder(db, IDBranch, QueryStrings);
  //          query = BS_SAP_BEO._sortBuilder(query, QueryStrings);
  //          query = BS_SAP_BEO._pagingBuilder(query, QueryStrings);

  //          return query.Select(s => new DTO_SAP_BEO()
  //          {
  //              ID = s.ID,
  //              Code = s.Code,
  //              Name = s.Name,
  //              EventDate = s.EventDate,
  //              Floor = s.Floor,
  //              DocEntry = s.DocEntry,
  //          });

  //      }

        [Route("ManagementPnL", Name = "GetManagementPnL")]
        public IHttpActionResult GetManagementPnL(int Frequency, DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {
      
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_RPT_Finance_Management_ProfitAndLost", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@Frequency", Frequency));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }
            
            return Ok(table);
        }

        [Route("ManagementCashFlow", Name = "GetManagementCashFlow")]
        public IHttpActionResult GetManagementCashFlow(int Frequency, DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_RPT_Finance_Management_CashFlow", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@Frequency", Frequency));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("IncomeStatement", Name = "GetStatementIncome")]
        public IHttpActionResult GetStatementIncome(DateTime FromDate, DateTime ToDate, int IDBranch, int IDTemplate, string ReportType)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Statement_Income", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@ReportType", ReportType));
                cmd.Parameters.Add(new SqlParameter("@IDBranch", IDBranch));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("CashflowStatement", Name = "GetStatementCashflow")]
        public IHttpActionResult GetStatementCashflow(DateTime FromDate, DateTime ToDate, int IDBranch, int IDTemplate, string ReportType)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Statement_Cashflow", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@ReportType", ReportType));
                cmd.Parameters.Add(new SqlParameter("@IDBranch", IDBranch));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("BalanceSheetStatement", Name = "GetStatementBalanceSheet")]
        public IHttpActionResult GetStatementBalanceSheet(DateTime FromDate, DateTime ToDate, int IDBranch, int IDTemplate, string ReportType)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Statement_BalanceSheet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@ReportType", ReportType));
                cmd.Parameters.Add(new SqlParameter("@IDBranch", IDBranch));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyBalance", Name = "GetDailyBalance")]
        public IHttpActionResult GetDailyBalance(DateTime ReportDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_Balance", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReportDate", ReportDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyGeneral", Name = "GetDailyGeneral")]
        public IHttpActionResult GetDailyGeneral(DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_General", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyRevenue", Name = "GetDailyRevenue")]
        public IHttpActionResult GetDailyRevenue(DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_Revenue", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyDebt", Name = "GetDailyDebt")]
        public IHttpActionResult GetDailyDebt(DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_Debt", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyRevAndExpen1", Name = "GetDailyRevAndExpen1")]
        public IHttpActionResult GetDailyRevAndExpen1(DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_RevExpn1", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }

        [Route("DailyRevAndExpen2", Name = "GetDailyRevAndExpen2")]
        public IHttpActionResult GetDailyRevAndExpen2(DateTime FromDate, DateTime ToDate, string IDBranches, int IDTemplate)
        {

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("erp_PRT_Finance_Daily_RevExpn2", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                cmd.Parameters.Add(new SqlParameter("@IDBranches", IDBranches));
                cmd.Parameters.Add(new SqlParameter("@IDTemplate", IDTemplate));
                da.Fill(table);
            }

            return Ok(table);
        }
    }
}

