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
    /// Lógica de interacción para Eimagenes.xaml
    /// </summary>
    public partial class Eimagenes : Window
    {
        Validacion validar = new Validacion();
        public Eimagenes()
        {
            InitializeComponent();
        }

        private void lblInternacion_Click(object sender, RoutedEventArgs e)
        {
            Internacion view = new Internacion();
            view.Show();
            this.Close();
        }

        private void lblresr_Click(object sender, RoutedEventArgs e)
        {
            Reserva view1 = new Reserva();
            view1.Show();
            this.Close();
        }

        private void lbllabo_Click(object sender, RoutedEventArgs e)
        {
            Plaboratorio view2 = new Plaboratorio();
            view2.Show();
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
            validar.validaralfabeto(sender, e);
        }

        private void txbnumhabi_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validaralfabeto(sender, e);
        }

        private void txbnumeorhisotria_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            validar.validarnum(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea cancelar el Pedido", "Salir", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Internacion viewinter = new Internacion();
                viewinter.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txbnumeorhisotria_Copy.Text == "" ||txbnumcam.Text == ""
                || txbnumeorhisotria.Text == "" || txbnumhabi.Text == "" ||
                 txbnumhabi_Copy.Text=="")
            {
                MessageBox.Show("Alerta", "Debes Llnar todos los datos");
            }
            else
            {
                MessageBox.Show("Se Envio el registro", "Envio");
                txbnumcam.Clear();
                txbnumeorhisotria.Clear();
                txbnumhabi.Clear();
                txbnumhabi_Copy.Clear();
                txbnumeorhisotria_Copy.Clear();
            }

        }
    }
}
