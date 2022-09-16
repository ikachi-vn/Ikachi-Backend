using System;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Linq.Expressions;

namespace ClassLibrary
{
    public static class Util
    {
        private static readonly string[] VietnameseSigns = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };
        public static string RemoveSign4VietnameseString(string str)
        {
            if (str == null)
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
            input = input.Replace(".", "iiidauchamiii").Replace("-/-", "iiidaugachcheoiii");

            return RemoveSpecialCharacters(RemoveSign4VietnameseString(input)).Trim().Replace("iiidauchamiii", ".").Replace(".", "-").Replace(" ", "-").Replace("--", "-").Replace("iiidaugachcheoiii", "/");
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


        public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new List<string>(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return self == to;
        }

    }



    public static class ExcelUtil{
        public static void SetValidateData(
            ExcelPackage package,
            int col,
            List<ItemModel> data,
            bool allowBlank = true,
            bool showTollTipInputMessage = false,
            string toolTipTitle = "",
            string tooltipMessage = "")
        {
            if (data==null)
                return;
            
            //Get or create ValidationData sheet
            var ws = package.Workbook.Worksheets["ValidationData"];
            if (ws == null)
            {
                ws = package.Workbook.Worksheets.Add("ValidationData");
            }

            ws.Hidden = eWorkSheetHidden.VeryHidden;


            //Define the accepted values
            int row = 0;
            foreach (var item in data)
            {
                row++;
                ws.Cells[row, col].Value = item.Id + ". " + item.Name;
            }

            //Add a List validation to B column. Values should be in a list
            var val = package.Workbook.Worksheets.FirstOrDefault().Cells[5, col, 999999, col].DataValidation.AddListDataValidation();// .DataValidations.AddListValidation();
            //Shows error message when the input doesn't match the accepted values
            val.ShowErrorMessage = true;
            //Style of warning. "information" and "warning" allow users to ignore the validation,
            //while "stop" and "undefined" doesn't
            val.ErrorStyle = OfficeOpenXml.DataValidation.ExcelDataValidationWarningStyle.stop;
            //Title of the error mesage box
            val.ErrorTitle = "Lỗi nhập liệu";
            //Message of the error
            val.Error = "Vui lòng chọn dữ liệu trong danh sách";
            //Set to true to show a prompt when user clics on the cell
            val.ShowInputMessage = showTollTipInputMessage;
            //Set the title for the prompt
            val.PromptTitle = toolTipTitle;
            //Set the message for the prompt
            val.Prompt = tooltipMessage;
            //Set to true if blank value is accepted
            val.AllowBlank = allowBlank;

            val.Formula.ExcelFormula = ws.Cells[1,col, row,col].FullAddressAbsolute;

        }

        public static void NoteToWorkSheet(ExcelWorksheet ws, int rowid, int colid, string message, System.Drawing.Color BackgroundColor, System.Drawing.Color FontColor)
        {
            //Bảng màu
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.brushes?redirectedfrom=MSDN&view=netframework-4.8

            if (ws.Cells[rowid, colid].Comment == null)
            {
                var comment = ws.Cells[rowid, colid].AddComment(message, "hungvq@live.com");
                comment.AutoFit = true;
            }
            else
                ws.Cells[rowid, colid].Comment.Text += "\n" + message;
            

            ws.Cells[rowid, colid].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            ws.Cells[rowid, colid].Style.Fill.BackgroundColor.SetColor(BackgroundColor);
            ws.Cells[rowid, colid].Style.Font.Color.SetColor(FontColor);
        }

    }

    public static class DynamicUtil
    {
        public static bool HasMember(object dynObj, string memberName)
        {
            return GetMemberNames(dynObj).Contains(memberName);
        }

        public static IEnumerable<string> GetMemberNames(object dynObj)
        {
            var metaObjProvider = dynObj as IDynamicMetaObjectProvider;

            if (null == metaObjProvider) throw new InvalidOperationException(
                "The supplied object must be a dynamic object " +
                "(i.e. it must implement IDynamicMetaObjectProvider)"
            );

            var metaObj = metaObjProvider.GetMetaObject(
                Expression.Constant(metaObjProvider)
            );

            var memberNames = metaObj.GetDynamicMemberNames();

            return memberNames;
        }
    }
}
