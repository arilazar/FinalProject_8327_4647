﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using BE;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class PlanetsDB_8327Entities2 : DbContext
    {
        public PlanetsDB_8327Entities2() : base("name=PlanetsDB_8327Entities2")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Planets> Planets { get; set; }
    }
}