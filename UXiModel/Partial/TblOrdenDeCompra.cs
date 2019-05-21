using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXiModel
{
    public partial class TblOrdenDeCompra
    {
        public TblOrdenDeCompra(int idUsuario, string Total)
        {
            this.IdUsuario = idUsuario;
            this.Total = Convert.ToDecimal(Total);
            this.IdEstatusOC = 1;
            this.FechaOrden = DateTime.Now.Date;
            this.FechaPagoMax = DateTime.Now.Date;
        }

    }
}
