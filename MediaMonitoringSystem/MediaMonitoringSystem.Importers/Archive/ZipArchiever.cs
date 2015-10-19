namespace MediaMonitoringSystem.Importers.Archive
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediaMonitoringSystem.Importers.Contracts;

    public class ZipArchiever : IArchiever
    {
        public void SendToArchieve(string rootFolder, string zipPath)
        {
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(rootFolder, zipPath);
        }

        public void UnArchieve(string zipPath, string exportFolder)
        {
            if (Directory.Exists(exportFolder))
            {
                Directory.Delete(exportFolder, true);
            }

            Directory.CreateDirectory(exportFolder);

            ZipFile.ExtractToDirectory(zipPath, exportFolder + Path.GetFileNameWithoutExtension(zipPath));
            Console.WriteLine("extracted");
        }
    }
}
