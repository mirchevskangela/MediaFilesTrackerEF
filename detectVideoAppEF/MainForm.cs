using ClassLibrary.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class MainForm : Form
    {
        #region Members
        private CameraConfigurationDbService _cameraConfigurationDbService;
        //  private NewConfigurationForm _newConfigurationForm;
        private ConfigurationForm _configurationForm;
        public List<FileMonitoringService> MyProperty = new List<FileMonitoringService>();


        #endregion

        #region Constructors
        public MainForm()
        {

            InitializeComponent();
            _cameraConfigurationDbService = new CameraConfigurationDbService();
            // _newConfigurationForm = new NewConfigurationForm();
            _configurationForm = new ConfigurationForm(_cameraConfigurationDbService);
            //_newConfigurationForm.NewConfigurationCreatedNotify += UpdateAvailablesCamera_NewConfigurationAdded;
            _configurationForm.ConfigurationModifiedNotify += UpdateAvailablesCamera_NewConfigurationAdded;

        }

        #endregion

        #region Events
        public void CreatedFile(object sender, MonitoringDetailsEventArgs e)
        {

            MonitoringDetailsDataGridView.Invoke(new Action(delegate ()
            {
                int rowId = MonitoringDetailsDataGridView.Rows.Add();

                DataGridViewRow row = MonitoringDetailsDataGridView.Rows[rowId];

                row.Cells[0].Value = e.Camera;
                row.Cells[1].Value = e.Action;
                row.Cells[2].Value = e.Path;
                row.Cells[3].Value = e.Name;
                row.Cells[4].Value = e.TimeStamp.ToString();

            }));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

            PopulateCheckListBoxWithActiveCameras();
            availableCamerasCheckListBox.Visible = false;
            MonitoringDetailsDataGridView.Visible = false;
            monitoringDataGroupBox.Visible = false;
            statusRunning.Visible = false;
            statusStopped.Visible = true;
            MonitoringDetailsDataGridView.ColumnCount = 5;
            MonitoringDetailsDataGridView.Columns[0].HeaderText = "Camera";
            MonitoringDetailsDataGridView.Columns[1].HeaderText = "Action";
            MonitoringDetailsDataGridView.Columns[2].HeaderText = "Folder Path";
            MonitoringDetailsDataGridView.Columns[3].HeaderText = "File Name";
            MonitoringDetailsDataGridView.Columns[4].HeaderText = "Timestamp";

            MonitoringDetailsDataGridView.Columns[0].Width = 150;
            MonitoringDetailsDataGridView.Columns[1].Width = 150;
            MonitoringDetailsDataGridView.Columns[2].Width = 220;
            MonitoringDetailsDataGridView.Columns[3].Width = 150;
            MonitoringDetailsDataGridView.Columns[4].Width = 150;

        }
        private void StartMonitoring_Click(object sender, EventArgs e)
        {
            MonitoringDetailsDataGridView.Visible = true;
            monitoringDataGroupBox.Visible = true;


            if (availableCamerasCheckListBox.CheckedItems.Count <= 0)
            {
                MonitoringDetailsDataGridView.Visible = false;
                monitoringDataGroupBox.Visible = true;

                MessageBox.Show("please choose at least one camera to start monitoring");

            }

            foreach (CameraConfiguration item in availableCamerasCheckListBox.CheckedItems)
            {

                //_fileMonitoringService = new FileMonitoringService(item);
                FileMonitoringService fileMonitoringService = new FileMonitoringService(item);
                MyProperty.Add(fileMonitoringService);

                fileMonitoringService.MonitoringDetailNotify += CreatedFile;
                if (item.Active == false)
                {
                    _cameraConfigurationDbService.UpdateDb_SetActiveCamera_Configuration((CameraConfiguration)item);

                }

                statusRunning.Visible = true;
                statusStopped.Visible = false;
            }
        }
        private void EndMonitoring_Click(object sender, EventArgs e)
        {
            MonitoringDetailsDataGridView.Visible = false;
            monitoringDataGroupBox.Visible = false;


            statusRunning.Visible = false;
            statusStopped.Visible = true;
            //  _fileMonitoringService.StopMonitoring();
            foreach (FileMonitoringService item in MyProperty)
            {
                item.StopMonitoring();

            }
            MyProperty.Clear();
            for (int i = 0; i < availableCamerasCheckListBox.Items.Count; i++)
            {
                availableCamerasCheckListBox.SetItemChecked(i, false);
            }

        }
        private void AvailableCamerasBtn_Click(object sender, EventArgs e)
        {
            if (availableCamerasCheckListBox.Visible)
            {
                availableCamerasCheckListBox.Visible = false;

                availableCamerasBtn.BackColor = SystemColors.Control;

            }
            else
            {
                availableCamerasCheckListBox.Visible = true;
                availableCamerasBtn.BackColor = Color.White;
            }
        }
        #endregion
        private void UpdateAvailablesCamera_NewConfigurationAdded(object sender, ConfigurationsUpdateEventArgs e)
        {
            if (e.IsCreated)
            {
                PopulateCheckListBoxWithActiveCameras();


            }
        }

        /// <summary>
        /// Sets active cameras in checkboxlist as checked by default
        /// </summary>


        /// <summary>
        /// Adds camera names to checkboxlist from database
        /// </summary>
        #region Navigation Bar Events
        private void AddNewConfigurationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewConfigurationForm newConfigurationForm = new NewConfigurationForm(_cameraConfigurationDbService);
            newConfigurationForm.NewConfigurationCreatedNotify += UpdateAvailablesCamera_NewConfigurationAdded;
            newConfigurationForm.ShowDialog();
        }
        private void ModifyConfigurationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _configurationForm.ShowDialog();
   
        }
        private void ServerConfigurationFormStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerConfigurationForm serverConfigurationForm = new ServerConfigurationForm();
            serverConfigurationForm.ShowDialog();
        }
        private void HistoryFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.ShowDialog();

        }
        #endregion
        private void PopulateCheckListBoxWithActiveCameras()
        {
            availableCamerasCheckListBox.Items.Clear();

            var cameraConfigurationsObjects = _cameraConfigurationDbService.ReadDb_AllCameraConfigurations();
            int i = 0;

            cameraConfigurationsObjects.ForEach(config =>
            {
                availableCamerasCheckListBox.Items.Insert(i, config);
                if (config.Active == true)
                {
                    availableCamerasCheckListBox.SetItemChecked(i, true);
                }
                i++;
            });

        }

    }
}
