using Learn_Cqrs.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn_Cqrs.Infrastructure.Persistence.Configurations
{
    internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        void IEntityTypeConfiguration<Todo>.Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");       
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(t => t.Completed)
                .IsRequired();  
        }
    }
}
