using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using log4net;


namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainView_Closing;
            ShowZooLocations();

        }

        public void ShowZooLocations()
        {
            string query = "SELECT * FROM ZooLocation";
            SqlDataAdapter iSqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            using (iSqlDataAdapter)
            {
                DataTable tZooTable = new DataTable();
                iSqlDataAdapter.Fill(tZooTable);
                lListZooLocations.DisplayMemberPath = "Location";
                lListZooLocations.SelectedValuePath = "Id";
            }
        }

        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*
                if (((MainViewModel)(this.DataContext)).Data.IsModified)
                if (!((MainViewModel)(this.DataContext)).PromptSaveBeforeExit())
                {
                    e.Cancel = true;
                    return;
                }
            */
            Log.Info("Closing App");
        }
    }
}
