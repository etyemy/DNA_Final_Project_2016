using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DNA_Part_2
{
    class RefSNP
    {
        public string chromozomeNum;
        public string chromPosition;
        public string referenceNucleotide;
        public string varientNucleotide;
        public string rsId;
        public string clinicalSignificance;
        public string populationDiversity;
        public string maf;
        public string chromSampleCount;
        public string alleles;
        public string allelesPerc;
        WebBrowser webBrowser1;
        int pageCounter1 = 0;//addition
        Boolean isStartup;//addition
        Boolean isRsNumFound;


        public RefSNP(string chrom, string pos, string refNucleo, string varNucleo)
        {
            this.chromozomeNum = chrom;
            this.chromPosition = pos;
            this.referenceNucleotide = refNucleo;
            this.varientNucleotide = varNucleo;
            this.rsId = "";
            runWebPageSearch();
            runNcbiSearch();
            webBrowser1.Stop();

        }

        public string getRsId()
        {
            return this.rsId;
        }

        public Boolean IsRsNumFound()
        {
            return this.isRsNumFound;
        }
        public void runWebPageSearch()
        {
            isStartup = true;
            webBrowser1 = new WebBrowser();
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;//ADD DOCUMENT COMPLETED EVENT LISTINER
            webBrowser1.Navigate("http://db.systemsbiology.net/kaviar/cgi-pub/Kaviar.pl");
            waitReadyState();
        }

        public void runNcbiSearch()
        {
            try
            {
                String ncbiUrl = "http://www.ncbi.nlm.nih.gov/SNP/snp_ref.cgi?rs=" + this.rsId.Substring(2);
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;//ADD DOCUMENT COMPLETED EVENT LISTINER

                webBrowser1.Navigate(ncbiUrl);
                waitReadyState();
                String ncbiHtml = webBrowser1.DocumentText.ToString();
                HtmlElement el = webBrowser1.Document.GetElementById("Allele").GetElementsByTagName("td")[11];
                this.clinicalSignificance = el.InnerText;
                el = webBrowser1.Document.GetElementById("Allele").GetElementsByTagName("td")[13];
                this.maf = el.InnerText;
                el = webBrowser1.Document.GetElementById("Allele").GetElementsByTagName("td")[3];
                this.alleles = el.InnerText;
                HtmlElement table = webBrowser1.Document.GetElementById("Alleles");


                int i = 0;
                int j = 0;
                foreach (HtmlElement row in webBrowser1.Document.All)
                {
                    i++;
                    try
                    {
                        if (row.InnerText.Equals("ExAc_Aggregated_Populations"))
                        {
                            j = i + 4;
                            this.chromSampleCount = webBrowser1.Document.All[i + 2].InnerText;
                            while (webBrowser1.Document.All[j].InnerText == null)
                            {
                                j++;
                            }
                            this.allelesPerc = webBrowser1.Document.All[j].InnerText;
                            j += 2;
                            while (webBrowser1.Document.All[j].InnerText == null)
                            {
                                j++;
                            }
                            this.allelesPerc += " / " + webBrowser1.Document.All[j].InnerText;
                            break;
                        }
                    }
                    catch (NullReferenceException e)
                    {

                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //here we find that get RS ID failed
            }

        }


        public void readHtml()
        {

        }

        public void waitReadyState()
        {
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }
        //addition
        public void waitReadyState(WebBrowser webBrowser)
        {
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            pageCounter1++;
            webBrowser1.ScriptErrorsSuppressed = true;

            if ((this.chromozomeNum != "") && (this.chromPosition != "") && isStartup)
            {
                loadKaviarJsonPage(this.webBrowser1);
            }
            if (pageCounter1 == 2)
            {
                String browserContentsJson = webBrowser1.Document.Body.InnerText;
                setJSONData(browserContentsJson, this.varientNucleotide);
            }
        }

        private void loadKaviarJsonPage(WebBrowser webBrowser)
        {
            webBrowser.DocumentCompleted += webBrowser1_DocumentCompleted;//ADD DOCUMENT COMPLETED EVENT LISTINER
            webBrowser.Document.GetElementById("frz").SetAttribute("value", "hg19");
            webBrowser.Document.GetElementById("chr").SetAttribute("value", this.chromozomeNum);
            webBrowser.Document.GetElementById("pos").SetAttribute("value", this.chromPosition);
            webBrowser.Document.GetElementById("format").SetAttribute("value", "json");
            waitReadyState();
            clickSubmit(webBrowser);
            Application.DoEvents();
            System.Threading.Thread.Sleep(8500);
            waitReadyState(webBrowser);
            String browserContentsJson = webBrowser1.Document.Body.InnerText;
            isStartup = false;
        }

        private void clickSubmit(WebBrowser webBrowser)
        {
            webBrowser.DocumentCompleted += webBrowser1_DocumentCompleted;//ADD DOCUMENT COMPLETED EVENT LISTINER

            HtmlElementCollection elc = webBrowser.Document.GetElementsByTagName("input");
            foreach (HtmlElement el in elc)
            {
                if (el.GetAttribute("type").Equals("submit"))
                {
                    el.InvokeMember("Click");

                }
            }
        }

        private void setJSONData(String JSON, string variant)
        {

            // Make search case-insensitive with optional third argument:
            int searchResultCount = Regex.Matches(JSON, "chromosome", RegexOptions.IgnoreCase).Count;
            dynamic data = JObject.Parse(JSON);
            //MessageBox.Show(searchResultCount.ToString() + " RefSNP Numbers where found");//MESSAGE BOX DISABLED
            int i = 0;
            int j = 0;
            string kaviarTempVar;
            while (i < searchResultCount)
            {
                if (this.rsId != "")
                    break;
                j = 0;
                if (data["sites"][i]["rsids"] != null)
                {

                    while (data["sites"][i]["varInfo"][j] != null)
                    {
                        kaviarTempVar = (string)data["sites"][i]["varInfo"][j]["variant"];
                        if (kaviarTempVar.Equals(this.varientNucleotide))
                        {
                            this.rsId = (string)data["sites"][i]["rsids"][0];
                            break;
                        }
                        j++;
                        try
                        {
                            if (data["sites"][i]["varInfo"][j] == null)
                            {
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            //MessageBox.Show("There is no referanceSNP number for this chrm position and varNucleotide");
                            break;
                        }
                    }
                }
                i++;
            }

        }

        private void loadKaviarSearchResultPage(WebBrowser webBrowser)
        {

            webBrowser.Document.GetElementById("frz").SetAttribute("value", "hg19");
            webBrowser.Document.GetElementById("chr").SetAttribute("value", this.chromozomeNum);
            webBrowser.Document.GetElementById("pos").SetAttribute("value", this.chromPosition);
            webBrowser.Document.GetElementById("format").SetAttribute("value", "table");
            clickSubmit(webBrowser);
            isStartup = false;
        }



    }

}
