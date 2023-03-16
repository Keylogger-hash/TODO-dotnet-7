using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;



namespace TODO.Data.Models{

    public class Workspace {
        [Key]
        public Guid WorkspaceId {get; set;}
        [ForeignKey("UserTodoItemForeignKey")]
        public IdentityUser User {get; set;}
        
        public ICollection<IdentityUser> Members {get;set;}
        public bool IsCompleted {get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} 

    }
}