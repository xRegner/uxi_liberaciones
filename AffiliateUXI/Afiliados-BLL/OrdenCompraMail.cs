using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UxiEntities;

namespace AffiliateUXI.Afiliados_BLL
{
    public class OrdenCompraMail
    {
        public string generaMAILODC(List<OrdenCompraAll> _objODC)
        {
            string resultado = string.Empty;
            resultado = "<style type='text/css'>                                                                                                                                                                                              ";
            resultado += ".tg  {border-collapse:collapse;border-spacing:0;border-color:#999;}                                                                                                                                                  ";
            resultado += ".tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#444;background-color:#F7FDFA;}                   ";
            resultado += ".tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#999;color:#fff;background-color:#26ADE4;}";
            resultado += ".tg .tg-yw4l{vertical-align:top}                                                                                                                                                                                     ";
            resultado += "</style>                                                                                                                                                                                                             ";
            resultado += "<table class='tg'>                                                                                                                                                                                                   ";
            resultado += "  <tr>                                                                                                                                                                                                               ";
            resultado += "    <th class='tg-yw4l'>Servicio</th>                                                                                                                                                                                ";
            resultado += "    <th class='tg-yw4l'>Precio Venta </th>                                                                                                                                                                           ";
            resultado += "    <th class='tg-yw4l'>IMEI</th>                                                                                                                                                                                    ";
            resultado += "    <th class='tg-yw4l' colspan='2'>Estatus</th>                                                                                                                                                                     ";
            resultado += "  </tr>                                                                                                                                                                                                              ";
            foreach (OrdenCompraAll rep in _objODC)
            {
                resultado += "  <tr>                                                                                                                                                                                                               ";
                resultado += "    <td class='tg-yw4l'>"+rep.Descripcion_Larga+"</td>                                                                                                                                                                          ";
                resultado += "    <td class='tg-yw4l'>"+rep.PrecioVenta+" MXN</td>                                                                                                                                                                              ";
                resultado += "    <td class='tg-yw4l'>"+rep.IMEI+"</td>                                                                                                                                                                         ";
                resultado += "    <td class='tg-yw4l' colspan='2'>"+rep.descripcion+"</td>                                                                                                                                                                      ";
                resultado += "  </tr>                                                                                                                                                                                                              ";
            }
            resultado += "  <tr>                                                                                                                                                                                                               ";
            resultado += "    <td class='tg-yw4l'></td>                                                                                                                                                                                        ";
            resultado += "    <td class='tg-yw4l'></td>                                                                                                                                                                                        ";
            resultado += "    <td class='tg-yw4l'></td>                                                                                                                                                                                        ";
            resultado += "    <td class='tg-yw4l'>MONTO TOTAL</td>                                                                                                                                                                             ";
            resultado += "    <td class='tg-yw4l'>$"+_objODC[0].Total+"MXN</td>                                                                                                                                                                                 ";
            resultado += "  </tr>                                                                                                                                                                                                              ";
            resultado += "  <tr>                                                                                                                                                                                                               ";
            resultado += "    <td class='tg-yw4l' colspan='2'>A nombre de:"+_objODC[0].Nombre+ " "+ _objODC[0].apPaterno+ "</td>                                                                                                                                              ";
            resultado += "    <td class='tg-yw4l' colspan='3'>Email: "+ _objODC[0].email+ " Telefono:"+_objODC[0].telefono+"</td>                                                                                                                           ";
            resultado += "  </tr>                                                                                                                                                                                                              ";
            resultado += "</table>                                                                                                                                                                                                             ";

            return resultado;
        }
    }
}