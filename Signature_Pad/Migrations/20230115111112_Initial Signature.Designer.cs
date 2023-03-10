// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Signature_Pad.Data;

#nullable disable

namespace Signature_Pad.Migrations
{
    [DbContext(typeof(SignaturesContext))]
    [Migration("20230115111112_Initial Signature")]
    partial class InitialSignature
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Signature_Pad.Models.Signature", b =>
                {
                    b.Property<int>("SignatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SignatureId"), 1L, 1);

                    b.Property<string>("Signatures")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SignatureId");

                    b.ToTable("Signature");
                });
#pragma warning restore 612, 618
        }
    }
}
