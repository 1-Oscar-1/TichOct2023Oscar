using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolaMundoWFDOS
{
    public class CrudAdo
    {
        List<Estado> listaEstados = new List<Estado>
        {
            new Estado{id = 1, nombre = "Veracruz"},
            new Estado{id = 2, nombre = "Oaxaca"},
            new Estado{id = 3, nombre = "Queretaro"},
            new Estado{id = 4, nombre = "Puebla"}
        };
        public List<Estado> Consultar()
        {
            return listaEstados;
        }
    }
}