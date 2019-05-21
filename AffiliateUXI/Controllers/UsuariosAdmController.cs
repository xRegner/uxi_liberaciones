using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UXiModel;
using UxiEntities;

namespace AffiliateUXI.Controllers
{
    public class UsuariosAdmController : ApiController
    {
        // GET: api/UsuariosAdm
        public List<UxiEntities.USP_GetUsuarioCuenta_EE> Get()
        {
            List<USP_GetUsuarioCuenta_EE> resultado = new List<USP_GetUsuarioCuenta_EE>();

            using(uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                var query = from i in context.SPU_GetUsuarioCuenta()
                            select new USP_GetUsuarioCuenta_EE()
                            {
                                Activo = i.Activo,
                                ApMaterno = i.ApMaterno,
                                ApPaterno = i.ApPaterno,
                                Email = i.Email,
                                IdRol = i.IdRol,
                                IdUsuario = i.IdUsuario,
                                Nombre = i.Nombre,
                                saldoafavor=i.saldoafavor,
                                Telefono = i.Telefono,
                                TipoCliente = i.TipoCliente,
                                VerTarifas = i.VerTarifas
                            };

                resultado.AddRange(query);
                
            }


            return resultado;
        }

        //// GET: api/UsuariosAdm/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/UsuariosAdm
        public UXiModel.UXI_Usuarios Post(USP_GetUsuarioCuenta_EE Obj_nuevoUsr)
        {
            //buscar que el id usuario exista en cuenta contable 
            UXiModel.CuentaUsuario cuenta_resultado = new UXiModel.CuentaUsuario();
            UXiModel.UXI_Usuarios usuarios_cuenta = new UXI_Usuarios();
            
            using (uxisolutionbdEntities context = new uxisolutionbdEntities())
            {

                var query = from i in context.CuentaUsuario
                            where i.IdUsuario == Obj_nuevoUsr.IdUsuario
                            select i;

                if (!query.Any())
                {
                    cuenta_resultado.IdUsuario = Obj_nuevoUsr.IdUsuario;
                    cuenta_resultado.SaldoAFavor = Obj_nuevoUsr.saldoafavor;
                    cuenta_resultado.UUM = 0;
                    cuenta_resultado.FUM = DateTime.Now.Date;
                    cuenta_resultado.Activo = true;

                    cuenta_resultado = context.CuentaUsuario.Add(cuenta_resultado);
                    //salvar el saldo a favor

                    var saldo = context.HistorialSaldos.Add(new HistorialSaldos()
                    {
                        Fecha = DateTime.Now,
                        IdUsuario = Obj_nuevoUsr.IdUsuario,
                        UUM = Obj_nuevoUsr.IdUsuario,
                        Monto_Entrada = (decimal)Obj_nuevoUsr.saldoafavor,
                        IDTipoMovimiento = 2
                    });

                }


                else
                {
                    cuenta_resultado = context.CuentaUsuario.First(i => i.IdUsuario == Obj_nuevoUsr.IdUsuario);
                    cuenta_resultado.SaldoAFavor = cuenta_resultado.SaldoAFavor + Obj_nuevoUsr.saldoafavor;


                    var saldo = context.HistorialSaldos.Add(new HistorialSaldos()
                    {
                        Fecha = DateTime.Now,
                        IdUsuario = Obj_nuevoUsr.IdUsuario,
                        UUM = Obj_nuevoUsr.IdUsuario,
                        Monto_Entrada = (decimal)Obj_nuevoUsr.saldoafavor,
                        IDTipoMovimiento = 2
                    });
                   

                }
                context.SaveChanges();
            }

            // actualizar la tabla de usuarios llenar la entidad 

            using(uxisolutionbdEntities context = new uxisolutionbdEntities())
            {
                usuarios_cuenta = context.UXI_Usuarios.First(i => i.IdUsuario==Obj_nuevoUsr.IdUsuario);
                usuarios_cuenta.TipoCliente = Obj_nuevoUsr.TipoCliente;
                usuarios_cuenta.VerTarifas = Obj_nuevoUsr.VerTarifas;
                context.SaveChanges();
            }

            return usuarios_cuenta;
        }

        //// PUT: api/UsuariosAdm/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/UsuariosAdm/5
        //public void Delete(int id)
        //{
        //}
    }
}
