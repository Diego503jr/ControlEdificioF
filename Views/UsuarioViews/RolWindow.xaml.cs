using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlEdificioF.Views.UsuarioViews
{
    /// <summary>
    /// Lógica de interacción para RolWindow.xaml
    /// </summary>
    public partial class RolWindow : Window
    {
        public RolWindow()
        {
            InitializeComponent();
        }

        #region VARIABLES 

        // Variables para manejar el evento que se esta realizando
        private bool agregando = false,
             editando = false;

        // Variables para obtener los id's
        private int IdRol = -1;

        #endregion


        #region METODOS PERSONALIZADOS

        // Metodo para validar entradas del formulario
        bool ValidarFormulario()
        {
            bool estado = true;
            string msj = "";

            if (string.IsNullOrEmpty(txtRol.Text))
            {
                estado = false;
                msj += "Rol\n";
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
            if (dgRol.Items.Count == 0)
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
            txtRol.Clear();
        }

        #endregion


        #region METODOS DEL FOMULARIO

        // Boton para crear una carrrera
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

            agregando = true;
            editando = false;
            dgRol.IsEnabled = false;

            txtRol.Focus();
            ControlFormulario();
        }

        // Boton para actualizar una carrera
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            agregando = false;
            editando = true;

            txtRol.Focus();
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
                dgRol.IsEnabled = true;
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
