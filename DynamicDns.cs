using System;
using System.IO;
using System.Net;
using System.Xml;

namespace namecheap_dynamic_dns
{
    static class DynamicDns
    {
        public static string GetIp()
        {
            var request = WebRequest.CreateHttp("https://dynamicdns.park-your-domain.com/getip");
            return new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
        }

        public static string PerformDynamicDnsUpdate(Profile profile)
        {
            try
            {
                var ip = profile.IpAddress;
                if (profile.AutoDetectIpAddress)
                {
                    ip = GetIp();
                }
                HttpWebRequest request = WebRequest.CreateHttp("https://dynamicdns.park-your-domain.com/update?" +
                    "host=" + WebUtility.UrlEncode(profile.Host) +
                    "&domain=" + WebUtility.UrlEncode(profile.Domain) +
                    "&password=" + WebUtility.UrlEncode(profile.DynamicDnsPassword) +
                    "&ip=" + WebUtility.UrlEncode(ip));
                var response = new XmlDocument();
                response.LoadXml(new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd());
                var errCount = response.GetElementsByTagName("ErrCount");

                if (errCount.Count == 1 && errCount[0].InnerText == "0")
                {
                    return "Update successful (" + ip + ")";
                }
                else
                {
                    return "Update failed (non-zero error count)";
                }
            }
            catch (XmlException)
            {
                return "Update failed (XML parse error)";
            }
            catch (WebException)
            {
                return "Update failed (network error)";
            }
            catch (IOException)
            {
                return "Update failed (network error)";
            }
            catch (Exception)
            {
                return "Update failed (unknown error)";
            }
        }
    }
}
