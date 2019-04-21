using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMeatMore.Context;
using ProjectMeatMore.Models;

namespace ProjectMeatMore.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        private readonly UserContext _context;

        public UserInfoController(UserContext context)
        {
            _context = context;
        }

        // GET: UserInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInfo.ToListAsync());
        }

        // GET: UserInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.UserInfoId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: UserInfo/Create
        public IActionResult Create()
        {
            var model = new UserInfo();
            model.Type = "Leverancier";
            return View(model);
        }

        // POST: UserInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserInfoId,Type,Name,LastName,Company,LicensePlate")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.OnCreated = DateTime.Now;
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        // GET: UserInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserInfoId,Type,Name,LastName,Company,LicensePlate")] UserInfo userInfo)
        {
            if (id != userInfo.UserInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userInfo.OnEdited = DateTime.Now;
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.UserInfoId))
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
            return View(userInfo);
        }

        // GET: UserInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.UserInfoId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: UserInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);
            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfo.Any(e => e.UserInfoId == id);
        }
    }
}
