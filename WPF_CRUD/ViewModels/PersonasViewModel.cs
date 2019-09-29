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
using WPF_CRUD.Enlaces.Commands;
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
                if(value != null && value.Count > 0)
                {
                    //Se selecciona por defecto el primer valor
                    this.CurrentPersona = value[0];
                }

                //Notificamos el cambio para la vista
                RaisePropertyChanged("ListaPersonas");
            }
        }

        private bool CanShowInfo
        {
            get => CurrentPersona != null;
        }

        private Persona currentPersona;
        public Persona CurrentPersona
        {
            get => currentPersona;
            set
            {
                currentPersona = value;
                //Notificamos el cambio para la vista
                RaisePropertyChanged("CurrentPersona");
                RaisePropertyChanged("canShowInfo");
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

        private ICommand _verInfoCommand;
        public ICommand VerInfoCommand
        {
            get
            {
                if (_verInfoCommand == null)
                    //Habilita o desabilita el boton de acuerdo a la propiedad CanShowInfo
                    _verInfoCommand = new RelayCommand(new Action(VerInfo), () => CanShowInfo);

                return _verInfoCommand;
            }
        }

        private ICommand _verMasCommand;
        public ICommand VerMasCommand
        {
            get
            {
                if (_verMasCommand == null)
                    _verMasCommand = new ParamCommand(new Action<object>(VerMas));

                return _verMasCommand;
            }
        }

        private ICommand _eliminarCommand;
        public ICommand EliminarCommand
        {
            get
            {
                if (_eliminarCommand == null)
                    _eliminarCommand = new ParamCommand(new Action<object>(EliminarPersona));

                return _eliminarCommand;
            }
        }


        public PersonasViewModel()
        {
            db = DbConnector.getInstance();
            ListarPersonas();
        }

        private void ListarPersonas()
        {
            ListaPersonas = db.listarPersonas();
        }

        private void VerInfo()
        {
            MessageBox.Show(this.CurrentPersona.Nombre);
        }

        private void VerMas(object persona)
        {
            if (persona != null)
            {
                CurrentPersona = (Persona)persona;
                MessageBox.Show($"Ver mas: {CurrentPersona.Nombre}");
            }
                
        }

        private void EliminarPersona(object persona)
        {
            if(persona != null)
            {
                CurrentPersona = (Persona)persona;
                if (MessageBox.Show($"Eliminar a: {CurrentPersona.Nombre}") == MessageBoxResult.OK)
                {
                    ListaPersonas.Remove(CurrentPersona);
                }
                    
            }
        }
    }
}
