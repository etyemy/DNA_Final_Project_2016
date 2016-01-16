using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;


namespace FinalProject.FileHendlers
{
    /*
     * DOCExportHandler class.
     * Main purpose - export mutation details to DOCX file.
     */
    public class DOCExportHandler
    {
        //Main class function, export the mutationList to DOCX file, sets file name to patient's testName.
        public static void saveDOC(Patient patient, List<Mutation> mutationList, bool includePersonalDetails)
        {
            WordprocessingDocument myDoc = null;
            string fullPath = Properties.Settings.Default.ExportSavePath + @"\" + patient.TestName;
            if (includePersonalDetails)
                fullPath += "_withDetails";
            fullPath += ".docx";
            try
            {
                myDoc = WordprocessingDocument.Create(fullPath, WordprocessingDocumentType.Document);
            }
            catch(IOException )
            {
                throw ;
            }
            MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = new Body();
            Paragraph paragraph = new Paragraph();
            Run run_paragraph = new Run();
            paragraph.Append(run_paragraph);

            //add paragraph for each detail of the patient.
            body.Append(generateParagraph("Test Name",true));
            body.Append(generateParagraph(patient.TestName,false));
            //add personal details of the patien, if includePersonalDetails=true
            if (includePersonalDetails)
            {
                body.Append(generateParagraph("ID", true));
                body.Append(generateParagraph(patient.PatientID, false));
                body.Append(generateParagraph("First Name", true));
                body.Append(generateParagraph(patient.FName, false));
                body.Append(generateParagraph("Last Name", true));
                body.Append(generateParagraph(patient.LName, false));
            }
            
            body.Append(generateParagraph("Pathological Number", true));
            body.Append(generateParagraph(patient.PathoNum, false));
            body.Append(generateParagraph("Run Number", true));
            body.Append(generateParagraph(patient.RunNum, false));
            body.Append(generateParagraph("Tumour Site", true));
            body.Append(generateParagraph(patient.TumourSite, false));
            body.Append(generateParagraph("Disease Level", true));
            body.Append(generateParagraph(patient.DiseaseLevel, false));
            body.Append(generateParagraph("Backgroud", true));
            body.Append(generateParagraph(patient.Background, false));
            body.Append(generateParagraph("Previous Treatment", true));
            body.Append(generateParagraph(patient.PrevTreatment, false));
            body.Append(generateParagraph("Current Treatment", true));
            body.Append(generateParagraph(patient.CurrTreatment, false));
            body.Append(generateParagraph("Conclusion", true));
            body.Append(generateParagraph(patient.Conclusion, false));

            //Add related mutation of the patient.
            CreateTable(body, mutationList);

            mainPart.Document.Append(body);
            mainPart.Document.Save();
            myDoc.Close();
        }

        //Create paragraph that contain the text.
        private static Paragraph generateParagraph(string text,bool isHeader)
        {
            Paragraph paragraph = new Paragraph();
            Run run_paragraph = new Run();
            paragraph.Append(run_paragraph);
            //if isHeader=true style the text as header.
            if(isHeader)
            {
                RunProperties runProperties = run_paragraph.AppendChild(new RunProperties());
                Bold bold = new Bold();
                bold.Val = OnOffValue.FromBoolean(true);
                runProperties.AppendChild(bold);
                FontSize fontSize = new FontSize();
                fontSize.Val = "26";
                runProperties.Color = new Color() { Val = "0E6EB8" };
                runProperties.AppendChild(fontSize);
            }
            run_paragraph.AppendChild(new Text(text));
            if (!isHeader)
                run_paragraph.AppendChild(new Break());
            return paragraph;
        }

        //Create table that contain the mutation details and add it to body. 
        private static void CreateTable(Body body, List<Mutation> mutationList)
        {
            Table mutationTable = new Table();
            mutationTable.AppendChild<TableProperties>(getTableProperties());
            TableRow headerRow = new TableRow();
            headerRow.Append(makeCell("Chromosome", 1));
            headerRow.Append(makeCell("Position", 1));
            headerRow.Append(makeCell("Gene Name", 1));
            headerRow.Append(makeCell("Ref", 1));
            headerRow.Append(makeCell("Var", 1));
            headerRow.Append(makeCell("Ref Codon", 1));
            headerRow.Append(makeCell("Var Codon", 1));
            headerRow.Append(makeCell("Mutation", 1));
            mutationTable.Append(headerRow);
            foreach (Mutation m in mutationList)
            {
                int toColor = 0;
                if (!m.CosmicName.Equals("-----"))
                    toColor = 2;
                TableRow row = new TableRow();
                row.Append(makeCell(m.Chrom, toColor));
                row.Append(makeCell(m.Position + "", toColor));
                row.Append(makeCell(m.GeneName, toColor));
                row.Append(makeCell(m.Ref + "", toColor));
                row.Append(makeCell(m.Var + "", toColor));
                row.Append(makeCell(m.RefCodon, toColor));
                row.Append(makeCell(m.VarCodon, toColor));
                row.Append(makeCell(m.PMutationName, toColor));
                mutationTable.Append(row);
            }
            body.Append(mutationTable);
        }

        //create new cell for the table with text and color for background.
         private static TableCell makeCell(string text,int colorType)
        {
            TableCell cell = new TableCell();
            if(colorType!=0)
            {
                string color = "";
                if(colorType==1)
                    color="a9a9a9";
                else if(colorType==2)
                    color="ABCDEF";
                TableCellProperties tcp = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Auto, }
                );
                Shading shading = new Shading()
                    {
                        Color = "auto",
                        Fill = color,
                        Val = ShadingPatternValues.Clear
                    };
                // Add the Shading object to the TableCellProperties object
                tcp.Append(shading);
                cell.Append(tcp);
            }
            cell.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            cell.Append(new Paragraph(new Run(new Text(text))));
            return cell;
        }

        //Generate table properties.
        private static TableProperties getTableProperties()
        {
            return new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new BottomBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new LeftBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new RightBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        }
                    )
                );
        }
    }
}
