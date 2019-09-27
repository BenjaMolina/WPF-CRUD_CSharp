using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CRUD.Models
{
    public class Persona
    {
        private int id;
        public int Id
        {
            get => id;
            set => id = value;
        }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        private DateTime _fechaNaci;
        public DateTime FechaNaci
        {
            get => _fechaNaci;
            set => _fechaNaci = value;
        }

        public Persona() { }

        public Persona(int id, string nombre, DateTime fechaNaci)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.FechaNaci = fechaNaci;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
