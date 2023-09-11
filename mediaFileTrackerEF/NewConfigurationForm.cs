using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class NewConfigurationForm : Form
    {
        #region Members
        public event EventHandler<ConfigurationsUpdateEventArgs> NewConfigurationCreatedNotify;
        private CameraConfigurationDbService _cameraConfigurationDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDetailDbService;
        List<string> VideoExtenList = new List<string>();
        List<string> PhotoExtenList = new List<string>();
        List<string> FolderPathList = new List<string>();
        #endregion

        #region Cosntructors
        public NewConfigurationForm(CameraConfigurationDbService cameraConfigurationDbService)
        {
            InitializeComponent();
            _cameraConfigurationDbService = cameraConfigurationDbService;
            _configurationModificationDetailDbService = new ConfigurationModificationDetailDbService();
        }
        #endregion

        #region Events

        // browse folder button
        private void BrowseFolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPathTxtBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Adds new configuration to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveConfiguration_Click(object sender, EventArgs e)
        {


            if (cameraNameTxtBox.Text == "")
            {
                MessageBox.Show("insert camera");
            }
            else if (FolderPathList.Count == 0)
            {
                MessageBox.Show("Must contain at least one folder!");
            }
            if (_cameraConfigurationDbService.ReadFromDb_Configuration_InDetail(cameraNameTxtBox.Text.ToString()).name.ToLower() == cameraNameTxtBox.Text.ToString().ToLower())
            {
                MessageBox.Show(cameraNameTxtBox.Text + " is alredy entered, please insert another camera name");

            }
            else
            {
                try
                {
                    CameraConfiguration cameraConfiguration = new CameraConfiguration();
                    cameraConfiguration.CameraName = cameraNameTxtBox.Text;
                    cameraConfiguration.FolderPath = string.Join(",", FolderPathList);
                    cameraConfiguration.VideoExtension = string.Join(" ", VideoExtenList);
                    cameraConfiguration.PhotoExtension = string.Join(" ", PhotoExtenList);
                    cameraConfiguration.Timestamp = DateTime.Now;
                    _cameraConfigurationDbService.WriteDb_AddCameraConfiguration(cameraConfiguration);
                    _configurationModificationDetailDbService.WriteDb_Configuration_Modification(cameraNameTxtBox.Text, string.Join(",", FolderPathList), string.Join(" ", VideoExtenList), string.Join(" ", PhotoExtenList), true);
                    OnNewConfigurationCreated(new ConfigurationsUpdateEventArgs(true));

                    VideoExtenList.Clear();
                    PhotoExtenList.Clear();
                    FolderPathList.Clear();
                    photoExtListView.Items.Clear();
                    videoExtListView.Items.Clear();
                    pathListView.Items.Clear();
                    cameraNameTxtBox.Text = "";
                    NewConfigurationForm_Load(sender, e);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //call event
                MessageBox.Show("New Configuration Added");

            }
        }
        private void FolderPathTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            AddFolderPath();
        }

        private void AddVideoExtenBtn_Click(object sender, EventArgs e)
        {
            AddVideoExtension();
        }
        private void AddPhotoExtenBtn_Click(object sender, EventArgs e)
        {
            AddPhotoExtension();
        }
        private void AddFolderPathBtn_Click(object sender, EventArgs e)
        {
            AddFolderPath();
        }
        protected virtual void OnNewConfigurationCreated(ConfigurationsUpdateEventArgs e)
        {
            NewConfigurationCreatedNotify?.Invoke(this, e);

        }
        private void NewConfigurationForm_Load(object sender, EventArgs e)
        {
            cameraNameWarningLabel.Visible = false;

        }
        private void CameraNameTxtBox_TextChanged(object sender, EventArgs e)
        {

            if (cameraNameTxtBox.Text.ToString() != "" && _cameraConfigurationDbService.ReadFromDb_Configuration_InDetail(cameraNameTxtBox.Text.ToString()).name.ToLower() == cameraNameTxtBox.Text.ToString().ToLower())
            {
                cameraNameWarningLabel.Visible = true;

            }
            else if (cameraNameTxtBox.Text.ToString() == " ")
            {
                cameraNameWarningLabel.Visible = false;

            }
            else
            {
                cameraNameWarningLabel.Visible = false;

            }
        }
        #endregion

        /// <summary>
        /// Adds the folder path value provided by user to the list only if the path is valid and doesn't already exist in the list.
        /// </summary>
        public void AddFolderPath()
        {
            if (Directory.Exists(folderPathTxtBox.Text))
            {
                if (!FolderPathList.Contains(folderPathTxtBox.Text.ToLower()))
                {
                    ListViewItem lvi = new ListViewItem(folderPathTxtBox.Text);
                    pathListView.Items.Add(lvi);
                    FolderPathList.Add(folderPathTxtBox.Text.ToLower().Trim());
                    folderPathTxtBox.Text = "";
                }
                else
                {
                    MessageBox.Show(folderPathTxtBox.Text + " was alredy entered");
                    folderPathTxtBox.Text = "";

                }

            }
            else
            {
                MessageBox.Show(folderPathTxtBox.Text + " doesn't exist");

            }
        }

        /// <summary>
        ///  Adds the video extension provided by the user to a list only if the extension is valid and doesn't already exist in the list
        /// </summary>
        public void AddVideoExtension()
        {
            if (addVideoExteTxtBox.Text != "")
            {
                VideoExtensionsEnum extension;
                //  if (FileService.IsVideo(addVideoExteTxtBox.Text.ToLower()))

                if (Enum.TryParse((addVideoExteTxtBox.Text.ToUpper()), out extension))
                {

                    if (!VideoExtenList.Contains(addVideoExteTxtBox.Text.ToLower()))
                    {
                        ListViewItem lvi = new ListViewItem(extension.ToString().ToLower());
                        videoExtListView.Items.Add(lvi);
                        VideoExtenList.Add("." + extension.ToString().ToLower());
                        addVideoExteTxtBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(addVideoExteTxtBox.Text + " was alredy entered");
                        addVideoExteTxtBox.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("insert valid video extension");
                }
            }



        }
        /// <summary>
        ///  Adds the photo extension provided by the user to a list only if the extension is valid and doesn't already exist in the list
        /// </summary>
        public void AddPhotoExtension()
        {

            if (addPhotoExteTxtBox.Text != "")
            {
                PhotoExtensionsEnum extension;
                if (Enum.TryParse((addPhotoExteTxtBox.Text.ToLower()), out extension))

                // if (FileService.IsImage(addPhotoExteTxtBox.Text.ToLower()))
                {
                    if (!PhotoExtenList.Contains("." + addPhotoExteTxtBox.Text.ToLower()))
                    {
                        ListViewItem lvi = new ListViewItem(extension.ToString().ToLower());
                        photoExtListView.Items.Add(lvi);
                        PhotoExtenList.Add("." + extension.ToString().ToLower());
                        addPhotoExteTxtBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(addPhotoExteTxtBox.Text + " was alredy entered");
                        addPhotoExteTxtBox.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("insert valid photo extension");
                }
            }



        }

    }
}


