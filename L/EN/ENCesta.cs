using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCesta
    {
        private int numCesta;

        public int NumCesta
        {
            get { return numCesta; }
            set { numCesta = value; }
        }

        public ENCesta()
        {
            numCesta = -1;
        }

        public ENCesta(int numCesta)
        {
            NumCesta = numCesta;
        }

        public string getUserID()
        {
            CADCesta c = new CADCesta();
            return c.getUserID(this);
        }

        public bool AddNewBasketForUser(string dni)
        {
            CADCesta c = new CADCesta();
            return c.AddNewBasketForUser(dni);
        }

        public int getBasketByDNI(string dni)
        {
            CADCesta c = new CADCesta();
            return c.getBasketByDNI(dni);
        }

        public string getDNIByBasket(int basket)
        {
            CADCesta c = new CADCesta();
            return c.getDNIByBasket(basket);
        }

        public bool ProceedToBuy()
        {
            CADCesta c = new CADCesta();
            return c.ProceedToBuy(this);
        }

        public DataTable ShowBasketItems(string dni)
        {
            CADCesta c = new CADCesta();
            return c.ShowBasketItems(dni);
        }

        public void InsertItemsIntoOrders(int numCesta)
        {
            CADCesta c = new CADCesta();
            c.InsertItemsIntoOrders(numCesta);
        }

        public void DeleteItemsFromBasket(int numCesta)
        {
            CADCesta c = new CADCesta();
            c.DeleteItemsFromBasket(numCesta);
        }

        public bool CheckIfSomeItem()
        {
            CADCesta c = new CADCesta();
            return c.CheckIfSomeItem();
        }

        public bool CheckIfItemExists(int numCesta, int linea)
        {
            CADCesta c = new CADCesta();
            return c.CheckIfItemExists(numCesta, linea);
        }

        public bool CheckIfHaveBuyData(int numCesta)
        {
            CADCesta c = new CADCesta();
            string userID = this.getUserID();
            return c.CheckIfHaveBuyData(userID, numCesta);
        }

        public void InsertItemsIntoBasket(int numCesta, int producto, float importe, int cantidad)
        {
            CADCesta c = new CADCesta();
            c.InsertItemsIntoBasket(numCesta, producto, importe, cantidad);
        }
    }
}
