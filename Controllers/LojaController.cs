using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        List<Cliente> cl = new(){
                new Cliente(){id=1,data=DateTime.Now.ToShortDateString(),nome="alan",telefone="37520913",email="alan@gmail.com",cep="25515045"},
                new Cliente(){id=2,data=DateTime.Now.ToShortDateString(),nome="paulo",telefone="37520913",email="paulo@gmail.com",cep="25515046"},
                new Cliente(){id=3,data=DateTime.Now.ToShortDateString(),nome="mario",telefone="37520913",email="mario@gmail.com",cep="25515047"},
                new Cliente(){id=4,data=DateTime.Now.ToShortDateString(),nome="josé",telefone="37520913",email="jose@gmail.com",cep="25515048"},
                new Cliente(){id=5,data=DateTime.Now.ToShortDateString(),nome="carlos",telefone="37520913",email="carlos@gmail.com",cep="25515049"}

        };


        List<Loja> lojas = new(){

            new Loja(){id=1,filial="PAVUNA",email="pavuna@gmail.com",telefone="(21) 00000-0000",endereco="rua da matriz"},
            new Loja(){id=2,filial="MEIER",email="meier@gmail.com",telefone="(21) 00000-0000",endereco="rua da matriz"},
            new Loja(){id=3,filial="BOTAFOGO",email="botafogo@gmail.com",telefone="(21) 00000-0000",endereco="rua da matriz"},
            new Loja(){id=4,filial="PILARES",email="pilares@gmail.com",telefone="(21) 00000-0000",endereco="rua da matriz"},
            new Loja(){id=5,filial="MADUREIRA",email="madureira@gmail.com",telefone="(21) 00000-0000",endereco="rua da matriz"}

        };

        [HttpGet]
        public async Task<ActionResult<List<Loja>>> findAll()
        {
            lojas.ForEach(l =>
            {
                cl.ForEach(c =>
                {
                    l.clientes.Add(c);
                });
            });

            return Ok(lojas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loja>> findById(int id)
        {
            var loja = this.lojas.Find((l) => l.id == id);

            return Ok(loja);

        }

        [HttpPost]
        public async Task<ActionResult<List<Loja>>> save(Loja loja)
        {
            this.lojas.Add(loja);
            return Ok(this.lojas);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Loja[]>> update(int id, Loja loja)
        {
            await this.findAll();

            var lupdate = this.lojas.Find(l => l.id == id);

            if (lupdate != null)
            {
                this.lojas.Where(l => l == lupdate).Select(l =>
                {
                    l.filial = loja.filial;
                    l.telefone = loja.telefone;
                    l.email = loja.email;
                    l.endereco = loja.endereco;
                    return l;
                }).ToList();

                return Ok(this.lojas);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Loja>>> delete(int id)
        {

            await this.findAll();

            int index = this.lojas.FindIndex((c) => c.id == id);
            Console.WriteLine(index);
            if (index > -1)
            {

                this.lojas.RemoveAt(index);
                return Ok(this.lojas.ToList());

            }
            else
            {
                return BadRequest();
            }
        }

    }
}