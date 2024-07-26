using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
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
using System.Configuration;
using System.Data.SqlClient;
using log4net;

namespace WpfApp3.Views
{
    public partial class MainWindow : Window                    // Interaction logic for MainWindow.xaml
    {
        private SqlConnection sqlConnection;
        private ListBox listZoos; // Assuming listZoos is a ListBox

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfApp3.Views.Properties.Settings"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            listZoos = (ListBox)this.FindName("listZoos"); // Assuming listZoos is a ListBox in your XAML
        }

        public void ShowZoos()
        {
            string query = "select * from Zoo";                                               // Unser Query gibt uns alles aus der Table "Zoo" zurück
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);        // We give this Adapter the Query and the Connection


            using (sqlDataAdapter)
            {
                DataTable tZooTable = new DataTable();              // we create an Object from Type: DataTable !
                sqlDataAdapter.Fill(tZooTable);


                listZoos.DisplayMemberPath = "Location";        // which Values are visible @ ListBox
                listZoos.SelectedValuePath = "Id";             // which Values are visible @ selected Items
                listZoos.ItemsSource = tZooTable.DefaultView; // Default view is the origin for the new items


            }

        }
    }
}