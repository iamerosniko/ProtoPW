﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectWorkplace.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProjectWorkplaceContext : DbContext
    {
        public ProjectWorkplaceContext()
            : base("name=ProjectWorkplaceContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PW_Answers> PW_Answers { get; set; }
        public virtual DbSet<PW_Persons> PW_Persons { get; set; }
        public virtual DbSet<PW_Questions> PW_Questions { get; set; }
        public virtual DbSet<PW_QuizTags> PW_QuizTags { get; set; }
        public virtual DbSet<PW_Roles> PW_Roles { get; set; }
        public virtual DbSet<PW_Subjects> PW_Subjects { get; set; }
        public virtual DbSet<PW_VW_QUESTIONS> PW_VW_QUESTIONS { get; set; }
        public virtual DbSet<PW_Examinees> PW_Examinees { get; set; }
        public virtual DbSet<PW_PersonTeams> PW_PersonTeams { get; set; }
        public virtual DbSet<PW_resources> PW_resources { get; set; }
        public virtual DbSet<PW_Teams> PW_Teams { get; set; }
        public virtual DbSet<PW_Teamresources> PW_Teamresources { get; set; }
        public virtual DbSet<PW_ViewEmployeeScore> PW_ViewEmployeeScore { get; set; }
        public virtual DbSet<PW_Leaders> PW_Leaders { get; set; }
        public virtual DbSet<PW_TemporaryUsers> PW_TemporaryUsers { get; set; }
    
        public virtual ObjectResult<PW_GetResourcePath_Result> PW_GetResourcePath(string username, string resourceCategory)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var resourceCategoryParameter = resourceCategory != null ?
                new ObjectParameter("resourceCategory", resourceCategory) :
                new ObjectParameter("resourceCategory", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PW_GetResourcePath_Result>("PW_GetResourcePath", usernameParameter, resourceCategoryParameter);
        }
    
        public virtual ObjectResult<PW_GetResourcePath2_Result> PW_GetResourcePath2(string username, string resourceCategory)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var resourceCategoryParameter = resourceCategory != null ?
                new ObjectParameter("resourceCategory", resourceCategory) :
                new ObjectParameter("resourceCategory", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PW_GetResourcePath2_Result>("PW_GetResourcePath2", usernameParameter, resourceCategoryParameter);
        }
    
        public virtual ObjectResult<PW_GetVideo_Result> PW_GetVideo(string username, Nullable<bool> isLeader)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var isLeaderParameter = isLeader.HasValue ?
                new ObjectParameter("isLeader", isLeader) :
                new ObjectParameter("isLeader", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PW_GetVideo_Result>("PW_GetVideo", usernameParameter, isLeaderParameter);
        }
    
        public virtual ObjectResult<PW_GetCurrentUser_Result> PW_GetCurrentUser(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PW_GetCurrentUser_Result>("PW_GetCurrentUser", usernameParameter);
        }
    }
}
