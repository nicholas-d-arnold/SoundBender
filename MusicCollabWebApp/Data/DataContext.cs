using Microsoft.EntityFrameworkCore;
using MusicCollabWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCollabWebApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<AudioFile> AudioFiles { get; set; }
    }
}
