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
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Sistema_de_Informaciones_Hotel
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            //DataTable dt = new DataTable();
            //dt.Load(cod.ExecuteReader());
            //dtinternacion.DataContext = dt;
            //con.Close();
        }
        public void validarusuario()
        {
            try
            {
                string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
                MySqlConnection con = new MySqlConnection(connectionstring);

                MySqlCommand cod = new MySqlCommand("SELECT nombre_usuario,contraseña_usuario FROM usuario where nombre_usuario='" + tbxusuario.Text + "' AND contraseña_usuario='" + tbpassword.Password + "'", con);
                con.Open();

                MySqlDataReader dr = cod.ExecuteReader();

                if (dr.Read())
                {
                    Internacion viewinter = new Internacion();
                    viewinter.Show();
                    this.Close();
                }
                else {
                    MessageBoxResult result = MessageBox.Show("Datos Incorrectos", "Error");
                }

            }
            catch (Exception ex ) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Ingreso_Click(object sender, RoutedEventArgs e)
        {
            validarusuario();
            //if (tbxusuario.Text == "walter" && tbpassword.Password == "123")
            //{
            //    Internacion viewinter = new Internacion();  
            //    viewinter.Show();
            //    this.Close();
            //    System.Windows.Application.Current.Shutdown();
                
            //}
            //else 
            //{
            //    if (tbxusuario.Text != "walter")
            //    {
            //        MessageBoxResult result = MessageBox.Show("El usuario es incorrecto", "Error");
            //    }
            //    else {
            //        if (tbpassword.Password !="123") {
            //            MessageBoxResult result = MessageBox.Show("La contraseña es incorrecta", "Error");
            //        }
            //    }
            //     }
        }
                private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea Salir", "Salir", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) { 
            Close();
            }
        }
            
        }
    }

