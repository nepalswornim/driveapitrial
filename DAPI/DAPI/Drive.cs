using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;

namespace DAPI
{
    public partial class Drive : Form
    {
        public Drive()
        {
            InitializeComponent();
        }


        private void Drive_Load(object sender, EventArgs e)
        {

        }
        public static File createDirectory(DriveService _service, string _title, string _description, string _parent)
        {

            File NewDirectory = null;

            // Create metaData for a new Directory
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List() { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return NewDirectory;
        }
    }
}
