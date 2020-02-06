using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppRealPromo.Models
{
    public class Promocao
    {
        //public int PromocaoId { get; set; }

        public string Empresa { get; set; }

        public string Chamada { get; set; }

        public string Regras { get; set; }

        public string EnderecoURL { get; set; }
    }
}
