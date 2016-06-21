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
        private string chromozomeNum;
        private string chromPosition;
        private string referenceNucleotide;
        private string varientNucleotide;
        private string rsId;
        private string clinicalSignificance;
        private string populationDiversity;
        private string maf;
        private string chromSampleCount;
        private string alleles;
        private string allelesPerc;

        WebBrowser webBrowser1;
        int pageCounter1 = 0;//addition
        Boolean isStartup;//addition


        public RefSNP(string chrom, string pos, string refNucleo, string varNucleo)
        {
            this.chromozomeNum = chrom;
            this.chromPosition = pos;
            this.referenceNucleotide = refNucleo;
            this.varientNucleotide = varNucleo;
            this.rsId = "";
            runWebPageSearch();
            runNcbiSearch();
            if (chromSampleCount == null)
            {
                this.chromSampleCount = "N/A";
            }
            if (allelesPerc == null)
            {
                this.allelesPerc = "N/A";
            }
            if (populationDiversity == null)
            {
                this.populationDiversity = "N/A";
            }
            webBrowser1.Stop();

        }

        public RefSNP(List<String> refList)
        {
            this.chromozomeNum = refList[0];
            this.chromPosition = refList[1];
            this.referenceNucleotide = refList[2];
            this.varientNucleotide = refList[3];
            this.rsId = refList[4];
            this.clinicalSignificance = refList[5];
            this.populationDiversity = refList[6];
            this.maf = refList[7];
            this.chromSampleCount = refList[8];
            this.alleles = refList[9];
            this.allelesPerc= refList[10];
        }
        public string getRsId()
        {
            return this.rsId;
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
            if ((this.rsId == null) || (this.rsId.Equals("")))
                return;
            try
            {
                
                String ncbiUrl = "http://www.ncbi.nlm.nih.gov/SNP/snp_ref.cgi?rs=" + this.rsId.Substring(2);
                //webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;//ADD DOCUMENT COMPLETED EVENT LISTINER   - REMOVED
                webBrowser1.Navigate(ncbiUrl);
                waitReadyState(); //REMOVED
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
                        if ((row.InnerText!=null) && (row.InnerText.Equals("ExAc_Aggregated_Populations")))
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
                        return;
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //here we find that get RS ID failed
                return;
            }

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
                System.Threading.Thread.Sleep(5000);//ADDED
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
            waitReadyState();//added
            webBrowser.Document.GetElementById("frz").SetAttribute("value", "hg19");
            webBrowser.Document.GetElementById("chr").SetAttribute("value", this.chromozomeNum);
            webBrowser.Document.GetElementById("pos").SetAttribute("value", this.chromPosition);
            webBrowser.Document.GetElementById("format").SetAttribute("value", "json");
            //waitReadyState();
            clickSubmit(webBrowser);
            Application.DoEvents();
            System.Threading.Thread.Sleep(5000);//re added
            //waitReadyState(webBrowser);
            //String browserContentsJson = webBrowser1.Document.Body.InnerText;
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
                    //waitReadyState();//added
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
                            if (kaviarTempVar == null)
                            {
                                break;
                            }
                            if (kaviarTempVar.Length > 1)
                            {
                                break;
                            }
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

        public string ChromozomeNum
        {
            get { return chromozomeNum; }
            set { chromozomeNum = value; }
        }

        public string ChromPosition
        {
            get { return chromPosition; }
            set { chromPosition = value; }
        }

        public string ReferenceNucleotide
        {
            get { return referenceNucleotide; }
            set { referenceNucleotide = value; }
        }

        public string VarientNucleotide
        {
            get { return varientNucleotide; }
            set { varientNucleotide = value; }
        }

        public string RsId
        {
            get { return rsId; }
            set { rsId = value; }
        }

        public string ClinicalSignificance
        {
            get { return clinicalSignificance; }
            set { clinicalSignificance = value; }
        }

        public string PopulationDiversity
        {
            get { return populationDiversity; }
            set { populationDiversity = value; }
        }

        public string Maf
        {
            get { return maf; }
            set { maf = value; }
        }

        public string ChromSampleCount
        {
            get { return chromSampleCount; }
            set { chromSampleCount = value; }
        }

        public string Alleles
        {
            get { return alleles; }
            set { alleles = value; }
        }

        public string AllelesPerc
        {
            get { return allelesPerc; }
            set { allelesPerc = value; }
        }


    }

}
