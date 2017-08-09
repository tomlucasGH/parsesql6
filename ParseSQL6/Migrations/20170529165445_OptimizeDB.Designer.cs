using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ParseSQL2.DAL;

namespace ParseSQL6.Migrations
{
    [DbContext(typeof(QueryContext))]
    [Migration("20170529165445_OptimizeDB")]
    partial class OptimizeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParseSQL2.Models.ColumnIdentifiers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("asciiend");

                    b.Property<int>("asciistart");

                    b.HasKey("ID");

                    b.ToTable("columnidentifiers");
                });

            modelBuilder.Entity("ParseSQL2.Models.datasources", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("image_uri");

                    b.Property<string>("name");

                    b.Property<string>("type");

                    b.HasKey("ID");

                    b.ToTable("datasources");
                });

            modelBuilder.Entity("ParseSQL2.Models.QueryMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QueryText");

                    b.Property<int>("customerid");

                    b.HasKey("ID");

                    b.ToTable("Query");
                });

            modelBuilder.Entity("ParseSQL2.Models.SelectColumns", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<int>("QueryID");

                    b.Property<string>("TableName");

                    b.HasKey("ID");

                    b.ToTable("columnlist");
                });

            modelBuilder.Entity("ParseSQL2.Models.TableList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AliasName");

                    b.Property<string>("DB");

                    b.Property<int?>("QueryMasterID");

                    b.Property<int?>("QueryMasterID1");

                    b.Property<string>("TableName");

                    b.Property<string>("owner");

                    b.Property<int>("queryID");

                    b.HasKey("ID");

                    b.HasIndex("QueryMasterID");

                    b.HasIndex("QueryMasterID1");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("ParseSQL2.Models.WhereClause", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<int>("QueryID");

                    b.Property<string>("TableName");

                    b.Property<string>("comparison_operator");

                    b.Property<string>("comparison_value");

                    b.Property<string>("function_name");

                    b.Property<string>("function_string");

                    b.HasKey("ID");

                    b.ToTable("whereclause");
                });

            modelBuilder.Entity("ParseSQL2.Models.TableList", b =>
                {
                    b.HasOne("ParseSQL2.Models.QueryMaster")
                        .WithMany("SelectColumns")
                        .HasForeignKey("QueryMasterID");

                    b.HasOne("ParseSQL2.Models.QueryMaster")
                        .WithMany("Tables")
                        .HasForeignKey("QueryMasterID1");
                });
        }
    }
}
