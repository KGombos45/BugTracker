﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTeamsData;
using AgileTeamsData.Data;
using AgileTeamsData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileTeams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly AgileTeamsContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProjectController(AgileTeamsContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        //POST: api/Project/Create
        public async Task<ActionResult<WorkItem>> CreateProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        [Route("UpdateProject")]
        //PUT : /api/Project/Update
        public async Task<IActionResult> UpdateProject(Project project)
        {
            _context.Projects.Update(project);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(Project project)
        {
                  
            foreach (var workItem in project.WorkItems)
            {
                 _context.Tickets.RemoveRange(workItem.Tickets);
            }

            _context.WorkItems.RemoveRange(project.WorkItems);

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("Projects")]
        //GET : /api/Project/Projects
        public async Task<IActionResult> GetProjects()
        {
            var projects = _context.Projects
                .Include(p => p.WorkItems).ThenInclude(w => w.Tickets)
                .Include(p => p.WorkItems).ThenInclude(w => w.WorkItemStatus)
                .Include(p => p.WorkItems).ThenInclude(w => w.WorkItemOwner)
                .Include(p => p.WorkItems).ThenInclude(w => w.Comments)
                .Include(p => p.WorkItems).ThenInclude(w => w.WorkItemType)
                .Include(p => p.WorkItems).ThenInclude(w => w.Project)
                .Include(p => p.WorkItems).ThenInclude(w => w.WorkItemPriority).ToList();     


            return Ok(projects);

        }

    }
}
