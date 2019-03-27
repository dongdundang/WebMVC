using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomeUserRole : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomeUserRole(ApplicationDbContext context) : base(context)
        {
        }
    }
}
