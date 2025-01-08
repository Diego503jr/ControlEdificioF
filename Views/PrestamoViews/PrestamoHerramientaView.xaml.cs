using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
using static System.Collections.Specialized.BitVector32;

namespace ControlEdificioF.Views.PrestamoViews
{
    /// <summary>
    /// Lógica de interacción para PrestamoHerramientaView.xaml
    /// </summary>
    public partial class PrestamoHerramientaView : Page
    {
        public PrestamoHerramientaView()
        {
            InitializeComponent();
        }

        #region VARIABLES 

        // Variables para manejar el evento que se esta realizando
        private bool agregando = false, 
             editando = false;

        // Variables para obtener los id's
        private int IdDocente = -1, 
            IdEstado = -1,
            IdHerramienta = -1,
            IdCentroComputo = -1;

        #endregion


        #region METODOS PERSONALIZADOS

        // Metodo para manejar el la hora y las fechas actuales
        void ManejarHoraFecha()
        {
            //Establecer las variables para obtener fecha y tiempo
            DateOnly dto = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly tmo = TimeOnly.FromDateTime(DateTime.Now);

            dtpFechaPrestamoHerramienta.Text = Convert.ToString(dto);
            tmpHoraEntregaHerramienta.Text = Convert.ToString(tmo);
        }

        // Metodo para validar entradas del formulario
        bool ValidarFormulario()
        {
            bool estado = true;
            string msj = "";

            //Formulario Docente
            if(cbDocentePrestamo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Docente\n";
            }

            if(string.IsNullOrEmpty(dtpFechaPrestamoHerramienta.Text))
            {
                estado = false;
                msj += "Fecha de prestamo";
            }

            if(cbCentroComputo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Centro Computo\n";
            }

            if(cbHerramienta.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Herramienta\n";
            }

            if(string.IsNullOrEmpty(txtCantidadPrestamoHerramienta.Text))
            {
                estado = false;
                msj += "Cantidad a prestar\n";
            }

            if(cbEstadoPrestamo.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Estado del prestamo\n";
            }

            //Formulario Tecnico
            if (cbTecnicoEntrega.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Entrega Tecnico\n";
            }

            if (string.IsNullOrEmpty(tmpHoraEntregaHerramienta.Text))
            {
                estado = false;
                msj += "Fecha de Entrega\n";
            }

            if (cbTecnicoRecibe.SelectedIndex <= -1)
            {
                estado = false;
                msj += "Recibe Tecnico\n";
            }

            if (string.IsNullOrEmpty(tmpHoraRecibeHerramienta.Text))
            {
                estado = false;
                msj += "Fecha de Devolucion\n";
            }

            if (!estado)
            {
                MessageBox.Show("Necesita completar los siguientes parametros :\n"+msj, "Validar Formulario", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return estado;
        }

        // Metodo para controlar las acciones del formulario
        void ControlFormulario()
        {
            if(dgPrestamoHerramienta.Items.Count == 0)
            {
                btnCrear.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Collapsed;

                spFormulario.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnCrear.Visibility= Visibility.Visible;
                btnEditar.Visibility= Visibility.Visible;

                spFormulario.Visibility = Visibility.Collapsed;
            }

            if (agregando || editando)
            {
                if(agregando)
                {
                    btnCrear.Visibility = Visibility.Visible;
                    btnEditar.Visibility = Visibility.Collapsed;

                    spFormulario.Visibility = Visibility.Visible;
                    btnDevuelto.Visibility = Visibility.Collapsed;
                }
                else if(editando)
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
            //Formulario Docente
            cbDocentePrestamo.Items.Clear();
            dtpFechaPrestamoHerramienta.SelectedDate = null;
            cbCentroComputo.Items.Clear();
            cbHerramienta.Items.Clear();
            txtCantidadPrestamoHerramienta.Clear();
            cbEstadoPrestamo.Items.Clear();
            txtDUIEntregado.Clear();
            txtDUIRecibido.Clear();

            //Formulario Tecnico
            cbTecnicoEntrega.Items.Clear();
            tmpHoraEntregaHerramienta.SelectedTime = null;
            cbTecnicoEntrega.Items.Clear();
            tmpHoraRecibeHerramienta.SelectedTime = null;
        }
        #endregion


        #region METODOS DEL FORMULARIOS

        // Boton para crear un prestamo
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
            
            agregando = true;
            editando = false;
            dgPrestamoHerramienta.IsEnabled = false;

            ManejarHoraFecha();
            cbDocentePrestamo.Focus();
            ControlFormulario();
        }

        // Boton para actualizar el prestamo
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            agregando = false;
            editando = true;

            ManejarHoraFecha();
            cbDocentePrestamo.Focus();
            ControlFormulario();
        }

        // Boton para realizar la entrega
        private void btnEntregar_Click(object sender, RoutedEventArgs e)
        {
            // Se valida que el formulario este lleno
            if(ValidarFormulario())
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
                dgPrestamoHerramienta.IsEnabled = true;
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
