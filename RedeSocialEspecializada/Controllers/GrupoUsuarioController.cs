using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedeSocialEspecializada.Data;
using RedeSocialEspecializada.Models;

namespace RedeSocialEspecializada.Controllers
{
    public class GrupoUsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public GrupoUsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GrupoUsuario
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.GruposUsuarios.Include(g => g.Grupo).Include(g => g.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: GrupoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.GruposUsuarios
                .Include(g => g.Grupo)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // GET: GrupoUsuario/Create
        public IActionResult Create()
        {
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: GrupoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupoId,UsuarioId")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // GET: GrupoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.GruposUsuarios.FindAsync(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // POST: GrupoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupoId,UsuarioId")] GrupoUsuario grupoUsuario)
        {
            if (id != grupoUsuario.GrupoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoUsuarioExists(grupoUsuario.GrupoId))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", grupoUsuario.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", grupoUsuario.UsuarioId);
            return View(grupoUsuario);
        }

        // GET: GrupoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.GruposUsuarios
                .Include(g => g.Grupo)
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.GrupoId == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // POST: GrupoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoUsuario = await _context.GruposUsuarios.FindAsync(id);
            if (grupoUsuario != null)
            {
                _context.GruposUsuarios.Remove(grupoUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoUsuarioExists(int id)
        {
            return _context.GruposUsuarios.Any(e => e.GrupoId == id);
        }
    }
}
