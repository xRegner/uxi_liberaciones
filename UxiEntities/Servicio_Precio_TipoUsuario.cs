using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UxiEntities
{
    public class Servicio_Precio_TipoUsuario
    {
        [JsonProperty(PropertyName = "IDServicioPrecioUsuario")]
        public int IDServicioPrecioUsuario { get; set; }
        [JsonProperty(PropertyName = "TipoCliente")]
        public int Tipocliente { get; set; }
        [JsonProperty(PropertyName = "Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        public Nullable<decimal> Precio { get; set; }
    }
}
