using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http.Samples.WebRequest
{
    public class QickrNavigator
    {
        private const string Log_Folder_Location = @"C:\temp";
        private const string ListOfAllPlaces_FileName = "ListOfDocLibs.xml";
        private string user = "Prolifics Admin";
        private string pass = "Welcome#1";
        NetworkCredential basicAuthCreds;

        private readonly string LoginPage = @"https://quickr1.emcor.net/LotusQuickr/lotusquickr/Main.nsf/?OpenDatabase&Login";
        private readonly string ListofPlaces = @"https://quickr1.emcor.net/myqcs/rest/places/feed?pagesize=512";
        private readonly string US_Bank = @"https://quickr1.emcor.net/dm/atom/libraries/feed?placeId=%5B@Pusbank/@RMain.nsf%5D";

        public QickrNavigator()
        {
            basicAuthCreds = new NetworkCredential(user, pass);
        }

        public void GetUS_BankEntry()
        {
            try {
            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(US_Bank);

            request.Credentials = basicAuthCreds;

            string userAgent = @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705 Chrome/15.0.874.121 Safari/535.2;)";
            //string userAgent = @"Mozilla/5.0 (Windows NT; Windows NT 10.0; en-US)";
            request.UserAgent = userAgent;
            request.KeepAlive = false;
            request.ContentType = "application/xml";
            request.Accept = "application/xml";
            request.PreAuthenticate = true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            System.IO.File.WriteAllText(Log_Folder_Location + @"\" + ListOfAllPlaces_FileName, responseFromServer);
            Debug.Write(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            }catch (WebException webex)
            {
                Console.WriteLine(webex.ToString());
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }


    }
}
