



namespace TODO.Data.DTO {
    public class TodoItemDetailDto {
        public Guid ItemId {get;set;}
        public string Username {get;set;}
        public string ItemName {get;set;}

        public bool IsCompleted {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} 
    }
}