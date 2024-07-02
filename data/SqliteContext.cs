using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_auth.models;
using Microsoft.EntityFrameworkCore;

namespace api_auth.data
    {
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}