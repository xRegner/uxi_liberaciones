using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace UxiEntities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Categoria
    {
        [JsonProperty(PropertyName = "IdCategoria")]
        public int IdCategoria { get; set; }
        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty(PropertyName = "Activo")]
        public bool? Activo { get; set; }
    }
}
