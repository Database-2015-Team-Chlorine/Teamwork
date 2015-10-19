namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using MediaMonitoringSystem.Data.MSSQL;
    using MediaMonitoringSystem.Models.PDF;

    public static class Pdf
    {
        public static void GeneratePdf(IList<IGrouping<DateTime, Theme>> groupsOfThemes, string path)
        {
            var doc = new Document();
            var stream = new FileStream(path, FileMode.Create);

            using (PdfWriter.GetInstance(doc, stream))
            {
                doc.Open();

                var table = new PdfPTable(1);
                table.AddCell("Themes");

                foreach (var group in groupsOfThemes)
                {
                    table.AddCell(group.Key.ToString());

                    var innerTable = new PdfPTable(5);

                    innerTable.AddCell("Theme");
                    innerTable.AddCell("Client Name");
                    innerTable.AddCell("Count Of Medias");
                    innerTable.AddCell("End date");
                    innerTable.AddCell("Price");

                    decimal sum = 0.0M;

                    foreach (var theme in group)
                    {
                        innerTable.AddCell(theme.Name.ToString());
                        innerTable.AddCell(theme.Client.ToString());
                        innerTable.AddCell(theme.CountMedias.ToString());
                        innerTable.AddCell(theme.EndDate.ToString());
                        innerTable.AddCell(theme.Price.ToString());
                        
                        sum += theme.Price;
                    }

                    var tableSum = new PdfPTable(new float[] { 75, 25 });
                    tableSum.AddCell("Sum:");
                    tableSum.AddCell(sum.ToString());

                    table.AddCell(innerTable);
                    table.AddCell(tableSum);

                }

                doc.Add(table);
                doc.Close();
            }
        }
    }
}
