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
    public class OrdenPagoController : Controller
    {
        public IOrdenPagoRepository OrdenPagoRepository { get; }

        public OrdenPagoController(IOrdenPagoRepository ordenPagoRepository)
        {
            OrdenPagoRepository = ordenPagoRepository;
        }

        // GET: OrdenPago
        public IActionResult Index()
        {
            var lista = OrdenPagoRepository.GetAll();

            var remplazado = new List<OrdenPagoSucursalModel>(from r in lista
                                                              select new OrdenPagoSucursalModel
                                                              {
                                                                  Id = r.Id,
                                                                  Monto = r.Monto,
                                                                  TipoPago = (OrdenPagoSucursalModel.TiposPago)(r.Moneda ? 1 : 0),
                                                                  Estados = (OrdenPagoSucursalModel.EstadosOrden)r.Estado,
                                                                  FechaRegistro = r.FechaRegistro,
                                                                  NombreSucursal = r.NombreSucursal
                                                              });

            return View(remplazado);
        }

        // GET: OrdenPago/Details/5
        public IActionResult Details(int? id)
        {
            var existente = OrdenPagoRepository.GetById(id.Value);

            if (existente == null)
                return NotFound();

            var detalle = new OrdenPagoSucursalModel
            {
                Id = existente.Id,
                Monto = existente.Monto,
                TipoPago = (OrdenPagoSucursalModel.TiposPago)(existente.Moneda ? 1 : 0),
                Estados = (OrdenPagoSucursalModel.EstadosOrden)existente.Estado,
                FechaRegistro = existente.FechaRegistro,
                NombreSucursal = existente.NombreSucursal
            };

            return View(detalle);
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            var sucursales = OrdenPagoRepository.GetSucursales();

            var nueva = new OrdenPagoSucursalModel
            {
                Sucursales = new List<SelectListItem>(from r in sucursales
                                                      select new SelectListItem
                                                      {
                                                          Value = r.Id.ToString(),
                                                          Text = r.Nombre
                                                      })
            };

            return View(nueva);
        }

        // POST: OrdenPago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenPagoSucursalModel ordenPagoSucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrdenPagoRepository.Create(new BE.OrdenPagoBE
                    {
                        Monto = ordenPagoSucursal.Monto,
                        Moneda = ordenPagoSucursal.TipoPago.GetHashCode().Equals(1) ? true : false,
                        Estado = ordenPagoSucursal.Estados.GetHashCode(),
                        IdSucursal = ordenPagoSucursal.IdSucursal
                    });

                    return RedirectToAction(nameof(Index));
                }

                return View(ordenPagoSucursal);
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public IActionResult Edit(int id)
        {
            var existente = OrdenPagoRepository.GetById(id);

            var editar = new OrdenPagoSucursalModel
            {
                Id = existente.Id,
                Monto = existente.Monto,
                TipoPago = (OrdenPagoSucursalModel.TiposPago) (existente.Moneda ? 1 : 0),
                Estados = (OrdenPagoSucursalModel.EstadosOrden) existente.Estado,
                FechaRegistro = existente.FechaRegistro,
                NombreSucursal = existente.NombreSucursal
            };

            return View(editar);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrdenPagoSucursalModel ordenPagoSucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrdenPagoRepository.Update(new OrdenPagoBE
                    {
                        Id = ordenPagoSucursal.Id,
                        Estado = ordenPagoSucursal.Estados.GetHashCode()
                    });

                    return RedirectToAction(nameof(Index));
                }

                return View(ordenPagoSucursal);
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public IActionResult Delete(int? id)
        {
            var existente = OrdenPagoRepository.GetById(id.Value);

            if (existente == null)
                return NotFound();

            var eliminar = new OrdenPagoSucursalModel
            {
                Id = existente.Id,
                Monto = existente.Monto,
                TipoPago = (OrdenPagoSucursalModel.TiposPago)(existente.Moneda ? 1 : 0),
                Estados = (OrdenPagoSucursalModel.EstadosOrden)existente.Estado,
                FechaRegistro = existente.FechaRegistro,
                NombreSucursal = existente.NombreSucursal
            };          

            return View(eliminar);
        }

        // POST: OrdenPago/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(OrdenPagoSucursalModel ordenPagoSucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrdenPagoRepository.Delete(new OrdenPagoBE
                    {
                        Id = ordenPagoSucursal.Id
                    });

                    return RedirectToAction(nameof(Index));
                }

                return View(ordenPagoSucursal);
            }
            catch
            {
                return View();
            }
        }
    }
}