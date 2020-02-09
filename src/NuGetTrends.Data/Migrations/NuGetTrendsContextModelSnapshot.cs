﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NuGetTrends.Data;

namespace NuGetTrends.Data.Migrations
{
    [DbContext(typeof(NuGetTrendsContext))]
    partial class NuGetTrendsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DependencyId")
                        .HasColumnName("dependency_id")
                        .HasColumnType("text");

                    b.Property<int?>("PackageDependencyGroupId")
                        .HasColumnName("package_dependency_group_id")
                        .HasColumnType("integer");

                    b.Property<string>("Range")
                        .HasColumnName("range")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_package_dependency");

                    b.HasIndex("DependencyId");

                    b.HasIndex("PackageDependencyGroupId")
                        .HasName("ix_package_dependency_package_dependency_group_id");

                    b.ToTable("package_dependency");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependencyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PackageDetailsCatalogLeafId")
                        .HasColumnName("package_details_catalog_leaf_id")
                        .HasColumnType("integer");

                    b.Property<string>("TargetFramework")
                        .HasColumnName("target_framework")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_package_dependency_group");

                    b.HasIndex("PackageDetailsCatalogLeafId")
                        .HasName("ix_package_dependency_group_package_details_catalog_leaf_id");

                    b.ToTable("package_dependency_group");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDetailsCatalogLeaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Authors")
                        .HasColumnName("authors")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CommitTimestamp")
                        .HasColumnName("commit_timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnName("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .HasColumnName("icon_url")
                        .HasColumnType("text");

                    b.Property<bool?>("IsPrerelease")
                        .HasColumnName("is_prerelease")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .HasColumnName("language")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastEdited")
                        .HasColumnName("last_edited")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LicenseUrl")
                        .HasColumnName("license_url")
                        .HasColumnType("text");

                    b.Property<bool?>("Listed")
                        .HasColumnName("listed")
                        .HasColumnType("boolean");

                    b.Property<string>("MinClientVersion")
                        .HasColumnName("min_client_version")
                        .HasColumnType("text");

                    b.Property<string>("PackageHash")
                        .HasColumnName("package_hash")
                        .HasColumnType("text");

                    b.Property<string>("PackageHashAlgorithm")
                        .HasColumnName("package_hash_algorithm")
                        .HasColumnType("text");

                    b.Property<string>("PackageId")
                        .HasColumnName("package_id")
                        .HasColumnType("text");

                    b.Property<long>("PackageSize")
                        .HasColumnName("package_size")
                        .HasColumnType("bigint");

                    b.Property<string>("PackageVersion")
                        .HasColumnName("package_version")
                        .HasColumnType("text");

                    b.Property<string>("ProjectUrl")
                        .HasColumnName("project_url")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Published")
                        .HasColumnName("published")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnName("release_notes")
                        .HasColumnType("text");

                    b.Property<bool?>("RequireLicenseAgreement")
                        .HasColumnName("require_license_agreement")
                        .HasColumnType("boolean");

                    b.Property<string>("Summary")
                        .HasColumnName("summary")
                        .HasColumnType("text");

                    b.Property<List<string>>("Tags")
                        .IsRequired()
                        .HasColumnName("tags")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("integer");

                    b.Property<string>("VerbatimVersion")
                        .HasColumnName("verbatim_version")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_package_details_catalog_leafs");

                    b.HasIndex("PackageId");

                    b.HasIndex("PackageId", "PackageVersion")
                        .IsUnique();

                    b.ToTable("package_details_catalog_leafs");
                });

            modelBuilder.Entity("NuGetTrends.Data.Cursor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Value")
                        .HasColumnName("value")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("pk_cursors");

                    b.ToTable("cursors");

                    b.HasData(
                        new
                        {
                            Id = "Catalog",
                            Value = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("NuGetTrends.Data.DailyDownload", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnName("package_id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DownloadCount")
                        .HasColumnName("download_count")
                        .HasColumnType("bigint");

                    b.HasKey("PackageId", "Date");

                    b.ToTable("daily_downloads");
                });

            modelBuilder.Entity("NuGetTrends.Data.DailyDownloadResult", b =>
                {
                    b.Property<long?>("Count")
                        .HasColumnName("download_count")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Week")
                        .HasColumnName("week")
                        .HasColumnType("timestamp without time zone");

                    b.ToTable("daily_download_result");
                });

            modelBuilder.Entity("NuGetTrends.Data.PackageDownload", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnName("package_id")
                        .HasColumnType("text");

                    b.Property<string>("IconUrl")
                        .HasColumnName("icon_url")
                        .HasColumnType("text");

                    b.Property<long?>("LatestDownloadCount")
                        .HasColumnName("latest_download_count")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LatestDownloadCountCheckedUtc")
                        .HasColumnName("latest_download_count_checked_utc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PackageIdLowered")
                        .IsRequired()
                        .HasColumnName("package_id_lowered")
                        .HasColumnType("text");

                    b.HasKey("PackageId");

                    b.HasIndex("PackageIdLowered")
                        .IsUnique();

                    b.ToTable("package_downloads");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependency", b =>
                {
                    b.HasOne("NuGet.Protocol.Catalog.Models.PackageDependencyGroup", null)
                        .WithMany("Dependencies")
                        .HasForeignKey("PackageDependencyGroupId")
                        .HasConstraintName("fk_package_dependency_package_dependency_group_package_dependenc")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependencyGroup", b =>
                {
                    b.HasOne("NuGet.Protocol.Catalog.Models.PackageDetailsCatalogLeaf", null)
                        .WithMany("DependencyGroups")
                        .HasForeignKey("PackageDetailsCatalogLeafId")
                        .HasConstraintName("fk_package_dependency_group_package_details_catalog_leafs_package")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
