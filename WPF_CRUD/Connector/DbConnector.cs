using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CRUD.Models;

namespace WPF_CRUD.Connector
{
    public class DbConnector
    {
        private ObservableCollection<Persona> personas;
        private static DbConnector connector = null;
        private DbConnector()
        {
            crearListaPersonas();
        }

        public static DbConnector getInstance()
        {
            if (connector == null)
                connector = new DbConnector();
            return connector;
        }
        
        public ObservableCollection<Persona> listarPersonas()
        {
            return personas;
        }

        private void crearListaPersonas()
        {
            personas = new ObservableCollection<Persona>();
            personas.Add(new Persona(1, "Manuel"));
            personas.Add(new Persona(2, "Luis"));
            personas.Add(new Persona(3, "Jose Luis"));
            personas.Add(new Persona(4, "Rafael"));
            personas.Add(new Persona(5, "Mario Cesar"));
            personas.Add(new Persona(6, "Antonio"));
            personas.Add(new Persona(7, "Leonidas"));
            personas.Add(new Persona(8, "Margarita"));
        }

    }
}
