using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back.Models
{
    public class Cliente
    {
        public int id {get;set;}=0;
        public string data {get;set;}=string.Empty;
        public string nome {get;set;}=string.Empty;
        public string telefone {get;set;}=string.Empty;
        public string email {get;set;}=string.Empty;
        public string cep {get;set;}=string.Empty;

        [JsonIgnore]
        public Loja loja {get;set;}=new Loja();


    }
}