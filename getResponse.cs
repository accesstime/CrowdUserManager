using System;
using System.IO;
using System.Net;
using System.Text;


namespace CrowdUserManager
{
    class getResponse
    {



        public void MessageBox1(string message)
        {


            MessageBox1 MessageBox1 = new MessageBox1();
            MessageBox1.Show(message);


        }



        public void GET(string url, string[] auth,out string responseFromServer)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = new NetworkCredential(auth[0], auth[1]);

            try
            {

                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
           //     MessageBox1(ex.Message);
                responseFromServer = "";
            }


        }




        public void POST(string url, string requestData, string[] auth, out string responseFromServer)
        {


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.Credentials = new NetworkCredential(auth[0], auth[1]);
            string postData = requestData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                }
                catch (Exception ex)
                {
          //      MessageBox1(ex.Message);
                responseFromServer = "";
                }


        }



        public void PUT(string url, string requestData, string[] auth,out string responseFromServer)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.Credentials = new NetworkCredential(auth[0], auth[1]);
            string postData = requestData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            try
            {
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
          //      MessageBox1(ex.Message);
                responseFromServer = "";
            }
        }




        public void DELETE(string url, string[] auth,out string responseFromServer)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            WebRequest request = WebRequest.Create(url);
            request.Method = "DELETE";
            request.Credentials = new NetworkCredential(auth[0], auth[1]);
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
           //     MessageBox1(ex.Message);
                responseFromServer = "";
            }


        }

    }
}
