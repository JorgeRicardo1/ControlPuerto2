using System;
using System.Collections.Generic;
using System.Text;

namespace ControlPuerto2.Models
{
    public class XxxxciaoModel
    {
        public string obra { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string pasabordo { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string cargo { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public int status { get; set; }
        public int nivel { get; set; }
        public int nroprint { get; set; }
        public string pw { get; set; }

        //Para saber cuantos barcos tiene asignados(NO ESTA EN LA BD)
        public int BarcosAsignados { get; set; }
    }
}
