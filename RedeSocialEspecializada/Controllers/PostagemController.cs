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
    public class PostagemController : Controller
    {
        private readonly AppDbContext _context;

        public PostagemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Postagem
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.postagems.Include(p => p.Grupo).Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Postagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.postagems
                .Include(p => p.Grupo)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // GET: Postagem/Create
        public IActionResult Create()
        {
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Postagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Conteudo,DataPublicacao,Imagem,Video,UsuarioId,GrupoId")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", postagem.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", postagem.UsuarioId);
            return View(postagem);
        }

        // GET: Postagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.postagems.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", postagem.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", postagem.UsuarioId);
            return View(postagem);
        }

        // POST: Postagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Conteudo,DataPublicacao,Imagem,Video,UsuarioId,GrupoId")] Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemExists(postagem.Id))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "Id", postagem.GrupoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", postagem.UsuarioId);
            return View(postagem);
        }

        // GET: Postagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _context.postagems
                .Include(p => p.Grupo)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View(postagem);
        }

        // POST: Postagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagem = await _context.postagems.FindAsync(id);
            if (postagem != null)
            {
                _context.postagems.Remove(postagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagemExists(int id)
        {
            return _context.postagems.Any(e => e.Id == id);
        }
    }
}
