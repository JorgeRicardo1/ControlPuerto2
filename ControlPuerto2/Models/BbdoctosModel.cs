using System;
using System.Collections.Generic;
using System.Text;

namespace ControlPuerto2.Models
{
    public class BbdoctosModel
    {
        public int id_doctos { get; set; }
        public string doc_grupo { get; set; }
        public string doc_nombre { get; set; }
        public int doc_clase1 { get; set; }
        public int doc_clase2 { get; set; }
        public int doc_tipo { get; set; }
        public int doc_vence { get; set; }
        public string doc_extension { get; set; }
        public string doc_url { get; set; }
        public string doc_descripcion { get; set; }
        public int id_nave { get; set; }
    }
}
