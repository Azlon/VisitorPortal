using Microsoft.EntityFrameworkCore;
using ProjectMeatMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMeatMore.Context
{
    public class UserContext: DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
       
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {

        }
    }
}
