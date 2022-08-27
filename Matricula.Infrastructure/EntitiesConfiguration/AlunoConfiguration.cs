using Matricula.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Infrastructure.EntitiesConfiguration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .HasColumnType("int");

            builder.Property(prop => prop.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100);

            builder.Ignore(m => m.Invalid);

            builder.Ignore(m => m.ValidationResult);

            builder.Ignore(m => m.Valid);
        }
    }
}
