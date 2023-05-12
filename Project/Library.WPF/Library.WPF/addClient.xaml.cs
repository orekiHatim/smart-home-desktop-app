using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace Library.WPF
{
    /// <summary>
    /// Interaction logic for addClient.xaml
    /// </summary>
    public partial class addClient : Window
    {
        string adminName;

        public string AdminName { get => adminName; set => adminName = value; }

        public addClient()
        {
            InitializeComponent();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            Connection conn = new Connection();
            conn.Initialize();
            if (conn.openConnection())
            {

                if (txtName.Text.Length == 0 || txtCin.Text.Length == 0 || txtPhone.Text.Length == 0)
                {
                    textError.Foreground = Brushes.Red;
                    iconError.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    iconError.Foreground = Brushes.Red;
                    textError.Text = "Please fill the form";
                    formError.Visibility = Visibility.Visible;
                }
                else
                {
                    try
                    {
                        MySqlCommand cmd = conn.getConnection().CreateCommand();
                        cmd.CommandText = "Insert into clients(username, cin, phone, blocked) VALUES (@username, @cin, @phone, @blocked)";
                        cmd.Parameters.AddWithValue("@username", txtName.Text);
                        cmd.Parameters.AddWithValue("@cin", txtCin.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@blocked", 0);
                        cmd.ExecuteNonQuery();
                        conn.closeConnection();
                        txtName.Clear();
                        txtCin.Clear();
                        txtPhone.Clear();
                        textError.Foreground = Brushes.LimeGreen;
                        iconError.Kind = MaterialDesignThemes.Wpf.PackIconKind.Done;
                        iconError.Foreground = Brushes.LimeGreen;
                        textError.Text = "Inserted Successfully!";
                        formError.Visibility = Visibility.Visible;
                        
                    }
                    catch (MySqlException)
                    {
                        textError.Foreground = Brushes.Red;
                        iconError.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                        iconError.Foreground = Brushes.Red;
                        textError.Text = "Error inserting infos to database";
                        formError.Visibility = Visibility.Visible;
                    }

                }
            }
            else
            {
                textError.Foreground = Brushes.Red;
                iconError.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                iconError.Foreground = Brushes.Red;
                textError.Text = "Cannot connect to database!";
                formError.Visibility = Visibility.Visible;
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            //Clients c = new Clients();
            //c.AdminName = adminName;
            //c.Show();
            this.Close();
        }
    }
}
