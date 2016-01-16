using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    //Contains only static functions
    class GeneralMethods
    {
        //Generate error message box that shows the text that it gets. 
        public static void showErrorMessageBox(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

        }

        //Gets string and return its reverse string.
        public static string reverseString(string toReverse)
        {
            char[] arr = toReverse.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        //Method that represent the Amino Acid Table, get 3 character string as codon and return the amino acid that it represent.
        public static string getAminoAcid(string codon)
        {
            switch (codon)
            {
                case "TTT":
                case "TTC":
                    return "F";
                case "TTA":
                case "TTG":
                case "CTT":
                case "CTA":
                case "CTG":
                case "CTC":
                    return "L";
                case "ATT":
                case "ATC":
                case "ATA":
                    return "I";
                case "ATG":
                    return "M";
                case "GTA":
                case "GTT":
                case "GTG":
                case "GTC":
                    return "V";
                case "TCA":
                case "TCT":
                case "TCG":
                case "TCC":
                case "AGT":
                case "AGC":
                    return "S";
                case "CCA":
                case "CCT":
                case "CCG":
                case "CCC":
                    return "P";
                case "ACA":
                case "ACT":
                case "ACG":
                case "ACC":
                    return "T";
                case "GCA":
                case "GCT":
                case "GCG":
                case "GCC":
                    return "A";
                case "TAT":
                case "TAC":
                    return "Y";
                case "TAA":
                case "TAG":
                case "TGA":
                    return "Stop";
                case "CAT":
                case "CAC":
                    return "H";
                case "CAA":
                case "CAG":
                    return "Q";
                case "AAT":
                case "AAC":
                    return "N";
                case "AAG":
                case "AAA":
                    return "K";
                case "GAT":
                case "GAC":
                    return "D";
                case "GAG":
                case "GAA":
                    return "E";
                case "TGT":
                case "TGC":
                    return "C";
                case "TGG":
                    return "W";
                case "CGA":
                case "CGT":
                case "CGG":
                case "CGC":
                case "AGA":
                case "AGG":
                    return "R";
                case "GGA":
                case "GGT":
                case "GGG":
                case "GGC":
                    return "G";
                default:
                    return null;
            }
        }
    }
}
