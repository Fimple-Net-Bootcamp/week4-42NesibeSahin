﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DataAccessLayer.Context;

#nullable disable

namespace hafta3.Migrations
{
    [DbContext(typeof(ProjeDB))]
    partial class ProjeDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("hafta3.Entities.Aktiviteler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("Aktiviteler");
                });

            modelBuilder.Entity("hafta3.Entities.Besinler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Besinler");
                });

            modelBuilder.Entity("hafta3.Entities.Beslenme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BesinlerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("BesinlerID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("Beslenme");
                });

            modelBuilder.Entity("hafta3.Entities.Egitimler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EgitimTuru")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("Egitimler");
                });

            modelBuilder.Entity("hafta3.Entities.Etkinlikler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Etkinlikler");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Kodu")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("hafta3.Entities.SaglikDurumlari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DurumAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HastaMi")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("SaglikDurumlari");
                });

            modelBuilder.Entity("hafta3.Entities.SosyalEtkilesimler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EtkinlikID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvcilHayvanID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isSilindi")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EtkinlikID");

                    b.HasIndex("EvcilHayvanID");

                    b.ToTable("SosyalEtkilesimler");
                });

            modelBuilder.Entity("hafta3.Entities.Aktiviteler", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("Aktiviteler")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Beslenme", b =>
                {
                    b.HasOne("hafta3.Entities.Besinler", "Besinler")
                        .WithMany("Beslenme")
                        .HasForeignKey("BesinlerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("Beslenme")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Besinler");

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Egitimler", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("Egitimler")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.HasOne("hafta3.Entities.Kullanici", "Kullanici")
                        .WithMany("EvcilHayvanlar")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("hafta3.Entities.SaglikDurumlari", b =>
                {
                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("SaglikDurumlari")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.SosyalEtkilesimler", b =>
                {
                    b.HasOne("hafta3.Entities.Etkinlikler", "Etkinlikler")
                        .WithMany("SosyalEtkilesimler")
                        .HasForeignKey("EtkinlikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hafta3.Entities.EvcilHayvanlar", "EvcilHayvanlar")
                        .WithMany("SosyalEtkilesimler")
                        .HasForeignKey("EvcilHayvanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etkinlikler");

                    b.Navigation("EvcilHayvanlar");
                });

            modelBuilder.Entity("hafta3.Entities.Besinler", b =>
                {
                    b.Navigation("Beslenme");
                });

            modelBuilder.Entity("hafta3.Entities.Etkinlikler", b =>
                {
                    b.Navigation("SosyalEtkilesimler");
                });

            modelBuilder.Entity("hafta3.Entities.EvcilHayvanlar", b =>
                {
                    b.Navigation("Aktiviteler");

                    b.Navigation("Beslenme");

                    b.Navigation("Egitimler");

                    b.Navigation("SaglikDurumlari");

                    b.Navigation("SosyalEtkilesimler");
                });

            modelBuilder.Entity("hafta3.Entities.Kullanici", b =>
                {
                    b.Navigation("EvcilHayvanlar");
                });
#pragma warning restore 612, 618
        }
    }
}
