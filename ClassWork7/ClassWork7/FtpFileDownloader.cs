using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ClassWork7
{
    /// <summary>
    /// Class for downloading files with ftp
    /// </summary>
    class FtpFileDownloader
    {
        public string ServerPath { get; private set; }
        public string DestinationPath { get; private set; }

        /// <summary>
        /// Constructor initializes properties
        /// Creates directory if does not exists
        /// </summary>
        /// <param name="serverPath">Path of download server</param>
        /// <param name="destinationPath">Path of directory for downloading</param>
        public FtpFileDownloader(string serverPath, string destinationPath)
        {
            this.ServerPath = serverPath;
            this.DestinationPath = destinationPath;
            DirectoryInfo directory = new DirectoryInfo(this.DestinationPath);

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        /// <summary>
        /// Returns file names from current server
        /// </summary>
        /// <returns>List of file names</returns>
        public List<string> GetFileNames()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.ServerPath);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            List<string> fileNames = new List<string>();
            string fileName = streamReader.ReadLine();

            while (fileName != null)
            {
                fileNames.Add(fileName);
                fileName = streamReader.ReadLine();
            }

            streamReader.Close();
            responseStream.Close();
            response.Close();

            return fileNames;
        }

        /// <summary>
        /// Downloads file from current server
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public void DownloadFile(object fileName)
        {
            string destinationPath = this.DestinationPath + fileName;
            Console.WriteLine($"Start {fileName} downloading");
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.ServerPath + fileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream fileStream = new FileStream(destinationPath, FileMode.Create);
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, size);
            }

            fileStream.Close();
            responseStream.Close();
            response.Close();
            Console.WriteLine($"Finish {fileName} downloading");
        }

        /// <summary>
        /// Downloads all files from current server in order
        /// </summary>
        /// <param name="fileNames">List of file names</param>
        /// <returns>Time span of downloading</returns>
        public TimeSpan DownloadFilesInOrder(List<string> fileNames)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string fileName in fileNames)
            {
                this.DownloadFile(fileName);
            }

            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Console.WriteLine("All files downloaded");

            return timeSpan;
        }

        /// <summary>
        /// Downloads all files from current server in parallel
        /// </summary>
        /// <param name="fileNames">List of file names</param>
        /// <returns>Time span of downloading</returns>
        public TimeSpan DownloadFilesInParallel(List<string> fileNames)
        {
            List<Task> tasks = new List<Task>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (string fileName in fileNames)
            {
                tasks.Add(Task.Factory.StartNew(this.DownloadFile, fileName));
            }

            Task.WaitAll(tasks.ToArray());
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Console.WriteLine("All files downloaded");

            return timeSpan;
        }
    }
}
