//App.xaml.cs

using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;
using System.ComponentModel;
using WPF_App.ViewModels;
using WPF_App.Views;

namespace WPF_App
{
    public partial class App : Application
    {

        //#Section  private Fields
        private string connectionString;
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static MainWindow app;


        //#Section private Methods
        public App()
        {
            
            InitializeComponent();           //#Info  Wir erstellen eine Verbindung zur Datenbank 
            connectionString = ConfigurationManager.ConnectionStrings["WPF_App.Properties.Settings.db_Tutorial_ConString"].ConnectionString;
        }

        public static void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs args)
        {
            // Here change path to the log.txt file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                                    + "\\Student\\WPF_App\\log.txt";

            // Show a message before closing application
            var dialogService = new MvvmDialogs.DialogService();
            dialogService.ShowMessageBox((INotifyPropertyChanged)(app.DataContext),
                "Oops, something went wrong and the application must close. Please find a " +
                "report on the issue at: " + path + Environment.NewLine +
                "If the problem persist, please contact Student.",
                "Unhandled Error",
                MessageBoxButton.OK);

            Exception e = (Exception)args.ExceptionObject;
            Log.Fatal("Application has crashed", e);
        }

        public void LogMachineDetails()
        {
            var computer = new Microsoft.VisualBasic.Devices.ComputerInfo();

            string text = "OS: " + computer.OSPlatform + " v" + computer.OSVersion + Environment.NewLine +
                          computer.OSFullName + Environment.NewLine +
                          "RAM: " + computer.TotalPhysicalMemory.ToString() + Environment.NewLine +
                          "Language: " + computer.InstalledUICulture.EnglishName;
            Log.Info(text);
        }


        //#Section public Methods
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Log.Info("Application Startup");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Log.Info("Connected to database");
                    // Now you can use the connection to execute queries, etc.
                }
                catch (SqlException ex)
                {
                    Log.Error("Error connecting to database", ex);
                }
            }

            // For catching Global uncaught exception
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionOccured);

            Log.Info("Starting App");
            LogMachineDetails();
            app = new MainWindow();
            var context = new MainViewModel();
            app.DataContext = context;
            app.Show();

            if (e.Args.Length == 1) //make sure an argument is passed
            {
                Log.Info("File type association: " + e.Args[0]);
                FileInfo file = new FileInfo(e.Args[0]);
                if (file.Exists) //make sure it's actually a file
                {
                    // Here, add you own code
                    // ((MainViewModel)app.DataContext).OpenFile(file.FullName);
                }
            }
        }

    }
}
