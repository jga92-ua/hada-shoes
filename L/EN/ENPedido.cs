using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENPedido
    {
        private int _numPedido;
        private string _dni;
        private string _fecha;

        public int numPedido
        {
            get { return _numPedido; }

            set { _numPedido = value; }
        }

        public string dni
        {
            get { return _dni; }

            set { _dni = value; }
        }

        public string fecha
        {
            get { return _fecha; }

            set { _fecha = value; }
        }
        public ENPedido(int numeroPedido, string dni, string fecha)
        {
            this.numPedido = numeroPedido;
            this.dni = dni;
            this.fecha = fecha;
        }

        public ENPedido()
        {
            this.numPedido = 0;
            this.dni = "";
            this.fecha = "";
        }

        public bool readPedido()
        {
            CADPedido m = new CADPedido();
            return m.readPedido(this);
        }

        public bool deletePedido()
        {
            bool retornar = false;
            CADPedido m = new CADPedido();
            if (m.readPedido(this))
            {
                retornar = m.deletePedido(this);
            }
            return retornar;
        }

        public bool createPedido()
        {
            bool retornar = false;
            CADPedido m = new CADPedido();
            if (!m.readPedido(this))
            {
                retornar = m.createPedido(this);
            }
            return retornar;
        }

        public bool modifyPedido(string nombrenuevo)
        {
            CADPedido m = new CADPedido();
            return m.modifyPedido(this);
        }

        public DataTable getPedidos(string dni)
        {
            CADPedido ped = new CADPedido();
            DataTable pedidos = ped.getPedidos(dni);
            return pedidos;
        }
    }
}
