/*
 * 
 * Name: Logan Brown
 * Date: 2/22/2021
 * File: MainWindow.xaml.cs
 * Description: Implementation of the main window and all buttons associated.
 * 
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
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

namespace WpfDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\logan\Documents\WPFdatabase.accdb");
        }

        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            Text_Area.Text = "";
            Text_Area.FontSize = 20;

            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";

            //Setting labels for the Chart
            data += "Employee ID | " + "Asset ID | " + "Description\n" + "----------------------------------------\n";

            while (read.Read())
            {
                data += read[0].ToString() + "          | " + read[1].ToString() + "      | " + read[2].ToString() +"\n" + "----------------------------------------\n";
            }

            Text_Area.Text = data;
            cn.Close();
        }


        // I just copy and pasted the first button, then made changes. See below for changes
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text_Area.Text = "";
            Text_Area.FontSize = 20;

            // Changed the query
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";

            //Setting labels for the Chart also changed
            data += "Employee ID | " + "First Name | " + "Last Name\n" + "----------------------------------------\n";

            while (read.Read())
            {
                // Slight changes to the spacing
                data += read[0].ToString() + "          | " + read[1].ToString() + "       | " + read[2].ToString() + "\n" + "----------------------------------------\n";
            }

            Text_Area.Text = data;
            cn.Close();
        }
    }
}
