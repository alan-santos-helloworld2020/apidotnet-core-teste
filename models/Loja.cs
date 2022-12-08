
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back.Models
{
    public class Loja
    {

        public int id {get;set;} = 0;
        public string filial {get;set;} = string.Empty;
        public string telefone {get;set;} = string.Empty;
        public string email {get;set;} = string.Empty;
        public string endereco {get;set;} = string.Empty;        
        public List<Cliente> clientes {get;set;} = new List<Cliente>();
        
    }
}