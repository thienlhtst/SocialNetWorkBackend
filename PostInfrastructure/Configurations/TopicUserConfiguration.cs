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
    public class TopicUserConfiguration : IEntityTypeConfiguration<TopicUser>
    {
        public void Configure(EntityTypeBuilder<TopicUser> builder)
        {
            builder.ToTable("TopicUser");
            builder.HasKey(e => new { e.TopicId, e.AccountName });
            builder.HasOne(x => x.Topic).WithMany(x => x.TopicUsers).HasForeignKey(x => x.TopicId);
        }
    }
}