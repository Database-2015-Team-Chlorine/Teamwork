namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using MediaMonitoringSystem.Data.MSSQL;

    public class Pdf
    {
        public void GetPdf()
        {
            var db = new MediaMonitoringSystemData();

            var groupsOfThemes = db.Themes.All()
                .Select(t => new
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



            var doc = new Document();
            var stream = new FileStream("Test.pdf", FileMode.Create);

            using (PdfWriter.GetInstance(doc, stream))
            {
                doc.Open();

                var table = new PdfPTable(1);
                table.AddCell("Themes");
                doc.Add(Chunk.NEWLINE);


                foreach (var gr in groupsOfThemes)
                {
                    table.AddCell(gr.Key.ToString());
                    doc.Add(Chunk.NEWLINE);

                    Console.WriteLine(gr.Key);
                    var innerTable = new PdfPTable(5);

                    innerTable.AddCell("Theme");
                    innerTable.AddCell("Client Name");
                    innerTable.AddCell("Count Of Medias");
                    innerTable.AddCell("Price");
                    innerTable.AddCell("Until");


                    foreach (var item in gr)
                    {
                        innerTable.AddCell(item.Name.ToString());
                        innerTable.AddCell(item.Client.ToString());
                        innerTable.AddCell(item.CountMedias.ToString());
                        innerTable.AddCell(item.Price.ToString());
                        innerTable.AddCell(item.EndDate.ToString());

                        doc.Add(Chunk.NEWLINE);
                        Console.WriteLine(item.Client);
                    }
                    table.AddCell(innerTable);

                }



                doc.Add(table);

                doc.Close();
            }




        }
    }
}
