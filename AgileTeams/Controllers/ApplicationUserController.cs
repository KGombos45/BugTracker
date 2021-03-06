﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AgileTeamsData;
using AgileTeamsData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AgileTeams.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _applicationSettings;
        private readonly AgileTeamsContext _context;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> applicationSettings, AgileTeamsContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationSettings = applicationSettings.Value;
            _context = context;
        }
        

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = "Default";
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);
                return Ok(result);

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> UserLogin(ApplicationUserLoginModel model)
        {
            var applicationUser = await _userManager.FindByNameAsync(model.UserName);

            if (applicationUser != null && await _userManager.CheckPasswordAsync(applicationUser, model.Password))
            {

                // Get user assigned role
                var role = await _userManager.GetRolesAsync(applicationUser);
                IdentityOptions _options = new IdentityOptions();               

                if (!ApplicationUserExists(applicationUser.Id))
                {
                    var applicationUserRole = new ApplicationUserRole()
                    {
                        ID = applicationUser.Id,
                        UserName = applicationUser.UserName,
                        FirstName = applicationUser.FirstName,
                        LastName = applicationUser.LastName,
                        Email = applicationUser.Email,
                        Role = role.FirstOrDefault()
                    };

                    await _context.ApplicationUserRoles.AddAsync(applicationUserRole);
                    await _context.SaveChangesAsync();
                }


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",applicationUser.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_Token)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });

            } else
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
        }

        private bool ApplicationUserExists(string ID)
        {
            return _context.ApplicationUserRoles.Any(u => u.ID == ID);
        }
    }
}