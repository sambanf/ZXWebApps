﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZXWebApps.Models;

namespace ZXWebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailsController : ControllerBase
    {
        private readonly TransactionContext _context;

        public TransactionDetailsController(TransactionContext context)
        {
            _context = context;
        }

        // GET: api/TransactionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDetail>>> GetTransactionDetails()
        {
            return await _context.TransactionDetails.ToListAsync();
        }

        // GET: api/TransactionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDetail>> GetTransactionDetail(int id)
        {
            var transactionDetail = await _context.TransactionDetails.FindAsync(id);

            if (transactionDetail == null)
            {
                return NotFound();
            }

            return transactionDetail;
        }

        // PUT: api/TransactionDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionDetail(int id, TransactionDetail transactionDetail)
        {
            if (id != transactionDetail.NoTrans)
            {
                return BadRequest();
            }

            _context.Entry(transactionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionDetailExists(id))
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

        // POST: api/TransactionDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TransactionDetail>> PostTransactionDetail(TransactionDetail transactionDetail)
        {
            _context.TransactionDetails.Add(transactionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionDetail", new { id = transactionDetail.NoTrans }, transactionDetail);
        }

        // DELETE: api/TransactionDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionDetail>> DeleteTransactionDetail(int id)
        {
            var transactionDetail = await _context.TransactionDetails.FindAsync(id);
            if (transactionDetail == null)
            {
                return NotFound();
            }

            _context.TransactionDetails.Remove(transactionDetail);
            await _context.SaveChangesAsync();

            return transactionDetail;
        }

        private bool TransactionDetailExists(int id)
        {
            return _context.TransactionDetails.Any(e => e.NoTrans == id);
        }
    }
}
