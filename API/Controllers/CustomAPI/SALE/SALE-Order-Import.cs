using API.Models;
using BaseBusiness;
using ClassLibrary;
using DTOModel;
using MasanService.MasanServices;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers.V1
{
    public partial class SALE_OrderController : CustomApiController
    {
        [HttpGet]
        [Route("MasanImport")]
        public IHttpActionResult MasanImport()
        {
            int JobId = 0;
            string Kho = "*";
            DateTime StartDate = DateTime.Today;
            DateTime EndDate = DateTime.Today;

            if (QueryStrings.Any(d => d.Key == "JobId"))
            {
                int.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "JobId").Value, out JobId);
            }
            if (QueryStrings.Any(d => d.Key == "Kho"))
            {
                Kho = QueryStrings.FirstOrDefault(d => d.Key == "Kho").Value;
            }
            if (QueryStrings.Any(d => d.Key == "StartDate"))
            {
                DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "StartDate").Value, out StartDate);
            }
            if (QueryStrings.Any(d => d.Key == "EndDate"))
            {
                DateTime.TryParse(QueryStrings.FirstOrDefault(d => d.Key == "EndDate").Value, out EndDate);
            }

            Kho = Kho == "KF1652" ? "1-QLJ6XX" : "1-XH1P4G"; //1-XH1P4G:KF1652T01-Long Thành; 1-QLJ6XX:KF1652-Xuân Lộc -- KF1652: Xuân Lộc; KF1652T01: Long Thành
            string rptName = "Import";
            string fileurl = "";
            string err = string.Empty;
            try
            {
                ReportResponse rptResponse = null;
                if (JobId == 1) //RPT061
                {
                    rptName = string.Format(Kho + "-RPT061-Line-Item({0}-{1})", StartDate.ToString("yyMMdd"), EndDate.ToString("yyMMdd"));
                    rptResponse = MasanService.MasanReports.downloadRPT061(Kho, StartDate, EndDate, out err);
                }


                if (rptResponse == null)
                {
                    return BadRequest(err);
                }

                ExcelPackage package = ConvertToExcelPackage(rptResponse, rptName, out fileurl);


                var shipDate = DateTime.Parse(QueryStrings.FirstOrDefault(d => d.Key == "EndDate").Value).AddDays(1);
                if (shipDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    shipDate = shipDate.AddDays(1);
                }
                importRPT61(package, Kho, shipDate, out err);

                importRPT19(Kho, StartDate, EndDate);

                //var task3 = new Task(() => importRPT19(Kho, StartDate, EndDate), TaskCreationOptions.LongRunning);
                //task3.Start();

            }
            catch (Exception ex)
            {
                err = ex.Message;
                return BadRequest(err);
            }

            //if (!string.IsNullOrEmpty(err))
            //{
            //    return BadRequest(fileurl);
            //}

            return Ok(fileurl);

        }

        [HttpPost]
        [Route("ImportFile")]
        public IHttpActionResult Post_FileImport()
        {
            string err = "";
            string fileurl = "";
            string Kho = "*";
            if (QueryStrings.Any(d => d.Key == "Kho"))
            {
                Kho = QueryStrings.FirstOrDefault(d => d.Key == "Kho").Value;
            }
            Kho = Kho == "KF1652" ? "1-QLJ6XX" : "1-XH1P4G"; //1-XH1P4G:KF1652T01-Long Thành; 1-QLJ6XX:KF1652-Xuân Lộc -- KF1652: Xuân Lộc; KF1652T01: Long Thành

            try
            {
                var package = SaveImportedFile(out fileurl);

                var shipDate = DateTime.Today.AddDays(1);
                if (shipDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    shipDate = shipDate.AddDays(1);
                }
                importRPT61(package, Kho, shipDate, out err);

            }
            catch (Exception ex)
            {
                err = ex.Message;
                return BadRequest(err);
            }

            return Ok(fileurl);
        }

        private void importRPT61(ExcelPackage package, string Kho, DateTime shipDate, out string err)
        {
            ExcelWorkbook workBook = package.Workbook;
            err = "";

            if (workBook != null)
            {
                var DsHdVtList = new List<Dictionary<string, object>>();
                var workSheet = workBook.Worksheets.FirstOrDefault();

                try
                {
                    DsHdVtList = validateAndImportRow(workSheet);

                    var today = DateTime.Now;
                    if (Kho == "1-QLJ6XX")
                    {
                        Kho = "10KF1652T00";
                    }
                    else if (Kho == "1-XH1P4G")
                    {
                        Kho = "10KF1652T01";
                    }

                    var branch = db.tbl_BRA_Branch.FirstOrDefault(d => d.IsDeleted == false && d.Code == Kho);

                    var itemIds = DsHdVtList.Select(s => int.Parse(s["C3"].ToString())).Distinct().ToList();
                    var itemUoMs = db.tbl_WMS_ItemUoM.Where(d => itemIds.Contains(d.IDItem) && d.IsDeleted == false).ToList();

                    //Lấy danh sách hợp đồng
                    var HdList = DsHdVtList.Select(s => new DTO_SALE_Order
                    {
                        Code = s["C16"].ToString(),
                        OrderDate = DateTime.TryParse(s["C13"].ToString(), out DateTime orderDate) ? orderDate : DateTime.Parse("1990/1/1"),
                        ExpectedDeliveryDate = DateTime.TryParse(s["C17"].ToString(), out DateTime deliDate) ? deliDate : DateTime.Parse("1990/1/1"),
                        IDContact = int.TryParse(s["C25"].ToString(), out int idContact) ? idContact : 0,
                        IDAddress = int.TryParse(s["IDAddress"].ToString(), out int idAddress) ? idAddress : 0,
                        IDOwner = int.TryParse(s["C57"].ToString(), out int idSale) ? idSale : 0,
                        RefShipper = s["C12"].ToString(),
                        RefContact = int.TryParse(s["C25"].ToString(), out int idRefContact) ? idRefContact.ToString() : null,
                        IDStatus = 103,
                        IDBranch = branch.IDParent.HasValue ? branch.IDParent.Value : branch.Id
                    }).GroupBy(g => g.Code)
                    .Select(group => group.First()).ToList();

                    var savedOrders = new List<tbl_SALE_Order>();

                    var Codes = HdList.Where(d => !string.IsNullOrEmpty(d.Code)).Select(s => s.Code).Distinct();
                    var dbOrders = db.tbl_SALE_Order.Where(d => Codes.Contains(d.Code) && !d.IsDeleted).ToList();

                    foreach (var o in HdList)
                    {
                        if (o.OrderDate == DateTime.Parse("1990/1/1"))
                        {
                            o.OrderDate = DateTime.Now;
                        }
                        if (o.ExpectedDeliveryDate == DateTime.Parse("1990/1/1"))
                        {
                            o.ExpectedDeliveryDate = DateTime.Now.AddDays(1);
                        }
                        if (o.IDOwner == 0)
                        {
                            //o.IDOwner = null;
                        }

                        o.IDType = 1;
                        o.Name = "Imported " + today.ToString("yyyy-MM-dd hh:mm");

                        var splitLines = DsHdVtList.Where(d => d["C16"].ToString() == o.Code && d.ContainsKey("_split")).Select(s => new DTO_SALE_OrderDetail
                        {

                            index = int.Parse(s["_index"].ToString()),
                            IDItem = int.Parse(s["C3"].ToString()),

                            IDUoM = int.Parse(s["_IDUoM"].ToString()),

                            IsPromotionItem = s["C32"].ToString() == "Y",
                            UoMPrice = s["C32"].ToString() == "Y" ? 0 : decimal.Parse(s["_UoMPrice"].ToString()),

                            Quantity = int.Parse(s["_Quantity"].ToString()),
                            UoMSwap = int.Parse(s["_UoMSwap"].ToString()),
                            IDBaseUoM = int.Parse(s["_IDBaseUoM"].ToString()),
                            BaseQuantity = int.Parse(s["_BaseQuantity"].ToString()),

                            ProductWeight = decimal.Parse(s["_ProductWeight"].ToString()),
                            ProductDimensions = decimal.Parse(s["_ProductDimensions"].ToString()),

                            OriginalDiscount1 = decimal.Parse(s["_C20"].ToString()), //21
                            OriginalPromotion = 0, //decimal.Parse(s["_C24"].ToString()),
                            OriginalDiscountByOrder = decimal.Parse(s["_C23"].ToString())

                        }).ToList();

                        var lines = DsHdVtList.Where(d => d["C16"].ToString() == o.Code).Select(s => new DTO_SALE_OrderDetail
                        {
                            index = int.Parse(s["_index"].ToString()),
                            IDItem = int.Parse(s["C3"].ToString()),
                            IDUoM = int.Parse(s["IDUoM"].ToString()),
                            Remark = s["C32"].ToString(),
                            IsPromotionItem = s["C32"].ToString() == "Y",
                            UoMPrice = s["C32"].ToString() == "Y" ? 0 : decimal.Parse(s["UoMPrice"].ToString()),

                            Quantity = int.Parse(s["Quantity"].ToString()),
                            UoMSwap = int.Parse(s["UoMSwap"].ToString()),
                            IDBaseUoM = int.Parse(s["IDBaseUoM"].ToString()),
                            BaseQuantity = int.Parse(s["BaseQuantity"].ToString()),

                            ProductWeight = decimal.Parse(s["ProductWeight"].ToString()),
                            ProductDimensions = decimal.Parse(s["ProductDimensions"].ToString()),

                            OriginalDiscount1 = decimal.Parse(s["C20"].ToString()), //21
                            OriginalPromotion = 0,//decimal.Parse(s["C24"].ToString()),
                            OriginalDiscountByOrder = decimal.Parse(s["C23"].ToString())

                        }).ToList();

                        lines.AddRange(splitLines);

                        o.OrderLines = lines.OrderBy(p => p.index).ToList();

                        /////////////


                        tbl_SALE_Order dbitem = null;
                        var dbfitem = dbOrders.FirstOrDefault(d => d.Code == o.Code);

                        if (dbfitem != null)
                        {
                            o.Id = dbfitem.Id;
                            if (dbfitem.ModifiedDate != dbfitem.CreatedDate)
                            {
                                #region keep order edited
                                if (o.IDContact != dbfitem.IDContact)
                                {
                                    o.IDContact = dbfitem.IDContact;
                                    o.IDAddress = dbfitem.IDAddress;
                                }

                                o.IsSampleOrder = dbfitem.IsSampleOrder;
                                o.IsShipBySaleMan = dbfitem.IsShipBySaleMan;
                                o.IsUrgentOrders = dbfitem.IsUrgentOrders;
                                o.IsWholeSale = dbfitem.IsWholeSale;
                                #endregion

                                #region keep order details
                                var ck3s = dbfitem.tbl_SALE_OrderDetail.Where(d => !d.IsDeleted && d.OriginalDiscountFromSalesman != 0);

                                foreach (var ck in ck3s)
                                {
                                    var l = o.OrderLines.FirstOrDefault(d =>
                                    d.IDItem == ck.IDItem
                                    && d.IDUoM == ck.IDUoM
                                    && d.IsPromotionItem == ck.IsPromotionItem
                                    && d.Quantity == ck.Quantity
                                    && d.OriginalDiscountFromSalesman == 0
                                    );

                                    if (l == null)
                                    {
                                        l = o.OrderLines.FirstOrDefault(d =>
                                        d.IDItem == ck.IDItem
                                        && d.IDUoM == ck.IDUoM
                                        && d.IsPromotionItem == ck.IsPromotionItem
                                        && d.OriginalDiscountFromSalesman == 0
                                        );
                                    }

                                    if (l != null)
                                    {
                                        l.OriginalDiscountFromSalesman = ck.OriginalDiscountFromSalesman;
                                    }
                                }

                                #endregion

                            }
                        }

                        if (o.Id == 0)
                        {
                            dbitem = new tbl_SALE_Order();
                            dbitem.CreatedBy = Username;
                            dbitem.CreatedDate = DateTime.Now;
                            db.tbl_SALE_Order.Add(dbitem);
                        }
                        else
                        {
                            dbitem = dbOrders.FirstOrDefault(d => d.Id == o.Id);
                        }

                        savedOrders.Add(dbitem);

                        BS_SALE_Order.calcOrder(dbitem, o, Username, DateTime.Now, out err, itemUoMs);

                        //var saved = BS_SALE_Order.calc_SALE_Order(db, IDBranch, o, Username, out err);



                        //if (saved == null)
                        //{
                        //    foreach (var notSave in DsHdVtList.Where(d => d["C16"].ToString() == o.Code))
                        //    {
                        //        int index = int.Parse(notSave["_index"].ToString());
                        //        NoteToWookSheet(workSheet, index, 1, "Không import được! Debug: " + err, System.Drawing.Color.Red, System.Drawing.Color.White);
                        //    }
                        //}
                    }

                    db.SaveChanges();
                    package.Save();


                    #region Create shipments
                    //var vehicleIds = savedOrders.Where(d=> d.RefShipper != "").Select(s => int.Parse( s.RefShipper)).Distinct().ToList();

                    //var vehicles = db.tbl_SHIP_Vehicle.Where(d =>
                    //    vehicleIds.Contains(d.Id) && d.IsDeleted == false
                    //).ToList();


                    //foreach (var v in vehicles)
                    //{
                    //    DTO_SHIP_Shipment item = new DTO_SHIP_Shipment();
                    //    item.IDStatus = 301;
                    //    item.IDVehicle = v.Id;
                    //    item.IDShipper = v.IDShipper;
                    //    item.IDWarehouse = branch.Id;
                    //    item.IDBranch = branch.IDParent.HasValue? branch.IDParent.Value : branch.Id;

                    //    //item.DeliveryDate = DateTime.Parse(shipDate.ToString("yyyy-MM-dd") + " 07:07:07" );
                    //    //item.OrderIds = savedOrders.Where(d => d.RefShipper == v.Id.ToString()).Select(s => s.Id).ToList();
                    //    //BS_SHIP_Shipment.calc_Shipment(db, IDBranch, item, Username, out err);


                    //    var SaleOrders = savedOrders.Where(d => d.RefShipper == v.Id.ToString()).Select(s => new tbl_SALE_Order()
                    //    {
                    //        Id = s.Id,
                    //        ProductWeight = s.ProductWeight,
                    //        ProductDimensions = s.ProductDimensions
                    //    }).ToList();


                    //    BS_SHIP_Shipment.createShipmentByRoute(db, v, SaleOrders, IDBranch, branch.Id, Username, DateTime.Parse(shipDate.ToString("yyyy-MM-dd")) );

                    //}
                    //db.SaveChanges();

                    #endregion
                }
                catch (Exception ex)
                {
                    package.Save();
                    err = ex.Message;
                    if (ex.InnerException != null)
                    {
                        err = ex.InnerException.Message;
                        if (ex.InnerException.InnerException != null)
                        {
                            err = ex.InnerException.InnerException.Message;
                        }
                    }
                }
            }
        }

        private void importRPT19(string Kho, DateTime StartDate, DateTime EndDate)
        {
            string err = "";
            string fileurl = "";
            string rptName = string.Format(Kho + "-RPT019-Promotion-Tracking({0}-{1})", StartDate.ToString("yyMMdd"), EndDate.ToString("yyMMdd"));
            ReportResponse rptResponse = MasanService.MasanReports.downloadRPT019(Kho, StartDate, EndDate, out err);
            ExcelPackage package = ConvertToExcelPackage(rptResponse, rptName, out fileurl);
            ExcelWorkbook workBook = package.Workbook;

            if (workBook == null || workBook.Worksheets.FirstOrDefault() == null || workBook.Worksheets.FirstOrDefault().Dimension == null)
            {
                err = "File report \"" + fileurl + "\" không có dữ liệu.";
            }
            else
            {
                var lineRows = new List<Dictionary<string, object>>();
                var workSheet = workBook.Worksheets.FirstOrDefault();

                try
                {
                    lineRows = validateAndImportRPT19Row(workSheet);

                    var Prs = lineRows.Where(d => !string.IsNullOrEmpty(d["MaDH"].ToString())).Select(s => new tbl_PR_PromotionTracking()
                    {
                        MaNVBH = s["MaNVBH"].ToString(),
                        TenNVBH = s["TenNVBH"].ToString(),
                        MaKH = s["MaKH"].ToString(),
                        TenKH = s["TenKH"].ToString(),
                        DiaChi = s["DiaChi"].ToString(),
                        MaDH = s["MaDH"].ToString(),
                        TrangThai = s["TrangThai"].ToString(),
                        //NgayDonHang = s["NgayDonHang"],
                        //NgayHoaDon = s["NgayHoaDon"],
                        //ClaimDate = s["ClaimDate"],
                        TenChuongTrinh = s["TenChuongTrinh"].ToString(),
                        MaSP = s["MaSP"].ToString(),
                        TenSP = s["TenSP"].ToString(),
                        SoThung = int.Parse(s["SoThung"].ToString()),
                        SoLe = int.Parse(s["SoLe"].ToString()),
                        TongLe = int.Parse(s["TongLe"].ToString()),
                        ChietKhau = double.Parse(s["ChietKhau"].ToString())
                    }).Distinct().ToList();

                    var toDeleteHD = Prs.Select(s => s.MaDH).Distinct().ToList();


                    //db = new AppEntities();

                    var deleteRows = db.tbl_PR_PromotionTracking.Where(d => toDeleteHD.Contains(d.MaDH));
                    db.tbl_PR_PromotionTracking.RemoveRange(deleteRows);

                    db.tbl_PR_PromotionTracking.AddRange(Prs);

                    db.SaveChanges();

                    //db.Dispose();

                    //package.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }

        public List<Dictionary<string, object>> validateAndImportRPT19Row(ExcelWorksheet ws)
        {
            var lineRows = new List<Dictionary<string, object>>();

            var noOfCol = ws.Dimension.End.Column;
            var noOfRow = ws.Dimension.End.Row;

            //Đọc data từ file excel
            for (int rowIndex = 8; rowIndex <= noOfRow; rowIndex++)
            {
                if (ws.Cells[rowIndex, 7].Value == null)
                {
                    continue;
                }
                var item = new Dictionary<string, object>();
                item["IsValid"] = true;
                item["_index"] = rowIndex;
                item["ValidateMessage"] = "";

                item["MaNVBH"] = ws.Cells[rowIndex, 2].Value == null ? "" : ws.Cells[rowIndex, 2].Value.ToString();
                item["TenNVBH"] = ws.Cells[rowIndex, 3].Value == null ? "" : ws.Cells[rowIndex, 3].Value.ToString();
                item["MaKH"] = ws.Cells[rowIndex, 4].Value == null ? "" : ws.Cells[rowIndex, 4].Value.ToString();
                item["TenKH"] = ws.Cells[rowIndex, 5].Value == null ? "" : ws.Cells[rowIndex, 5].Value.ToString();
                item["DiaChi"] = ws.Cells[rowIndex, 6].Value == null ? "" : ws.Cells[rowIndex, 6].Value.ToString();
                item["MaDH"] = ws.Cells[rowIndex, 7].Value == null ? "" : ws.Cells[rowIndex, 7].Value.ToString();
                item["TrangThai"] = ws.Cells[rowIndex, 8].Value == null ? "" : ws.Cells[rowIndex, 8].Value.ToString();


                item["NgayDonHang"] = null;
                item["NgayHoaDon"] = null;
                item["ClaimDate"] = null;

                if (ws.Cells[rowIndex, 9].Value != null && DateTime.TryParseExact(ws.Cells[rowIndex, 9].Value.ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ngayDH))
                {
                    item["NgayDonHang"] = ngayDH;
                }
                if (ws.Cells[rowIndex, 10].Value != null && DateTime.TryParseExact(ws.Cells[rowIndex, 10].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ngayHD))
                {
                    item["NgayHoaDon"] = ngayHD;
                }
                if (ws.Cells[rowIndex, 11].Value != null && DateTime.TryParseExact(ws.Cells[rowIndex, 11].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime claimDate))
                {
                    item["ClaimDate"] = claimDate;
                }

                item["TenChuongTrinh"] = ws.Cells[rowIndex, 12].Value == null ? "" : ws.Cells[rowIndex, 12].Value.ToString();
                item["MaSP"] = ws.Cells[rowIndex, 13].Value == null ? "" : ws.Cells[rowIndex, 13].Value.ToString();
                item["TenSP"] = ws.Cells[rowIndex, 14].Value == null ? "" : ws.Cells[rowIndex, 14].Value.ToString();

                item["SoThung"] = ws.Cells[rowIndex, 15].Value == null ? "0" : int.TryParse(ws.Cells[rowIndex, 15].Value.ToString(), out int thung) ? thung.ToString() : "0";
                item["SoLe"] = ws.Cells[rowIndex, 16].Value == null ? "0" : int.TryParse(ws.Cells[rowIndex, 16].Value.ToString(), out int le) ? le.ToString() : "0";
                item["TongLe"] = ws.Cells[rowIndex, 17].Value == null ? "0" : double.TryParse(ws.Cells[rowIndex, 17].Value.ToString(), out double tle) ? tle.ToString() : "0";

                item["ChietKhau"] = ws.Cells[rowIndex, 18].Value == null ? "0" : double.TryParse(ws.Cells[rowIndex, 18].Value.ToString(), out double ck) ? ck.ToString() : "0";

                lineRows.Add(item);
            }

            return lineRows.Where(d => bool.Parse(d["IsValid"].ToString())).ToList();
        }

        private ExcelPackage ConvertToExcelPackage(ReportResponse rptResponse, string rptName, out string fileurl)
        {

            fileurl = "";

            if (rptResponse.reportContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                return null;
            }


            #region upload file

            string mapPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            string fileName = rptName + "-" + DateTime.Now.ToString("yyMMdd-hhmmss") + "-import.xlsx";
            string uploadPath = "/Uploads/" + DateTime.Today.ToString("yyyy/MM/dd").Replace("-", "/");
            string strDirectoryPath = mapPath + uploadPath;
            string strFilePath = strDirectoryPath + "/" + fileName;

            fileurl = uploadPath + "/" + fileName;

            System.IO.FileInfo existingFile = new System.IO.FileInfo(strFilePath);

            if (!System.IO.Directory.Exists(strDirectoryPath))
                System.IO.Directory.CreateDirectory(strDirectoryPath);
            if (existingFile.Exists)
            {
                existingFile.Delete();
                existingFile = new System.IO.FileInfo(strFilePath);
            }

            System.IO.File.WriteAllBytes(strFilePath, rptResponse.reportBytes);

            #endregion

            return new ExcelPackage(existingFile);

        }

        public void NoteToWorkSheet(ExcelWorksheet ws, int rowid, int colid, string message, System.Drawing.Color BackgroundColor, System.Drawing.Color FontColor)
        {
            //Bảng màu
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.brushes?redirectedfrom=MSDN&view=netframework-4.8

            if (ws.Cells[rowid, colid].Comment == null)
            {
                var comment = ws.Cells[rowid, colid].AddComment(message, "hungvq@live.com");
                comment.AutoFit = true;
            }
            else
            {
                ws.Cells[rowid, colid].Comment.Text += "\n" + message;
            }



            ws.Cells[rowid, colid].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells[rowid, colid].Style.Fill.BackgroundColor.SetColor(BackgroundColor);
            ws.Cells[rowid, colid].Style.Font.Color.SetColor(FontColor);
        }

        public List<Dictionary<string, object>> validateAndImportRow(ExcelWorksheet ws)
        {
            var DsHdVtList = new List<Dictionary<string, object>>();

            var noOfCol = ws.Dimension.End.Column;
            var noOfRow = ws.Dimension.End.Row;


            //Đọc data từ file excel
            for (int rowIndex = 7; rowIndex <= noOfRow; rowIndex++)
            {
                var item = new Dictionary<string, object>();
                item["IsValid"] = true;
                item["_index"] = rowIndex;
                item["ValidateMessage"] = "";

                for (int colIndex = 1; colIndex <= noOfCol; colIndex++)
                {
                    int[] intCols = new int[] { 5, 6, 7, 8, 9, 10, 11, 19, 20, 21, 22, 23, 24, 43 };
                    if (intCols.Contains(colIndex))
                    {
                        item["C" + colIndex] = ws.Cells[rowIndex, colIndex].Value == null ? "0" : decimal.TryParse(ws.Cells[rowIndex, colIndex].Value.ToString(), out decimal dblVal) ? dblVal.ToString() : "0";
                    }
                    else if (colIndex == 13 || colIndex == 17)
                    {
                        item["C" + colIndex] = ws.Cells[rowIndex, colIndex].Value == null ? "" : DateTime.TryParseExact(ws.Cells[rowIndex, colIndex].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateVal) ? dateVal.ToString("yyyy-MM-dd") : "";
                    }
                    else
                    {
                        item["C" + colIndex] = ws.Cells[rowIndex, colIndex].Value == null ? "" : ws.Cells[rowIndex, colIndex].Value.ToString().Trim();
                    }
                }

                DsHdVtList.Add(item);
            }


            //Validate data


            var products = DsHdVtList.Select(s => s["C3"].ToString()).Distinct().ToList();
            products.RemoveAll(s => { return s == ""; });
            var productItems = db.tbl_WMS_Item.Where(d => d.IsDeleted == false && products.Contains(d.Code)).Select(
                s => new
                {
                    s.Id,
                    s.Code,
                    UoM = s.tbl_WMS_ItemUoM.FirstOrDefault(dd => dd.IsDeleted == false && dd.IsBaseUoM == true),
                    UoMSale = s.SalesUoM.HasValue ? s.tbl_WMS_ItemUoM.FirstOrDefault(dd => dd.IsDeleted == false && dd.Id == s.SalesUoM) : s.tbl_WMS_ItemUoM.FirstOrDefault(dd => dd.IsDeleted == false && dd.IsBaseUoM == true)
                }).ToList();


            var contactCodes = DsHdVtList.Select(s => s["C25"].ToString()).Distinct().ToList();
            contactCodes.RemoveAll(s => { return s == ""; });
            var contacts = db.tbl_CRM_Contact.Where(d => d.IsDeleted == false && d.Code != "" && (contactCodes.Contains(d.Code) || d.tbl_CRM_ContactReference.Any(e => contactCodes.Contains(e.Code))))
                .Select(s => new { 
                    s.Id, 
                    s.Code, 
                    Reff = s.tbl_CRM_ContactReference,
                    Addresses = s.tbl_CRM_PartnerAddress.Where(d=>!d.IsDeleted).Select(sa=>new DTO_CRM_PartnerAddress { 
                        Id = sa.Id,
                        AddressLine1 = sa.AddressLine1,
                    }).ToList()
                }).ToList();


            var staffCodes = DsHdVtList.Select(s => s["C57"].ToString()).Distinct().ToList();
            //staffCodes.AddRange( DsHdVtList.Select(s => s["C12"].ToString()).Distinct().ToList());
            staffCodes.RemoveAll(s => s == "");
            var staffs = db.tbl_HRM_Staff.Where(d => staffCodes.Contains(d.Code) && d.IsDeleted == false).Select(s => new { s.Id, s.Code }).ToList();


            var vehicleCodes = DsHdVtList.Select(s => s["C12"].ToString()).Distinct().ToList();
            vehicleCodes.RemoveAll(s => s == "");
            var vehicles = db.tbl_SHIP_Vehicle.Where(d => d.IsDeleted == false && vehicleCodes.Contains(d.RefShipper)).Select(s => new { s.Id, s.RefShipper }).ToList();

            var orderCodes = DsHdVtList.Select(s => s["C16"].ToString()).Distinct().ToList();
            orderCodes.RemoveAll(s => { return s == ""; });
            var blockedStatus = new int[] {
                //101,	// Mới (sale tạo)
                //102,	// Mới (khách tạo)
                //103,	// Imported
                104,	// Đã xác nhận
                105,	// Đã phân tài
                106,	// Đang lấy hàng - đóng gói
                107,	// Đã giao đơn vị vận chuyển
                108,	// Đang giao hàng
                109,	// Đã giao hàng
                110,	// Chờ giao lại
                111,	// Đã xuất hóa đơn
                112,	// Đã có phiếu thu
                113,	// Còn nợ
                114,	// Đã xong
            }.ToList();

            var ordersLocked = db.tbl_SALE_Order.Where(d => d.IsDeleted == false && orderCodes.Contains(d.Code) && blockedStatus.Contains(d.IDStatus))
                .Select(s => new { s.Code }).ToList();


            //Map data
            foreach (var item in DsHdVtList)
            {

                #region Map Sản phẩm
                if (!string.IsNullOrEmpty(item["C3"].ToString()))
                {
                    //Check Item => get Id Item
                    //int IDItem = checkAndCreateItem(new DTO_WMS_Item()
                    //{
                    //    Code = item["C3"].ToString(), //Mã Sản phẩm
                    //    Name = item["C4"].ToString(), //Tên Sản phẩm
                    //}, int.Parse(item["C5"].ToString()) //Thùng/Lẻ
                    //, decimal.Parse(item["C19"].ToString()) //Đơn giá
                    //, decimal.Parse(item["C43"].ToString()) / decimal.Parse(item["C8"].ToString())  //Trọng lượng
                    //, out int IDBaseUoM
                    //, out decimal ProductWeight
                    //, out decimal ProductDimensions
                    //);

                    var product = productItems.FirstOrDefault(d => d.Code == item["C3"].ToString());



                    if (product != null && product.UoM != null)
                    {
                        try
                        {
                            item["C3"] = product.Id;
                            int quyCach = int.Parse(item["C5"].ToString());

                            if (item["C7"].ToString() == "0" && product.UoMSale != null) //Thung
                            {
                                int soThung = int.Parse(item["C6"].ToString());
                                item["IDUoM"] = product.UoMSale.Id;
                                item["UoMPrice"] = decimal.Parse(item["C19"].ToString()) * quyCach;
                                item["Quantity"] = soThung;
                                item["UoMSwap"] = quyCach;
                                item["IDBaseUoM"] = product.UoM.Id;
                                item["BaseQuantity"] = quyCach * soThung;

                                item["ProductWeight"] = (product.UoMSale.Weight > 0 ? product.UoMSale.Weight : (product.UoM.Weight * quyCach)) * soThung;
                                item["ProductDimensions"] = (product.UoMSale.Length > 0 ? (product.UoMSale.Length * product.UoMSale.Width * product.UoMSale.Height) : (product.UoM.Length * product.UoM.Width * product.UoM.Height * quyCach)) * soThung;
                            }
                            else
                            {
                                int tongLe = int.Parse(item["C9"].ToString());

                                int le = tongLe % quyCach;

                                item["IDUoM"] = product.UoM.Id;
                                item["UoMPrice"] = decimal.Parse(item["C19"].ToString());
                                item["Quantity"] = le;
                                item["UoMSwap"] = 1;
                                item["IDBaseUoM"] = product.UoM.Id;
                                item["BaseQuantity"] = le;

                                item["ProductWeight"] = ((product.UoM.Weight == 0 && product.UoMSale != null) ? (product.UoMSale.Weight / quyCach) : product.UoM.Weight) * le;
                                item["ProductDimensions"] = ((product.UoM.Length == 0 && product.UoMSale != null) ?
                                    (product.UoMSale.Length * product.UoMSale.Width * product.UoMSale.Height / quyCach) :
                                    (product.UoM.Length * product.UoM.Width * product.UoM.Height)) * le;

                                if (tongLe > quyCach)
                                {
                                    int soThung = (tongLe - le) / quyCach;

                                    try
                                    {



                                        item["_split"] = "1";

                                        item["_IDUoM"] = product.UoMSale.Id;
                                        item["_UoMPrice"] = decimal.Parse(item["C19"].ToString()) * quyCach;
                                        item["_Quantity"] = soThung;
                                        item["_UoMSwap"] = quyCach;
                                        item["_IDBaseUoM"] = product.UoM.Id;
                                        item["_BaseQuantity"] = quyCach * soThung;

                                        item["_ProductWeight"] = (product.UoMSale.Weight > 0 ? product.UoMSale.Weight : (product.UoM.Weight * quyCach)) * soThung;
                                        item["_ProductDimensions"] = (product.UoMSale.Length > 0 ? (product.UoMSale.Length * product.UoMSale.Width * product.UoMSale.Height) : (product.UoM.Length * product.UoM.Width * product.UoM.Height * quyCach)) * soThung;

                                        var maxCK = le * decimal.Parse(item["UoMPrice"].ToString());
                                        var curCK = decimal.Parse(item["C20"].ToString());

                                        if (curCK > maxCK)
                                        {
                                            item["C20"] = maxCK;
                                            item["_C20"] = curCK - maxCK;
                                        }
                                        else
                                        {
                                            item["_C20"] = 0;
                                        }

                                        item["_C23"] = item["C23"];
                                        item["C23"] = 0;
                                    }
                                    catch (Exception ex)
                                    {

                                        throw;
                                    }
                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            string m = ex.Message;

                            throw ex;
                        }

                    }
                    else
                    {
                        item["C3"] = "";
                    }


                }
                #endregion
                #region Mã KH
                if (!string.IsNullOrEmpty(item["C25"].ToString()))
                {
                    var contact = contacts.FirstOrDefault(d => d.Code == item["C25"].ToString() || d.Reff.Any(e => e.Code == item["C25"].ToString()));
                    if (contact != null)
                        item["C25"] = contact.Id;
                    else
                    {
                        dynamic co = new Newtonsoft.Json.Linq.JObject();
                        co.Code = item["C25"].ToString();
                        co.Name = item["C26"].ToString();
                        co.IsOutlets = true;


                        DTO_CRM_Contact newContact = BS_CRM_Contact.post(db, IDBranch, StaffID, co, Username);
                        item["C25"] = newContact.Id;

                        ICollection<tbl_CRM_ContactReference> r = new List<tbl_CRM_ContactReference>();
                        List<DTO_CRM_PartnerAddress> add = new List<DTO_CRM_PartnerAddress>();

                        contact = new { Id = newContact.Id, Code = newContact.Code, Reff = r, Addresses = add };
                        contacts.Add(contact);
                    }

                    var address = contact.Addresses.FirstOrDefault();
                    if (address != null)
                    {
                        item["IDAddress"] = address.Id;
                    }
                    else
                    {
                        var newAddress = BS_CRM_PartnerAddress.post(db, IDBranch, StaffID, new DTO_CRM_PartnerAddress()
                        {
                            IDPartner = contact.Id,
                            Contact = item["C26"].ToString(),
                            AddressLine1 = string.Format("{0} {1}", item["C33"], item["C34"]),
                            Ward = item["C38"].ToString(),
                            District = item["C37"].ToString(),
                            Province = item["C36"].ToString(),
                            Country = item["C35"].ToString(), 

                            AddressLine2 = item["C39"].ToString(),

                        }, Username) ;
                        item["IDAddress"] = newAddress.Id;
                        contact.Addresses.Add(newAddress);
                    }
                
                }
                #endregion
                #region NV Sale
                if (!string.IsNullOrEmpty(item["C57"].ToString()))
                {
                    //Check Sale => get Id Staff
                    //int IDSale = checkAndCreateStaff(new DTO_HRM_Staff()
                    //{
                    //    Code = item["C57"].ToString(), //Mã NV Sale
                    //    Name = item["C15"].ToString(), //Tên NV Sale
                    //});

                    var staff = staffs.FirstOrDefault(d => d.Code == item["C57"].ToString().Trim());

                    if (staff != null)
                    {
                        item["C57"] = staff.Id;
                    }
                    else
                    {
                        item["C57"] = "";
                    }

                }
                #endregion
                #region Xe
                if (!string.IsNullOrEmpty(item["C12"].ToString()))
                {
                    var vehicle = vehicles.FirstOrDefault(d => d.RefShipper == item["C12"].ToString());

                    if (vehicle != null)
                    {
                        item["C12"] = vehicle.Id;
                    }
                    else
                    {
                        item["C12"] = "";
                    }
                }
                #endregion
                #region check locked
                if (!string.IsNullOrEmpty(item["C16"].ToString()))
                {
                    if (ordersLocked.Any(d => d.Code == item["C16"].ToString()))
                    {
                        item["C16"] = "Locked";
                    }
                }
                #endregion
            }


            #region validate

            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C12"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = true;
                item["ValidateMessage"] += "Không tìm được xe; ";
                NoteToWorkSheet(ws, index, 12, item["ValidateMessage"].ToString(), System.Drawing.Color.Yellow, System.Drawing.Color.Black);
            }

            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C57"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Không có mã NVBH; ";
                NoteToWorkSheet(ws, index, 57, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }


            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C16"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Không có mã hợp đồng; ";
                NoteToWorkSheet(ws, index, 16, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }

            foreach (var item in DsHdVtList.Where(d => d["C16"].ToString() == "Locked"))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Đơn hàng đã khóa; ";
                NoteToWorkSheet(ws, index, 16, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }

            List<string> lockedOrderNotFoundItem = new List<string>();
            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C3"].ToString())))
            {
                string orderCode = item["C16"].ToString();
                if (orderCode != "Locked" && !lockedOrderNotFoundItem.Contains(orderCode))
                {
                    lockedOrderNotFoundItem.Add(orderCode);
                }
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Không có mã sản phẩm; ";
                NoteToWorkSheet(ws, index, 3, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }
            foreach (var item in DsHdVtList.Where(d => lockedOrderNotFoundItem.Contains(d["C16"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Đơn hàng có mã sản phẩm không hợp lệ; ";
                NoteToWorkSheet(ws, index, 16, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }

            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C13"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Không có ngày đơn hàng; ";
                NoteToWorkSheet(ws, index, 13, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }

            foreach (var item in DsHdVtList.Where(d => string.IsNullOrEmpty(d["C25"].ToString())))
            {
                int index = int.Parse(item["_index"].ToString());
                item["IsValid"] = false;
                item["ValidateMessage"] += "Không có mã khách hàng; ";
                NoteToWorkSheet(ws, index, 25, item["ValidateMessage"].ToString(), System.Drawing.Color.Red, System.Drawing.Color.White);
            }


            #endregion

            //Thông báo lỗi
            var invalidList = DsHdVtList.Where(d => !bool.Parse(d["IsValid"].ToString()));
            if (invalidList.Count() > 0)
            {
                ws.Cells["A4:BJ" + (noOfRow - 1).ToString()].AutoFilter = true;

                foreach (var item in invalidList)
                {
                    int index = int.Parse(item["_index"].ToString());
                    string message = item["ValidateMessage"].ToString();
                    NoteToWorkSheet(ws, index, 1, message, System.Drawing.Color.Yellow, System.Drawing.Color.Black);
                }
            }

            return DsHdVtList.Where(d => bool.Parse(d["IsValid"].ToString())).ToList();
        }

        public int checkAndCreateContact(DTO_CRM_Contact contact, DTO_CRM_PartnerAddress address, out int IDAddress)
        {
            var c = db.tbl_CRM_Contact.FirstOrDefault(d => d.Code == contact.Code && !d.IsDeleted);
            if (c == null)
            {
                var newContact = BS_CRM_Contact.post(db, IDBranch, StaffID, contact, Username);
                var newAdd = BS_CRM_PartnerAddress.post(db, IDBranch, StaffID, address, Username);
                IDAddress = newAdd.Id;
                return newContact.Id;
            }
            else
            {
                var add = c.tbl_CRM_PartnerAddress.FirstOrDefault();
                IDAddress = add.Id;
                return c.Id;
            }
        }

        public int checkAndCreateItem(DTO_WMS_Item item, int QuyCach, decimal EachPrice, decimal EachWeight, out int IDBaseUoM, out decimal ProductWeight, out decimal ProductDimensions)
        {
            IDBaseUoM = 0;
            ProductWeight = 0;
            ProductDimensions = 0;

            var findItem = db.tbl_WMS_Item.FirstOrDefault(d => d.IsDeleted == false && d.IsDisabled == false && d.Code == item.Code);

            if (findItem != null)
            {

                var baseUoM = findItem.tbl_WMS_ItemUoM.FirstOrDefault(d => d.IsBaseUoM);
                if (baseUoM != null)
                {
                    IDBaseUoM = baseUoM.Id;
                    ProductWeight = baseUoM.Weight;
                    ProductDimensions = baseUoM.Length * baseUoM.Width * baseUoM.Height;
                }
                return findItem.Id;
            }

            return 0;
            //var newItem = BS_WMS_Item.post_WMS_Item(db, IDBranch, item, Username);
            //return newItem.Id;

        }

        public int checkAndCreateStaff(DTO_HRM_Staff item)
        {
            var findItem = BS_HRM_Staff.getAnItemByCode(db, IDBranch, StaffID, item.Code);
            if (findItem != null)
            {
                return findItem.Id;
            }
            else
            {
                return 0;
                //var newItem = BS_WMS_Item.post_WMS_Item(db, IDBranch, item, Username);
                //return newItem.Id;
            }
        }

        public int checkAndCreateShipper(DTO_HRM_Staff item)
        {
            var nameParts = item.Name.Split(' ').AsEnumerable().ToList();

            if (nameParts.Count() < 2)
            {
                return 0;
            }

            nameParts.Add(nameParts[0]);
            nameParts.RemoveAt(0);

            item.FullName = string.Join(" ", nameParts.ToArray());


            var findItem = db.tbl_HRM_Staff.FirstOrDefault(d => d.IsDeleted == false && d.IsDeleted == false && (d.Code == item.Code || d.FullName == item.FullName));
            if (findItem != null)
            {
                return findItem.Id;
            }
            else
            {
                return 0;
                //var newItem = BS_WMS_Item.post_WMS_Item(db, IDBranch, item, Username);
                //return newItem.Id;
            }
        }

        public bool checkIsLockedOrder(string code)
        {

            var blockedStatus = new int[] {
                //101,	// Mới (sale tạo)
                //102,	// Mới (khách tạo)
                //103,	// Imported
                104,	// Đã xác nhận
                105,	// Đã phân tài
                106,	// Đang lấy hàng - đóng gói
                107,	// Đã giao đơn vị vận chuyển
                108,	// Đang giao hàng
                109,	// Đã giao hàng
                110,	// Chờ giao lại
                111,	// Đã xuất hóa đơn
                112,	// Đã có phiếu thu
                113,	// Còn nợ
                114,	// Đã xong
            }.ToList();


            return db.tbl_SALE_Order.Any(d => d.IsDeleted == false && d.Code == code && blockedStatus.Contains(d.IDStatus));


        }

    }
}