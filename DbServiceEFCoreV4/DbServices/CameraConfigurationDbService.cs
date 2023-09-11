using ClassLibrary.ModelClass;
using DbServicesEFCore.ModelClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DbServicesEFCore.DbServices
{
    public class CameraConfigurationDbService
    {
        #region Members
        private VideoDetectContext _videoDetectContext;
        private DatabaseConfig _databaseConfig;
        #endregion
        #region Constructors
        public CameraConfigurationDbService()
        {
            _databaseConfig = new DatabaseConfig();
            _videoDetectContext = new VideoDetectContext(_databaseConfig.DatabaseConnectionString());

        }
        #endregion

        #region Services
        /// <summary>
        /// Adds a new camera configuration to the cameraconfigurations table
        /// </summary>
        /// <param name="newConfiguration"></param>
        public void WriteDb_AddCameraConfiguration(CameraConfiguration newConfiguration)
        {
            try
            {
                _videoDetectContext.CameraConfigurations.Add(newConfiguration);
                _videoDetectContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns a camera name or id or folder path or video extension or photo extension value of a particular record from the configuration_details table based on given camera name
        /// </summary>
        /// <param name="insertedCameraName"></param>
        /// <returns></returns>
        public (string videoExtensions, string photoExtensions, string folderPath, string name, int id) ReadFromDb_Configuration_InDetail(string insertedCameraName) // tuple return type
        {
            string videoExtensions = "";
            string photoExtensions = "";
            string folderPaths = "";
            string name = "";
            int id = 0;
            var existingObject = _videoDetectContext.CameraConfigurations.Where(c => c.CameraName == insertedCameraName).SingleOrDefault();

            try
            {
                if (existingObject != null)
                {
                    videoExtensions = existingObject.VideoExtension;
                    photoExtensions = existingObject.PhotoExtension;
                    folderPaths = existingObject.FolderPath;
                    name = existingObject.CameraName;
                    id = existingObject.Id;
                }



                return (videoExtensions: videoExtensions, photoExtensions: photoExtensions, folderPath: folderPaths, name: name, id: id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (videoExtensions: videoExtensions, photoExtensions: photoExtensions, folderPath: folderPaths, name: name, id: id);
        }
        /// <summary>
        /// Retrieves all camera names
        /// </summary>
        /// <returns></returns>
        public List<String> ReadDb_AllCameraNames()
        {
            List<String> allCameraNames = new List<String>();

            try
            {
                allCameraNames = _videoDetectContext.CameraConfigurations.Select(c => c.CameraName).ToList();
                return allCameraNames;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allCameraNames;
        }
        //  public List<CameraConfiguration> ReadDb_
        /// <summary>
        /// Retrieves all camera names
        /// </summary>
        /// <returns></returns>
        public List<CameraConfiguration> ReadDb_AllCameraConfigurations()
        {
            List<CameraConfiguration> configurationObjects = new List<CameraConfiguration>();

            try
            {

                configurationObjects = _videoDetectContext.CameraConfigurations.ToList();


                return configurationObjects;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configurationObjects;
        }
        /// <summary>
        /// Retrieves specific configuration based on the given camera name 
        /// </summary>
        /// <param name="cameraName"></param>
        /// <returns></returns>
        public CameraConfiguration ReadDb_CameraConfiguration(string cameraName)
        {
            CameraConfiguration configurationObject = new CameraConfiguration();
            try
            {
                configurationObject = _videoDetectContext.CameraConfigurations.Where(c => c.CameraName == cameraName).SingleOrDefault();
                return configurationObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return configurationObject;
        }
        /// <summary>
        /// Updates the configuration details for a specific camera configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="folderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        public void UpdateDb_ConfigurationDetails(CameraConfiguration configuration, string folderPath = "", string videoExtension = "", string photoExtension = "")
        {
            try
            {
                if (folderPath != "")
                {
                    var existingFolderPaths = configuration.FolderPath;
                    configuration.FolderPath = existingFolderPaths + "," + folderPath;
                    _videoDetectContext.SaveChanges();
                }
                if (videoExtension != "")
                {
                    var existingVideoExtensions = configuration.VideoExtension;
                    if (existingVideoExtensions != "")
                    {
                        configuration.VideoExtension = existingVideoExtensions + " " + videoExtension;

                    }
                    else
                    {
                        configuration.VideoExtension = videoExtension;
                    }
                    _videoDetectContext.SaveChanges();
                }
                if (photoExtension != "")
                {
                    var existingVideoExtensions = configuration.PhotoExtension;
                    if (existingVideoExtensions != "")
                    {
                        configuration.PhotoExtension = existingVideoExtensions + " " + photoExtension;

                    }
                    else
                    {
                        configuration.PhotoExtension = photoExtension;
                    }
                    _videoDetectContext.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Sets the active default value from false to true to a record in the configuration_details table based on given camera name
        /// </summary>
        /// <param name="cameraName"></param>
        public void UpdateDb_SetActiveCamera_Configuration(CameraConfiguration configuration)
        {
            try
            {
                //   var configuration = _videoDetectContext.CameraConfigurations.Where(c => c.CameraName == cameraName).SingleOrDefault();
                configuration.Active = true;
                _videoDetectContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Deletes a camera configuration from the database.
        /// </summary>
        /// <param name="cameraName">The configuration object to delete</param>
        /// <returns>True if the deletion was successful, false otherwise</returns>
        public bool UpdateDb_DeleteConfiguration(CameraConfiguration configurationObject)
        {

            if (configurationObject != null)
            {
                try
                {
                    _videoDetectContext.CameraConfigurations.Remove(configurationObject);
                    _videoDetectContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return false;
        }
        /// <summary>
        /// Updates configuration
        /// </summary>
        /// <param name="cameraName"></param>
        /// <param name="folderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        /// <returns></returns>
        public bool UpdateDb_DeleteConfigurationDetail(CameraConfiguration configurationObject, string folderPath = "", string videoExtension = "", string photoExtension = "")
        {
            bool updated = false;

            try
            {
                if (folderPath != "" && configurationObject != null && configurationObject.FolderPath != "")
                {
                    var folderPathsList = configurationObject.FolderPath.Split(',').ToList();
                    //configuration must contain at least one folder 
                    if (folderPathsList.Count > 1)
                    {
                        for (int i = 0; i < folderPathsList.Count; i++)
                        {
                            if (folderPathsList[i] == folderPath)
                            {
                                folderPathsList.RemoveAt(i);
                                configurationObject.FolderPath = String.Join(",", folderPathsList);
                                _videoDetectContext.SaveChanges();
                                updated = true;

                            }
                        }
                    }
                }
                if (videoExtension != "" && configurationObject != null && configurationObject.VideoExtension != "")
                {
                    var videoExtensionsList = configurationObject.VideoExtension.Split(' ').ToList();
                    for (int i = 0; i < videoExtensionsList.Count; i++)
                    {
                        if (videoExtensionsList[i] == videoExtension)
                        {
                            videoExtensionsList.RemoveAt(i);
                            configurationObject.VideoExtension = String.Join(" ", videoExtensionsList);
                            _videoDetectContext.SaveChanges();
                            updated = true;

                        }
                    }
                }
                if (photoExtension != "" && configurationObject != null && configurationObject.PhotoExtension != "")
                {
                    var photoExtensionsList = configurationObject.PhotoExtension.Split(' ').ToList();
                    for (int i = 0; i < photoExtensionsList.Count; i++)
                    {
                        if (photoExtensionsList[i] == photoExtension)
                        {
                            photoExtensionsList.RemoveAt(i);
                            configurationObject.PhotoExtension = String.Join(" ", photoExtensionsList);
                            _videoDetectContext.SaveChanges();
                            updated = true;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return updated;
        }
    }
    #endregion

}
