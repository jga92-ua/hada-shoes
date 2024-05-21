using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        private string _dni;
        private string _nombre;
        private string _apellidos;
        private string _email;
        private string _contraseña;
        private int _telefono;
        private int _numTarjeta;
        private int _cvv;
        private string _expTarjeta;
        private string _fechanac; 
        private bool _admin;

        public ENUsuario(string dni, string nombre, string apellidos, string email, string contraseña, int tlf, string fechanac)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.contraseña = contraseña;
            this.tlf = tlf;
            this.fechanac = fechanac;
        }

        public ENUsuario()
        {
            this.dni = "";
            this.nombre = "";
            this.apellidos = "";
            this.email = "";
            this.contraseña = "";
            this.tlf = 0;
            this.cvv = 0;
            this.numTarjeta = 0;
            this.expTarjeta = "";
            this.fechanac = "";
        }

        public string dni
        {
            get { return _dni; }

            set { _dni = value; }
        }

        public string nombre
        {
            get { return _nombre; }

            set { _nombre = value; }
        }

        public string apellidos
        {
            get { return _apellidos; }

            set { _apellidos = value; }
        }

        public string email
        {
            get { return _email; }

            set { _email = value; }
        }

        public string contraseña
        {
            get { return _contraseña; }

            set { _contraseña = value; }
        }

        public int tlf
        {
            get { return _telefono; }

            set { _telefono = value; }
        }

        public int numTarjeta
        {
            get { return _numTarjeta; }

            set { _numTarjeta = value; }
        }

        public int cvv
        {
            get { return _cvv; }

            set { _cvv = value; }
        }

        public string expTarjeta
        {
            get { return _expTarjeta; }

            set { _expTarjeta = value; }
        }

        public string fechanac
        {
            get { return _fechanac; }

            set { _fechanac = value; }
        }

        public bool admin
        {
            get { return _admin; }

            set { _admin = value; }
        }


        public bool readUsuario()
        {
            bool devolver;
            CADUsuario usu = new CADUsuario();
            devolver = usu.readUsuario(this);
            return devolver;
        }

        public bool readUsuarioPago()
        {
            bool devolver;
            CADUsuario usu = new CADUsuario();
            devolver = usu.readUsuarioPago(this);
            return devolver;
        }

        public bool readUsuarioEmail()
        {
            bool devolver;
            CADUsuario usu = new CADUsuario();
            devolver = usu.readUsuarioEmail(this);
            return devolver;
        }


        public bool createUsuario()
        {
            bool devolver = false;
            CADUsuario usu = new CADUsuario();
            if (!usu.readUsuario(this))
            {
                devolver = usu.createUsuario(this);
            }
            return devolver;
        }


        public bool deleteUsuario()
        {
            CADUsuario us = new CADUsuario();
            return us.deleteUsuario(this);

        }


        public bool updateUsuario()
        {
            CADUsuario us = new CADUsuario();
            return us.updateUsuario(this);
        }

        public bool deletePedidoFromUsu()
        {
            CADUsuario ped = new CADUsuario();
            return ped.deletePedidoFromUsu(this);
        }

        public bool deleteValUsu()
        {
            CADUsuario ped = new CADUsuario();
            return ped.deleteValUsu(this);
        }

        public bool deleteCestaUsu()
        {
            CADUsuario ped = new CADUsuario();
            return ped.deleteCestaUsu(this);
        }

        public bool deleteDirEnvioUsu()
        {
            CADUsuario ped = new CADUsuario();
            return ped.deleteDirEnvioUsu(this);
        }

    }
}
