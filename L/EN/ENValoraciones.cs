using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENValoraciones
    {
        public string usuaro_id
        {
            get
            {
                return new string(usuario.ToCharArray());
            }

            set
            {
                usuario = value;
            }
        }

        public string tex_val
        {
            get
            {
                return new string(texto.ToCharArray());
            }

            set
            {
                texto = value;
            }
        }

        public int pun_val
        {
            get
            {
                return puntos;
            }

            set
            {
                puntos = value;
            }
        }

        public int producto_id
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public string estr_val
        {
            get
            {
                return new string(estrella.ToCharArray());
            }

            set
            {
                estrella = value;
            }
        }

        private string usuario;
        private int producto;
        private string texto;
        private int puntos;
        private string estrella;

        public ENValoraciones() { }

        public ENValoraciones(string usuario, string texto, int puntos, int producto)
        {
            producto_id = producto;
            usuaro_id = usuario;
            tex_val = texto;
            pun_val = puntos;
            estr_val = estrella;
        }
        public bool createValoracion()
        {
            CADValoraciones cval = new CADValoraciones();
            return cval.createValoraciones(this);
        }

        public bool readValoraciones()
        {
            CADValoraciones cval = new CADValoraciones();
            return cval.readValoraciones(this);
        }

        public bool deleteValoraciones()
        {
            CADValoraciones cval = new CADValoraciones();
            return cval.deleteValoraciones(this);
        }

        public bool updateValoraciones()
        {
            CADValoraciones cval = new CADValoraciones();
            return cval.updateValoraciones(this);
        }

        public bool readAuxValoraciones()
        {
            CADValoraciones cval = new CADValoraciones();
            return cval.readAuxValoraciones(this);
        }

        public DataTable showValo()
        {
            CADValoraciones p = new CADValoraciones();
            return p.showValo(this);
        }

    }
}