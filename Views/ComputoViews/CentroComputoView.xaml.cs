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
    /// Lógica de interacción para CentroComputoView.xaml
    /// </summary>
    public partial class CentroComputoView : Page
    {
        public CentroComputoView()
        {
            InitializeComponent();
        }

        #region INSTANCIAS

        ComputoEquiposView cev = new ComputoEquiposView();

        #endregion


        #region VARIABLES

        // Variables para manejar el evento que se esta realizando
        private bool agregando = false,
             editando = false;

        // Variables para obtener los id's
        private int IdCentroComputo = -1,
            IdEstado = -1;

        #endregion


        #region METODOS PERSONALIZADOS

        // Metodo para validar entradas del formulario
        bool ValidarFormulario()
        {
            bool estado = true;
            string msj = "";

            if (string.IsNullOrEmpty(txtComputo.Text))
            {
                estado = false;
                msj += "Centro de computo\n";
            }

            if (cbEstado.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Estado\n";
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
            if (dgCentroComputo.Items.Count == 0)
            {
                btnCrear.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Collapsed;

                gContenedorBotones.Visibility = Visibility.Collapsed;
                btnGuardar.Visibility = Visibility.Collapsed;
                btnCancelar.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnCrear.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Visible;

                gContenedorBotones.Visibility = Visibility.Collapsed;
                btnGuardar.Visibility = Visibility.Collapsed;
                btnCancelar.Visibility = Visibility.Collapsed;
            }

            if (agregando || editando)
            {
                if (agregando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    gContenedorBotones.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Visible;
                    btnCancelar.Visibility = Visibility.Visible;
                }
                else if (editando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    gContenedorBotones.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    btnCancelar.Visibility = Visibility.Visible;
                }
            }
        }

        //Metodo para limpiar todo el formulario despues de hacer una accion
        void LimpiarFormulario()
        {
            txtComputo.Clear();
            cbEstado.Items.Clear();
        }

        #endregion


        #region METODOS DEL FORMULARIO

        // Boton para ir a revisar los equipos que hay de un centro de computo
        private void btnVerInventario_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(cev);
        }

        // Boton para crear una centro de computo
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

            agregando = true;
            editando = false;
            dgCentroComputo.IsEnabled = false;

            txtComputo.Focus();
            ControlFormulario();
        }

        // Boton para actualizar un centro de computo
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            agregando = false;
            editando = true;

            txtComputo.Focus();
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
                dgCentroComputo.IsEnabled = true;
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
