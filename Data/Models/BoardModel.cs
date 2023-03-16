using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;
namespace TODO.Data.Models {

    public class Board {
        [Key]
        public Guid BoardId {get; set;}
        [ForeignKey("UserBoardForeignKey")]
        public IdentityUser User {get; set;}
        public String BoardName {get;set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} 

    }

}