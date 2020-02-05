using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveFiles
{
    class Files
    {
        public List<string> fileName = new List<string>();
        public List<string> fileID = new List<string>();
        public List<string> fileLink = new List<string>();

        public Files()
        {
            fileName = null;
            fileID = null;
            fileLink = null;
        }

        public Files(string theFileName, string theFileID, string theFileLink )
        {
            fileName.Add(theFileName);
            fileID.Add(theFileID);
            fileLink.Add(theFileLink);

        }

    }
}
