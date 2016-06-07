using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using STADL;
using System.Configuration;
using System.Diagnostics;

namespace STADLTestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DBConnectButton_Click(object sender, RoutedEventArgs e)
        {            
            STADL.Bot _stadlbotOpenConnection = new STADL.Bot();
            _stadlbotOpenConnection.DBConnection();
            if (_stadlbotOpenConnection.DBOpenConnection() == true)
            {
                MessageBox.Show("Database Connected");
            }
            else
            {
                MessageBox.Show("Database Not Connected");
            }
        }       

        private void DBCloseButton_Click(object sender, RoutedEventArgs e)
        {            
            STADL.Bot _stadlbotCloseConnection = new STADL.Bot();            
            _stadlbotCloseConnection.DBCloseConnection();
            if (_stadlbotCloseConnection.DBCloseConnection() == true)
            {
                MessageBox.Show("Database Not Connected");
            }
            else
            {
                MessageBox.Show("Database Still Connected");
            }
        }


        /// <summary>
        /// This his for hidden print functionality
        /// I pass the file name in hard coded from C: this could be taken from user also. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = @"c:\sample.pdf";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Normal;

            ////Load Files in Selected Folder
            //string[] allFiles = System.IO.Directory.GetFiles(Directory);
            //foreach (string file in allFiles)
            //{
            //    info.FileName = @file;
            //    info.CreateNoWindow = true;
            //    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //    p.StartInfo = info;
            //    p.Start();
            //}

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }
    }
}
