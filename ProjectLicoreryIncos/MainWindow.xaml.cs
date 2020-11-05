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
using Implementation;
using Model;
using System.Data;

namespace ProjectLicoreryIncos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        byte contador = 0;
        UserImplement brl;
        User user;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            if (contador >= 3)
            {
                MessageBox.Show("Supero la cantidad de intentos permitidos el login");
                this.Close();
            }
            else
            {
                if (txt_user.Text != "" && txt_password.Password != "")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        brl = new UserImplement();
                        dt = brl.login(txt_user.Text, txt_password.Password);
                        if (dt.Rows.Count > 0)
                        {


                            user=new User( byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString());
                            //string pass = txtPassword.Password;
                            this.Hide();
                            txt_user.Clear();
                            txt_password.Clear();
                            MainWin main = new MainWin(user,this);
                            main.Show();

                        }
                        else
                        {
                            MessageBox.Show( "Usuario y/o Contraseña Incorrecto");
                            contador++;

                            txt_user.Text = "";
                            txt_password.Password = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de Usuario y Contraseña");
                    contador++;
                }
            }
         }
    }
}
