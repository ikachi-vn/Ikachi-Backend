using System;

using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using ClassLibrary;
using DTOModel;
using System.Collections.Generic;

namespace API
{
    public static class MailService
    {
        public static List<DTO_BOOK_Bookings> GetBlueCareTrack(int hour=1)
        {
            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("imap.gmail.com", 993, true);

                client.Authenticate("gretchenbrear31450@gmail.com", "JPptzkvck56776");

                // The Inbox folder is always available on all IMAP servers...

                string[] CommonSentFolderNames = { "3-bluecare" };
                var personal = client.GetFolder(client.PersonalNamespaces[0]);

                var folder = client.GetFolder("3-Bluecare");

                folder.Open(FolderAccess.ReadOnly);

                var uids = folder.Search(SearchQuery.DeliveredAfter(DateTime.Now.Subtract(new TimeSpan(hour, 5, 0))));

              
                List<DTO_BOOK_Bookings> Orders = new List<DTO_BOOK_Bookings>();

                foreach (var uid in uids)
                {

                    
                    var message = folder.GetMessage(uid);

                    string OrderNumber = "";
                    string BTrack = "";


                    var oMat = System.Text.RegularExpressions.Regex.Matches(message.Subject, "Tracking for (.+) /");
                    if (oMat.Count > 0 && oMat[0].Groups.Count > 1)
                    {
                        OrderNumber = oMat[0].Groups[1].Value;

                        var bMat = System.Text.RegularExpressions.Regex.Matches(message.HtmlBody, "Tracking number =.+\">([A-Z|0-9]+)");
                        if (bMat.Count > 0 && bMat[0].Groups.Count > 1)
                        {
                            BTrack = bMat[0].Groups[1].Value;

                            DTO_BOOK_Bookings order = new DTO_BOOK_Bookings();
                            //order.OrderNumber = OrderNumber;
                            //order.TrackID = BTrack;

                            Orders.Add(order);
                        }
                    }

                }

                client.Disconnect(true);

                return Orders;
            }
        }
    }
}



