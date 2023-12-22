using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ServicioNegocio
    {
        public List<Servicio> listarServicios()
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();


            datos.setConsulta("select IdServicio, IdCliente, NombreCliente, Telefono, Mail, Dni, FACliente, ActivoCliente, IdAbonoMensual, IdFormaPagoAm,\nFechaVencimiento1, FechaVencimiento2, Pagado, IdFormaPago, FormaPago, IdPlan, CantidadMegas, Precio,NombrePlan, IdDomicilio, Direccion,\nBarrio, Ciudad, DireccionComentarios, FechaAltaServicio,ID_Estado, Estado, ComentarioServicios from VistaServicios");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Servicio aux = new Servicio();
                // Datos Servicio
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Comentarios = (string)datos.Lector["ComentarioServicios"];
                aux.FechaAlta = (DateTime)datos.Lector["FechaAltaServicio"];

                EstadoServicio estadoAux = new EstadoServicio();
                estadoAux.Id = (int)datos.Lector["ID_Estado"];
                estadoAux.Descripcion = (string)datos.Lector["Estado"];
                aux.Estado = estadoAux;

                //Datos Cliente
                Cliente ClienteAux = new Cliente();
                ClienteAux.IdCliente = (int)datos.lector["IdCliente"];
                ClienteAux.Nombre = (string)datos.Lector["NombreCliente"];
                ClienteAux.Telefono = (string)datos.lector["Telefono"];
                ClienteAux.Mail = (string)datos.lector["Mail"];
                ClienteAux.Dni = (string)datos.lector["Dni"];
                ClienteAux.FechaAlta = (DateTime)datos.lector["FACliente"];
                ClienteAux.Activo = (bool)datos.lector["ActivoCliente"];

                aux.Cliente = ClienteAux;

                // Datos Abono mensual
                AbonoMensual abonoMensualAux = new AbonoMensual();
                abonoMensualAux.IdAbonoMensual = (int)datos.lector["IdAbonoMensual"];

                FormaPago formaPagoAux = new FormaPago();
                formaPagoAux.IdFormaPago = (int)datos.lector["IdFormaPagoAm"];
                formaPagoAux.Nombre = (string)datos.lector["FormaPago"];
                abonoMensualAux.FormaPago = formaPagoAux;

                abonoMensualAux.FechaVencimiento1 = (DateTime)datos.lector["FechaVencimiento1"];
                abonoMensualAux.FechaVencimiento2 = (DateTime)datos.lector["FechaVencimiento2"];
                abonoMensualAux.Pagado = (bool)datos.lector["Pagado"];
                aux.AbonoMensual = abonoMensualAux;


                // Datos Plan
                TPlan planAux = new TPlan();
                planAux.IdPlan = (int)datos.lector["IdPlan"];
                planAux.CantidadMegas = (int)datos.lector["CantidadMegas"];
                planAux.Precio = (decimal)datos.lector["Precio"];
                planAux.Nombre = (string)datos.lector["NombrePlan"];
                aux.Plan = planAux;

                // Datos Domicilio
                Domicilio domicilioAux = new Domicilio();
                domicilioAux.IdDomicilio = (int)datos.lector["IdDomicilio"];
                domicilioAux.Direccion = (string)datos.lector["Direccion"];
                domicilioAux.Barrio = (string)datos.lector["Barrio"];
                domicilioAux.Ciudad = (string)datos.lector["Ciudad"];
                domicilioAux.Comentario = (string)datos.lector["DireccionComentarios"];
                aux.Domicilio = domicilioAux;
                lista.Add(aux);

            }

            return lista;
        }
        public int agregarServicio(Servicio nuevo)
        {
            int idservicio = -1;
            int idCliente = nuevo.Cliente.IdCliente;
            int idDomicilio = nuevo.Domicilio.IdDomicilio;
            int idPlan = nuevo.Plan.IdPlan;
            int idAbonoMensual = nuevo.AbonoMensual.IdAbonoMensual;
            DateTime FechaAlta = DateTime.Now;
            string comentarios = nuevo.Comentarios;

            string query = "insert into Servicio(IdCliente,IdDomicilio,IdPlan,IdAbonoMensual,FechaAlta,Estado,Comentarios) values (@idCliente,@idDomicilio,@idPlan,@idAbonoMensual,@FechaAlta,1,@comentarios)" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(query);
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@idDomicilio", idDomicilio);
                datos.setearParametro("@idPlan", idPlan);
                datos.setearParametro("@idAbonoMensual", idAbonoMensual);
                datos.setearParametro("@FechaAlta", FechaAlta);
                datos.setearParametro("@comentarios", comentarios);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idservicio = (int)datos.Lector["ID"];
                }


                return idservicio;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public void activarServicio(int IdServicio)
        {
            try
            {
                DateTime FechaRealizado = DateTime.Now;
                AccesoDatos Datos = new AccesoDatos();
                Datos.setConsulta("Update Servicio set Estado = 1 where IdServicio = @IdServicio");
                Datos.setearParametro("@IdServicio", IdServicio);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void BajaLogica(int IdServicio)
        {
            try
            {
                DateTime FechaRealizado = DateTime.Now;
                AccesoDatos Datos = new AccesoDatos();
                Datos.setConsulta("Update Servicio set Estado = 0 where IdServicio = @IdServicio");
                Datos.setearParametro("@IdServicio", IdServicio);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Cliente> listarClientesSinServicios()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            datos.setConsulta("select C.IdCliente as IdCliente, Nombre, Telefono, Mail, Dni, C.FechaAlta as FechaAlta, Activo from Cliente C\r\nleft join Servicio as S on S.IdCliente = C.IdCliente\r\nwhere S.IdServicio is null");
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
        public List<Servicio> buscarServicio(int IdServicio)
        {
            List<Servicio> lista = new List<Servicio>();
            AccesoDatos datos = new AccesoDatos();


            datos.setConsulta("select IdServicio, IdCliente, NombreCliente, Telefono, Mail, Dni, FACliente, ActivoCliente, IdAbonoMensual, IdFormaPagoAm,\nFechaVencimiento1, FechaVencimiento2, Pagado, IdFormaPago, FormaPago, IdPlan, CantidadMegas, Precio,NombrePlan , IdDomicilio, Direccion,\nBarrio, Ciudad, DireccionComentarios, FechaAltaServicio,ID_Estado, Estado, ComentarioServicios from VistaServicios where IdServicio = @IdServicio");
            datos.setearParametro("@IdServicio", IdServicio);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Servicio aux = new Servicio();
                // Datos Servicio
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Comentarios = (string)datos.Lector["ComentarioServicios"];
                aux.FechaAlta = (DateTime)datos.Lector["FechaAltaServicio"];

                EstadoServicio estadoAux = new EstadoServicio();
                estadoAux.Id = (int)datos.Lector["ID_Estado"];
                estadoAux.Descripcion = (string)datos.Lector["Estado"];
                aux.Estado = estadoAux;

                //Datos Cliente
                Cliente ClienteAux = new Cliente();
                ClienteAux.IdCliente = (int)datos.lector["IdCliente"];
                ClienteAux.Nombre = (string)datos.Lector["NombreCliente"];
                ClienteAux.Telefono = (string)datos.lector["Telefono"];
                ClienteAux.Mail = (string)datos.lector["Mail"];
                ClienteAux.Dni = (string)datos.lector["Dni"];
                ClienteAux.FechaAlta = (DateTime)datos.lector["FACliente"];
                ClienteAux.Activo = (bool)datos.lector["ActivoCliente"];

                aux.Cliente = ClienteAux;

                // Datos Abono mensual
                AbonoMensual abonoMensualAux = new AbonoMensual();
                abonoMensualAux.IdAbonoMensual = (int)datos.lector["IdAbonoMensual"];

                FormaPago formaPagoAux = new FormaPago();
                formaPagoAux.IdFormaPago = (int)datos.lector["IdFormaPagoAm"];
                formaPagoAux.Nombre = (string)datos.lector["FormaPago"];
                abonoMensualAux.FormaPago = formaPagoAux;

                abonoMensualAux.FechaVencimiento1 = (DateTime)datos.lector["FechaVencimiento1"];
                abonoMensualAux.FechaVencimiento2 = (DateTime)datos.lector["FechaVencimiento2"];
                abonoMensualAux.Pagado = (bool)datos.lector["Pagado"];
                aux.AbonoMensual = abonoMensualAux;


                // Datos Plan
                TPlan planAux = new TPlan();
                planAux.IdPlan = (int)datos.lector["IdPlan"];
                planAux.CantidadMegas = (int)datos.lector["CantidadMegas"];
                planAux.Precio = (decimal)datos.lector["Precio"];
                planAux.Nombre = (string)datos.lector["NombrePlan"];
                aux.Plan = planAux;

                // Datos Domicilio
                Domicilio domicilioAux = new Domicilio();
                domicilioAux.IdDomicilio = (int)datos.lector["IdDomicilio"];
                domicilioAux.Direccion = (string)datos.lector["Direccion"];
                domicilioAux.Barrio = (string)datos.lector["Barrio"];
                domicilioAux.Ciudad = (string)datos.lector["Ciudad"];
                domicilioAux.Comentario = (string)datos.lector["DireccionComentarios"];
                aux.Domicilio = domicilioAux;
                lista.Add(aux);

            }

            return lista;
        }
        public void EditarEstado(int IdServicio, int IdEstado)
        {
            try
            {
                DateTime FechaRealizado = DateTime.Now;
                AccesoDatos Datos = new AccesoDatos();
                Datos.setConsulta("Update Servicio set Estado = @IdEstado where IdServicio = @IdServicio");
                Datos.setearParametro("@IdServicio", IdServicio);
                Datos.setearParametro("@IdEstado", IdEstado);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void modificarDomicilio (int IdServicio, int IdDomicilio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Update Servicio set IdDomicilio = @IdDomicilio where IdServicio = @IdServicio");
                datos.setearParametro("@IdDomicilio", IdDomicilio);
                datos.setearParametro("@IdServicio", IdServicio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void modificarPlan(int IdServicio, int IdPlan)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Update Servicio set IdPlan = @IdPlan where IdServicio = @IdServicio");
                datos.setearParametro("@IdPlan", IdPlan);
                datos.setearParametro("@IdServicio", IdServicio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void modificarFormaPago(int IdServicio, int IdAbono)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Update Servicio set IdAbonoMensual = @IdAbono where IdServicio = @IdServicio");
                datos.setearParametro("@IdAbono", IdAbono);
                datos.setearParametro("@IdServicio", IdServicio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

    }
}
