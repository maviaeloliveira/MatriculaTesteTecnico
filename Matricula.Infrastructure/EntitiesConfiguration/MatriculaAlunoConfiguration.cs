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
    internal class MatriculaAlunoConfiguration : IEntityTypeConfiguration<MatriculaAluno>
    {
        public void Configure(EntityTypeBuilder<MatriculaAluno> builder)
        {
            builder.ToTable("MatriculaAluno");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                   .IsRequired()
                   .HasColumnName("id")
                   .HasColumnType("int");

            builder.Property(prop => prop.IdAluno)
                .HasColumnName("IdAluno")
                .HasColumnType("int");

            builder.HasOne(prop => prop.Aluno)
                     .WithMany(a => a.Matriculas)
                     .HasForeignKey(prop => prop.IdAluno);

            builder.Property(prop => prop.DataMatricula)
                   .HasColumnName("DataMatricula")
                   .HasColumnType("DateTime");

            builder.Ignore(m => m.Invalid);

            builder.Ignore(m => m.ValidationResult);

            builder.Ignore(m => m.Valid);
        }
    }
}
