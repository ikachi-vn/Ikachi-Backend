using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace iData.Common
{
    public static class StringUtil
    {
        private static readonly string[] VietnameseSigns = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };
        public static string RemoveSign4VietnameseString(string str)
        {
            if (str==null)
            {
                return null;
            }
            for (int i = 1; i < VietnameseSigns.Length; i++)
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    
                        str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
                    
                    
            return str;
        }
        public static string RemoveSpecialCharacters(string input)
        {
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, String.Empty);
        }
        public static string RemoveVietSignAndSpecialChar(string input)
        {
            return RemoveSpecialCharacters(RemoveSign4VietnameseString(input));
        }
        public static string RemoveVietSignSpecialCharAndSpaceChar(string input)
        {
            input = input.Replace(".", "iiidauchamiii").Replace("-/-","iiidaugachcheoiii");

            return RemoveSpecialCharacters(RemoveSign4VietnameseString(input)).Trim().Replace("iiidauchamiii", ".").Replace(".", "-").Replace(" ", "-").Replace("--", "-").Replace("iiidaugachcheoiii","/");
        }
        public static string GS1CheckSum(string pInput)
        {
            if (!(pInput.Length == 7 || pInput.Length == 11 || pInput.Length == 12 || pInput.Length == 13 || pInput.Length == 17))
            {
                return "N/A";
            }
            for (int i = 0; i < pInput.Length; i++)
            {
                try
                {
                    int.Parse(pInput.Substring(i, 1));
                }
                catch (Exception)
                {
                    return "N/A";
                }
            }

            while (pInput.Length < 17)
            {
                pInput = "0" + pInput;
            }
            int TongChan = 0;
            int TongLex3 = 0;
            for (int i = 1; i <= 17; i++)
            {
                if (i % 2 == 0)
                {
                    TongChan += int.Parse(pInput.Substring(i - 1, 1));
                }
                else
                {
                    TongLex3 += 3 * int.Parse(pInput.Substring(i - 1, 1));
                }
            }
            int Tong = TongChan + TongLex3;
            int TempNo = int.Parse(Tong.ToString().Substring(Tong.ToString().Length));
            int returnValue = 0;
            if (TempNo == 0)
            {
                return returnValue.ToString();
            }
            else
            {
                return (10 - TempNo).ToString();
            }
        }
        public static string GS1Complete(string pInput)
        {
            return pInput + GS1CheckSum(pInput);
        }
        public static string TrimLeftText(string input, int length, string ReadMoreText)
        {
            if (input.Length <= ReadMoreText.Length + length)
                return input;
            else
                return input.Substring(0, length) + ReadMoreText;
        }
        public static string TrimWords(string input, int length, string ReadMoreText)
        {
            System.Text.RegularExpressions.MatchCollection wordColl = System.Text.RegularExpressions.Regex.Matches(input, @"[\S]+");

            if (wordColl.Count > length)
            {
                var words = input.Split(' ');
                var index = 0;
                input = "";
                while (index < length)
                {
                    input += words[index] + " ";
                    index++;
                }

                input += ReadMoreText;
            }

            return input;
        }
        public static string file_get_contents(string fileName)
        {
            string sContents = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("http:") > -1 || fileName.ToLower().IndexOf("https:") > -1)
                { // URL 
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.UTF8.GetString(response);
                }
                else
                {
                    // Regular Filename 
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {

                sContents = "Mục tin này đang cập nhật, vui lòng quay lại sau. <br/> Xin chân thành cảm ơn! " + ex.Message;
            }

            return sContents;
        }

        public static string QRC(int ID, string prefix = "")
        {
            string key = prefix + ID.ToString();
            string result = "";
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(key, QRCodeGenerator.ECCLevel.M);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap bitMap = qrCode.GetGraphic(10))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    result = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return result;
        }


        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        // Hàm đọc số thành chữ
        public static string DocTienBangChu(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }

    }
}