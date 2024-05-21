using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library

{
    public class ENProductos
    {
        public int id_producto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
            }
        }

        public string nom_producto
        {
            get
            {
                return nomProducto;
            }

            set
            {
                nomProducto = value;
            }

        }

        public string desc_producto
        {
            get
            {
                return descProducto;
            }
            set
            {
                descProducto = value;
            }
        }

        public float pre_producto
        {
            get
            {
                return preProducto;
            }
            set
            {
                preProducto = value;
            }
        }

        public string tipo_producto
        {
            get
            {
                return tipoProducto;
            }

            set
            {
                tipoProducto = value;
            }
        }

        public string categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }
         public DataTable getBetterReviewed()
        {
            CADProductos p = new CADProductos();
            return p.getMostSold();
        }

        public DataTable getRecommended()
        {
            CADProductos p = new CADProductos();
            return p.getMostSold();
        }

        public DataTable getMostSold()
        {
            CADProductos p = new CADProductos();
            return p.getMostSold();
        }

        public string ImageLocation
        {
            get
            {
                return imaProducto;
            }
            set
            {
                imaProducto = value;
            }
        }


        private int idProducto;
        private string nomProducto;
        private string descProducto;
        private float preProducto;
        private string tipoProducto;
        private string imaProducto;

        public ENProductos() { }

        public ENProductos(int idProducto, string nomProducto, string descProducto, float preProducto, string tipoProducto, string imaProductos)
        {
            id_producto = idProducto;
            nom_producto = nomProducto;
            desc_producto = descProducto;
            pre_producto = preProducto;
            tipo_producto = tipoProducto;
            ImageLocation = imaProducto;
        }
        public bool readProducto()
        {
            CADProductos cpro = new CADProductos();
            return cpro.readProductos(this);
        }

        public bool createProducto()
        {
            CADProductos cpro = new CADProductos();
            return cpro.createProductos(this);
        }

        public bool deleteProductos()
        {
            CADProductos cpro = new CADProductos();
            return cpro.deleteProductos(this);
        }

        public bool updateProductos()
        {
            CADProductos cpro = new CADProductos();
            return cpro.updateProductos(this);
        }

    }
}
