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
               new Posts
               {
                   Id = "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b",
                   Content = "AI đang thay đổi thế giới như thế nào?",
                   AccountName = "thienzn",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   Privacy = Privacy.Public,
                   RepostId = null,
               },
    new Posts
    {
        Id = "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1",
        Content = "Chung kết Champions League sắp diễn ra!",
        AccountName = "tienminh",
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Privacy = Privacy.Public,
        RepostId = null,
    },
    new Posts
    {
        Id = "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6",
        Content = "Bản hit mới nhất của ca sĩ X đang làm mưa làm gió",
        AccountName = "minhthanh",
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Privacy = Privacy.Public,
        RepostId = null,
    }

                );
            modelbuilder.Entity<Media>().HasData(
                new Media() { Id= "4758c4fe-1546-4c01-a46f-e9fcab755389", ParentId="a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", MediaName="testdulieu", Height=0, Width=0, Url="/test", MediaType =MediaType.picture }
                );
            modelbuilder.Entity<Comment>().HasData(
               new Comment() { Id= "4752c4fe-1546-4c01-a46f-e9fcab755389", ParentId="a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", Content="Test Du lieu Comment xiu di ban oi", AccountName="tienminh", CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now }
               );
            modelbuilder.Entity<Topic>().HasData(
                new Topic { Id = "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0", Name = "Công nghệ", CountTopic = 0 },
                 new Topic { Id = "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7", Name = "Thể thao", CountTopic = 0 },
             new Topic { Id = "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0", Name = "Âm nhạc", CountTopic = 0 }

                );
            modelbuilder.Entity<TopicPost>().HasData(
                new TopicPost { PostId = "4aa068ad-f48a-42c0-ad99-de7b5e8ad15b", TopicId = "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" }, // AI -> Công nghệ
                 new TopicPost { PostId = "c3d5e7a9-b1f2-40c3-d4e5-a6b7c8f9d0e1", TopicId = "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" }, // Bóng đá -> Thể thao
                new TopicPost { PostId = "a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6", TopicId = "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" }  // Nhạc -> Âm nhạc
                );
            modelbuilder.Entity<TopicUser>().HasData(
                new TopicUser { AccountName = "thienminh", TopicId = "d1a5b0c3-4e6f-47a1-b2c4-d5e6f7a8b9c0" }, // AI -> Công nghệ
                 new TopicUser { AccountName = "thienminh", TopicId = "a2b3c4d5-e6f7-48a9-b0c1-d2e3f4a5b6c7" }, // Bóng đá -> Thể thao
                new TopicUser { AccountName = "thienminh", TopicId = "e5f6a7b8-c9d0-41e2-b3f4-a5c6d7e8f9b0" }  // Nhạc -> Âm nhạc
                );
        }
    }
}