using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject
{
    /*
     * CSVHandler class.
     * Main purpose - Handle csv file that holds mutation data.
     */
    class CSVHandler
    {
        enum CsvColumn { Chrom = 0, Position, Ref, Variant, AlleleCall, Filter1, Frequency, Quality, Filter2, Type, AlleleSource, AlleleName, GeneID };

        //Get the csv path and return only the important fields.
        public static List<string[]> getMutationsImportantDetails(string csvPath)
        {
            List<string[]> _csvMin = new List<string[]>();
            StreamReader reader = new StreamReader(csvPath);
            string header = reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts[(int)CsvColumn.Type].Equals("SNP"))
                {
                    string chrom = parts[(int)CsvColumn.Chrom];
                    string position = parts[(int)CsvColumn.Position];
                    string geneName = parts[(int)CsvColumn.GeneID];
                    string refNuc = parts[(int)CsvColumn.Ref];
                    string varNuc = parts[(int)CsvColumn.Variant];
                    string[] a = new string[6] { chrom, position, geneName, refNuc, varNuc,"1" };
                    _csvMin.Add(a);
                }
            }
            return _csvMin;
        }
    }
}
