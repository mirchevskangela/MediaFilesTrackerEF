using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class HistoryForm : Form
    {
        #region members

        private MonitoringDetailDbService _fileMonitorDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDbService;
        #endregion
        #region constructor
        public HistoryForm()
        {
            InitializeComponent();
            _fileMonitorDbService = new MonitoringDetailDbService();
            _configurationModificationDbService = new ConfigurationModificationDetailDbService();

            chooseHistoryComboBox.SelectedIndex = 0;

        }
        #endregion

        #region Members
        private void GetHistoryBtn_Click(object sender, EventArgs e)
        {
            if (displayHistoryDataGridView.Rows.Count > 0)
            {
                displayHistoryDataGridView.DataSource = null;
                displayHistoryDataGridView.Rows.Clear();

            }
            if (displayHistoryDataGridView.Columns.Contains("openFile"))
            {
                displayHistoryDataGridView.Columns.Remove("openFile");
            }



            displayHistoryDataGridView.ReadOnly = true;

            if (chooseHistoryComboBox.Text == "")
            {
                MessageBox.Show("Select History");
            }
            else
            {

                if (!string.IsNullOrEmpty(chooseHistoryComboBox.GetItemText(chooseHistoryComboBox.SelectedItem)) && (String)chooseHistoryComboBox.SelectedItem == "Monitoring Report")
                {
                    try
                    {
                        if (showVideosCheckBox.Checked && showPhotosCheckBox.Checked)
                        {
                            var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), true, true);

                            var closestMonitoringDetailToInputFromDateTimePicker = _fileMonitorDbService.ReadFromDb_ClosestMonitoringDetail(DateTime.Parse(fromDateTimePicker.Text), true);

                            if (closestMonitoringDetailToInputFromDateTimePicker != null)
                            {



                                bool containsItem = monitoringReportBetweenTwoDatesList.Any(item => item.FileName == closestMonitoringDetailToInputFromDateTimePicker.FileName);
                                if (closestMonitoringDetailToInputFromDateTimePicker != null && !containsItem
                                   && DateTimeCalculator.IsBetweenTwoDates(date: (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp, fromDate: DateTime.Parse(fromDateTimePicker.Text), toDate: DateTime.Parse(toDateTimePicker.Text))
                                   && DateTime.Parse(fromDateTimePicker.Text) >= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.StartTimestamp && DateTime.Parse(fromDateTimePicker.Text) <= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp)
                                {

                                    monitoringReportBetweenTwoDatesList.Add(closestMonitoringDetailToInputFromDateTimePicker);

                                }

                            }

                            displayHistoryDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                        }
                        if (showPhotosCheckBox.Checked && !showVideosCheckBox.Checked)
                        {
                            var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), false, true);

                            displayHistoryDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                        }
                        if (!showPhotosCheckBox.Checked && showVideosCheckBox.Checked)
                        {
                            var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), true, false);

                            var closestMonitoringDetailToInputFromDateTimePicker = _fileMonitorDbService.ReadFromDb_ClosestMonitoringDetail(DateTime.Parse(fromDateTimePicker.Text), true);

                            if (closestMonitoringDetailToInputFromDateTimePicker != null)
                            {



                                bool containsItem = monitoringReportBetweenTwoDatesList.Any(item => item.FileName == closestMonitoringDetailToInputFromDateTimePicker.FileName);
                                if (closestMonitoringDetailToInputFromDateTimePicker != null && !containsItem
                                   && DateTimeCalculator.IsBetweenTwoDates(date: (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp, fromDate: DateTime.Parse(fromDateTimePicker.Text), toDate: DateTime.Parse(toDateTimePicker.Text))
                                   && DateTime.Parse(fromDateTimePicker.Text) >= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.StartTimestamp && DateTime.Parse(fromDateTimePicker.Text) <= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp)
                                {

                                    monitoringReportBetweenTwoDatesList.Add(closestMonitoringDetailToInputFromDateTimePicker);

                                }

                            }





                            displayHistoryDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                        }




                        //Add the column to the DataGridView
                        if (!displayHistoryDataGridView.Columns.Contains("openFile"))
                        {
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            btn.HeaderText = "media_files";
                            btn.Name = "openFile";
                            btn.Text = "open";
                            btn.UseColumnTextForButtonValue = true;
                            displayHistoryDataGridView.Columns.Add(btn);
                        }
                        displayHistoryDataGridView.Columns[0].Width = 130;

                        displayHistoryDataGridView.Columns[1].Width = 80;
                        displayHistoryDataGridView.Columns[2].Width = 400;
                        displayHistoryDataGridView.Columns[3].Width = 120;
                        displayHistoryDataGridView.Columns[4].Width = 120;
                        displayHistoryDataGridView.Columns[5].Width = 120;
                        displayHistoryDataGridView.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                        displayHistoryDataGridView.Columns[5].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                }

                if (!string.IsNullOrEmpty(chooseHistoryComboBox.GetItemText(chooseHistoryComboBox.SelectedItem)) && (String)chooseHistoryComboBox.SelectedItem == "Camera Configuration")
                {
                    mediaFilesgroupBox.Visible = false;
                    showVideosCheckBox.Visible = false;
                    showPhotosCheckBox.Visible = false;
                    var modifiedConfigurationsList = _configurationModificationDbService.ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text));


                    displayHistoryDataGridView.DataSource = modifiedConfigurationsList;

                    displayHistoryDataGridView.Columns[0].Width = 130;

                    displayHistoryDataGridView.Columns[1].Width = 490;
                    displayHistoryDataGridView.Columns[2].Width = 100;
                    displayHistoryDataGridView.Columns[3].Width = 120;
                    displayHistoryDataGridView.Columns[4].Width = 120;
                    displayHistoryDataGridView.Columns[5].Width = 120;



                }
            }
        }

        private void DisplayHistoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {

                try
                {
                    //getting a specific file path from the table
                    var filePath = this.displayHistoryDataGridView[2, e.RowIndex].Value.ToString();

                    if (Enum.TryParse((FileService.GetFileExtension(filePath).Substring(1)), out PhotoExtensionsEnum PhotoExten))
                    {
                        Process.Start(filePath);
                    }
                    else
                    {
                        Process test = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();


                        var existStartDateTime = _fileMonitorDbService.ReadDb_Timestamps_ForFile(filePath).startTimestamp;
                        var existeEndTime = _fileMonitorDbService.ReadDb_Timestamps_ForFile(filePath).endTimestamp;
                        startInfo.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

                        string start = "0";
                        string stop = "0";

                        if (DateTimeCalculator.IsBetweenTwoDates(DateTime.Parse(fromDateTimePicker.Text), existStartDateTime, existeEndTime) || DateTimeCalculator.IsBetweenTwoDates(DateTime.Parse(toDateTimePicker.Text), existStartDateTime, existeEndTime))
                        {
                            var substrResultOFStartTime = DateTimeCalculator.SubstactTwoDates(existStartDateTime, DateTime.Parse(fromDateTimePicker.Text));
                            var substrResultOfEndTime = DateTimeCalculator.SubstactTwoDates(existStartDateTime, DateTime.Parse(toDateTimePicker.Text));
                            var videoDuration = FileService.VideoTotalDuration(existStartDateTime, existeEndTime);
                            if (substrResultOFStartTime > 0 && substrResultOFStartTime < videoDuration && DateTimeCalculator.isEqual(DateTime.Parse(fromDateTimePicker.Text).Date, existStartDateTime.Date))
                            {
                                start = substrResultOFStartTime.ToString();

                            }
                            if (substrResultOfEndTime > 0 && substrResultOfEndTime < videoDuration && DateTimeCalculator.isEqual(DateTime.Parse(toDateTimePicker.Text).Date, existeEndTime.Date))
                            {
                                stop = substrResultOfEndTime.ToString();
                            }
                        }


                        startInfo.Arguments = $"\"" + filePath + "\"" + " --start-time" + " " + start + " --stop-time " + stop;


                        Process.Start(startInfo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

            }
        }

        private void ChooseHistoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (displayHistoryDataGridView.Rows.Count > 0)
                {
                    displayHistoryDataGridView.DataSource = null;
                    displayHistoryDataGridView.Rows.Clear();
                }
                if (displayHistoryDataGridView.Columns.Contains("openFile"))
                {
                    displayHistoryDataGridView.Columns.Remove("openFile");
                }
                if (chooseHistoryComboBox.SelectedIndex == 1)
                {
                    mediaFilesgroupBox.Visible = true;
                    showVideosCheckBox.Visible = true;
                    showPhotosCheckBox.Visible = true;
                    showVideosCheckBox.Checked = true;
                    showPhotosCheckBox.Checked = true;
                }
                if (chooseHistoryComboBox.SelectedIndex == 0)
                {
                    showVideosCheckBox.Visible = false;
                    showPhotosCheckBox.Visible = false;
                    mediaFilesgroupBox.Visible = false;

                }



            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

        }

        #endregion

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            mediaFilesgroupBox.Visible = false;
            showVideosCheckBox.Visible = false;
            showPhotosCheckBox.Visible = false;

        }


    }
}

