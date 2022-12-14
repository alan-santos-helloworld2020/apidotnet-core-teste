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
                new Cliente(){id=1,data=DateTime.Now.ToShortDateString(),nome="alan",telefone="(21)00000-0000",email="fulanoalan@gmail.com",cep="11111-111"},
                new Cliente(){id=2,data=DateTime.Now.ToShortDateString(),nome="paulo",telefone="(21)00000-0000",email="fulanopaulo@gmail.com",cep="22222-222"},
                new Cliente(){id=3,data=DateTime.Now.ToShortDateString(),nome="mario",telefone="(21)00000-0000",email="fulanomario@gmail.com",cep="33333-333"},
                new Cliente(){id=4,data=DateTime.Now.ToShortDateString(),nome="josé",telefone="(21)00000-0000",email="fulanojose@gmail.com",cep="44444-444"},
                new Cliente(){id=5,data=DateTime.Now.ToShortDateString(),nome="carlos",telefone="(21)00000-0000",email="fulanocarlos@gmail.com",cep="55555-555"}

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
            await this.findAll();

            var loja = this.lojas.Find((l) => l.id == id);

            return Ok(loja);

        }

        [HttpPost]
        public async Task<ActionResult<List<Loja>>> save(Loja loja)
        {
            await this.findAll();

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