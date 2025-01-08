using ControlEdificioF.Views.UsuarioViews;
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

namespace ControlEdificioF.Views.ComputoViews
{
    /// <summary>
    /// Lógica de interacción para EquipoView.xaml
    /// </summary>
    public partial class EquipoView : Page
    {
        public EquipoView()
        {
            InitializeComponent();
        }

        #region VARIABLES 

        // Variables para manejar el evento que se esta realizando
        private bool agregando = false,
             editando = false;

        // Variables para obtener los id's
        private int IdEquipo = -1,
            IdMarca = -1,
            IdEstado = -1,
            IdCentroComputo = -1;

        #endregion


        #region METODOS PERSONALIZADOS

        // Metodo para validar entradas del formulario
        bool ValidarFormulario()
        {
            bool estado = true;
            string msj = "";

            if (string.IsNullOrEmpty(txtEquipo.Text))
            {
                estado = false;
                msj += "Equipo\n";
            }

            if (cbModelo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Modelo\n";
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                estado = false;
                msj += "Codigo\n";
            }

            if (string.IsNullOrEmpty(txtSerie.Text))
            {
                estado = false;
                msj += "Serie\n";
            }

            if (string.IsNullOrEmpty(txtMicroprocesador.Text))
            {
                estado = false;
                msj += "Microprocesador\n";
            }

            if (string.IsNullOrEmpty(txtRAM.Text))
            {
                estado = false;
                msj += "RAM\n";
            }

            if (string.IsNullOrEmpty(txtDisco.Text))
            {
                estado = false;
                msj += "Disco\n";
            }

            if (cbEstado.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Estado\n";
            }

            if (cbCentroComputo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Centro Computo\n";
            }

            if (!estado)
            {
                MessageBox.Show("Necesita completar los siguientes parametros :\n" + msj, "Validar Formulario", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return estado;
        }

        // Metodo para controlar las acciones del formulario
        void ControlFormulario()
        {
            if (dgEquipos.Items.Count == 0)
            {
                btnCrear.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Collapsed;

                spFormulario.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnCrear.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Visible;

                spFormulario.Visibility = Visibility.Collapsed;
            }

            if (agregando || editando)
            {
                if (agregando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    spFormulario.Visibility = Visibility.Visible;
                }
                else if (editando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    spFormulario.Visibility = Visibility.Visible;
                }
            }
        }

        //Metodo para limpiar todo el formulario despues de hacer una accion
        void LimpiarFormulario()
        {
            txtEquipo.Clear();
            cbModelo.Items.Clear();
            txtCodigo.Clear();
            txtSerie.Clear();
            txtMicroprocesador.Clear();
            txtRAM.Clear();
            txtDisco.Clear();
            cbEstado.Items.Clear();
            cbCentroComputo.Items.Clear();
            txtDetalle.Clear();
        }

        #endregion


        #region METODOS DEL FOMULARIO

        // Boton para crear un equipo
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

            agregando = true;
            editando = false;
            dgEquipos.IsEnabled = false;

            txtEquipo.Focus();
            ControlFormulario();
        }

        // Boton para actualizar la herramienta
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            agregando = false;
            editando = true;

            txtEquipo.Focus();
            ControlFormulario();
        }

        // Boton para guardar la accion que se realiza
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Se valida que el formulario este lleno
            if (ValidarFormulario())
            {

            }
        }

        //Boton para cancelar la accion que se realiza
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (
               MessageBox.Show("Desea cancelar la operacion",
               "Accion",
               MessageBoxButton.YesNo,
               MessageBoxImage.Warning) == MessageBoxResult.Yes
               )
            {
                LimpiarFormulario();

                agregando = false;
                editando = false;

                ControlFormulario();
                dgEquipos.IsEnabled = true;
            }
        }

        // Metodo para que se carguen datos al dentrar al formulario
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ControlFormulario();
            LimpiarFormulario();
        }

        #endregion
    }
}
