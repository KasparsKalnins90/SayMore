namespace SayMore.Models
{
    using SayMore.Logic.Database;
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

    [Table("Users")]
    public partial class UsersModel

    {
        public UsersModel()
        {

        }
        
        public int id { get; set;  }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static UsersModel FromData(Users user)
        {
            return new UsersModel()
            {
                id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };
        }

    }
}