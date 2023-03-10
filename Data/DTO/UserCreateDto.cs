using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TODO.Data.DTO{
   public class UserCreateDto{
        public string UserName {get; set;} 

        public string Password {get; set;}
        public string Email {get; set;}

    }
}