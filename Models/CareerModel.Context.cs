﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareerConnect.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_careerhuntEntities : DbContext
    {
        public db_careerhuntEntities()
            : base("name=db_careerhuntEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_contact> tbl_contact { get; set; }
        public virtual DbSet<tbl_jobseekers_profile> tbl_jobseekers_profile { get; set; }
        public virtual DbSet<tbl_employer_profile> tbl_employer_profile { get; set; }
        public virtual DbSet<tbl_job_posts> tbl_job_posts { get; set; }
        public virtual DbSet<tbl_colleges_profile> tbl_colleges_profile { get; set; }
        public virtual DbSet<tbl_college_events> tbl_college_events { get; set; }
        public virtual DbSet<tbl_users> tbl_users { get; set; }
        public virtual DbSet<tbl_userRole> tbl_userRole { get; set; }
    }
}