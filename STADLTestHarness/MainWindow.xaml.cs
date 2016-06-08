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
using System.Drawing;
using System.Drawing.Printing;


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
            try
            {
                STADL.Bot _stadlbotOpenConnection = new STADL.Bot();
                _stadlbotOpenConnection.DBConnection();
                if (_stadlbotOpenConnection.DBOpenConnection() == true)
                {
                    Console.WriteLine("Database Connected");
                }
                else
                {
                    Console.WriteLine("Database Not Connected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error When Connectiing To Database Connection {0}", ex.ToString());
            }
        }       

        private void DBCloseButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                STADL.Bot _stadlbotCloseConnection = new STADL.Bot();
                _stadlbotCloseConnection.DBCloseConnection();
                if (_stadlbotCloseConnection.DBCloseConnection() == true)
                {
                    Console.WriteLine("Database Not Connected");
                }
                else
                {
                    Console.WriteLine("Database Still Connected");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error When Closing Database Connection {0}", ex.ToString());
            }           
        }


        /// <summary>
        /// This his for hidden print functionality
        /// I pass the file name in hard coded from C: this could be taken from user also. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void HiddenPrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = @"c:\sample.pdf";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Normal;

                //Load Files in Selected Folder
                //Loop for more than one file.
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
            catch (Exception ex)
            {
                Console.WriteLine("Error When Printing {0}", ex.ToString());
            }            
        }

        private void DialogPrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
           
            dlg.ShowDialog();

        }
    }
}
