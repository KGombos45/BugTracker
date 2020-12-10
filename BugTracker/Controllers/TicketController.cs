﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private UserManager<ApplicationUser> _userManager;

        public TicketController(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        //POST: api/Ticket/Create
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        [Route("UpdateTicket")]
        //PUT : /api/Ticket/UpdateTicket
        public async Task<IActionResult> UpdateTicket(Ticket ticket)
        {
            ticket.TicketOwner = await _userManager.FindByIdAsync(ticket.TicketOwnerID);

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]
        [Route("Statuses")]
        //GET : /api/Project/Statuses
        public async Task<IActionResult> GetStatuses()
        {
            var Statuses = _context.TicketStatuses.ToList();

            return Ok(Statuses);

        }


        [HttpGet]
        [Route("Tickets/{userId}")]
        //GET : /api/Ticket/Tickets
        public IActionResult GetTickets(string userId)
        {
            var tickets =  _context.Tickets.Include(t => t.TicketOwner)
                                            .Include(t => t.TicketProject)
                                            .Include(t => t.TicketStatus)
                                            .Where(t => t.TicketOwnerID.Equals(userId)).ToList();

            return Ok(tickets);
        }
    }
}