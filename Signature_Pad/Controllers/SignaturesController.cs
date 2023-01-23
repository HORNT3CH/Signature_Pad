#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Signature_Pad.Data;
using Signature_Pad.Models;

namespace Signature_Pad.Controllers
{
    public class SignaturesController : Controller
    {
        private readonly SignaturesContext _context;

        public SignaturesController(SignaturesContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetPageSizes(int selectedPageSize = 5)
        {
            var pagesSizes = new List<SelectListItem>();

            if (selectedPageSize == 5)
            {
                pagesSizes.Add(new SelectListItem("5", "5", true));
            }
            else
            {
                pagesSizes.Add(new SelectListItem("5", "5"));
            }

            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPageSize)
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true));
                }

                else
                {
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
                }
            }

            return pagesSizes;
        }

        // GET: GetSignatures
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 5)
        {
            List<Signature> signature;

            if (pg < 1) pg = 1;

            if (SearchText != "" && SearchText != null)
            {
                signature = _context.Signature
                    .Where(p => p.LoadNbr.Contains(SearchText))
                    .ToList();
            }
            else
            {
                signature = _context.Signature.ToList();
            }

            int recsCount = signature.Count();

            int recSkip = (pg - 1) * pageSize;

            List<Signature> retSignature = signature.Skip(recSkip).Take(pageSize).OrderBy(m => m.Signatures).ToList();

            Pager SearchPager = new Pager(recsCount, pg, pageSize) { Action = "Index", Controller = "Signatures", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            this.ViewBag.PageSizes = GetPageSizes(pageSize);

            return View(retSignature.ToList());
        }

        // GET: Signatures/SignSheet/5
        public async Task<IActionResult> SignSheet(int? id)
        {
            if (id == null || _context.Signature == null)
            {
                return NotFound();
            }

            var signature = await _context.Signature
                .FirstOrDefaultAsync(m => m.SignatureId == id);
            if (signature == null)
            {
                return NotFound();
            }

            return View(signature);
        }

        // GET: Signatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Signatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignatureId,Signatures,ActualStart,ActualFinish,LoadNbr,ArrivalTime,CarrierName,Date,MbolNumber,TimeSlot")] Signature signature)
        {            
            var loadNbr = _context.Signature.FirstOrDefault(d => d.LoadNbr == signature.LoadNbr);
            
            if (ModelState.IsValid && loadNbr == null)
            {
                _context.Add(signature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Signatures/Sign/5
        public async Task<IActionResult> Sign(int? id)
        {
            if (id == null || _context.Signature == null)
            {
                return NotFound();
            }

            var signature = await _context.Signature.FindAsync(id);
            if (signature == null)
            {
                return NotFound();
            }
            return View(signature);
        }

        // POST: Signatures/Sign/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sign(int id, [Bind("SignatureId,Signatures,ActualStart,ActualFinish,LoadNbr,ArrivalTime,CarrierName,Date,MbolNumber,TimeSlot")] Signature signature)
        {
            if (id != signature.SignatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignatureExists(signature.SignatureId))
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
            return View(signature);
        }

        private bool SignatureExists(int id)
        {
          return _context.Signature.Any(e => e.SignatureId == id);
        }
    }
}
