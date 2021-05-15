﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballInfoApp.API.Infrastructure.Models.User
{
     public class UserLoginModel
     {
          [Required]
          public string Email { get; set; }

          [Required]
          public string Password { get; set; }

     }
}
