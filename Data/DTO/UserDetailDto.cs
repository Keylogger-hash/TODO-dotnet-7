using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TODO.Data.DTO{
   public class UserDetailDto{
        public string Id {get; set;}
        public string UserName {get; set;} 

        public string Email {get; set;}

    }
}