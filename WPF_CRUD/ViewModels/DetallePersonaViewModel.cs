using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_CRUD.Enlaces;
using WPF_CRUD.Enlaces.Commands;
using WPF_CRUD.Models;

namespace WPF_CRUD.ViewModels
{
    public class DetallePersonaViewModel: BaseViewModel
    {
        private Persona personaDetalle;
        public Persona PersonaDetalle
        {
            get => personaDetalle;
            set
            {
                personaDetalle = value;
                RaisePropertyChanged("PersonaDetalle");
            }
        }

        private ICommand _verInfoCommand;
        public ICommand VerInfoCommand
        {
            get
            {
                if (_verInfoCommand == null)
                    _verInfoCommand = new RelayCommand(new Action(VerInfo));

                return _verInfoCommand;
            }
        }
        public DetallePersonaViewModel(Persona personaDetalle)
        {
            this.PersonaDetalle = personaDetalle;
        }

        public void VerInfo()
        {
            MessageBox.Show($"{personaDetalle.Nombre}");
        }
    }
}
