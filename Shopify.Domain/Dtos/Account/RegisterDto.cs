﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supliex.Domain.Dtos.Account
{
    public class RegisterDto
    {

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

}
