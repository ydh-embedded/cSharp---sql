using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using log4net;

namespace WpfApp3.Views
{
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection;
        private System.Windows.Controls.ListBox listZoos;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfApp3.Views.Properties.Settings"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            listZoos = (System.Windows.Controls.ListBox)this.FindName("listZoos");

            if (listZoos != null)
            {
                ShowZoos();
            }
            else
            {
                log4net.LogManager.GetLogger(typeof(MainWindow)).Error("listZoos control not found");
            }
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public void ShowZoos()
        {
            try
            {
                DataTable tZooTable = GetZooData();
                listZoos.DisplayMemberPath = "Location";
                listZoos.SelectedValuePath = "Id";
                listZoos.ItemsSource = tZooTable.DefaultView;
            }
            catch (Exception e)
            {
                log4net.LogManager.GetLogger(typeof(MainWindow)).Error("Error showing zoos", e);
                MessageBox.Show(e.ToString());
            }
        }

        private DataTable GetZooData()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                connection.Open();
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable tZooTable = new DataTable();
                sqlDataAdapter.Fill(tZooTable);
                return tZooTable;
            }
        }
    }
}