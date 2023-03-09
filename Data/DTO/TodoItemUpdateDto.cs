using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TODO.Data.DTO{
   public class TodoItemUpdateDto{
        [Editable(true)]
        public string? ItemName {get;set;}
        public bool? IsCompleted {get; set;}
    }
}