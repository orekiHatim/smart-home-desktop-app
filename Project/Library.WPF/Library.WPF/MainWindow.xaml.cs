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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;

namespace Library.WPF
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


        public bool isDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if(isDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                isDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                logo.Source = new BitmapImage(new Uri(@"logo-purple.png", UriKind.Relative));
            } else
            {
                isDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                logo.Source = new BitmapImage(new Uri(@"logo-purple.png", UriKind.Relative));
            }
            paletteHelper.SetTheme(theme);
        }

        private void login(object sender, RoutedEventArgs e)
        {
            
            Connection conn = new Connection();
            conn.Initialize();
            if (conn.openConnection())
            {
                
                if(txtUsername.Text.Length == 0 || txtPassword.Password.Length == 0)
                {
                    textError.Text = "Please fill the form";
                    formError.Visibility = Visibility.Visible;
                } else
                {
                   try
                   {
                        string sql = "SELECT id,login,password from responsable where login=@login and password=@password";
                        var cmd = new MySqlCommand(sql, conn.getConnection());
                        cmd.Parameters.AddWithValue("@login", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Password);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if(!reader.Read())
                        {
                            textError.Text = "Invalid username and password!";
                            formError.Visibility = Visibility.Visible;
                            txtUsername.Clear();
                            txtPassword.Clear();
                        } else
                        {
                            try
                            {
                                string id = reader["id"].ToString();
                                conn.closeConnection();
                                conn.Initialize();
                                if (conn.openConnection())
                                {
                                    string sql1 = "SELECT * from appartement where responsable=@id";
                                    var cmd1 = new MySqlCommand(sql1, conn.getConnection());
                                    cmd1.Parameters.AddWithValue("@id", id);
                                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                                    if (!reader1.Read())
                                    {
                                        textError.Text = "There is no appartement!";
                                        formError.Visibility = Visibility.Visible;
                                        txtUsername.Clear();
                                        txtPassword.Clear();
                                    }
                                    else
                                    {
                                        string appId = reader1["id"].ToString();
                                        Dashboard d = new Dashboard(id, appId);
                                        this.Close();
                                        d.Show();
                                    }
                                }
                                
                            }
                            catch (MySqlException)
                            {
                                textError.Text = "Error checking 1";
                                formError.Visibility = Visibility.Visible;
                            }
                            
                            
                        }
                    }
                    catch (MySqlException)
                    {
                        textError.Text = "Error checking 2";
                        formError.Visibility = Visibility.Visible;
                    }

                }
            } else
            {
                textError.Text = "Cannot connect to database!";
                formError.Visibility = Visibility.Visible;
            }

        }
    }
}
