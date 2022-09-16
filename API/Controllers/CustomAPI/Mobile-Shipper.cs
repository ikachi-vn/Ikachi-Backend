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
using System.Web.Http.Description;
using ClassLibrary;
using DTOModel;
using BaseBusiness;
using System.Text.RegularExpressions;
using API.Models;
using System.Dynamic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Union.Data;

namespace API.Controllers.JOBS
{

    [RoutePrefix("DmHd")]
    public class SHIPPERAPPController : CustomApiController
    {
        UnionData _unionData = new UnionData();

        [Route("FullOrders")]
        public IHttpActionResult GetFullOrders()
        {
            try
            {

                //var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;


                string taiXe = "";
                string ngayGiaoHang = "";

                if (QueryStrings.Any(d => d.Key == "MA_NV_GH") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "MA_NV_GH").Value))
                {
                    taiXe = QueryStrings.FirstOrDefault(d => d.Key == "MA_NV_GH").Value;
                }

                if (QueryStrings.Any(d => d.Key == "NGAY_GIAO_HANG") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "NGAY_GIAO_HANG").Value))
                {
                    ngayGiaoHang = QueryStrings.FirstOrDefault(d => d.Key == "NGAY_GIAO_HANG").Value;
                }

                ngayGiaoHang = string.IsNullOrEmpty(ngayGiaoHang) ? DateTime.Now.ToString("yyyy/MM/dd") : ngayGiaoHang;

                string sql = @"[b3_SHIP_ShipperGetOrders] @MA_NV_GH, @NGAY_CT, @TINH_TRANG ";
                DataTable dataTable = this._unionData.GetDataTable(sql,
                    new string[] { "@MA_NV_GH", "@NGAY_CT", "@TINH_TRANG" },
                    new object[] { taiXe, ngayGiaoHang, 3 }, CommandType.Text
                );

                var data = ConvertToList(dataTable);

                foreach (var result in data)
                {
                    //Get dept
                    if (float.Parse(result["DA_GIAO_HANG"].ToString()) == 2)
                    {

                        var cnTable = this._unionData.GetDataTable("b3_SHIP_ShipperGetDebts @Id", new string[] { "@Id" }, new object[] { result["UID"].ToString() }, CommandType.Text);

                        var cnR = GetTableRows(cnTable);
                        result["CN"] = cnR;
                        result["NO_CU"] = cnR.Count > 0 ? (double.Parse(cnTable.Compute("Sum(NO)", string.Empty).ToString()) - double.Parse(cnTable.Compute("Sum(TRA)", string.Empty).ToString())) : 0;
                    }

                    //Get order detail rows
                    var orderRows = this._unionData.GetDataTable("[b3_SHIP_ShipperGetOrderLines] @Id",
                        new string[] { "@Id" },
                        new object[] { result["UID"].ToString() }, CommandType.Text
                    );
                    var orderDetailRows = GetTableRows(orderRows);
                    result["ORDER_LINES"] = orderDetailRows;
                }


                return Ok(data);

            }
            catch (Exception ex)
            {
               
                return Ok(new
                {
                    Success = false,
                    Error = ex.Message
                });
            }


            #region temp
            //var query = BS_SALE_Order._queryBuilder(db, IDBranch, QueryStrings);

            ////Query RefID (string)
            //if (QueryStrings.Any(d => d.Key == "CustomerName") && !string.IsNullOrEmpty(QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value))
            //{
            //    var keyword = QueryStrings.FirstOrDefault(d => d.Key == "CustomerName").Value;
            //    if (keyword.StartsWith("O:") && int.TryParse(keyword.Replace("O:", ""), out int id))
            //    {
            //        query = query.Where(d => d.Id == id);
            //    }
            //    else
            //    {
            //        query = query.Where(d =>
            //        d.tbl_CRM_Contact.Name.Contains(keyword)
            //        || d.tbl_CRM_Contact.WorkPhone.Contains(keyword)
            //        || d.tbl_CRM_Contact.HomePhone.Contains(keyword)
            //        || d.tbl_CRM_Contact.MobilePhone.Contains(keyword)
            //        || d.tbl_CRM_Contact.tbl_CRM_ContactReference.Any(e => !e.IsDeleted && e.Code.Contains(keyword))
            //        );
            //    }
            //}

            //query = BS_SALE_Order._sortBuilder(query, QueryStrings);
            //query = BS_SALE_Order._pagingBuilder(query, QueryStrings);

            //int IDShipment = 1;

            //var shipment = db.tbl_SHIP_Shipment.FirstOrDefault(d => d.IsDeleted == false && d.IDShipper == IDShipment);
            //if (shipment == null)
            //{
            //    return Ok(new List<int>());
            //}

            ////Order in shipment
            //query = query.Where(d => d.tbl_SHIP_ShipmentDetail.Any(e => e.IDShipment == IDShipment && e.IsDeleted == false));
            //var result = query.Select(s => new
            //{
            //    UID = s.Id,
            //    MA_HD = s.Code,
            //    TEN_HD = s.Name,
            //    NGAY_HD = s.OrderDate,
            //    MA_NV_GH = shipment.tbl_HRM_Staff.Code,
            //    MA_DT = s.tbl_CRM_Contact.Code,
            //    TEN_DT = s.tbl_CRM_Contact.Name,
            //    DIEN_THOAI = s.tbl_CRM_Contact.WorkPhone,
            //    DIA_CHI = s.tbl_CRM_Contact.AddressLine1,
            //    MA_KHO = shipment.IDWarehouse,

            //    CK = 0,
            //    KM = s.OriginalPromotion,
            //    CK_SP = s.OriginalDiscountByItem,
            //    CK_NHOM_HANG = s.OriginalDiscountByGroup,
            //    CK_DONG_HANG = s.OriginalDiscountByLine,
            //    CK_HOA_DON = s.OriginalDiscountByOrder,
            //    CK_TONG = s.OriginalTotalDiscount,

            //    GIA_TRI_TRUOC_CK = s.OriginalTotalBeforeDiscount,
            //    GIA_TRI_SAU_CK = s.OriginalTotalAfterDiscount,
            //    DA_GIAO_HANG = s.IDStatus,

            //    CK_THUC = 0,
            //    KM_THUC = s.Promotion,
            //    CK_SP_THUC = s.DiscountByItem,
            //    CK_NHOM_HANG_THUC = s.DiscountByGroup,
            //    CK_DONG_HANG_THUC = s.DiscountByLine,
            //    CK_HOA_DON_THUC = s.DiscountByOrder,
            //    CK_TONG_THUC = s.TotalDiscount,

            //    GIA_TRI_TRUOC_CK_THUC = s.TotalBeforeDiscount,
            //    GIA_TRI_THUC = s.OriginalTotalAfterDiscount,

            //    SO_TIEN_DA_NHAN = s.Received,
            //    SO_TIEN_CON_LAI = s.Debt,
            //    XAC_NHAN_SO_LUONG_THUC = s.IDStatus,
            //    XAC_NHAN_THU_TIEN = s.IsPaymentReceived,
            //    CON_NO = s.Debt,
            //    NGAY_GIAO = shipment.DeliveryDate,

            //    ORDER_LINES = s.tbl_SALE_OrderDetail.Where(d => d.IsDeleted == false).Select(l => new
            //    {
            //        UID = l.Id,
            //        MA_HD = s.Code,
            //        MA_VT = l.tbl_WMS_Item.Code,
            //        TEN_VT = l.tbl_WMS_Item.Name,
            //        QC_THUNG_LE = l.UoMSwap,
            //        SO_THUNG = l.Quantity,
            //        SO_LE = l.BaseQuantity,
            //        DON_GIA_THUNG = 0,
            //        DON_GIA_LE = 0,
            //        GIA_TRI_TRUOC_CK = 0,
            //        KM = 0,
            //        CK = 0,
            //        CK_NHOM_HANG = 0,
            //        CK_DONG_HANG = 0,
            //        CK_HOA_DON = 0,
            //        GIA_TRI_SAU_CK = 0,
            //        SO_THUNG_THUC = 0,
            //        SO_LE_THUC = 0,
            //        SO_THUNG_TRA_LAI = 0,
            //        SO_LE_TRA_LAI = 0,
            //        GIA_TRI_TRUOC_CK_THUC = 0,
            //        CK_SP_THUC = 0,
            //        CK_NHOM_HANG_THUC = 0,
            //        CK_DONG_HANG_THUC = 0,
            //        CK_HOA_DON_THUC = 0,
            //        CK_TONG_THUC = 0,
            //        GIA_TRI_THUC = 0,
            //    })



            //}).ToList();

            //return Ok(result);
            #endregion
        }

        [Route("SaveGiaoNhanData")]
        [HttpPost]
        public IHttpActionResult SaveGiaoNhanData([FromBody] SaveGiaoNhan pitem )
        {
            int ret;
            string err = string.Empty;

            DmHdViewModel model = pitem.model;
            List<Dictionary<string, object>> dataVt = pitem.dataVt;
            string UpdateBy = string.IsNullOrEmpty(pitem.UserName) ? "Old Shipper" : pitem.UserName;
            try
            {

                int orderId = model.UID;
                int IDShipmentDetail = model.IDShipmentDetail;

                if (model.SO_TIEN_CON_LAI > 0)
                {
                    var dbShipmentDebt = db.tbl_SHIP_ShipmentDebt.FirstOrDefault(d => d.Id == IDShipmentDetail);
                    var item = BS_SHIP_ShipmentDebt.toDTO(dbShipmentDebt);


                    item.Remark = model.Remark;
                    item.Received = decimal.Parse(model.SO_TIEN_DA_NHAN.ToString());
                    item.IDStatus = model.IDStatus;
                    

                    var totalReceivedDebt = dbShipmentDebt.tbl_SALE_Order.tbl_SHIP_ShipmentDebt.Where(d => d.IsDeleted == false && d.tbl_SHIP_Shipment.IsDeleted == false).Sum(s => s.Received);
                    var totalReceivedShipmentDetail = dbShipmentDebt.tbl_SALE_Order.tbl_SHIP_ShipmentDetail.Where(d => d.IsDeleted == false && d.tbl_SHIP_Shipment.IsDeleted == false).Sum(s => s.Received);
                    dbShipmentDebt.tbl_SALE_Order.Received = totalReceivedDebt + totalReceivedShipmentDetail + item.Received;
                    dbShipmentDebt.tbl_SALE_Order.Debt = dbShipmentDebt.tbl_SALE_Order.TotalAfterTax - dbShipmentDebt.tbl_SALE_Order.Received;

                    dbShipmentDebt.tbl_SALE_Order.IsPaymentReceived = (dbShipmentDebt.tbl_SALE_Order.TotalAfterTax == dbShipmentDebt.tbl_SALE_Order.Received) && (dbShipmentDebt.tbl_SALE_Order.Debt == 0);
                    if (!dbShipmentDebt.tbl_SALE_Order.IsDebt)
                    {
                        dbShipmentDebt.tbl_SALE_Order.IsDebt = dbShipmentDebt.tbl_SALE_Order.Debt > 0;
                    }

                    //113     Còn nợ
                    //114     Đã xong
                    dbShipmentDebt.tbl_SALE_Order.IDStatus = dbShipmentDebt.tbl_SALE_Order.IsPaymentReceived ? 114 : 113;

                    dbShipmentDebt.tbl_SALE_Order.ModifiedBy = UpdateBy;
                    dbShipmentDebt.tbl_SALE_Order.ModifiedDate = DateTime.Now;


                    //--33    322 NULL Đóng -Đã thu một phần
                    //--33    323 NULL Đóng -Đã thu xong

                    if (item.Received > 0)
                    {
                        dbShipmentDebt.IDStatus = dbShipmentDebt.tbl_SALE_Order.Debt == 0 ? 323 : 322;
                    }
                    else
                    {
                        dbShipmentDebt.IDStatus = item.IDStatus;
                    }

                    dbShipmentDebt.Remark = item.Remark;
                    dbShipmentDebt.Received = item.Received;
                    dbShipmentDebt.ModifiedBy = UpdateBy;
                    dbShipmentDebt.ModifiedDate = DateTime.Now;

                    //BS_SHIP_Shipment.updateShipmentDebtStatus(db, new List<int>(), dbShipmentDebt.IDStatus, new List<int>() { dbShipmentDebt.tbl_SALE_Order.Id });
                    BS_SHIP_Shipment.updateShipmentStatus(db, item.IDShipment);
                    db.SaveChanges();

                }
                else
                {
                    var dbShipmentDetail = db.tbl_SHIP_ShipmentDetail.FirstOrDefault(d => d.Id == IDShipmentDetail);
                    var item = BS_SHIP_ShipmentDetail.toDTO(dbShipmentDetail);

                    item.IDStatus = model.IDStatus;
                    item.Remark = model.Remark;
                    item.Received = decimal.Parse(model.SO_TIEN_DA_NHAN.ToString());


                    item.SaleOrder = BS_SALE_Order.toDTO(dbShipmentDetail.tbl_SALE_Order);
                    item.SaleOrder.OrderLines = new List<DTO_SALE_OrderDetail>();

                    foreach (var line in dataVt)
                    {
                        int lineID = int.Parse(line["UID"].ToString());

                        var dbl = dbShipmentDetail.tbl_SALE_Order.tbl_SALE_OrderDetail.FirstOrDefault(d => d.Id == lineID);

                        DTO_SALE_OrderDetail l = BS_SALE_OrderDetail.toDTO(dbl);


                        l.ShippedQuantity = l.UoMSwap == 1 ? int.Parse(line["SO_LE_THUC"].ToString()) : int.Parse(line["SO_THUNG_THUC"].ToString());
                        l.Discount1 = 0;
                        l.Discount2 = 0;
                        l.Promotion = decimal.Parse(line["KM_THUC"].ToString());

                        l.TotalDiscount = decimal.Parse(line["CK_TONG_THUC"].ToString());
                        l.DiscountByOrder = decimal.Parse(line["CK_HOA_DON_THUC"].ToString());
                        l.DiscountByLine = decimal.Parse(line["CK_DONG_HANG_THUC"].ToString());
                        l.DiscountByGroup = decimal.Parse(line["CK_NHOM_HANG_THUC"].ToString());

                        if (l.TotalDiscount == l.OriginalTotalDiscount)
                        {
                            l.Discount1 = l.OriginalDiscount1;
                            l.Discount2 = l.OriginalDiscount2;
                            l.Promotion = l.OriginalPromotion;
                            l.DiscountByOrder = l.DiscountByOrder;

                        }
                        else
                        {
                            l.DiscountByItem = l.TotalDiscount - l.DiscountByOrder - l.DiscountByGroup;
                            l.Discount1 = l.DiscountByItem;
                            l.Discount2 = 0;
                        }

                        item.SaleOrder.OrderLines.Add(l);

                    }

                    BS_SHIP_Shipment.PutDelivered(db, 1, item, UpdateBy, DateTime.Now);
                    BS_SHIP_Shipment.updateShipmentStatus(db, item.IDShipment);

                    db.SaveChanges();

                }

                return Ok(new
                {
                    Success = true
                });

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return Ok(new
            {
                Success = false,
                Error = err
            });
        }


        [Route("GiaoNhanLogin")]
        [HttpPost]
        public IHttpActionResult UnionLogin(LoginViewModel model)
        {
            

            string message = string.Empty;
            bool isSuccess = false;
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            if (!ModelState.IsValid)
            {
                message = "Tài khoản không hợp lệ";
            }
            else
            {
                var dataTable = _unionData.GetDataTable("SELECT UID as Id, USER_ID, USER_NAME as UserName, UNION63.dbo.TCVN2Unicode(FULL_NAME) as FullName, IS_ADMIN IsAdmin, MA_BP MaBP FROM CODE_USER WHERE USER_NAME = @USER_NAME AND PASSWORD = @PASSWORD",
                    new string[] { "@USER_NAME", "@PASSWORD" },
                    new object[] { model.UserName.ToUpper(), Encrypt(model.UserName.ToUpper(), model.Password.ToUpper()) },
                    System.Data.CommandType.Text);

                if (dataTable.Rows.Count > 0)
                {
                    string cols = "Id,USER_ID,UserName,FullName,IsAdmin,MaBP";
                    data = GetTableRows(dataTable, cols.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

                    isSuccess = true;
                    message = "";
                }
                else
                {
                    message = "Tài khoản không hợp lệ";
                }
            }


            return Ok(new
            {
                Data = data.FirstOrDefault(),
                Success = isSuccess,
                Message = message
            });
        }

        protected List<Dictionary<string, object>> GetTableRows(DataTable dtData, string[] paramColumns = null)
        {
            List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
            foreach (DataRow row in (InternalDataCollectionBase)dtData.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)dtData.Columns)
                {
                    DataColumn dataColumn = column;
                    object unicode = row[dataColumn];
                    if (unicode is string && !string.IsNullOrEmpty(unicode as string) && (paramColumns != null && ((IEnumerable<string>)paramColumns).Any<string>((Func<string, bool>)(s => s.ToLower() == dataColumn.ColumnName.ToLower()))))
                    {
                        //unicode = (object)Toolkit.ConvertFontToUNICODE(unicode as string);
                    }

                    dictionary.Add(dataColumn.ColumnName.ToUpper(), unicode);
                }
                dictionaryList.Add(dictionary);
            }
            return dictionaryList;
        }
        protected List<Dictionary<string, object>> ConvertToList(DataTable dtData, string DateFormat = "dd/MM/yyyy")
        {
            List<Dictionary<string, object>> dictionaryList = new List<Dictionary<string, object>>();
            foreach (DataRow row in (InternalDataCollectionBase)dtData.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in (InternalDataCollectionBase)dtData.Columns)
                {
                    DataColumn dataColumn = column;
                    object unicode = row[dataColumn];
                    if (unicode is string && !string.IsNullOrEmpty(unicode as string))
                    {
                        //unicode = (object)Toolkit.ConvertFontToUNICODE(unicode as string);
                    }
                    else if (unicode is DateTime)
                    {
                        unicode = DateTime.Parse(unicode.ToString()).ToString(DateFormat);
                    }
                    dictionary.Add(dataColumn.ColumnName, unicode);
                }
                dictionaryList.Add(dictionary);
            }
            return dictionaryList;
        }

        public static string Encrypt(string user, string pass)
        {
            user = user.ToUpper().PadRight(10).Substring(0, 10);
            pass = pass.ToUpper().PadRight(10).Substring(0, 10);

            string passEncrypt = string.Empty;

            for (int i = 0; i < user.Length; i++)
            {
                var val1 = (i + 1) % user.Length;
                if (val1 == 0)
                {
                    val1 = user.Length;
                }

                var val2 = (i + 1) % pass.Length;
                if (val2 == 0)
                {
                    val2 = pass.Length;
                }

                var val3 = 2 * (int)user[val1 - 1] + 3 * (int)pass[val2 - 1];
                val3 = 65 + (val3 % 26);

                passEncrypt = passEncrypt + (char)(val3);
            }

            return pass.Aggregate(passEncrypt, (current, t) => current + (char)((int)t + 10));
        }

    }
}

