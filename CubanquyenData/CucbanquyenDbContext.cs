using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using CucbanquyenModel.Models;

namespace CucbanquyenData
{
    public class CucbanquyenDbContext: DbContext
    {
        public CucbanquyenDbContext() : base("CucbanquyenConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<ConfigSystem> ConfigSystems { set; get; }
        public DbSet<RelatedPost> RelatedPosts { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<Slider> Sliders { set; get; }
        public DbSet<SliderDetail> SliderDetails { set; get; }
        public DbSet<Tags> Tags { set; get; }
        //public DbSet<TagsPost> TagsPosts { set; get; }
        public DbSet<Document> Documents { set; get; }
        public DbSet<DocumentType> DocumentTypes { set; get; }
        public DbSet<Video> Videos { set; get; }
        public DbSet<Answer> Answers { set; get; }
        public DbSet<Question> Question { set; get; }

        //public DbSet<Visiter> Visiters { set; get; }
        public static CucbanquyenDbContext Create()
        {
            return new CucbanquyenDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
