using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Configurations
{
    public class TopicPostConfiguration : IEntityTypeConfiguration<TopicPost>
    {
        public void Configure(EntityTypeBuilder<TopicPost> builder)
        {
            builder.ToTable("TopicPost");
            builder.HasKey(e => new { e.TopicId, e.PostId });
        }
    }
}