public class SaveGiaoNhan
{
    public DmHdViewModel model { get; set; }
    public List<Dictionary<string, object>> dataVt { get; set; }
    public string UserName { get; set; }
}

public class LoginViewModel
{
    [Required]
    [Display(Name = "Tài khoản")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }

    [Display(Name = "Nhớ mật khẩu")]
    public bool RememberMe { get; set; }
}

public class DmHdViewModel
{
    public int UID { get; set; }

    public int IDShipment { get; set; }

    public int IDShipmentDetail { get; set; }

    public int IDStatus { get; set; }
    public string Remark { get; set; }

    public string MA_HD_OLD { get; set; }

    [Required]
    [Display(Name = "Số đơn hàng")]
    public string MA_HD { get; set; }

    //[Required]
    [Display(Name = "Nội dung")]
    public string TEN_HD { get; set; }

    [Display(Name = "Nội dung tiếng anh")]
    public string TEN_HD_E { get; set; }

    [Display(Name = "Ngày ký")]
    public DateTime NGAY_HD { get; set; }

    [Required]
    [Display(Name = "Vụ việc")]
    public string MA_VV { get; set; }

    [Display(Name = "Tài khoản")]
    public string TK { get; set; }

    [Display(Name = "Nhân viên")]
    public string MA_NV { get; set; }

