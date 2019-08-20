using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace BlushMe.Model
{
    public class User
    {
        [Key] public long UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}