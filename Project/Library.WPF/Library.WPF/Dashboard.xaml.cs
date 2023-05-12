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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private string responsableId;
        private string appId;

        public string ResponsableId { get => responsableId; set => responsableId = value; }

        public Dashboard(string id, string appId)
        {
            InitializeComponent();
            responsableId = id;
            this.appId = appId;
            admin.Text = appId + " App";
            loadZones();
        }

        private void logout(object sender, RoutedEventArgs e)
        {
           MainWindow m = new MainWindow();
            m.Show();
            this.Close();
            
        }

        private void loadZones()
        {
            zone1.Visibility = Visibility.Collapsed;
            zone2.Visibility = Visibility.Collapsed;
            zone3.Visibility = Visibility.Collapsed;
            zone4.Visibility = Visibility.Collapsed;
            zone5.Visibility = Visibility.Collapsed;
            zone6.Visibility = Visibility.Collapsed;
            zone7.Visibility = Visibility.Collapsed;
            zone8.Visibility = Visibility.Collapsed;
            zone9.Visibility = Visibility.Collapsed;
            zone10.Visibility = Visibility.Collapsed;
            Connection conn = new Connection();
            conn.Initialize();
            if (conn.openConnection())
            {
                string sql = "SELECT * from zone where appartement=@app";
                var cmd = new MySqlCommand(sql, conn.getConnection());
                cmd.Parameters.AddWithValue("@app", appId);
                MySqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    if (c == 0)
                    {
                        zone1.Visibility = Visibility.Visible;
                        zone1.Title = reader["nom"].ToString();
                        if (reader["status"].ToString() == "0")
                        {
                            
                            zone1.Type2 = "Visible";
                        }
                        else
                        {

                            zone1.Type2 = "Collapsed";
                        }
                    }

                    if (c == 1)
                    {
                        zone2.Visibility = Visibility.Visible;
                        zone2.Title = reader["nom"].ToString();
                        if (reader["status"].ToString() == "0")
                        {
                            
                            zone2.Type2 = "Visible";
                        }
                        else
                        {
                            
                            zone2.Type2 = "Collapsed";
                        }


                    }

                    if (c == 2)
                    {
                        zone3.Visibility = Visibility.Visible;
                        zone3.Title = reader["nom"].ToString();
                        if (reader["status"].ToString() == "0")
                        {
                            zone3.Type2 = "Visible";
                        }
                        else
                        {

                            zone3.Type2 = "Collapsed";
                        }
                    }

                    c++;
                }
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            /*
            Connection conn = new Connection();
            conn.Initialize();
            if (conn.openConnection())
            {
                string sql = "SELECT username,cin,phone from clients ORDER by id DESC LIMIT 4";
                string sql1 = "SELECT count(id) from clients";
                var cmd = new MySqlCommand(sql, conn.getConnection());
                var cmd1 = new MySqlCommand(sql1, conn.getConnection());
                object clientNum = cmd1.ExecuteScalar();
                cliCount.Text = clientNum.ToString();
                using (MySqlDataReader res = cmd.ExecuteReader())
                {
                    int c = 0;
                    while (res.Read())
                    {
                        if (c == 0)
                        {
                            latestClientsUsername1.Text = res.GetString(0);
                            latestClientsCin1.Text = res.GetString(1);
                            latestClientsPhone1.Text = res.GetString(2);
                        }
                        else if (c == 1)
                        {
                            latestClientsUsername2.Text = res.GetString(0);
                            latestClientsCin2.Text = res.GetString(1);
                            latestClientsPhone2.Text = res.GetString(2);
                        }
                        else if (c == 2)
                        {
                            latestClientsUsername3.Text = res.GetString(0);
                            latestClientsCin3.Text = res.GetString(1);
                            latestClientsPhone3.Text = res.GetString(2);
                        }
                        else
                        {
                            latestClientsUsername4.Text = res.GetString(0);
                            latestClientsCin4.Text = res.GetString(1);
                            latestClientsPhone4.Text = res.GetString(2);
                        }
                        c++;
                    }
                }
            }
            */
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void clientTab(object sender, RoutedEventArgs e)
        {
            /*
            Clients c = new Clients();
            c.AdminName = adminName;
            c.Show();
            this.Close();
           */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            Books b = new Books();
            b.Show();
            this.Close();
            */
        }
    }
}
