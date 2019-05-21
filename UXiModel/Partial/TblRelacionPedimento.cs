using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UxiEntities.Utilities;

namespace UXiModel
{
    public partial class TblRelacionPedimento
    {
        public TblRelacionPedimento(string request, int idUsuario, int idOrden)
        {
            List<string> values = request.Split('>').ToList();
            decimal monto = Convert.ToDecimal(values[0]);
            this.IdOrdenCompra = idOrden;
            this.Total = monto;
            this.UUM = idUsuario;
            this.FechaPedimento = DateTime.Now.Date;
            this.FUM = DateTime.Now.Date;
            this.IdDescuento = 0;
            this.IdEstatusPedimento = 1;
            this.IdProducto = Convert.ToInt32(values[1]);
            this.IMEI = values[2];
            if (!this.IMEI.IsValidImei())
                throw new Exception("IMEI Inválido");
            this.PrecioNeto = monto;
            this.PrecioVenta = monto;
            this.SKU = values[3];
        }
    }
}
