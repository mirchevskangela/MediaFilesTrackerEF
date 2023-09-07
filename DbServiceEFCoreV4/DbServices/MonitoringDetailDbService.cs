using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.ModelClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbServicesEFCore.DbServices
{
    public class MonitoringDetailDbService
    {
        #region Constructors
        public MonitoringDetailDbService()
        {
            _databaseConfig = new DatabaseConfig();
            _videoDetectContext = new VideoDetectContext(_databaseConfig.DatabaseConnectionString());
        }
        #endregion
        #region Members
        private VideoDetectContext _videoDetectContext;
        private DatabaseConfig _databaseConfig;

        #endregion
        #region Services

        /// <summary>
        /// Adds a new monitoring detail to the monitoring_details table
        /// </summary>
        /// <param name="configurationId"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public void WriteInDb_NewMonitoringDetail(CameraConfiguration configurationId, string path, string fileName, bool isVideo = false)
        {

            try
            {
                MonitoringDetail monitoringDetail = new MonitoringDetail();
                DateTime timeNow = DateTime.Now;
                monitoringDetail.EndTimestamp = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                monitoringDetail.StartTimestamp = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                monitoringDetail.EndTimestamp = timeNow;
                monitoringDetail.CameraConfigurationID = configurationId.Id;
                monitoringDetail.FolderPath = path;
                monitoringDetail.FileName = fileName;
                monitoringDetail.ActionsID = (int)ActionsEnum.Created;
                monitoringDetail.IsVideo = isVideo;
                _videoDetectContext.MonitoringDetails.Add(monitoringDetail);
                _videoDetectContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        ///Modifies the end timestamp and action values for a particular monitoring detail from the monitoring_details table based on the given camera name
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="timeNow"></param>
        public void UpdateDb_MonitoringDetail(String fileName)
        {

            try
            {

                var monitoringDetail = _videoDetectContext.MonitoringDetails.Where(m => m.FileName == fileName).SingleOrDefault();
                if (monitoringDetail != null)
                {
                    DateTime timeNow = DateTime.Now;
                    timeNow = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                    monitoringDetail.EndTimestamp = timeNow;
                    monitoringDetail.ActionsID = (int)ActionsEnum.Modified;
                    _videoDetectContext.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        /// <summary>
        /// Retrieves monitoring detail records from monitoring_details table,that are between the given from and to timestamp values
        /// </summary>
        /// <param name="from">from timestamp </param>
        /// <param name="to">to timestamp</param>
        /// <returns>a datatable containing retrieved records</returns>
        /// 
        public List<MonitoringDetail> ReadFromDb_MonitoringDetails_BetweenDates(DateTime from, DateTime to, bool showVideos = false, bool showPhotos = false)
        {
            try
            {
                if (showVideos && !showPhotos)
                {
                    var monitoringDetails = _videoDetectContext.MonitoringDetails.Include(x => x.Actions).Include(x => x.CameraConfiguration).Where(m => m.StartTimestamp >= from && m.EndTimestamp <= to && m.IsVideo == true).ToList();

                    return monitoringDetails;
                }
                if (!showVideos && showPhotos)
                {
                    var monitoringDetails = _videoDetectContext.MonitoringDetails.Include(x => x.Actions).Include(x => x.CameraConfiguration).Where(m => m.StartTimestamp >= from && m.EndTimestamp <= to && m.IsVideo == false).ToList();

                    return monitoringDetails;
                }
                if (showVideos && showPhotos)
                {
                    var monitoringDetails = _videoDetectContext.MonitoringDetails.Include(x => x.Actions).Include(x => x.CameraConfiguration).Where(m => m.StartTimestamp >= from && m.EndTimestamp <= to).ToList();

                    return monitoringDetails;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;

        }

        /// <summary>
        /// Retrieves camera name, file path, file name, start and end timestamp values of a monitoring detail from monitoring_details table
        /// based on the given start timestamp value
        /// </summary>
        /// <param name="from_dateTimePicker"></param>
        /// <returns>the closest monitoring detail to the given start timestmap</returns>
        public MonitoringDetail ReadFromDb_ClosestMonitoringDetail(DateTime from_dateTimePicker, bool showVideos = false)
        {
            MonitoringDetail monitoringDetails = null;

            try
            {
                if (showVideos)
                {
                    monitoringDetails = _videoDetectContext.MonitoringDetails.Include(x => x.Actions).Include(x => x.CameraConfiguration).Where(m => m.StartTimestamp <= from_dateTimePicker && m.IsVideo == true).OrderByDescending(m => m.StartTimestamp).FirstOrDefault();
                    return monitoringDetails;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return monitoringDetails;

        }

        /// <summary>
        /// Retrieves start_timestamp or end timestamp value for a file based on the given path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>a datatable with one row and one column  </returns>
        public (DateTime startTimestamp, DateTime endTimestamp) ReadDb_Timestamps_ForFile(string path)
        {
            DateTime startTimestamp = DateTime.MinValue;
            DateTime endTimestamp = DateTime.MinValue;
            try
            {
                var monitoringDetail = _videoDetectContext.MonitoringDetails.Where(m => m.FolderPath == path).FirstOrDefault();
                startTimestamp = monitoringDetail.StartTimestamp;
                endTimestamp = monitoringDetail.EndTimestamp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (startTimestamp: startTimestamp, endTimestamp: endTimestamp);

        }
        #endregion
    }
}
