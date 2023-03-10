using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;



namespace TODO.Data.Models {
    public class User{
        [Key]
        public Guid Id {get; set;}

        [Required]
        public string UserName {get; set;} 

        [Required]
        public string Password {get; set;}

        [Required]
        public string Email {get; set;}
    }
}