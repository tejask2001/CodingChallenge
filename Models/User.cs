﻿using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isEventOrginizer { get; set; }

    }
}
