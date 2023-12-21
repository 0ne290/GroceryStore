﻿using GroceryStore.Data.Interfaces;
using GroceryStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GroceryStore.Data;

public sealed class MySqlContext : GroceryStoreContext
{
    public MySqlContext(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("connectionString should not be empty.", nameof(connectionString));

        _connectionString = connectionString;
        
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Города");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код города");
            entity.Property(e => e.RegionKey).HasColumnName("Код региона");
            entity.Property(e => e.Name).HasMaxLength(255);
            
            entity.HasOne(d => (Region)d.RegionKeyNavigation).WithMany(p => (IEnumerable<City>)p.Cities)
                .HasForeignKey(d => d.RegionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("РегионыГорода");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Должности");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код должности");
            entity.Property(e => e.Name).HasMaxLength(255);
        });
        
        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Магазины");

            entity.Property(e => e.Key).ValueGeneratedNever();
            entity.Property(e => e.EndOfLease).HasColumnName("Аренда_до");
            entity.Property(e => e.CityKey).HasColumnName("Код города");
            entity.Property(e => e.RegionKey).HasColumnName("Код региона");
            entity.Property(e => e.StreetKey).HasColumnName("Код улицы");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.HouseLetter).HasMaxLength(255);
            entity.Property(e => e.HouseNumber).HasColumnName("Номер дома");

            entity.HasOne(d => (City)d.CityKeyNavigation).WithMany(p => (IEnumerable<Store>)p.Stores)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ГородаМагазины");

            entity.HasOne(d => (Region)d.RegionKeyNavigation).WithMany(p => (IEnumerable<Store>)p.Stores)
                .HasForeignKey(d => d.RegionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("РегионыМагазины");

            entity.HasOne(d => (Street)d.StreetKeyNavigation).WithMany(p => (IEnumerable<Store>)p.Stores)
                .HasForeignKey(d => d.StreetKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("УлицыМагазины");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Персонал магазинов");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код сотрудника");
            entity.Property(e => e.FullName).HasColumnName("ФИО");
            entity.Property(e => e.EmploymentDate).HasColumnName("Дата приема на работу");
            entity.Property(e => e.PositionKey).HasColumnName("Код должности");
            entity.Property(e => e.StoreKey).HasColumnName("Код магазина");

            entity.HasOne(d => (Position)d.PositionKeyNavigation).WithMany(p => (IEnumerable<Employee>)p.StoreStaff)
                .HasForeignKey(d => d.PositionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ДолжностиПерсонал магазинов");

            entity.HasOne(d => (Store)d.StoreKeyNavigation).WithMany(p => (IEnumerable<Employee>)p.Staff)
                .HasForeignKey(d => d.StoreKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("МагазиныПерсонал магазинов");
        });
        
        modelBuilder.Entity<RegularCustomer>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Постоянные клиенты");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код клиента");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => new { КодТовара = e.ProductKey, КодКлиента = e.CustomerKey, Дата = e.Date }).HasName("PrimaryKey");

            entity.ToTable("Продажа");

            entity.Property(e => e.ProductKey).HasColumnName("Код_товара");
            entity.Property(e => e.CustomerKey).HasColumnName("Код клиента");

            entity.HasOne(d => (RegularCustomer)d.CustomerKeyNavigation).WithMany(p => (IEnumerable<Sale>)p.Purchases)
                .HasForeignKey(d => d.CustomerKey)
                .HasConstraintName("Постоянные клиентыПродажа");

            entity.HasOne(d => (Product)d.ProductKeyNavigation).WithMany(p => (IEnumerable<Sale>)p.Sales)
                .HasForeignKey(d => d.ProductKey)
                .HasConstraintName("ТоварыПродажа");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Производитель");

            entity.Property(e => e.Key).HasColumnName("Код_производителя");
            entity.Property(e => e.CityKey).HasColumnName("Код_города");
            entity.Property(e => e.RegionKey).HasColumnName("Код_региона");
            entity.Property(e => e.CountryKey).HasColumnName("Код_страны");
            entity.Property(e => e.StreetKey).HasColumnName("Код_улицы");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.HouseLetter).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.HouseNumber).HasColumnName("Номер_дома");

            entity.HasOne(d => (City)d.CityKeyNavigation).WithMany(p => (IEnumerable<Manufacturer>)p.Manufacturers)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ГородаПроизводитель");

            entity.HasOne(d => (Region)d.RegionKeyNavigation).WithMany(p => (IEnumerable<Manufacturer>)p.Manufacturers)
                .HasForeignKey(d => d.RegionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("РегионыПроизводитель");

            entity.HasOne(d => (Country)d.CountryKeyNavigation).WithMany(p => (IEnumerable<Manufacturer>)p.Manufacturers)
                .HasForeignKey(d => d.CountryKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("СтраныПроизводитель");

            entity.HasOne(d => (Street)d.StreetKeyNavigation).WithMany(p => (IEnumerable<Manufacturer>)p.Manufacturers)
                .HasForeignKey(d => d.StreetKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("УлицыПроизводитель");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Регионы");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код региона");
            entity.Property(e => e.CountryKey).HasColumnName("Код страны");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => (Country)d.CountryKeyNavigation).WithMany(p => (IEnumerable<Region>)p.Regions)
                .HasForeignKey(d => d.CountryKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("СтраныРегионы");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Склады");

            entity.Property(e => e.Key).ValueGeneratedNever();
            entity.Property(e => e.EndOfLease).HasColumnName("Аренда_до");
            entity.Property(e => e.CityKey).HasColumnName("Код города");
            entity.Property(e => e.RegionKey).HasColumnName("Код региона");
            entity.Property(e => e.StreetKey).HasColumnName("Код улицы");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.HouseLetter).HasMaxLength(255);
            entity.Property(e => e.HouseNumber).HasColumnName("Номер дома");

            entity.HasOne(d => (City)d.CityKeyNavigation).WithMany(p => (IEnumerable<Warehouse>)p.Warehouses)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ГородаСклады");

            entity.HasOne(d => (Region)d.RegionKeyNavigation).WithMany(p => (IEnumerable<Warehouse>)p.Warehouses)
                .HasForeignKey(d => d.RegionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("РегионыСклады");

            entity.HasOne(d => (Street)d.StreetKeyNavigation).WithMany(p => (IEnumerable<Warehouse>)p.Warehouses)
                .HasForeignKey(d => d.StreetKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("УлицыСклады");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Страны");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код страны");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Товары");

            entity.HasIndex(e => e.Name, "ТоварыНаименование");

            entity.Property(e => e.Key).HasColumnName("Код товара");
            entity.Property(e => e.ManufacturerKey).HasColumnName("Код производителя");
            entity.Property(e => e.BestBefore).HasColumnName("Срок годности");
            entity.Property(e => e.DegreeOfProcessing)
                .HasMaxLength(255)
                .HasColumnName("Степень обработки");

            entity.HasOne(d => (Manufacturer)d.ManufacturerKeyNavigation).WithMany(p => (IEnumerable<Product>)p.Products)
                .HasForeignKey(d => d.ManufacturerKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ПроизводительТовары");
        });

        modelBuilder.Entity<ProductInStore>(entity =>
        {
            entity.HasKey(e => new { КодМагазина = e.StoreKey, КодТовара = e.ProductKey }).HasName("PrimaryKey");

            entity.ToTable("Товары в магазинах");

            entity.Property(e => e.StoreKey).HasColumnName("Код магазина");
            entity.Property(e => e.ProductKey).HasColumnName("Код товара");
            entity.Property(e => e.Quantity).HasColumnName("Кол-во");
            entity.Property(e => e.WarehouseKey).HasColumnName("Привезено со склада");

            entity.HasOne(d => (Store)d.StoreKeyNavigation).WithMany(p => (IEnumerable<ProductInStore>)p.Products)
                .HasForeignKey(d => d.StoreKey)
                .HasConstraintName("МагазиныТовары в магазинах");

            entity.HasOne(d => (Product)d.ProductKeyNavigation).WithMany(p => (IEnumerable<ProductInStore>)p.ProductsInStores)
                .HasForeignKey(d => d.ProductKey)
                .HasConstraintName("ТоварыТовары в магазинах");

            entity.HasOne(d => (Warehouse)d.WarehouseKeyNavigation).WithMany(p => (IEnumerable<ProductInStore>)p.ProductsInStores)
                .HasForeignKey(d => d.WarehouseKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("СкладыТовары в магазинах");
        });

        modelBuilder.Entity<ProductInWarehouse>(entity =>
        {
            entity.HasKey(e => new { КодСклада = e.WarehouseKey, КодТовара = e.ProductKey }).HasName("PrimaryKey");

            entity.ToTable("Товары на складах");

            entity.Property(e => e.WarehouseKey).HasColumnName("Код склада");
            entity.Property(e => e.ProductKey).HasColumnName("Код товара");
            entity.Property(e => e.DateOfManufacture).HasColumnName("Дата производства");
            entity.Property(e => e.Quantity).HasColumnName("Кол-во");

            entity.HasOne(d => (Warehouse)d.WarehouseKeyNavigation).WithMany(p => (IEnumerable<ProductInWarehouse>)p.ProductsInWarehouses)
                .HasForeignKey(d => d.WarehouseKey)
                .HasConstraintName("СкладыТовары на складах");

            entity.HasOne(d => (Product)d.ProductKeyNavigation).WithMany(p => (IEnumerable<ProductInWarehouse>)p.ProductsInWarehouses)
                .HasForeignKey(d => d.ProductKey)
                .HasConstraintName("ТоварыТовары на складах");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PrimaryKey");

            entity.ToTable("Улицы");

            entity.Property(e => e.Key)
                .ValueGeneratedNever()
                .HasColumnName("Код улицы");
            entity.Property(e => e.CityKey).HasColumnName("Код города");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => (City)d.CityKeyNavigation).WithMany(p => (IEnumerable<Street>)p.Streets)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ГородаУлицы");
        });
    }
    
    private readonly string _connectionString;
}
