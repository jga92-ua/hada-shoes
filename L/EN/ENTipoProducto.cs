using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
	public class ENTipoProducto
	{
		public string _tipo_producto;
		public string tipo_producto
		{
			get { return tipo_producto; }
			set { tipo_producto = value; }
		}

		public ENTipoProducto()
		{
			tipo_producto = "";
		}

		public ENTipoProducto(string tipo)
		{
			tipo_producto = tipo;
		}

		public bool createTipoProducto()
		{
			CADTipoProducto tip = new CADTipoProducto();
			return tip.createTipoProducto(this);
		}

		public bool readTipoProducto()
		{
			CADTipoProducto tip = new CADTipoProducto();
			return tip.readTipoProducto(this);
		}

		public bool updateTipoProducto()
		{
			CADTipoProducto tip = new CADTipoProducto();
			return tip.updateTipoProducto(this);
		}

		public bool deleteTipoProducto()
		{
			CADTipoProducto tip = new CADTipoProducto();
			return tip.deleteTipoProducto(this);
		}
	}
}
