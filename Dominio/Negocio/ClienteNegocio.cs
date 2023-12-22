using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        

        public List<Cliente> listarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("Select IdCliente, Nombre, Telefono, Mail, Dni, FechaAlta, Activo from Cliente");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Cliente aux = new Cliente();
                aux.IdCliente = (int)datos.Lector["IdCliente"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Telefono = (string)datos.Lector["telefono"];
                aux.Mail = (string)datos.Lector["mail"];
                aux.Dni = (string)datos.Lector["Dni"];
                aux.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
                aux.Activo = (bool)datos.Lector["Activo"];


                lista.Add(aux);
            }

            return lista;
        }
        public List<Cliente> listarClientesInactivos()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("Select IdCliente, Nombre, Telefono, Mail, Dni, FechaAlta, Activo from Cliente where Activo = 0");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Cliente aux = new Cliente();
                aux.IdCliente = (int)datos.Lector["IdCliente"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Telefono = (string)datos.Lector["telefono"];
                aux.Mail = (string)datos.Lector["mail"];
                aux.Dni = (string)datos.Lector["Dni"];
                aux.FechaAlta = (DateTime)datos.Lector["FechaAlta"];
                aux.Activo = (bool)datos.Lector["Activo"];


                lista.Add(aux);
            }

            return lista;
        }
        public int agregarCliente(Cliente cliente)
        {
            int idcliente = -1;
            string nombre = cliente.Nombre;
            string telefono = cliente.Telefono;
            string mail= cliente.Mail;
            string dni = cliente.Dni;
            DateTime fechaalta= cliente.FechaAlta;
            bool activo = cliente.Activo;

            string query = "insert into Cliente(Nombre,Telefono,Mail,Dni,FechaAlta,Activo) VALUES (@nombre,@telefono,@mail,@dni,@fechaalta,@activo)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@nombre",nombre);
                datos.setearParametro("@telefono", telefono);
                datos.setearParametro("@mail", mail);
                datos.setearParametro("@dni", dni);
                datos.setearParametro("@fechaalta", fechaalta);
                datos.setearParametro("@activo", activo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idcliente = (int)datos.Lector["ID"];
                }
                

                return idcliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
            
        }
    }

}
