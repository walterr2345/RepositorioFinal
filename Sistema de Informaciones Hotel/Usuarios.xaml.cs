using MySql.Data.MySqlClient;
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

namespace Sistema_de_Informaciones_Hotel
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        Validacion validar = new Validacion();
        public Usuarios()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea cancelar el registro", "Salir", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Internacion viewinter = new Internacion();
                viewinter.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ci;
            string nombre;
            string apellido;
            string contra;
            int tipo=2;
            if (txtci.Text == "" || txtnom.Text == "" || txtape.Text == "" || txtcontra.Password == "")
            {
                MessageBox.Show("Ingrese Todos los datos", "Error");

            }
            else
            {
                if (txtconfir.Password == txtcontra.Password)
                {
                    contra = Convert.ToString(txtcontra.Password);
                    ci = Convert.ToInt32(txtci.Text);
                    nombre = Convert.ToString(txtnom.Text);
                    apellido = Convert.ToString( txtape.Text);
                    string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
                    MySqlConnection con = new MySqlConnection(connectionstring);
                    MySqlCommand cod = new MySqlCommand("Insert", con);
                    con.Open();
                    MySqlCommand ing = con.CreateCommand();
                    ing.CommandText = "INSERT INTO usuario(ci_usuario,nombre_usuario,apellido_ususario,contraseña_usuario,tipo_permiso)" +
                        " VALUES('" + ci + "','" + nombre + "','" + apellido + "','" + contra + "','" + tipo + "')";
                    ing.ExecuteNonQuery();
                    con.Close();
                    txtci.Clear();
                    txtnom.Clear();
                    txtape.Clear();
                    txtcontra.Clear();
                    txtconfir.Clear();
                }
                else {
                    MessageBox.Show("Las Contraseñas no son iguales", "Error");
                }
           /*
           
           System.Windows.MessageBox.Show("Muy Bien, Todos los datos ingresados son correctos");
               int historia = 0;
               numerosol = Convert.ToInt32(nrosol.Text);
               codmuestra = codm.Text;
               tipoanalisis = tipoanalisiss.Text;
               historia = Convert.ToInt32(nrohistoria.Text);



               string connectionString = "server = localhost; UID = root;PASSWORD=chio; database = base_laboratorio;";
               MySqlConnection con = new MySqlConnection(connectionString);

               con.Open();
               MySqlCommand comm = con.CreateCommand();
               comm.CommandText = "INSERT INTO solicitud(id_solicitud,cod_muestra,Tipo_analisis,fecha_solicitud,id_historiaclinica) VALUES('" + numerosol + "','" + codmuestra + "','" + tipoanalisis + "','" + this.fechas + "','" + historia + "')";
               comm.ExecuteNonQuery();
               System.Windows.MessageBox.Show("Solicitud ingresada");
               con.Close();
               NavigationService.Navigate(new band());
               nrosol.Text = "";
               codm.Text = "";
               tipoanalisiss.Text = "";
               nrohistoria.Text = "";
           }

           */
                //if (txbnumeorhisotria.Text == "" && txbnumhabi.Text=="" && txbnumcam.Text==""&& txbnumblo.Text=="" && dpfechaingreso.SelectedDate==null && txbhorain.Text=="") {
                //    MessageBox.Show("Llene todos los campos", "Error");
                //}

            }
        }

        private void txtci_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txtnom_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }

        private void txtape_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }
    }
}
