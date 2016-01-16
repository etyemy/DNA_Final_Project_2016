using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.FileHendlers
{
    /*
     * XLSExportHandler class.
     * Main purpose - export mutation details to XLSX file.
     */
    class XLSExportHandler
    {
        //Main class function, export the mutationList to XLSX file, sets file name to testName.
        public static void saveXLS(String testName, List<Mutation> mutationList)
        {
            SpreadsheetDocument xl = null;
            string fullPath = Properties.Settings.Default.ExportSavePath + @"\" + testName;
            fullPath += ".xlsx";
            try
            {
                xl = SpreadsheetDocument.Create(fullPath, SpreadsheetDocumentType.Workbook);
            }
            catch (IOException )
            {
                throw ;
            }
            WorkbookPart wbp = xl.AddWorkbookPart();
            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            Workbook wb = new Workbook();
            FileVersion fv = new FileVersion();
            fv.ApplicationName = "Microsoft Office Excel";
            Worksheet ws = new Worksheet();
            SheetData sd = new SheetData();
            WorkbookStylesPart wbsp = wbp.AddNewPart<WorkbookStylesPart>();
            wbsp.Stylesheet = GenerateStyleSheet();
            wbsp.Stylesheet.Save();

            //save the longest width for each column.
            string[] longestWordPerColumn = new string[12];

            int k = 0;

            //create and add header row.
            Row headerRow = new Row();
            foreach (string s in Mutation.getHeaderForExport())
            {
                Cell cell = new Cell();
                cell.DataType = CellValues.String;
                cell.CellValue = new CellValue(s);
                cell.StyleIndex = 1;
                headerRow.AppendChild(cell);
                longestWordPerColumn[k] = s;
                k++;
            }
            sd.AppendChild(headerRow);

            //create and add rows for each mutation.
            foreach (Mutation m in mutationList)
            {
                Row newRow = new Row();
                string[] infoString = m.getInfoForExport();
                for (int i = 0; i < infoString.Length; i++)
                {
                    Cell cell1 = new Cell();
                    if (i == 1)
                        cell1.DataType = CellValues.Number;
                    else
                        cell1.DataType = CellValues.String;
                    cell1.CellValue = new CellValue(infoString[i]);
                    if (!m.CosmicName.Equals("-----"))
                        cell1.StyleIndex = 2;
                    else
                        cell1.StyleIndex = 3;
                    newRow.AppendChild(cell1);
                    if (longestWordPerColumn[i].Length < infoString[i].Length)
                        longestWordPerColumn[i] = infoString[i];
                }
                sd.AppendChild(newRow);
            }

            //Sets the column width to longest width for each column.
            Columns columns = new Columns();
            for (int i = 0; i < 12; i++)
            {
                columns.Append(CreateColumnData((UInt32)i + 1, (UInt32)i + 1, GetWidth("Calibri", 11, longestWordPerColumn[i])));
            }
            ws.Append(columns);


            ws.Append(sd);
            wsp.Worksheet = ws;
            wsp.Worksheet.Save();
            Sheets sheets = new Sheets();
            Sheet sheet = new Sheet();
            sheet.Name = "Sheet1";
            sheet.SheetId = 1;
            sheet.Id = wbp.GetIdOfPart(wsp);
            sheets.Append(sheet);
            wb.Append(fv);
            wb.Append(sheets);
            xl.WorkbookPart.Workbook = wb;
            xl.WorkbookPart.Workbook.Save();
            xl.Close();
        }

        //Create Stylesheet 
        private static Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                // Index 0 - The default font.
                    new Font(
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                // Index 1 - Header.
                   new Font(
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                // Index 0 - Regular row.
                    new Fill(
                        new PatternFill() { PatternType = PatternValues.None }),
                // Index 1 - Header row
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "A9A9A9" } }
                        ) { PatternType = PatternValues.Solid }),
                // Index 2 - Important Mutation row .
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "ABCDEF" } }
                        ) { PatternType = PatternValues.Solid }),
                // Index 3 - Regular Mutation row .
                    new Fill(
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF" } }
                        ) { PatternType = PatternValues.Solid })
                ),
                new Borders(
                // Index 0 - The default border.
                    new Border(
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
            new Border(
                new LeftBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new RightBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new TopBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new BottomBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 0, BorderId = 0 },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 1, FillId = 1, BorderId = 1, ApplyAlignment = true, ApplyBorder = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true, ApplyBorder = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 3, BorderId = 1, ApplyAlignment = true, ApplyBorder = true }
                )
            ); 
        }
        //create column with custom width.
        private static Column CreateColumnData(UInt32 StartColumnIndex, UInt32 EndColumnIndex, double ColumnWidth)
        {
            Column column;
            column = new Column();
            column.Min = StartColumnIndex;
            column.Max = EndColumnIndex;
            column.Width = ColumnWidth;
            column.CustomWidth = true;
            return column;
        }

        //get width of the text in the cell, use for fitting the cells width with the text.
        private static double GetWidth(string font, int fontSize, string text)
        {
            System.Drawing.Font stringFont = new System.Drawing.Font(font, fontSize);
            System.Drawing.Size textSize = TextRenderer.MeasureText(text, stringFont);
            double width = (double)(((textSize.Width / (double)7) * 256) - (128 / 7)) / 256;
            width = (double)decimal.Round((decimal)width + 0.2M, 2);
            return width;
        }
    }
}
