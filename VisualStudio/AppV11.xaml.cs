using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
 
namespace db_App_WPF
{
    SqlConnection SqlConnection;
 
    public MainWindow()
    {
        InitializeComponent();
        string connectionString = ConfigurationManager.connectionStrings["db_App_WPF.Properties.Settings.db_App_WPF"]
        sqlConnection = new SqlConnection(connectionString);
    }
 
    public void ShowZooLocations()
    {
        string query = "select * from Zoo";
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
    }
 
}