using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TF_PSA.BLL.Facades;
using TF_PSA.PL;

namespace LeilaoOfMyHeart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeilaosController : ControllerBase
    {
        //private readonly LeilaoContext _context;
        private readonly LeilaoFacade _facade;

        public LeilaosController(/*LeilaoContext context*/)
        {
            //_context = context;
            _facade = new LeilaoFacade();
        }

        // GET: api/Leilaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leilao>>> GetLeiloes()
        {
            return await _facade.ListAllLeiloes();
        }

        // GET: api/Leilaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leilao>> GetLeilao(int id)
        {
            //P.S: n esta sendo editado, mas time que ta winning não se change
            var leilao = await _facade.EditLeilao(id);

            if (leilao == null)
            {
                return NotFound();
            }

            return leilao;
        }

        // PUT: api/Leilaos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeilao(int id, Leilao leilao)
        {
            if (id != leilao.LeilaoId)
            {
                return BadRequest();
            }

            try
            {
                await _facade.PutLeilao(leilao);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeilaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Leilaos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Leilao>> PostLeilao(Leilao leilao)
        {
            await _facade.CreateLeilao(leilao);

            return CreatedAtAction(nameof(GetLeilao), new { id = leilao.LeilaoId }, leilao);
        }

        // DELETE: api/Leilaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Leilao>> DeleteLeilao(int id)
        {
            //P.S: n esta sendo editado, mas time que ta winning não se change
            var leilao = await _facade.EditLeilao(id);

            if (leilao == null)
            {
                return NotFound();
            }

            await _facade.DeleteLeilaoById(leilao.LeilaoId);

            return leilao;
        }

        private bool LeilaoExists(int id)
        {
            return _facade.LeilaoExits(id);
        }
    }
}
