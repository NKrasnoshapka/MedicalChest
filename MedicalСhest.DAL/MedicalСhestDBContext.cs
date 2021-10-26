using MedicalСhest.DAL.IdentityModels;
using MedicalСhest.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicalСhest.DAL
{
    public class MedicalСhestDBContext : IdentityDbContext<MedicalChestUser>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public MedicalСhestDBContext(DbContextOptions<MedicalСhestDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
