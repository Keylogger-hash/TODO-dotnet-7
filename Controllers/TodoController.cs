using Microsoft.AspNetCore.Mvc;

using TODO.Data;
using TODO.Data.DTO;
using System.Collections.Generic;
using System.Linq;
using TODO.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TODO.Controllers{
    [ApiController]
    [Route("api/todo/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext  _db ;


        public TodoController(ApplicationDbContext  db){
            _db = db;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetListTodoItems(){
            return await  _db.TodoItems.Select(i=> new TodoItem{Id=i.Id,ItemName=i.ItemName,CreatedAt=i.CreatedAt,UpdatedAt=i.UpdatedAt,IsCompleted=i.IsCompleted}).ToListAsync();
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddTodoItem(TodoItemCreateDto DTOItem){
            var Now = DateTime.Now;
            var Item = new TodoItem{ItemName=DTOItem.ItemName,UpdatedAt=Now};
            Console.WriteLine(Item.UpdatedAt);
            await _db.TodoItems.AddAsync(Item);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetailTodoItem),new {Id=Item.Id},Item);
        }
        [HttpGet("{id}/get")]
        public async Task<ActionResult> GetDetailTodoItem(Guid id){
            var todoItem = await _db.TodoItems.FindAsync(id);
            if (todoItem == null ){
                return NotFound();
            }
            return Ok(todoItem);
        }
        [HttpPatch("{id}/patch")]
        public async Task<ActionResult> UpdateTodoItem(Guid id,TodoItemUpdateDto DTOitem){
            var todoItem = await _db.TodoItems.FindAsync(id);
            if (todoItem == null){
                return NotFound();
            }
            if (DTOitem.ItemName != null){
                todoItem.ItemName = DTOitem.ItemName;
            }
            if (DTOitem.IsCompleted != null){
                todoItem.IsCompleted = (bool)DTOitem.IsCompleted;
            }
            todoItem.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> RemoveTodoItem(int id){
            var todoItem = await _db.TodoItems.FindAsync(id);
            if (todoItem == null){
                return NotFound();
            }
            _db.TodoItems.Remove(todoItem);
            await _db.SaveChangesAsync();  
            return Ok();
        }
    }
};

