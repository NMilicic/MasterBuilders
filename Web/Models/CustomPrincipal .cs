﻿using System.Security.Principal;
using Web.Interfaces;

namespace Web.Models
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
            this.Email = email;
        }

        public int Id { get; set; }
        public string Email { get; set; }
    }
}