    [Display(Name = "Khách hàng")]
    public string MA_DT { get; set; }

    [Display(Name = "Trị giá")]
    [DisplayFormat(DataFormatString = "{0:0.00}")]
    public decimal TRI_GIA { get; set; }







    // 1B
    [Display(Name = "Mã kho")]
    public string MA_KHO { get; set; }

    [Display(Name = "Mã bộ phận")]
    public string MA_BP { get; set; }
    [Display(Name = "Mã nhân viên giao hàng")]
    public string MA_NV_GH { get; set; }


    [Display(Name = "Giá trị trước CK")]
    public double GIA_TRI_TRUOC_CK { get; set; }

    [Display(Name = "Giá trị sau CK ")]
    public double GIA_TRI_SAU_CK { get; set; }

    [Display(Name = "% khuyến mãi (CK nhóm)")]
    public double KM { get; set; }

    [Display(Name = "% chiết khấu đơn hàng")]
    public double CK { get; set; }

    [Display(Name = "Tổng chiết khấu SP")]
    public double CK_SP { get; set; }

    [Display(Name = "Tổng chiết khấu nhóm hàng")]
    public double CK_NHOM_HANG { get; set; }

    [Display(Name = "Tổng chiết khấu dòng hàng")]
    public double CK_DONG_HANG { get; set; }

