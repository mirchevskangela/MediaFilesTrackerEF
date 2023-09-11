using detectVideoApp;

namespace ClassLibrary.ModelClass
{
    public class DatabaseConfig
    {
        #region Members
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        #endregion

        public string DatabaseConnectionString()
        {
            FileService fileService = new FileService();
            DatabaseConfig db = fileService.ReadFromXmlFile();
            var connectionString = $"Server={db.ServerName};Database={db.DatabaseName};User Id=sa;Password=mikrosam;";
            return connectionString;
        }
    }
}
