using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace WebexTest3
{
    public static class WebexHelper
    {
        /// <summary>
        /// This method is to create meeting with given webex required values
        /// </summary>
        /// <param name="webex"></param>
        /// <returns> returns output string of webex model</returns>
        public static string CreateWebexMeeting(WebexModel webex)
        {
            string Meetingkey = string.Empty, guestToken = string.Empty, hostUrl = string.Empty, attendeeUrl = string.Empty, OutPutString = string.Empty;
            string strXML = RequestXMLString(webex, "CREATEMEETING");
            string jsonText = XMLResponseToString(webex.siteName, strXML);
            // To convert JSON text contained in string json into an XML node
            // XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonText);
            // ltrlMessage.Text = jsonText;

            var data = (JObject)JsonConvert.DeserializeObject(jsonText);

            if (jsonText.ToString().ToUpper().Contains("<SERV:RESULT>SUCCESS</SERV:RESULT>"))
            {
                if (webex.siteName.ToUpper() == "MEETINGS")
                {
                    webex.meetingkey = data["serv:message"]["serv:body"]["serv:bodyContent"]["meet:meetingkey"].ToString();
                    OutPutString = "Meetingkey : " + webex.meetingkey + "<br/>";
                    if (!string.IsNullOrEmpty(Meetingkey))
                    {
                        OutPutString = GetmeetingDeatials(webex);
                    }

                }
                else
                {
                    Meetingkey = data["serv:message"]["serv:body"]["serv:bodyContent"]["meet:meetingkey"].ToString();
                    guestToken = data["serv:message"]["serv:body"]["serv:bodyContent"]["meet:guestToken"].ToString();
                    hostUrl = data["serv:message"]["serv:body"]["serv:bodyContent"]["meet:iCalendarURL"]["serv:host"].ToString();
                    attendeeUrl = data["serv:message"]["serv:body"]["serv:bodyContent"]["meet:iCalendarURL"]["serv:attendee"].ToString();
                    OutPutString = "Meetingkey : " + Meetingkey + "<br/>" + "guestToken : " + guestToken + "<br/>" + "hostUrl : " + hostUrl + "<br/>" + "attendeeUrl : " + attendeeUrl + "<br/>";
                }

            }
            else
            {

                OutPutString = "Failure : " + jsonText;
            }

            return OutPutString;
        }

        /// <summary>
        /// This method is to get the meeting details
        /// </summary>
        /// <param name="webex"></param>
        /// <returns></returns>
        public static string GetmeetingDeatials(WebexModel webex)
        {
            string XMLRequestString = RequestXMLString(webex, "GET");

            string jsonText = XMLResponseToString(webex.siteName, XMLRequestString);
            // To convert JSON text contained in string json into an XML node
            // XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonText);
            //  ltrlMessage.Text = jsonText;

            return jsonText;

        }

        /// <summary>
        ///  To get XML Response after requesting  and convert the output To String 
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="XMLRequestString"></param>
        /// <returns></returns>
        public static string XMLResponseToString(string siteName, string XMLRequestString)
        {
            string strXMLServer = "https://" + siteName + ".Webex.com/WBXService/XMLService";
            WebRequest request = WebRequest.Create(strXMLServer);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Set the ContentType property of the WebRequest.
            request.ContentType = "text/xml";// "application/raw";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(XMLRequestString);
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseFromServer);
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);
            reader.Close();
            dataStream.Close();
            response.Close();
            return jsonText;
        }

        /// <summary>
        /// To Get CreateMeeting Request XML String
        /// </summary>
        /// <param name="webex"></param>
        /// <returns>Request XML String</returns>
        public static string GetCreateMeetingRequestXMLString(WebexModel webex)
        {

            // Create POST data and convert it to a byte array.
            string strXML = "<?xml version='1.0' encoding='UTF-8'?>";
            strXML += "<serv:message xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            strXML += "<header>";
            strXML += "<securityContext>";
            strXML += "<webExID>" + webex.webExID + "</webExID>";
            strXML += "<password>" + webex.password + "</password>";
            strXML += "<siteName>" + webex.siteName + "</siteName>";
            strXML += "</securityContext>";
            strXML += "</header>";
            strXML += "<body>";
            strXML += "<bodyContent xsi:type='java:com.webex.service.binding.meeting.CreateMeeting'>";
            strXML += "<metaData>";
            strXML += "<confName>" + webex.meetingName + "</confName>";
            strXML += "</metaData>";
            strXML += "<schedule>";
            strXML += "<startDate>" + webex.startDate + "</startDate>";
            strXML += "<duration>" + webex.duration + "</duration>";
            strXML += "</schedule>";
            strXML += "</bodyContent>";
            strXML += "</body>";
            strXML += "</serv:message>";
            return strXML;
        }

        /// <summary>
        /// common method to build xml and convert to string for get and delete requests
        /// </summary>
        /// <param name="webex"></param>
        /// <param name="requestType"></param>
        /// <returns>XML string</returns>
        public static string RequestXMLString(WebexModel webex, string requestType)
        {
            // Create POST data and convert it to a byte array.
            string strXML = "<?xml version='1.0' encoding='UTF-8'?>";
            strXML += "<serv:message xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>";
            strXML += "<header>";
            strXML += "<securityContext>";
            strXML += "<webExID>" + webex.webExID + "</webExID>";
            strXML += "<password>" + webex.password + "</password>";
            strXML += "<siteName>" + webex.siteName + "</siteName>";
            strXML += "</securityContext>";
            strXML += "</header>";
            strXML += "<body>";
            if (requestType.ToUpper() == "DELETE")
            {
                strXML += "<bodyContent xsi:type='java:com.webex.service.binding.meeting.DelMeeting'>";
                strXML += "<meetingKey>" + webex.meetingkey + "</meetingKey>";
            }
            else if (requestType.ToUpper() == "GET")
            {
                strXML += "<bodyContent xsi:type='java:com.webex.service.binding.meeting.GetMeeting'>";
                strXML += "<meetingKey>" + webex.meetingkey + "</meetingKey>";

            }
            else if (requestType.ToUpper() == "VALIDATE")
            {
                strXML += "<bodyContent xsi:type='java:com.webex.service.binding.user.AuthenticateUser'>";

            }
            else if (requestType.ToUpper() == "CREATEMEETING")
            {
                strXML += "<bodyContent xsi:type='java:com.webex.service.binding.meeting.CreateMeeting'>";
                strXML += "<metaData>";
                strXML += "<confName>" + webex.meetingName + "</confName>";
                strXML += "</metaData>";
                strXML += "<schedule>";
                strXML += "<startDate>" + webex.startDate + "</startDate>";
                strXML += "<duration>" + webex.duration + "</duration>";
                strXML += "</schedule>";
            }
            else
            {

            }

            strXML += "</bodyContent>";
            strXML += "</body>";
            strXML += "</serv:message>";
            return strXML;
        }

    }


    /// <summary>
    /// Webex Request Model
    /// </summary>
    public class WebexModel
    {
        public string requestUrl { get; set; }
        public string webExID { get; set; }
        public string password { get; set; }
        public string siteName { get; set; }
        public string meetingkey { get; set; }
        public string meetingName { get; set; }
        public string startDate { get; set; }
        public int duration { get; set; }

    }
}