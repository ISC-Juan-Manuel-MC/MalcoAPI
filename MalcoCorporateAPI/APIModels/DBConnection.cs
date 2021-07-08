using APIModels.General;
using APIModels.Security;
using Microsoft.EntityFrameworkCore;

namespace APIModels
{
    public class DBConnection : DbContext
    {

        public DBConnection():base()
        {
        }

        public DBConnection(DbContextOptions Options) : base(Options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-QFL3OT6P\DEVSERVER;Database=MalcoCorporate;Uid=sa;Pwd=DevUser;");
            }
        }

        #region General
        public virtual DbSet<ElectronicFile> ElectronicFiles { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        #endregion

        #region Security
        //public virtual DbSet<ProfileToOrganizations> ProfileToOrganizations { get; set; }
        #endregion



    }
}
