using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLineaPedido
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



        public int num_pedido
        {
            get
            {
                return numPedido;
            }
            set
            {
                numPedido = value;
            }
        }


        public int _linea
        {
            get
            {
                return linea;
            }
            set
            {
                linea = value;
            }
        }


        public float _importe
        {
            get
            {
                return importe;
            }
            set
            {
                importe = value;
            }
        }

        public int _cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }

        private int idProducto;
        private int numPedido;
        private int linea;
        private float importe;
        private int cantidad;

        ENLineaPedido() { }

        ENLineaPedido(int idProducto, int numPedido, int linea, float importe, int cantidad)
        {
            id_producto = idProducto;
            num_pedido = numPedido;
            _linea = linea;
            _importe = importe;
            _cantidad = cantidad;
        }

        public bool readLinPed()//Pablo
        {
            CADLineaPedido cpro = new CADLineaPedido();
            return cpro.readLinPed(this);
        }

        public bool createProducto()
        {
            CADLineaPedido cpro = new CADLineaPedido();
            return cpro.createLinPed(this);
        }

        public bool deleteProductos()
        {
            CADLineaPedido cpro = new CADLineaPedido();
            return cpro.deleteLinPed(this);
        }

        public bool updateProductos()
        {
            CADLineaPedido cpro = new CADLineaPedido();
            return cpro.updateLinPed(this);
        }

    }
}
