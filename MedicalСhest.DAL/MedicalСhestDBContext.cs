using MedicalСhest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicalСhest.DAL
{
    public class MedicalСhestDBContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public MedicalСhestDBContext(DbContextOptions<MedicalСhestDBContext> options)
            : base(options)
        {
        }
    }
}
