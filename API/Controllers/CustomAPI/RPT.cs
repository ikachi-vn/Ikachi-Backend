using BaseBusiness;
using DTOModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    [RoutePrefix("api/v1/RPT/SHIP")]
    public partial class RPTController : CustomApiController
    {
        [Route("DailyReport")]
        public IHttpActionResult GetDailyReport()
        {
            var query = BS_SHIP_Shipment._queryBuilder(db, IDBranch, StaffID, QueryStrings);

            //Query RefID (string)
            if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            {
                var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
                if (keyword.StartsWith("O:") && int.TryParse(keyword.Replace("O:", ""), out int id))
                {
                    query = query.Where(d => d.Id == id);
                }
                else
                {
                    query = query.Where(d =>
                    d.tbl_CRM_Contact.Name.Contains(keyword)
                    || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
                    || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
                    );
                }
            }

            List<int> UndoneStatus = new List<int>()
            {
                //301 , //	Đã phân tài
                //302 , //	Đã giao đơn vị vận chuyển
                //303 , //	Đã lấy hàng về kho
                //304 , //	Đang đóng gói
                //305 , //	Đang giao hàng
                //306 , //	Đóng - Đã giao hàng
                
                314 , //	Đã phân tài
                315 , //	Đã giao đơn vị vận chuyển
                316 , //	Đã lấy hàng về kho
                317 , //	Đang đóng gói
                318 , //	Đang giao hàng
                //319 , //	Đóng - Đã giao hàng
                //307 , //	Khách hẹn giao lại
                //308 , //	Không liên lạc được
                //309 , //	Đóng - Khách không nhận do hàng lỗi
                //310 , //	Đóng - Khách không nhận do giá
                //311 , //	Đóng - Khách không nhận do khách đổi ý
                //312 , //	Đóng - Khách không nhận do khách hết tiền
                //313 , //	Đóng - Không giao được - lý do khác

                //320 , //	Chuẩn bị đi thu
                //321 , //	Đang đi thu
                //322 , //	Đóng - Đã thu một phần
                //323 , //	Đóng - Đã thu xong
                //324 , //	Đóng - Khách hẹn lại
                //325 , //	Đóng - Không liên lạc được
                //326 , //	SAI TIỀN - Khách khiếu nại
                //327 , //	MẤT PHIẾU

            };


            var result = query.Select(s => new
            {
                s.Id,
                s.DeliveryDate,
                s.ShippedDate,
                Status = new { s.tbl_SYS_Status.Id, s.tbl_SYS_Status.Name, s.tbl_SYS_Status.Color},

                Vehicle = s.tbl_SHIP_Vehicle.Name,
                ShipperName = s.tbl_HRM_Staff.FullName,
                ShipperPhone = s.tbl_HRM_Staff.PhoneNumber,

                NumberOfOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false),
                TotalOfOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(e => e.tbl_SALE_Order.OriginalTotalAfterTax).DefaultIfEmpty(0).Sum(),

                NumberOfUndoneOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && UndoneStatus.Contains( d.IDStatus) ),
                TotalOfUndoneOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && UndoneStatus.Contains(d.IDStatus)).Select(e => e.tbl_SALE_Order.OriginalTotalAfterTax).DefaultIfEmpty(0).Sum(),


                NumberOfDoneOrder = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && d.IDStatus == 319),
                NumberOfNewDebt = s.tbl_SHIP_ShipmentDetail.Count(d => d.IsDeleted == false && d.tbl_SALE_Order.IsDebt),

                TotalOfDoneOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && d.IDStatus == 319 ).Select(e => e.tbl_SALE_Order.TotalAfterTax).DefaultIfEmpty(0).Sum(),
                TotalOfCashOrder = s.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum(),
                //TotalOfNewDebtOrder = TotalOfDoneOrder - TotalOfCashOrder

                NumberOfDebt = s.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false),
                NumberOfReceivedDebt = s.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false && d.Received > 0),
                NumberOfRemainingDebt = s.tbl_SHIP_ShipmentDebt.Count(d => d.IsDeleted == false && d.Received < d.Debt),

                TotalOfDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(e => e.Debt).DefaultIfEmpty(0).Sum(),
                TotalOfReceivedDebt = s.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false).Select(e => e.Received).DefaultIfEmpty(0).Sum(),

                

            }).OrderBy(o=>o.Vehicle).ToList();

            return Ok(result);
        }

      
    }

}