using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Download;

namespace DriveFiles
{
    public partial class Form1 : Form 
    {
        drive userDrive = new drive();
        
        public Form1()
        {
            InitializeComponent();

            userDrive.Auth();
            //foreach (var file in userDrive.fileIDList)
            //{
            //    lstOutput.Items.Add(file);



            //}
            int i = 0;
            while (i < userDrive.fileIDList.Count) 
            {
                lstOutput.Items.Add(userDrive.fileNameList[i]);
                i++;
            } 



        }

        private void btnGetItem_Click(object sender, EventArgs e)
        {
            //string id = lstOutput.Items[lstOutput.SelectedIndex].ToString();
            //string baseGetURL = "https://www.googleapis.com/drive/v3/files/";
            //string fullGetURL = baseGetURL + id;
            //Console.WriteLine(fullGetURL);

            //WebRequest wrGETURL;
            //wrGETURL = WebRequest.Create(fullGetURL);

            //Stream objStream;
            //objStream = wrGETURL.GetResponse().GetResponseStream();



        
            var fileId = userDrive.fileIDList[lstOutput.SelectedIndex];
            var request = userDrive.Auth().Files.Get(fileId);
            var stream = new System.IO.MemoryStream();



            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged +=
                (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
            request.Download(stream);
            FileStream downloadFile = new FileStream("C:\\Users\\Jonathan\\source\\repos\\DriveFilesTest\\DriveFiles\\Downloads\\" + 
                userDrive.fileNameList[lstOutput.SelectedIndex], FileMode.Create,FileAccess.Write);
            stream.WriteTo(downloadFile);
            downloadFile.Close();
            stream.Close();

        }
    }
}
