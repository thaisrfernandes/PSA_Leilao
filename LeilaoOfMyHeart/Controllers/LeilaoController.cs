using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TF_PSA.BLL.Facades;
using TF_PSA.PL;

namespace LeilaoOfMyHeart.Controllers
{
    public class LeilaoController : Controller
    {
        //private readonly LeilaosController _service;
        private readonly LeilaoFacade _facade;

        public LeilaoController()
        {
            //_service = new LeilaosController();
            _facade = new LeilaoFacade();
        }

        // GET: Leilao
        public async Task<IActionResult> Index()
        {
            return View(await _facade.ListAllLeiloes());
        }

        // GET: Leilao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _facade.GetLeilao(id);

            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        // GET: Leilao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leilao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeilaoId,Categoria,CategoriaDeLance,Preco,DataInicio,DataFinal,IdUsuarioResponsavel")] Leilao leilao)
        {
            if (ModelState.IsValid)
            {
                await _facade.CreateLeilao(leilao);
                return RedirectToAction(nameof(Index));
            }
            return View(leilao);
        }

        // GET: Leilao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _facade.EditLeilao(id);

            if (leilao == null)
            {
                return NotFound();
            }
            return View(leilao);
        }

        // POST: Leilao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeilaoId,Categoria,CategoriaDeLance,Preco,DataInicio,DataFinal,IdUsuarioResponsavel")] Leilao leilao)
        {
            if (id != leilao.LeilaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _facade.UpdateLeilao(leilao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeilaoExists(leilao.LeilaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leilao);
        }

        // GET: Leilao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _facade.GetLeilao(id);

            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        // POST: Leilao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _facade.DeleteLeilaoById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LeilaoExists(int id)
        {
            return _facade.LeilaoExits(id);
        }

        public async Task<IActionResult> SelecionaGanhador(int id)
        {
            //esta recebendo o id do leilao
            Console.WriteLine(id);
            if (_facade.LeilaoExits(id))
            {
                Leilao leilao = await _facade.EditLeilao(id);
                Console.WriteLine(leilao.ToString());
                Lance lance = await _facade.DeterminaGanhador(leilao);

                return View(lance);
            }

            return NotFound();
        }
    }
}
