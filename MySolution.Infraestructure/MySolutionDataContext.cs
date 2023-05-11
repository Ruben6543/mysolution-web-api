using Microsoft.EntityFrameworkCore;
using MySolution.Infraestructure.Configuration;
using MySolution.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Infraestructure
{
    public class MySolutionDataContext :DbContext
    {
        public DbSet<MusicEntity> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new MusicConfiguration());
        }
    }
}
