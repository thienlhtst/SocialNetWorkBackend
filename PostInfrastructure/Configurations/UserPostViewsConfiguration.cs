using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Configurations
{
    public class UserPostViewsConfiguration : IEntityTypeConfiguration<UserPostViews>
    {
        public void Configure(EntityTypeBuilder<UserPostViews> builder)
        {
            builder.ToTable("UserPostViews");
            builder.HasKey(e => new { e.PostId, e.AccountName });
            builder.HasOne(x => x.Posts).WithMany(x => x.UserPostViews).HasForeignKey(x => x.PostId);
        }
    }
}