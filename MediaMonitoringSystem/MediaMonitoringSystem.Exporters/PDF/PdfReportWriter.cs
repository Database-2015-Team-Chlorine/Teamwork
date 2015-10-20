namespace MediaMonitoringSystem.Exporters.Pdf
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using MediaMonitoringSystem.Data.Sql;
    using MediaMonitoringSystem.Exporters.Contracts;
    using MediaMonitoringSystem.Models.Pdf;

    public class PdfReportWriter : IDataWriter
    {
        private const string PathForPdfFile = "../../../ExportedFiles/PDFs/Themes.pdf";

        public void Generate()
        {
            var doc = new Document();
            var stream = new FileStream(PdfReportWriter.PathForPdfFile, FileMode.Create);

            using (PdfWriter.GetInstance(doc, stream))
            {
                doc.Open();

                var table = new PdfPTable(5);

                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var headerPhrase = new Phrase();

                headerPhrase.Add(new Chunk("Themes", boldFont));

                var headerCell = new PdfPCell(headerPhrase);

                headerCell.HorizontalAlignment = 1;

                headerCell.Colspan = 5;
                headerCell.BackgroundColor = new BaseColor(232, 232, 232);
                headerCell.Border = 1;
                table.AddCell(headerCell);

                foreach (var group in this.GetThemeData())
                {
                    var date = new PdfPCell(new Phrase("Date: " + group.Key.ToString("MMMM dd, yyyy")));
                    date.Colspan = 5;
                    table.AddCell(date);

                    table.AddCell(new Phrase(new Chunk("Name", boldFont)));
                    table.AddCell(new Phrase(new Chunk("Client Name", boldFont)));
                    table.AddCell(new Phrase(new Chunk("Count Of Medias", boldFont)));
                    table.AddCell(new Phrase(new Chunk("End date", boldFont)));
                    table.AddCell(new Phrase(new Chunk("Price", boldFont)));

                    decimal sum = 0.0M;

                    foreach (var theme in group)
                    {
                        table.AddCell(theme.Name);
                        table.AddCell(theme.Client);
                        table.AddCell(theme.CountMedias.ToString());
                        table.AddCell(theme.EndDate.ToString());
                        table.AddCell(theme.Price.ToString());

                        sum += theme.Price;
                    }

                    var sumText = new PdfPCell(new Phrase("SUM: "));
                    sumText.Colspan = 4;

                    table.AddCell(sumText);
                    var footer = new PdfPCell(new Phrase(new Chunk(sum.ToString(), boldFont)));

                    table.AddCell(footer);
                }

                doc.Add(table);
                doc.Close();
            }
            Console.WriteLine("PDF for themes generated!");
        }

        private IList<IGrouping<DateTime, PdfModel>> GetThemeData()
        {
            var db = new MediaMonitoringSystemData();
            var groups = db.Themes
                    .All()
                    .Select(t => new PdfModel
                    {
                        Name = t.Name,
                        Client = t.Client.Name,
                        CountMedias = t.Package.CountMedias,
                        StartDate = t.StartDate,
                        EndDate = t.EndDate,
                        Price = t.Package.PricePerMonth
                    })
                    .OrderBy(n => n.Name)
                    .GroupBy(gr => gr.StartDate)
                    .ToList();

            return groups;
        }
    }
}