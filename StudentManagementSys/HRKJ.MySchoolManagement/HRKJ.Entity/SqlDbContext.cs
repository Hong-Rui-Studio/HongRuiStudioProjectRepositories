﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRKJ.Entity
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
            :base("DbConstr")
        {

        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<SystemMenus> SystemMenus { get; set; }
        public virtual DbSet<UsersPermissions> UsersPermissions { get; set; }
        public virtual DbSet<Copyright> Copyright { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<ExamInfos> ExamInfos { get; set; }
        public virtual DbSet<ExamResults> ExamResults { get; set; }

        public virtual DbSet<Classes> Classes { get; set; }



    }
}
