using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenTecnico.Net.Parte2.BE;
using ExamenTecnico.Net.Parte2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTecnico.Net.Parte2.Controllers
{
    public class BancoController : Controller
    {
        public IBancoRepository BancoRepository { get; }

        public BancoController(IBancoRepository bancoRepository)
        {
            BancoRepository = bancoRepository;
        }

        // GET: Banco
        public IActionResult Index()
        {
            return View(BancoRepository.GetAll());
        }

        // GET: Banco/Details/5
        public IActionResult Details(int? id)
        {
            var banco = BancoRepository.GetById(id.Value);

            if (banco == null)
                return NotFound();

            return View(banco);

        }

        // GET: Banco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BancoBE banco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BancoRepository.Create(banco);

                    return RedirectToAction(nameof(Index));
                }

                return View(banco);
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public IActionResult Edit(int? id)
        {
            var banco = BancoRepository.GetById(id.Value);

            if (banco == null)
                return NotFound();

            return View(banco);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BancoBE banco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BancoRepository.Update(banco);

                    return RedirectToAction(nameof(Index));
                }

                return View(banco);
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Delete/5
        public IActionResult Delete(int? id)
        {
            var banco = BancoRepository.GetById(id.Value);

            if (banco == null)
                return NotFound();

            return View(banco);
        }

        // POST: Banco/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BancoBE banco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BancoRepository.Delete(banco);

                    return RedirectToAction(nameof(Index));
                }

                return View(banco);
            }
            catch
            {
                return View();
            }
        }
    }
}