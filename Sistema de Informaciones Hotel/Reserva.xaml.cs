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
    /// Lógica de interacción para Reserva.xaml
    /// </summary>
    public partial class Reserva : Window
    {
        Validacion validar = new Validacion();
        public Reserva()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea cancelar la reserva", "Salir", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Internacion viewinter = new Internacion();
                viewinter.Show();
                this.Close();                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txbnumblo.Text == "" || txbnumcam.Text == ""
                || txbnumeorhisotria.Text == "" || txbnumhabi.Text == "" ||
                 txbnumhabi_Copy.Text == "")
            {
                MessageBox.Show("Alerta", "Debes Llnar todos los datos");
            }
            else
            {
                MessageBox.Show("Se Envio el registro", "Envio");
                txbnumcam.Clear();
                txbnumeorhisotria.Clear();
                txbnumblo.Clear();
                txbnumhabi_Copy.Clear();
                txbnumhabi.Clear();

            }
        }

        private void lblInternacion_Click(object sender, RoutedEventArgs e)
        {
            Internacion viewinter = new Internacion();
            viewinter.Show();
            this.Close();
        }

        private void Lblimag_Click(object sender, RoutedEventArgs e)
        {
            Eimagenes viewima = new Eimagenes();
            viewima.Show();
            this.Close();
        }

        private void Lbllabo_Click(object sender, RoutedEventArgs e)
        {
            Plaboratorio viewlabo = new Plaboratorio();
            viewlabo.Show();
            this.Close();
        }

        private void Lblfar_Click(object sender, RoutedEventArgs e)
        {
            Farmacia viewfarma = new Farmacia();
            viewfarma.Show();
            this.Close();
        }

        private void Txbnumeorhisotria_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txbnumcam_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }

        private void txbnumhabi_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }

        private void txbnumcam_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }

        private void txbnumcam_Copy1_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txbnumblo_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void txbnumhabi_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }
    }
}
