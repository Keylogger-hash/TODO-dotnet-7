using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;



namespace TODO.Data.Models {


    public class ApplicationUser:IdentityUser {
        public ICollection<WorkspaceMember> WorkspaceMembers;
        
    }
}