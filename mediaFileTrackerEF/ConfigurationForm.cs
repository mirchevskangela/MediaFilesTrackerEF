using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class ConfigurationForm : Form
    {

        #region Cosntructors
        public ConfigurationForm(CameraConfigurationDbService cameraConfigurationDbService)
        {
            InitializeComponent();
            _cameraConfigurationDbService = cameraConfigurationDbService;
            _configurationModificationDetailDbService = new ConfigurationModificationDetailDbService();
        }
        #region Members
        public event EventHandler<ConfigurationsUpdateEventArgs> ConfigurationModifiedNotify;
        NewConfigurationForm _newConfigurationForm;
        private CameraConfigurationDbService _cameraConfigurationDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDetailDbService;

        #endregion
        #endregion
        #region Events
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            _newConfigurationForm = new NewConfigurationForm(_cameraConfigurationDbService);
            _newConfigurationForm.NewConfigurationCreatedNotify += UpdateCombobox;
            FillComboboxWtihCameraConfigurations();
            if (displayExistingCamerasComboBox.Items.Count > 0)
            {
                displayExistingCamerasComboBox.SelectedIndex = 0;
            }
        }
        private void DeleteConfigurationBtn_Click(object sender, EventArgs e)
        {
            var selectedConfigurationObject = (CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
            if (_cameraConfigurationDbService.UpdateDb_DeleteConfiguration(selectedConfigurationObject))
            {

                _configurationModificationDetailDbService.WriteDb_Configuration_Modification(selectedConfigurationObject.CameraName, selectedConfigurationObject.FolderPath, selectedConfigurationObject.VideoExtension, selectedConfigurationObject.PhotoExtension, false, true);
                MessageBox.Show("Configuration Deleted");
                FillComboboxWtihCameraConfigurations();
                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));
            }

        }
        private void UpdateCombobox(object sender, ConfigurationsUpdateEventArgs e)
        {
            if (e.IsCreated)
            {
                FillComboboxWtihCameraConfigurations();

            }
        }
        private void FolderPathsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {

                    if (this.folderPathsDataGridView[0, e.RowIndex].Value != null && this.folderPathsDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        var insertedValue = this.folderPathsDataGridView[0, e.RowIndex].Value.ToString();
                        var buttonCell = (DataGridViewButtonCell)folderPathsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var cameraConfigurationObject = (CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                        if (buttonCell.Value.ToString() == "Delete")
                        {
                            var isFolderPathDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(cameraConfigurationObject, folderPath: insertedValue);
                            if (isFolderPathDeleted)
                            {
                                MessageBox.Show(insertedValue + " deleted successfully");
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));


                            }
                            else
                            {
                                MessageBox.Show("Must contain at least one folder");

                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {

                            if (System.IO.Directory.Exists(insertedValue))
                            {
                                String existingFolderPaths = cameraConfigurationObject.FolderPath;
                                if (existingFolderPaths.ToLower().Contains(insertedValue.ToLower()))
                                {
                                    MessageBox.Show(insertedValue + " is alredy entered");

                                }
                                else
                                {
                                    _configurationModificationDetailDbService.WriteDb_Configuration_Modification(cameraConfigurationObject.CameraName, folderPath: insertedValue);
                                    _cameraConfigurationDbService.UpdateDb_ConfigurationDetails(cameraConfigurationObject, folderPath: insertedValue);
                                    MessageBox.Show(insertedValue + " added successfully");
                                    DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                    OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));


                                }
                            }
                            else
                            {
                                MessageBox.Show("insert a valid path");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void PhotoExtensDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    if (this.photoExtensDataGridView[0, e.RowIndex].Value != null && this.photoExtensDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        // var selectedConfiguration = displayExistingCamerasComboBox.SelectedItem.ToString();
                        var selectedConfigurationObject = (CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                        var buttonCell = (DataGridViewButtonCell)photoExtensDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var insertedData = this.photoExtensDataGridView[0, e.RowIndex].Value.ToString();
                        if (buttonCell.Value.ToString() == "Delete")
                        {

                            var isFolderPathDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(selectedConfigurationObject, photoExtension: insertedData);
                            if (isFolderPathDeleted)
                            {
                                MessageBox.Show(insertedData + " deleted successfully");
                                this.photoExtensDataGridView[0, e.RowIndex].Value = null;
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));



                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {

                            string existingPhotoExtensions = selectedConfigurationObject.PhotoExtension;
                            if (Enum.TryParse((insertedData), out PhotoExtensionsEnum extension))
                            {
                                if (existingPhotoExtensions.Contains(insertedData))
                                {
                                    MessageBox.Show(insertedData + " is alredy entered");
                                }
                                else
                                {
                                    _configurationModificationDetailDbService.WriteDb_Configuration_Modification(selectedConfigurationObject.CameraName, photoExtension: "." + insertedData.ToLower());
                                    _cameraConfigurationDbService.UpdateDb_ConfigurationDetails(selectedConfigurationObject, photoExtension: "." + insertedData.ToLower());
                                    MessageBox.Show(insertedData + " added successfully");
                                    DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                    OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));



                                }
                            }
                            else
                            {
                                MessageBox.Show("insert a valid extension");

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void VideoExtensDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {

                    if (this.videoExtensDataGridView[0, e.RowIndex].Value != null && this.videoExtensDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        var insertedData = this.videoExtensDataGridView[0, e.RowIndex].Value.ToString();
                        var buttonCell = (DataGridViewButtonCell)videoExtensDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        // var selectedConfiguration = displayExistingCamerasComboBox.SelectedItem.ToString();
                        var selectedConfigurationObject = (CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;

                        if (buttonCell.Value.ToString() == "Delete")
                        {
                            var isVideoExtensionDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(selectedConfigurationObject, videoExtension: insertedData);
                            if (isVideoExtensionDeleted)
                            {
                                MessageBox.Show(insertedData + " deleted successfully");

                                this.videoExtensDataGridView[0, e.RowIndex].Value = null;
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));

                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {

                            string existingVideoExtensions = selectedConfigurationObject.VideoExtension;
                            if (Enum.TryParse((insertedData.ToUpper()), out VideoExtensionsEnum extension))

                            {
                                if (existingVideoExtensions.Contains("." + insertedData.ToLower()))
                                {
                                    MessageBox.Show(insertedData + " is alredy entered");
                                }
                                else
                                {
                                    _configurationModificationDetailDbService.WriteDb_Configuration_Modification(cameraName: selectedConfigurationObject.CameraName, videoExtension: "." + insertedData.ToLower());
                                    _cameraConfigurationDbService.UpdateDb_ConfigurationDetails(selectedConfigurationObject, videoExtension: "." + insertedData.ToLower());
                                    MessageBox.Show(insertedData + " added successfully");
                                    DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                    OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));



                                }
                            }
                            else
                            {
                                MessageBox.Show("insert a valid extension");
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DisplayExistingCamerasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(displayExistingCamerasComboBox.GetItemText(displayExistingCamerasComboBox.SelectedItem)))
            {
                var selectedConfigurationObject = (CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                if (selectedConfigurationObject != null)
                {
                    List<string> selectedCameraConfigFolderPathsList = selectedConfigurationObject.FolderPath.Split(',').ToList();
                    List<string> selectedCameraConfigVideoExtensList = selectedConfigurationObject.VideoExtension.Split(' ').ToList();
                    List<string> selectedCameraConfigPhotoExtensList = selectedConfigurationObject.PhotoExtension.Split(' ').ToList();
                    FillDataGridView(selectedCameraConfigVideoExtensList, videoExtensDataGridView, "Video Extensions", 100);
                    FillDataGridView(selectedCameraConfigFolderPathsList, folderPathsDataGridView, "Folder Paths", 354);
                    FillDataGridView(selectedCameraConfigPhotoExtensList, photoExtensDataGridView, "Photo Extensions", 100);
                }
            }
        }

        protected virtual void OnConfigurationDeleted(ConfigurationsUpdateEventArgs e)
        {
            ConfigurationModifiedNotify?.Invoke(this, e);

        }
        #endregion
        public void FillComboboxWtihCameraConfigurations()
        {
            displayExistingCamerasComboBox.Items.Clear();
            var configurationObjects = _cameraConfigurationDbService.ReadDb_AllCameraConfigurations();
            configurationObjects.ForEach(c => displayExistingCamerasComboBox.Items.Add(c));
            displayExistingCamerasComboBox.DisplayMember = "CameraName";
            if (displayExistingCamerasComboBox.Items.Count > 0)
            {
                displayExistingCamerasComboBox.SelectedIndex = 0;
            }
            else
            {
                folderPathsDataGridView.Rows.Clear();
                photoExtensDataGridView.Rows.Clear();
                videoExtensDataGridView.Rows.Clear();
            }


        }
        public void FillDataGridView(List<string> list, DataGridView dataGridViewName, string columnName, int columnWidth)
        {
            if (dataGridViewName.Rows.Count > 0)
            {
                dataGridViewName.Rows.Clear();

            }
            dataGridViewName.ReadOnly = false;
            dataGridViewName.AllowUserToAddRows = true;
            dataGridViewName.ColumnCount = 2;
            dataGridViewName.Columns[0].Name = columnName;
            dataGridViewName.Columns[0].Width = columnWidth;
            dataGridViewName.Rows.Clear();
            dataGridViewName.RowCount = list.Count + 1;

            if (list.Count > 0)
            {


                for (int i = 0; i < list.Count; i++)
                {
                    dataGridViewName.Rows[i].Cells[columnName].Value = list.ElementAt(i);

                }

                foreach (DataGridViewRow row in dataGridViewName.Rows)
                {
                    DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell();
                    deleteButtonCell.Value = "Delete";
                    row.Cells[1] = deleteButtonCell;
                }

                // Add a button to the second column of the last row
                DataGridViewButtonCell addButtonCell = new DataGridViewButtonCell();
                addButtonCell.Value = "Add";
                dataGridViewName.Rows[dataGridViewName.Rows.Count - 1].Cells[1] = addButtonCell;

            }

        }

    }
}
