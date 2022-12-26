using Microsoft.EntityFrameworkCore;
using NoCond.Persistence.Email.Configurations;
using NoCond.Persistence.Meeting.Configurations;
using NoCond.Persistence.Settings.Configurations;
using NoCond.Persistence.Unit.Configurations;

namespace NoCond.Persistence
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Meeting
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingUnitConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonAddressConfiguration());
            modelBuilder.ApplyConfiguration(new VotingSessionConfiguration());
            modelBuilder.ApplyConfiguration(new VotingTopicConfiguration());
            modelBuilder.ApplyConfiguration(new VotingTopicOptionConfiguration());
            modelBuilder.ApplyConfiguration(new VotingTopicCandidateConfiguration());

            // Unit
            modelBuilder.ApplyConfiguration(new UnitGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new UnitTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerTypeConfiguration());
            
            // Email
            modelBuilder.ApplyConfiguration(new EmailTemplateConfiguration());
            
            // Settings
            modelBuilder.ApplyConfiguration(new MeetingSettingsConfiguration());
        }
    }
}