    [Display(Name = "Tổng chiết khấu đơn hàng")]
    public double CK_HOA_DON { get; set; }

    [Display(Name = "Tổng chiết khấu")]
    public double CK_TONG { get; set; }


    [Display(Name = "% khuyến mãi thực (CK nhóm)")]
    public double KM_THUC { get; set; }

    [Display(Name = "% chiết khấu đơn hàng thực")]
    public double CK_THUC { get; set; }
    [Display(Name = "Giá trị trước CK thực")]
    public double GIA_TRI_TRUOC_CK_THUC { get; set; }

    [Display(Name = "CK SP thực")]
    public double CK_SP_THUC { get; set; }

    [Display(Name = "CK nhóm thực")]
    public double CK_NHOM_HANG_THUC { get; set; }

    [Display(Name = "CK dòng thực")]
    public double CK_DONG_HANG_THUC { get; set; }

    [Display(Name = "CK đơn hàng thực")]
    public double CK_HOA_DON_THUC { get; set; }

    [Display(Name = "CK tổng thực")]
    public double CK_TONG_THUC { get; set; }

    [Display(Name = "Giá trị thực")]
    public double GIA_TRI_THUC { get; set; }

    [Display(Name = "Số tiền đã nhận")]
    public double SO_TIEN_DA_NHAN { get; set; }
    [Display(Name = "Số tiền còn lại")]
    public double SO_TIEN_CON_LAI { get; set; }



    [Display(Name = "Đã giao hàng")]
    public bool DA_GIAO_HANG { get; set; }

    [Display(Name = "Xác nhận số lượng thực")]
    public bool XAC_NHAN_SO_LUONG_THUC { get; set; }

    [Display(Name = "Xác nhận đã thu tiền")]
    public bool XAC_NHAN_THU_TIEN { get; set; }

    [Display(Name = "Ghi chú")]
    public string INFO { get; set; }
}