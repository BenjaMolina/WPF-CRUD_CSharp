using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRUD.Models;

namespace WPF_CRUD.ViewModels
{
    class PersonasViewModel : BaseViewModel
    {
        private ObservableCollection<Persona> _listaPersonas =  new ObservableCollection<Persona>();

        public ObservableCollection<Persona> ListaPersonas {
            get => _listaPersonas;
            set => _listaPersonas = value;
        }

        private Persona currentPersona;
        public Persona CurrentPersona
        {
            get => currentPersona;
            set => currentPersona = value;
        }

        public PersonasViewModel()  { }
    }
}
