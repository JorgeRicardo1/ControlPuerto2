using System;
using System.Collections.Generic;
using System.Text;

namespace ControlPuerto2.Models
{
    public class BbbarcosModel
    {
        public int id_nave { get; set; }
        public string nav_omi { get; set; }
        public string nav_numero { get; set; }
        public string nav_nombre { get; set; }
        public string nav_pais { get; set; }
        public string nav_mmsi { get; set; }
        public int nav_tipo { get; set; }
        public double nav_ab { get; set; }
        public double nav_an { get; set; }
        public double nav_dwt { get; set; }
        public double nav_eslora { get; set; }
        public double nav_manga { get; set; }
        public double nav_calado { get; set; }
        public double nav_creado { get; set; }
        public int nav_doble { get; set; }
        public int nav_clasif { get; set; }
        public string nav_armad { get; set; }
        public string nav_dueno { get; set; }
        public string nav_armnm { get; set; }
        public string nav_duennm { get; set; }
        public string nav_asigna { get; set; }
        public int nav_estado { get; set; }
        public DateTime nav_Afecha { get; set; }
        public DateTime nav_Zfecha { get; set; }
    }
}
