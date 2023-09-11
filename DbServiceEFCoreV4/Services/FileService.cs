using ClassLibrary.ModelClass;
using System;
using System.IO;
using System.Xml.Serialization;



namespace detectVideoApp
{
    public class FileService
    {
        #region Members
        private System.Xml.Serialization.XmlSerializer _serializer;
        #endregion
        #region Constructors
        public FileService()
        {
            _serializer = new XmlSerializer(typeof(DatabaseConfig));

        }
        #endregion
        #region xml file services
        /// <summary>
        /// Writes data in xml file
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        public void WriteXmlFile(string serverName, string databaseName)
        {
            FileStream fs = new FileStream("C:\\Users\\Angelam\\Desktop\\detectVideoAppEF\\DbServiceEFCoreV4\\bin\\Debug\\database.xml", FileMode.Create, FileAccess.Write);
            DatabaseConfig database = new DatabaseConfig();
            database.ServerName = serverName;
            database.DatabaseName = databaseName;
            _serializer.Serialize(fs, database);
            fs.Close();
        }
        /// <summary>
        /// Reads data from xml file
        /// </summary>
        /// <returns></returns>
        public DatabaseConfig ReadFromXmlFile()
        {
            System.IO.TextReader textReader = new System.IO.StreamReader("C:\\Users\\Angelam\\Desktop\\detectVideoAppEF\\DbServiceEFCoreV4\\bin\\Debug\\database.xml");
            var db = (DatabaseConfig)_serializer.Deserialize(textReader);
            textReader.Close();
            return db;
        }

        #endregion
        #region Services
        /// <summary>
        /// Returns the file extension of a given file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileExtension(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }
 
        /// <summary>
        /// Calculates total duration of video based on the given start and end time
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>seconds</returns>
        public static int VideoTotalDuration(DateTime startTime, DateTime endTime)
        {
            return DateTimeCalculator.SubstactTwoDates(startTime, endTime);
        }
        #endregion
    }
}