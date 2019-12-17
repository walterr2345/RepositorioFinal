using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Sistema_de_Informaciones_Hotel
{    
    /// <summary>
    /// Lógica de interacción para Internacion.xaml
    /// </summary>
    public partial class Internacion : Window
    {
        Validacion validar = new Validacion();
        public Internacion()
        {
            InitializeComponent();
            string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
            MySqlConnection con = new MySqlConnection(connectionstring);
            con.Open();
            MySqlCommand cod = new MySqlCommand("SELECT * FROM vista_hospedaje", con);
            

            DataTable dt = new DataTable();
            dt.Load(cod.ExecuteReader());
            dtinternacion.DataContext = dt;
            con.Close();         
        }


        private void lblresr_Click(object sender, RoutedEventArgs e)
        {
            Reserva viewres = new Reserva();
            viewres.ShowDialog();
            this.Close();        
        }

        private void lbllabo_Click(object sender, RoutedEventArgs e)
        {
            Plaboratorio viewinter = new Plaboratorio();
            viewinter.Show();
            this.Close();
        }

        private void Lblimag_Click(object sender, RoutedEventArgs e)
        {
            Eimagenes viewima = new Eimagenes();
            viewima.Show();
            this.Close();
        }

        private void Lblfar_Click(object sender, RoutedEventArgs e)
        {
            Farmacia viewfar = new Farmacia();
            viewfar.Show();
            this.Close();
        }

        private void Txbnumeorhisotria_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);            
        }

        private void txbnumcam_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txbnumhabi_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txbnumblo_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Esta seguro que desea Salir", "Cerrar Sesión", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MainWindow pop = new MainWindow();
                pop.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.Show();
            this.Close();
        }

        private void registro_click(object sender, RoutedEventArgs e)
        {
            
            string obs = "Ninguna";
            string alta = "no";
            // int ocupado = 2;
            // int vacio = 1;

           
            int dias = (dpfechaingreso_Copy.SelectedDate.Value.Day)- (dpfechaingreso.SelectedDate.Value.Day);
            if (dias < 0)
            {
                MessageBox.Show("Los valores de salida son incorrectos");
            }
            else {

                if ( txbnumblo.Text == "" || txtnumeorhisotria.Text == "" || txbnumhabi.Text == "" || txbnumcam.Text == "")
                {
                    MessageBox.Show("Alerta", "Debes Llnar todos los datos");

                }
                else
                {

                    int numinter = Convert.ToInt32(txbnumreg.Text);
                    string fechaingreso = dpfechaingreso.SelectedDate.Value.ToString("yyyy-MM-dd");
                    string fechasalida = dpfechaingreso_Copy.SelectedDate.Value.ToString("yyyy-MM-dd");
                    int ncamilla = Convert.ToInt32(txbnumcam.Text);
                    int nhabitacion = Convert.ToInt32(txbnumhabi.Text);
                    int nbloque = Convert.ToInt32(txbnumblo.Text);
                    string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
                    MySqlConnection con = new MySqlConnection(connectionstring);
                    con.Open();
                    MySqlCommand cod = new MySqlCommand("SELECT" +
                        " numerohistoria_clinica from datos_pacientes where numerohistoria_clinica ='" +
                        txtnumeorhisotria.Text + "'", con);
                    MySqlDataReader dr = cod.ExecuteReader();

                    if (dr.Read())
                    {

                        string connectionstring2 = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
                        MySqlConnection conm = new MySqlConnection(connectionstring2);
                        MySqlCommand cod2 = new MySqlCommand("Insert", conm);
                        conm.Open();
                        MySqlCommand cod1 = conm.CreateCommand();
                        cod1.CommandText = "INSERT INTO hospedaje_internacion(numero_internacion,fecha_salida,fecha_ingreso,alta_hospedaje,dias_estadia,observacion,historia_clinica_Numero_historiaclinica)" +
                            " VALUES('" + numinter + "','" + fechasalida + "','" + fechaingreso + "','" + alta + "','" + dias + "','" + obs + "','" + txtnumeorhisotria.Text + "') ";
                        cod1.ExecuteNonQuery();
                        conm.Close();
                        txbnumreg.Clear();
                        txbnumblo.Clear();
                        txbnumcam.Clear();
                        txbnumhabi.Clear();


                    }
                    
                    else
                    {
                        MessageBox.Show("El Numero de Historial Clinico" + txtnumeorhisotria.Text + " no existe, ingrese otro", "Error");

                    }
                    con.Close();
                }

            }

            
        }
                    
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string si = "Si";
            string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
            MySqlConnection con = new MySqlConnection(connectionstring);
            con.Open();
            MySqlCommand cod = new MySqlCommand("SELECT" +
                " numerohistoria_clinica from datos_pacientes where numerohistoria_clinica ='" +
                txbnumreg.Text + "'", con);
            MySqlDataReader dr = cod.ExecuteReader();
            if (dr.Read()) { 
             string connecionstring2 = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
                MySqlConnection con2 = new MySqlConnection(connecionstring2);
                con2.Open();
                MySqlCommand cod1 = con2.CreateCommand();
                cod1.CommandText ="UPDATE hospedaje_internacion SET alta_hospedaje='"+ si+ "' where numero_internacion="+txbnumreg.Text;
                cod1.ExecuteNonQuery();
                con2.Close();
                //UPDATE SET `fecha_ingreso` = '2012/12/12' 
                //WHERE (`numero_internacion` = '5');
                //SET  cod_muestra='" + data13 + "',Tipo_analisis='" + data12 + "',fecha_solicitud='" + fechas1 + "',id_historiaclinica='" + data14 + "' WHERE id_solicitud=" + Nrosolh;


            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {                  
            string url = @"\\vista.pdf";
            string cadena = @"C:\\Users\\Ucatec Lab 1 Pc 15\\" + url;
            System.IO.FileStream file = new FileStream(cadena, FileMode.Create);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter write = PdfWriter.GetInstance(doc, file);
            doc.Open();
            doc.Add(new iTextSharp.text.Paragraph("Tabla"+dtinternacion.Columns));
            doc.Close();
            write.Close();
            file.Close();

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string connectionstring = "server = localhost; UID = root; PASSWORD = root; port =3307; database = sistemahospitalarioclinico;";
            MySqlConnection con = new MySqlConnection(connectionstring);
            con.Open();
            MySqlCommand cod = new MySqlCommand("SELECT * FROM vista_hospedaje", con);


            DataTable dt = new DataTable();
            dt.Load(cod.ExecuteReader());
            dtinternacion.DataContext = dt;
            con.Close();
        }
    }
  

}
