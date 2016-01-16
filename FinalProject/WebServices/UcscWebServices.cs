using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalProject
{
    /*
     * UcscWebServices class.
     * Main purpose - get codon at specific position in specific chromosome.
     * Using http request and response.
     */
    public class UcscWebServices
    {
        //Main function of UcscWebServices class, return codon at specific position in specific chromosome.
        //If no codon exist, return null.
        public static string getCodonAt(string chrom, int index,int codonOffset)
        {
          
            string toReturn = null;
            switch (codonOffset)
            {
                case 0:
                    toReturn= getSeq(chrom, index, index + 2);
                    break;
                case 1:
                    toReturn = getSeq(chrom, index - 1, index + 1);
                    break;
                case 2:
                    toReturn = getSeq(chrom, index - 2, index);
                    break;
                default:
                    break;
            }
            return toReturn.ToUpper();   
        }
        
        //Return specific sequence from UCSC web services using http request and response.
        private static string getSeq(string chrom, int start, int end)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(buildRequest(chrom, start, end));
            XmlNode node = xmlDoc.SelectSingleNode("/DASDNA/SEQUENCE/DNA/text()");
            return node.Value.Trim();
        }
        
        //Return string that contain the request that need be sent via http.
        private static string buildRequest(string chrom, int start, int end)
        {
            return @"http://genome.ucsc.edu/cgi-bin/das/hg19/dna?segment=" + chrom + ":" + start + "," + end;
        }
    }
}
