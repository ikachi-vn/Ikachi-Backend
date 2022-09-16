using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace API
{
    public static class CloudMessaging
    {
        public static string PushMessage(string to, string title, string body)
        {
            //Firebase Console > Project Settings > Cloud Messaging tab
            string serverKey = "AAAAf2_Q3Cs:APA91bFQE5DlM5_IXMpOCPsD3q4Vfjgz8Vm-VbCnZ0orLbKA1WEOKfmdp-qRALzo2rw2n8forNGLX5LcbHbQRoerONOxKKPmTTtbVHafFIamxCcwcp1DmAez9NPWWdXGrLIa38_0e9Yf";
            //Legacy server key: AIzaSyBGNELLa9zcTCxsKOwK-sTMyc46ulm_8Vo
            string senderID = "547336805419";

            if (string.IsNullOrEmpty(to))
            {
                to = "/topics/all"; //Send to all
            }
            string result = "";
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderID));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                to = to,
                priority = "high",
                content_available = true,
                notification = new
                {
                    title = title,
                    body = body,
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result = sResponseFromServer;
                            }
                    }
                }
            }

            return result;
        }

        public static string OneSignalCreateNotification(string to, string title, string body)
        {
            string endPoint = "https://onesignal.com/api/v1/notifications";
            string appID = "fc929f10-5782-4157-8df4-f442238f1a19";
            string apiKey = "OWI1MDU3ZDMtNGE4Ni00ZTA4LTkxMzMtNTk4NDZhNTY4ZmYw";
            
            //User Auth Key
            string AUTH_KEY = "OTdmZTE1MDktZmRlYy00N2YwLWFlYTgtMmE3N2FhZDU3YWU0";
            
            List<string> tos = new List<string>();
            if (to.IndexOf(',') > -1)
            {
                tos.AddRange(to.Split(','));
            }
            else
            {
                tos.Add(to);
            }


            /////////
            var request = WebRequest.Create(endPoint) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "Basic "+ AUTH_KEY);


            var serializer = new JavaScriptSerializer();
            var obj = new {
                app_id = appID,
                headings = new { en = title },
                contents = new { en = body },
                include_player_ids = tos.ToArray()
            };
            

            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
            
            return responseContent;
        }


    }
}