using System;
using System.Collections.Generic;
using System.Linq;
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


            datos.setConsulta("select IdServicio, IdCliente, NombreCliente, Telefono, Mail, Dni, FACliente, ActivoCliente, IdAbonoMensual, IdFormaPagoAm,\nFechaVencimiento1, FechaVencimiento2, Pagado, IdFormaPago, FormaPago, IdPlan, CantidadMegas, Precio, IdDomicilio, Direccion,\nBarrio, Ciudad, DireccionComentarios, FechaAltaServicio, Estado, ComentarioServicios from VistaServicios");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Servicio aux = new Servicio();
                // Datos Servicio
                aux.IdServicio = (int)datos.Lector["IdServicio"];
                aux.Comentarios = (string)datos.Lector["ComentarioServicios"];
                aux.FechaAlta = (DateTime)datos.Lector["FechaAltaServicio"];
                aux.Estado = (bool)datos.Lector["Estado"];

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

                FormaPago formaPagoAux =    new FormaPago();
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
                aux.Plan = planAux;

                // Datos Domicilio
                Domicilio domicilioAux = new Domicilio();
                domicilioAux.IdDomicilio = (int)datos.lector["IdDomicilio"];
                domicilioAux.Direccion = (string)datos.lector["Direccion"];
                domicilioAux.Barrio = (string)datos.lector["Barrio"];
                domicilioAux.Ciudad = (string)datos.lector["Ciudad"];
                domicilioAux.Comentario = (string)datos.lector["DireccionComentarios"];
                aux.Domicilio= domicilioAux;
                lista.Add(aux);
                
            }

            return lista;
        }
    }
}
