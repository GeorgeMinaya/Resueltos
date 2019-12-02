using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenTecnico.Net.Parte2.BE;
using ExamenTecnico.Net.Parte2.Data;
using ExamenTecnico.Net.Parte2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenTecnico.Net.Parte2.Controllers
{
    public class SucursalController : Controller
    {
        public ISucursalRepository SucursalRepository { get; }

        public SucursalController(ISucursalRepository sucursalRepository)
        {
            SucursalRepository = sucursalRepository;
        }

        // GET: Sucursal
        public IActionResult Index()
        {
            return View(SucursalRepository.GetAll());
        }

        // GET: Sucursal/Details/5
        public IActionResult Details(int? id)
        {
            var sucursal = SucursalRepository.GetById(id.Value);

            if (sucursal == null)
                return NotFound();

            return View(sucursal);
        }

        // GET: Sucursal/Create
        public IActionResult Create()
        {
            var bancos = SucursalRepository.GetBancos();

            var nueva = new SucursalBancosModel
            {
                Bancos = new List<SelectListItem>(from r in bancos
                                                  select new SelectListItem
                                                  {
                                                      Value = r.Id.ToString(),
                                                      Text = r.Nombre
                                                  })
            };

            return View(nueva);
        }

        // POST: Sucursal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SucursalBancosModel sucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SucursalRepository.Create(new BE.SucursalBE
                    {
                        Nombre = sucursal.Nombre,
                        Direccion = sucursal.Direccion,
                        IdBanco = sucursal.IdBanco
                    });

                    return RedirectToAction(nameof(Index));
                }

                return View(sucursal);
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public IActionResult Edit(int id)
        {
            var bancos = SucursalRepository.GetBancos();

            var existente = SucursalRepository.GetById(id);

            var editar = new SucursalBancosModel
            {
                Id = existente.Id,
                Direccion = existente.Direccion,
                Nombre = existente.Nombre,
                IdBanco = existente.IdBanco,
                Bancos = new List<SelectListItem>(from r in bancos
                                                  select new SelectListItem
                                                  {
                                                      Value = r.Id.ToString(),
                                                      Text = r.Nombre
                                                  })
            };

            return View(editar);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SucursalBancosModel sucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SucursalRepository.Update(new BE.SucursalBE
                    {
                        Id = sucursal.Id,
                        Nombre = sucursal.Nombre,
                        Direccion = sucursal.Direccion,
                        IdBanco = sucursal.IdBanco
                    });

                    return RedirectToAction(nameof(Index));
                }

                return View(sucursal);
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public IActionResult Delete(int? id)
        {
            var sucursal = SucursalRepository.GetById(id.Value);

            if (sucursal == null)
                return NotFound();

            return View(sucursal);
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SucursalBE sucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SucursalRepository.Delete(sucursal);

                    return RedirectToAction(nameof(Index));
                }

                return View(sucursal);
            }
            catch
            {
                return View();
            }
        }
    }
}