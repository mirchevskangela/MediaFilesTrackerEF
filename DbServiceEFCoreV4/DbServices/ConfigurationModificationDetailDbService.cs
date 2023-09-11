using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.ModelClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbServicesEFCore.DbServices
{
    public class ConfigurationModificationDetailDbService
    {
        #region Constructors
        public ConfigurationModificationDetailDbService()
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
        ///  Adds modified configuration to the database
        /// </summary>
        /// <param name="cameraName"></param>
        /// <param name="folderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        public void WriteDb_Configuration_Modification(string cameraName, string folderPath = "", string videoExtension = "", string photoExtension = "", bool created = false, bool deleted = false)
        {
            try
            {
                if (folderPath != "" && videoExtension == "" && photoExtension == "" && !created && !deleted)
                {

                    ConfigurationModificationDetail modifiedConfiguration = new ConfigurationModificationDetail();
                    modifiedConfiguration.CameraName = cameraName;
                    modifiedConfiguration.FolderPath = folderPath;
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Modified;
                    modifiedConfiguration.Timestamp = DateTime.Now;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }
                if (videoExtension != "" && photoExtension == "" && folderPath == "" && !created && !deleted)
                {
                    ConfigurationModificationDetail modifiedConfiguration = new ConfigurationModificationDetail();
                    modifiedConfiguration.CameraName = cameraName;
                    modifiedConfiguration.VideoExtension = videoExtension;
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Modified;
                    modifiedConfiguration.Timestamp = DateTime.Now;

                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);

                    _videoDetectContext.SaveChanges();
                }
                if (photoExtension != "" && folderPath == "" && videoExtension == "" && !created && !deleted)
                {
                    ConfigurationModificationDetail modifiedConfiguration = new ConfigurationModificationDetail();
                    modifiedConfiguration.CameraName = cameraName;
                    modifiedConfiguration.PhotoExtension = photoExtension;
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Modified;
                    modifiedConfiguration.Timestamp = DateTime.Now;

                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();
                }
                if (created && !deleted)
                {
                    ConfigurationModificationDetail modifiedConfiguration = new ConfigurationModificationDetail();
                    modifiedConfiguration.CameraName = cameraName;
                    modifiedConfiguration.FolderPath = folderPath;
                    modifiedConfiguration.VideoExtension = videoExtension;
                    modifiedConfiguration.PhotoExtension = photoExtension;
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Created;
                    modifiedConfiguration.Timestamp = DateTime.Now;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }
                if (!created && deleted)
                {
                    ConfigurationModificationDetail modifiedConfiguration = new ConfigurationModificationDetail();
                    modifiedConfiguration.CameraName = cameraName;
                    modifiedConfiguration.FolderPath = folderPath;
                    modifiedConfiguration.VideoExtension = videoExtension;
                    modifiedConfiguration.PhotoExtension = photoExtension;
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Deleted;
                    modifiedConfiguration.Timestamp = DateTime.Now;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Retrieves a list of configuration modifications that occurred between the specified start and end dates.
        /// </summary>
        /// <param name="fromTimestamp"></param>
        /// <param name="toTimestamp"></param>
        /// <returns></returns>
        public List<ConfigurationModificationDetail> ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime fromTimestamp, DateTime toTimestamp)
        {
            try
            {

                var objects = _videoDetectContext.ConfigurationModificationDetails.Include(c => c.Actions).Where(c => c.Timestamp >= fromTimestamp && c.Timestamp <= toTimestamp).ToList();
                return objects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
