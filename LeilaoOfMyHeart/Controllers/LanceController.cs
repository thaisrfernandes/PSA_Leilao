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
    public class LanceController : Controller
    {
        private readonly LanceFacade _facade;

        public LanceController(LeilaoContext context)
        {
            _facade = new LanceFacade();
        }

        // GET: Lance
        public async Task<IActionResult> Index()
        {
            await _facade.Index();
            return View(await _facade.ListAllLances());
        }

        // GET: Lance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lance =  await _facade.GetLance(id);

            if (lance == null)
            {
                return NotFound();
            }

            return View(lance);
        }

        // GET: Lance/Create
        public IActionResult Create()
        {
            ViewData["LeilaoId"] = new SelectList(_facade.GetContext().Leiloes, "LeilaoId", "LeilaoId");
            return View();
        }

        // POST: Lance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Data,LanceId,Valor,EmailUsuario,LeilaoId")] Lance lance)
        {
            if (ModelState.IsValid)
            {
                await _facade.CreateLance(lance);
                return RedirectToAction(nameof(Index));
            }

            ViewData["LeilaoId"] = new SelectList(_facade.GetContext().Leiloes, "LeilaoId", "LeilaoId", lance.LeilaoId);
            return View(lance);
        }

        // GET: Lance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lance = await _facade.EditLance(id);

            if (lance == null)
            {
                return NotFound();
            }

            ViewData["LeilaoId"] = new SelectList(_facade.GetContext().Leiloes, "LeilaoId", "LeilaoId", lance.LeilaoId);
            return View(lance);
        }

        // POST: Lance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Data,LanceId,Valor,EmailUsuario,LeilaoId")] Lance lance)
        {
            if (id != lance.LanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _facade.UpdateLance(lance);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanceExists(lance.LanceId))
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

            ViewData["LeilaoId"] = new SelectList(_facade.GetContext().Leiloes, "LeilaoId", "LeilaoId", lance.LeilaoId);
            return View(lance);
        }

        // GET: Lance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lance = await _facade.GetLance(id);

            if (lance == null)
            {
                return NotFound();
            }

            return View(lance);
        }

        // POST: Lance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _facade.DeleteLanceById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LanceExists(int id)
        {
            return _facade.LanceExists(id);
        }
    }
}
