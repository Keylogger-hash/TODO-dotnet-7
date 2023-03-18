using Microsoft.AspNetCore.Mvc;

using TODO.Data;
using TODO.Data.DTO;
using System.Collections.Generic;
using System.Linq;
using TODO.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;

namespace TODO.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext  _db ;

        private IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ApplicationDbContext  db,UserManager<IdentityUser> userManager,IMapper mapper)
        {
            _userManager = userManager ;
            _db = db;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<TodoItemDetailDto>>> GetListTodoItems(){
            string username = HttpContext.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            var todoList = await  _db.TodoItems.Where(item=>item.User==user).Select(i=> new TodoItemDetailDto{ItemId=i.ItemId,Username=user.UserName,ItemName=i.ItemName,CreatedAt=i.CreatedAt,UpdatedAt=i.UpdatedAt,IsCompleted=i.IsCompleted}).ToListAsync();
            return Ok(todoList);
        }
        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult> AddTodoItem(TodoItemCreateDto DTOItem){
            string username = HttpContext.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            var Now = DateTime.Now;
            var Item = new TodoItem{ItemName=DTOItem.ItemName,UpdatedAt=Now,User=user};
            Console.WriteLine(Item.UpdatedAt);
            await _db.TodoItems.AddAsync(Item);
            await _db.SaveChangesAsync();
            var itemDetail = new TodoItemDetailDto{ItemId=Item.ItemId,Username=user.UserName,ItemName=Item.ItemName,IsCompleted=Item.IsCompleted,CreatedAt=Item.CreatedAt,UpdatedAt=Item.UpdatedAt};
            var jsonString = JsonSerializer.Serialize(itemDetail);
            return Created(nameof(GetDetailTodoItem),jsonString);
        }

        [Authorize]
        [HttpGet("{Guid:itemId}/get")]
        public async Task<ActionResult> GetDetailTodoItem(Guid itemId){
            string username = HttpContext.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            var todoItem = _db.TodoItems.Where(i=> i.User==user & i.ItemId==itemId);
            Console.WriteLine(todoItem);
            if (todoItem == null ){
                return NotFound();
            }
            return Ok(todoItem);
        }
        [HttpPatch("{Guid:itemId}/patch")]
        public async Task<ActionResult> UpdateTodoItem(Guid itemId,TodoItemUpdateDto DTOitem){
            var todoItem = await _db.TodoItems.FindAsync(itemId);
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
        [HttpDelete("{Guid:id}/delete")]
        public async Task<ActionResult> RemoveTodoItem(Guid id){
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

