using CommunityToolkit.Mvvm.Input;
using ControlEdificioF.Models;
using ControlEdificioF.Services.Contexts;
using ControlEdificioF.Services.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlEdificioF.ViewModels
{
    internal class RolViewModel : BaseViewModel
    {
        private readonly ConfigDb _config;
        private ObservableCollection<RolModel> _roles;
        private RolModel _rol;
        private RolContext _rolcontext;

        public RolViewModel()
        {
            _config = new ConfigDb()
            {
                Server = ConfigurationManager.AppSettings["SERVER"],
                Db = ConfigurationManager.AppSettings["DATABASE"],
                User = ConfigurationManager.AppSettings["USER"],
                Pwd = ConfigurationManager.AppSettings["PASSWORD"]
            };
            _rol = new RolModel();
            _roles = _rolcontext.Read();
        }

        public RolModel Rol
        {
            get => _rol;
            set
            {
                _rol = value;
                OnPropertyChanged(nameof(Rol));
            }
        }

        public ObservableCollection<RolModel> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        public ICommand RolCreateCommand
        {
            get
            {
                return new RelayCommand(RolExecuteCreate, RolCanExecuteCreate);
            }
        }

        private void RolExecuteCreate()
        {
            _rolcontext.Create(Rol);
            Roles = _rolcontext.Read();
        }

        private bool RolCanExecuteCreate()
        {
            return true;
        }
    }
}
