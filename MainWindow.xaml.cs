using ControlEdificioF.Views.ComputoViews;
using ControlEdificioF.Views.GlobalViews;
using ControlEdificioF.Views.HerramientaViews;
using ControlEdificioF.Views.PrestamoViews;
using ControlEdificioF.Views.UsuarioViews;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlEdificioF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region -- INSTANCIAS --

        //Esta region contiene las instancias de las paginas que
        //se muestran en el componente Frame y de variables requeridas

        private PrestamoHerramientaView phv;

        #endregion
        
        public MainWindow()
        {
            InitializeComponent();
        }

        #region -- METODOS MENU --

        //Esta region contiene el metodo click de cada boton del menu y
        //abrir las paginas en el Frame donde se muestra cada pagina

        private void btnPrestamoHerramienta_Click(object sender, RoutedEventArgs e)
        {
            phv = new PrestamoHerramientaView();
            fPrincipal.NavigationService.Navigate(phv);
        }

        private void btnPrestamoEquipo_Click(object sender, RoutedEventArgs e)
        {
            PrestamoEquipoView pev = new PrestamoEquipoView();
            fPrincipal.NavigationService.Navigate(pev);
        }

        private void btnControlHerramientas_Click(object sender, RoutedEventArgs e)
        {
            ControlHerramientaView chv = new ControlHerramientaView();
            fPrincipal.NavigationService.Navigate(chv);
        }

        private void btnCentroComputo_Click(object sender, RoutedEventArgs e)
        {
            CentroComputoView ccv = new CentroComputoView();
            fPrincipal.NavigationService.Navigate(ccv);
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioView uv = new UsuarioView();
            fPrincipal.NavigationService.Navigate(uv);
        }

        private void btnEstudiante_Click(object sender, RoutedEventArgs e)
        {
            EstudianteView ev = new EstudianteView();
            fPrincipal.NavigationService.Navigate(ev);
        }

        private void btnEquipo_Click(object sender, RoutedEventArgs e)
        {
            EquipoView eqv = new EquipoView();
            fPrincipal.NavigationService.Navigate(eqv);
        }

        private void btnRoles_Click(object sender, RoutedEventArgs e)
        {
            RolWindow rw = new RolWindow();
            rw.ShowDialog();
        }

        private void btnCarreras_Click(object sender, RoutedEventArgs e)
        {
            CarreraWindow cw = new CarreraWindow();
            cw.ShowDialog();
        }

        private void btnEstado_Click(object sender, RoutedEventArgs e)
        {
            EstadoWindow ew = new EstadoWindow();
            ew.ShowDialog();
        }

        private void btnEstadoPrestamo_Click(object sender, RoutedEventArgs e)
        {
            EstadoPrestamoWindow epw = new EstadoPrestamoWindow();
            epw.ShowDialog();
        }

        private void btnMarca_Click(object sender, RoutedEventArgs e)
        {
            MarcaWindow maw = new MarcaWindow();
            maw.ShowDialog();
        }

        private void btnModelo_Click(object sender, RoutedEventArgs e)
        {
            ModeloWindow mow = new ModeloWindow();
            mow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            phv = new PrestamoHerramientaView();
            fPrincipal.Navigate(phv);
        }

        #endregion
    }
}