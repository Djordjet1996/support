﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupportSystemApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBPodrskaEntities : DbContext
    {
        public DBPodrskaEntities()
            : base("name=DBPodrskaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryList> CategoryLists { get; set; }
        public virtual DbSet<PriorityList> PriorityLists { get; set; }
        public virtual DbSet<SectionsList> SectionsLists { get; set; }
        public virtual DbSet<SeverityList> SeverityLists { get; set; }
        public virtual DbSet<StatusesList> StatusesLists { get; set; }
        public virtual DbSet<SupportList> SupportLists { get; set; }
        public virtual DbSet<UserList> UserLists { get; set; }
    }
}
