using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
using PostCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Posts>().HasData(
                new Posts() { Id= "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", Content="Test Du lieu xiu di ban oi", AccountName="thienzn", CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, Privacy=Privacy.Public, RepostId=null, }

                );
            modelbuilder.Entity<Media>().HasData(
                new Media() { Id= "4758c4fe-1546-4c01-a46f-e9fcab755389", ParentId="4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", MediaName="testdulieu", Height=0, Width=0, Url="/test", MediaType =MediaType.picture }
                );
            modelbuilder.Entity<Comment>().HasData(
               new Comment() { Id= "4752c4fe-1546-4c01-a46f-e9fcab755389", ParentId="4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", Content="Test Du lieu Comment xiu di ban oi", AccountName="tienminh", CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now }
               );
        }
    }
}