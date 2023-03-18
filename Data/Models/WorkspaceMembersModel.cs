
using TODO.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;


namespace TODO.Data.Models{
    public class WorkspaceMember {
        public Guid WorkspaceId {get;set;}
        public string UserId {get;set;}
        public Workspace Workspace {get;set;}
        public ApplicationUser User {get; set;}

    }
}