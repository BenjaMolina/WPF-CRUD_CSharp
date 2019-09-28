using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_CRUD.Connector;
using WPF_CRUD.Enlaces;
using WPF_CRUD.Models;

namespace WPF_CRUD.ViewModels
{
    class PersonasViewModel : BaseViewModel
    {
        private ObservableCollection<Persona> _listaPersonas =  new ObservableCollection<Persona>();
        private DbConnector db;

        public ObservableCollection<Persona> ListaPersonas
        {
            get => _listaPersonas;
            set
            {
                _listaPersonas = value;
                RaisePropertyChanged("ListaPersonas");
            }
        }

        private Persona currentPersona;
        public Persona CurrentPersona
        {
            get => currentPersona;
            set
            {
                currentPersona = value;
                RaisePropertyChanged("CurrentPersona"); //Notificamos el cambio para la vista
            }
        }

        private ICommand _listarPersonasCommand;
        public ICommand ListarPersonasCommand
        {
            get
            {
                if (_listarPersonasCommand == null)
                    _listarPersonasCommand = new RelayCommand(new Action(ListarPersonas));
                return _listarPersonasCommand;
            }
        }


        public PersonasViewModel()
        {
            db = DbConnector.getInstance();
        }

        private void ListarPersonas()
        {
            ListaPersonas = db.listarPersonas();
        }
    }
}
