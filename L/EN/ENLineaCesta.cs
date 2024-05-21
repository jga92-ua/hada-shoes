using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLineaCesta
    {
        private int numCesta, linea;

        public int NumCesta
        {
            get { return this.numCesta; }
            set { this.numCesta = value; }
        }
        public int Linea
        {
            get { return this.linea; }
            set { this.linea = value; }
        }

        public ENLineaCesta()
        {
            this.numCesta = 0;
            this.linea = 0;
        }
        public ENLineaCesta(int numCesta, int linea)
        {
            this.numCesta = numCesta;
            this.linea = linea;
        }

        public bool addUnit()
        {
            int units = this.getUnits();
            if (units < 9999)
            {
                CADLineaCesta lc = new CADLineaCesta();
                return lc.setUnit(this, units + 1);
            }

            return false;
        }

        public bool substrUnit()
        {
            int units = this.getUnits();
            if (units > 1)
            {
                CADLineaCesta lc = new CADLineaCesta();
                return lc.setUnit(this, units - 1);
            }

            return false;
        }

        public bool removeItem()
        {
            CADLineaCesta lc = new CADLineaCesta();
            return lc.removeItem(this);
        }

        private int getUnits()
        {
            CADLineaCesta lc = new CADLineaCesta();
            return lc.getUnits(this);
        }
    }
}
