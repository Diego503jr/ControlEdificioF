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

namespace ControlEdificioF.Views.PrestamoViews
{
    /// <summary>
    /// Lógica de interacción para PrestamoEquipoView.xaml
    /// </summary>
    public partial class PrestamoEquipoView : Page
    {
        public PrestamoEquipoView()
        {
            InitializeComponent();
        }

        #region VARIABLES 

        // Variables para manejar el evento que se esta realizando
        private bool agregando = false,
             editando = false;

        // Variables para obtener los id's
        private int IdEstudiante = -1,
            IdEstado = -1,
            IdCarrera = -1,
            IdCentroComputo = -1;

        #endregion


        #region METODOS PERSONALIZADOS

        // Metodo para manejar el la hora y las fechas actuales
        void ManejarHoraFecha()
        {
            //Establecer las variables para obtener fecha y tiempo
            DateOnly dto = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly tmo = TimeOnly.FromDateTime(DateTime.Now);

            dtpFechaPrestamoEquipo.Text = Convert.ToString(dto);
            tmpHoraEntregaEquipo.Text = Convert.ToString(tmo);
        }

        // Metodo para validar entradas del formulario
        bool ValidarFormulario()
        {
            bool estado = true;  
            string msj = "";

            if (cbEstudiantePrestamo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Docente\n";
            }

            if (string.IsNullOrEmpty(dtpFechaPrestamoEquipo.Text))
            {
                estado = false;
                msj += "Fecha de prestamo";
            }

            if (cbCarrera.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Carrera\n";
            }

            if (cbAsignarEquipo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Asignar Equipo\n";
            }

            if (cbCentroComputo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Centro Computo\n";
            }

            if (cbEstadoPrestamo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Estado del prestamo\n";
            }

            if (string.IsNullOrEmpty(txtCarnetEntregado.Text))
            {
                estado = false;
                msj += "Carnet Entregado\n";
            }

            if (string.IsNullOrEmpty(txtCarnetRecibido.Text))
            {
                estado = false;
                msj += "Carnet Recibido\n";
            }


            if (string.IsNullOrEmpty(tmpHoraEntregaEquipo.Text))
            {
                estado = false;
                msj += "Hora Entregado\n";
            }

            if (string.IsNullOrEmpty(tmpHoraRecibeEquipo.Text))
            {
                estado = false;
                msj += "Hora Recibido\n";
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
            if (dgPrestamoEquipo.Items.Count == 0)
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
                    btnDevuelto.Visibility = Visibility.Collapsed;
                }
                else if (editando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    spFormulario.Visibility = Visibility.Visible;
                    btnEntregar.Visibility = Visibility.Collapsed;
                }
            }
        }

        //Metodo para limpiar todo el formulario despues de hacer una accion
        void LimpiarFormulario()
        {
            cbEstudiantePrestamo.Items.Clear();
            dtpFechaPrestamoEquipo.SelectedDate = null;
            cbCarrera.Items.Clear();
            cbAsignarEquipo.Items.Clear();
            cbCentroComputo.Items.Clear();
            cbEstadoPrestamo.Items.Clear();
            txtCarnetEntregado.Clear();
            txtCarnetRecibido.Clear();
            tmpHoraEntregaEquipo.SelectedTime = null;
            tmpHoraRecibeEquipo.SelectedTime = null;
        }

        #endregion


        #region METODOS DEL FORMULARIO

        // Boton para crear un prestamo
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();

            agregando = true;
            editando = false;
            dgPrestamoEquipo.IsEnabled = false;

            ManejarHoraFecha();
            cbEstudiantePrestamo.Focus();
            ControlFormulario();
        }

        // Boton para actualizar el prestamo
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            agregando = false;
            editando = true;

            ManejarHoraFecha();
            cbEstudiantePrestamo.Focus();
            ControlFormulario();
        }

        // Boton para realizar la entrega
        private void btnEntregar_Click(object sender, RoutedEventArgs e)
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
                dgPrestamoEquipo.IsEnabled = true;
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
