using ClassLibrary.ModelClass;
using System;
using System.Windows.Forms;
namespace detectVideoApp
{
    public partial class ServerConfigurationForm : Form
    {
        #region Members
        private FileService _xmlService;
        #endregion
        #region Constructors
        public ServerConfigurationForm()
        {
            _xmlService = new FileService();
            InitializeComponent();
        }
        #endregion
        #region Events
        private void DbSaveBtn_Click(object sender, EventArgs e)
        {
            _xmlService.WriteXmlFile(serverTxtBox.Text, dbTxtBox.Text);
        }
        private void DatabaseConfiguration_Load(object sender, EventArgs e)
        {
            DatabaseConfig db = _xmlService.ReadFromXmlFile();

            serverTxtBox.Text = db.ServerName;
            dbTxtBox.Text = db.DatabaseName;
        }
      
        #endregion

    }
}
