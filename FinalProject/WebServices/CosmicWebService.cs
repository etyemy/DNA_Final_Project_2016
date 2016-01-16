using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FinalProject
{
    /*
     * CosmicWebService class.
     * Main purpose - get articles list as tsv file from COSMIC website.
     * Using http request and response.
     */
    class CosmicWebService
    {
        //CookieContainer for saving session for COSMIC login
        private CookieContainer _cookieContainer;

        //Constructor - set new CookieContainer.
        public CosmicWebService()
        {
            _cookieContainer = new CookieContainer();
        }

        //Method that send login request to COSMIC, return true.
        //Can fail 5 times, on fifth failure return false.
        public bool loginToCosmic(string email,string password,int times)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://cancer.sanger.ac.uk/cosmic/User?email=" + email + "&pass=" + password);
            req.CookieContainer = _cookieContainer; 
            req.Method = "POST";
            req.KeepAlive = false;
            req.AllowAutoRedirect = false;
            req.Timeout = 10000;
            try
            {
                if (times == 0)
                    return false;
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                return isLogedIn();
            }
            catch (Exception)
            {
                return loginToCosmic(email, password,times-1);
            }
        }
        
        //Function that send request to user page in COSMIC, if loged in return true, otherwise return false.
        public bool isLogedIn()
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cosmic/user_info","GET");
            return !Regex.IsMatch(pageSource, "\\bLogin\\b");
            
        }

        //Get the COSMIC ID of mutation and return the tsv file containing the article list of that id.
        public string getTsvFromCosmic(int CosmicId)
        {
            string pageSource = getPageSource("http://cancer.sanger.ac.uk/cosmic/references?q=MUTATION_REFERENCES&amp;id=" + CosmicId,"GET");
            return pageSource;
        }

        //Method that get a string that contain the http request,send it to COSMIC website,get the response and return as a string containing the http response.
        //Use the CookieContainer for login premmissions.
        private string getPageSource(string url,string method)
        {
            string pageSource;
            HttpWebRequest getRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            getRequest.CookieContainer = _cookieContainer;
            getRequest.Method = method;
            getRequest.KeepAlive = false;
            getRequest.AllowAutoRedirect = false;
            getRequest.Timeout = 10000;
            try
            {
                WebResponse getResponse = getRequest.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    pageSource = sr.ReadToEnd();
                }
                getResponse.Close();
                return pageSource;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
