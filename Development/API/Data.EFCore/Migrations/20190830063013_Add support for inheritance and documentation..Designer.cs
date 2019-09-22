﻿// <auto-generated />
using System;
using Data.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.EFCore.Migrations
{
    [DbContext(typeof(MCMSContext))]
    [Migration("20190830063013_Add support for inheritance and documentation.")]
    partial class Addsupportforinheritanceanddocumentation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Data.Core.Models.Class.ClassCommittedMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("ClassCommittedMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documentation");

                    b.HasKey("Id");

                    b.ToTable("ClassMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassProposalMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClosedById");

                    b.Property<DateTime?>("ClosedOn");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsPublicVote");

                    b.Property<bool?>("Merged");

                    b.Property<Guid?>("MergedWithId");

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("ProposedById");

                    b.Property<DateTime>("ProposedOn");

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("ClosedById");

                    b.HasIndex("MergedWithId")
                        .IsUnique();

                    b.HasIndex("ProposedById");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("ClassProposalMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassReleaseMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MemberId");

                    b.Property<Guid>("ReleaseId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("ClassReleaseMember");
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassVersionedMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("GameVersionId");

                    b.Property<Guid>("MappingId");

                    b.Property<Guid?>("OuterId");

                    b.Property<string>("Package");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("MappingId");

                    b.HasIndex("OuterId");

                    b.ToTable("ClassVersionedMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Core.GameVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsPreRelease");

                    b.Property<bool>("IsSnapshot");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("GameVersions");
                });

            modelBuilder.Entity("Data.Core.Models.Core.Release", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClassCommittedMappingEntryId");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("FieldCommittedMappingEntryId");

                    b.Property<Guid>("GameVersionId");

                    b.Property<Guid?>("MethodCommittedMappingEntryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("ParameterCommittedMappingEntryId");

                    b.HasKey("Id");

                    b.HasIndex("ClassCommittedMappingEntryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FieldCommittedMappingEntryId");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("MethodCommittedMappingEntryId");

                    b.HasIndex("ParameterCommittedMappingEntryId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("Data.Core.Models.Core.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanCommit");

                    b.Property<bool>("CanCreateGameVersions");

                    b.Property<bool>("CanEdit");

                    b.Property<bool>("CanRelease");

                    b.Property<bool>("CanReview");

                    b.Property<Guid?>("ClassProposalMappingEntryId");

                    b.Property<Guid?>("ClassProposalMappingEntryId1");

                    b.Property<Guid?>("FieldProposalMappingEntryId");

                    b.Property<Guid?>("FieldProposalMappingEntryId1");

                    b.Property<Guid?>("MethodProposalMappingEntryId");

                    b.Property<Guid?>("MethodProposalMappingEntryId1");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("ParameterProposalMappingEntryId");

                    b.Property<Guid?>("ParameterProposalMappingEntryId1");

                    b.HasKey("Id");

                    b.HasIndex("ClassProposalMappingEntryId");

                    b.HasIndex("ClassProposalMappingEntryId1");

                    b.HasIndex("FieldProposalMappingEntryId");

                    b.HasIndex("FieldProposalMappingEntryId1");

                    b.HasIndex("MethodProposalMappingEntryId");

                    b.HasIndex("MethodProposalMappingEntryId1");

                    b.HasIndex("ParameterProposalMappingEntryId");

                    b.HasIndex("ParameterProposalMappingEntryId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldCommittedMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("FieldCommittedMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documentation");

                    b.HasKey("Id");

                    b.ToTable("FieldMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldProposalMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClosedById");

                    b.Property<DateTime?>("ClosedOn");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsPublicVote");

                    b.Property<bool?>("Merged");

                    b.Property<Guid?>("MergedWithId");

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("ProposedById");

                    b.Property<DateTime>("ProposedOn");

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("ClosedById");

                    b.HasIndex("MergedWithId")
                        .IsUnique();

                    b.HasIndex("ProposedById");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("FieldProposalMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldReleaseMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MemberId");

                    b.Property<Guid>("ReleaseId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("FieldReleaseMember");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldVersionedMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("GameVersionId");

                    b.Property<Guid>("MappingId");

                    b.Property<Guid>("MemberOfId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("MappingId");

                    b.HasIndex("MemberOfId");

                    b.ToTable("FieldVersionedMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodCommittedMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("MethodCommittedMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documentation");

                    b.HasKey("Id");

                    b.ToTable("MethodMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodProposalMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClosedById");

                    b.Property<DateTime?>("ClosedOn");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsPublicVote");

                    b.Property<bool?>("Merged");

                    b.Property<Guid?>("MergedWithId");

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("ProposedById");

                    b.Property<DateTime>("ProposedOn");

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("ClosedById");

                    b.HasIndex("MergedWithId")
                        .IsUnique();

                    b.HasIndex("ProposedById");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("MethodProposalMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodReleaseMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MemberId");

                    b.Property<Guid>("ReleaseId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("MethodReleaseMember");
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodVersionedMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Descriptor");

                    b.Property<Guid>("GameVersionId");

                    b.Property<bool>("IsStatic");

                    b.Property<Guid>("MappingId");

                    b.Property<Guid>("MemberOfId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("MappingId");

                    b.HasIndex("MemberOfId");

                    b.ToTable("MethodVersionedMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterCommittedMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<Guid?>("MethodVersionedMappingId");

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("MethodVersionedMappingId");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("ParameterCommittedMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documentation");

                    b.HasKey("Id");

                    b.ToTable("ParameterMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterProposalMappingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClosedById");

                    b.Property<DateTime?>("ClosedOn");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("InputMapping")
                        .IsRequired();

                    b.Property<bool>("IsOpen");

                    b.Property<bool>("IsPublicVote");

                    b.Property<bool?>("Merged");

                    b.Property<Guid?>("MergedWithId");

                    b.Property<string>("OutputMapping")
                        .IsRequired();

                    b.Property<Guid>("ProposedById");

                    b.Property<DateTime>("ProposedOn");

                    b.Property<Guid>("VersionedMappingId");

                    b.HasKey("Id");

                    b.HasIndex("ClosedById");

                    b.HasIndex("MergedWithId")
                        .IsUnique();

                    b.HasIndex("ProposedById");

                    b.HasIndex("VersionedMappingId");

                    b.ToTable("ParameterProposalMappingEntries");
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterReleaseMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MemberId");

                    b.Property<Guid>("ReleaseId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("ParameterReleaseMember");
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterVersionedMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("GameVersionId");

                    b.Property<int>("Index");

                    b.Property<Guid>("MappingId");

                    b.Property<Guid>("ParameterOfId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("MappingId");

                    b.HasIndex("ParameterOfId");

                    b.ToTable("ParameterVersionedMappings");
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassCommittedMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Class.ClassVersionedMapping", "VersionedMapping")
                        .WithMany("CommittedMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassProposalMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

                    b.HasOne("Data.Core.Models.Class.ClassCommittedMappingEntry", "MergedWith")
                        .WithOne("Proposal")
                        .HasForeignKey("Data.Core.Models.Class.ClassProposalMappingEntry", "MergedWithId");

                    b.HasOne("Data.Core.Models.Core.User", "ProposedBy")
                        .WithMany()
                        .HasForeignKey("ProposedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Class.ClassVersionedMapping", "VersionedMapping")
                        .WithMany("ProposalMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassReleaseMember", b =>
                {
                    b.HasOne("Data.Core.Models.Class.ClassCommittedMappingEntry", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.Release", "Release")
                        .WithMany("Classes")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Class.ClassVersionedMapping", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Class.ClassMapping", "Mapping")
                        .WithMany("VersionedMappings")
                        .HasForeignKey("MappingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Class.ClassVersionedMapping", "Outer")
                        .WithMany("InheritsFrom")
                        .HasForeignKey("OuterId");
                });

            modelBuilder.Entity("Data.Core.Models.Core.GameVersion", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Core.Release", b =>
                {
                    b.HasOne("Data.Core.Models.Class.ClassCommittedMappingEntry")
                        .WithMany("Releases")
                        .HasForeignKey("ClassCommittedMappingEntryId");

                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Field.FieldCommittedMappingEntry")
                        .WithMany("Releases")
                        .HasForeignKey("FieldCommittedMappingEntryId");

                    b.HasOne("Data.Core.Models.Core.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Method.MethodCommittedMappingEntry")
                        .WithMany("Releases")
                        .HasForeignKey("MethodCommittedMappingEntryId");

                    b.HasOne("Data.Core.Models.Parameter.ParameterCommittedMappingEntry")
                        .WithMany("Releases")
                        .HasForeignKey("ParameterCommittedMappingEntryId");
                });

            modelBuilder.Entity("Data.Core.Models.Core.User", b =>
                {
                    b.HasOne("Data.Core.Models.Class.ClassProposalMappingEntry")
                        .WithMany("VotedAgainst")
                        .HasForeignKey("ClassProposalMappingEntryId");

                    b.HasOne("Data.Core.Models.Class.ClassProposalMappingEntry")
                        .WithMany("VotedFor")
                        .HasForeignKey("ClassProposalMappingEntryId1")
                        .HasConstraintName("FK_Users_ClassProposalMappingEntries_ClassProposalMappingEntr~1");

                    b.HasOne("Data.Core.Models.Field.FieldProposalMappingEntry")
                        .WithMany("VotedAgainst")
                        .HasForeignKey("FieldProposalMappingEntryId");

                    b.HasOne("Data.Core.Models.Field.FieldProposalMappingEntry")
                        .WithMany("VotedFor")
                        .HasForeignKey("FieldProposalMappingEntryId1")
                        .HasConstraintName("FK_Users_FieldProposalMappingEntries_FieldProposalMappingEntr~1");

                    b.HasOne("Data.Core.Models.Method.MethodProposalMappingEntry")
                        .WithMany("VotedAgainst")
                        .HasForeignKey("MethodProposalMappingEntryId");

                    b.HasOne("Data.Core.Models.Method.MethodProposalMappingEntry")
                        .WithMany("VotedFor")
                        .HasForeignKey("MethodProposalMappingEntryId1")
                        .HasConstraintName("FK_Users_MethodProposalMappingEntries_MethodProposalMappingEn~1");

                    b.HasOne("Data.Core.Models.Parameter.ParameterProposalMappingEntry")
                        .WithMany("VotedAgainst")
                        .HasForeignKey("ParameterProposalMappingEntryId");

                    b.HasOne("Data.Core.Models.Parameter.ParameterProposalMappingEntry")
                        .WithMany("VotedFor")
                        .HasForeignKey("ParameterProposalMappingEntryId1")
                        .HasConstraintName("FK_Users_ParameterProposalMappingEntries_ParameterProposalMap~1");
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldCommittedMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Field.FieldVersionedMapping", "VersionedMapping")
                        .WithMany("CommittedMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldProposalMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

                    b.HasOne("Data.Core.Models.Field.FieldCommittedMappingEntry", "MergedWith")
                        .WithOne("Proposal")
                        .HasForeignKey("Data.Core.Models.Field.FieldProposalMappingEntry", "MergedWithId");

                    b.HasOne("Data.Core.Models.Core.User", "ProposedBy")
                        .WithMany()
                        .HasForeignKey("ProposedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Field.FieldVersionedMapping", "VersionedMapping")
                        .WithMany("ProposalMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldReleaseMember", b =>
                {
                    b.HasOne("Data.Core.Models.Field.FieldCommittedMappingEntry", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.Release", "Release")
                        .WithMany("Fields")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Field.FieldVersionedMapping", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Field.FieldMapping", "Mapping")
                        .WithMany("VersionedMappings")
                        .HasForeignKey("MappingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Class.ClassCommittedMappingEntry", "MemberOf")
                        .WithMany()
                        .HasForeignKey("MemberOfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodCommittedMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Method.MethodVersionedMapping", "VersionedMapping")
                        .WithMany("CommittedMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodProposalMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

                    b.HasOne("Data.Core.Models.Method.MethodCommittedMappingEntry", "MergedWith")
                        .WithOne("Proposal")
                        .HasForeignKey("Data.Core.Models.Method.MethodProposalMappingEntry", "MergedWithId");

                    b.HasOne("Data.Core.Models.Core.User", "ProposedBy")
                        .WithMany()
                        .HasForeignKey("ProposedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Method.MethodVersionedMapping", "VersionedMapping")
                        .WithMany("ProposalMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodReleaseMember", b =>
                {
                    b.HasOne("Data.Core.Models.Method.MethodCommittedMappingEntry", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.Release", "Release")
                        .WithMany("Methods")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Method.MethodVersionedMapping", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Method.MethodMapping", "Mapping")
                        .WithMany("VersionedMappings")
                        .HasForeignKey("MappingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Class.ClassCommittedMappingEntry", "MemberOf")
                        .WithMany()
                        .HasForeignKey("MemberOfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterCommittedMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Method.MethodVersionedMapping")
                        .WithMany("Parameters")
                        .HasForeignKey("MethodVersionedMappingId");

                    b.HasOne("Data.Core.Models.Parameter.ParameterVersionedMapping", "VersionedMapping")
                        .WithMany("CommittedMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterProposalMappingEntry", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

                    b.HasOne("Data.Core.Models.Parameter.ParameterCommittedMappingEntry", "MergedWith")
                        .WithOne("Proposal")
                        .HasForeignKey("Data.Core.Models.Parameter.ParameterProposalMappingEntry", "MergedWithId");

                    b.HasOne("Data.Core.Models.Core.User", "ProposedBy")
                        .WithMany()
                        .HasForeignKey("ProposedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Parameter.ParameterVersionedMapping", "VersionedMapping")
                        .WithMany("ProposalMappings")
                        .HasForeignKey("VersionedMappingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterReleaseMember", b =>
                {
                    b.HasOne("Data.Core.Models.Parameter.ParameterCommittedMappingEntry", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.Release", "Release")
                        .WithMany("Parameters")
                        .HasForeignKey("ReleaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Core.Models.Parameter.ParameterVersionedMapping", b =>
                {
                    b.HasOne("Data.Core.Models.Core.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Core.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Parameter.ParameterMapping", "Mapping")
                        .WithMany("VersionedMappings")
                        .HasForeignKey("MappingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Core.Models.Method.MethodCommittedMappingEntry", "ParameterOf")
                        .WithMany()
                        .HasForeignKey("ParameterOfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
