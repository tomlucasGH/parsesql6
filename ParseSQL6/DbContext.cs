using System;
using ParseSQL2.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ParseSQL2.DAL
{
    public class QueryContext : DbContext

    {
        public DbSet<QueryMaster> Query { get; set; }
        public DbSet<TableList> Tables { get; set; }

        public DbSet<SelectColumns> columnlist { get; set; }
        public DbSet<WhereClause> whereclause { get; set; }

        public DbSet<ColumnIdentifiers> columnidentifiers { get; set; }
        public DbSet<datasources> datasources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=ParseSQL;Trusted_Connection=True");
        }
    }

}
