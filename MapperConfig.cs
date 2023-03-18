using AutoMapper;
using TODO.Data.Models;
using TODO.Data.DTO;

namespace TODO {
    public class MapperConfig: Profile {
        public MapperConfig(){
            CreateMap<TodoItem,TodoItemDetailDto>();
        }
    }
}