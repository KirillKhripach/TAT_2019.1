using System;

namespace ClassWork7
{
    /// <summary>
    /// Class contains entry point to the program
    /// Downloads files with ftp
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Creates FtpFileDownloader
        /// Downloads all files from server in order and in parallel
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                FtpFileDownloader downloader = new FtpFileDownloader("ftp://ftp.pagat.com/adjogos/", "D:/ForFiles/");
                var fileNames = downloader.GetFileNames();
                TimeDisplayer displayer = new TimeDisplayer();
                displayer.DisplayTime(downloader.DownloadFilesInOrder(fileNames));
                displayer.DisplayTime(downloader.DownloadFilesInParallel(fileNames));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
