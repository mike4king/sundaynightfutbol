using Microsoft.EntityFrameworkCore;
using SoccerLeague.Models;

namespace SoccerLeague.Data
{
    public class SoccerLeagueContext : DbContext
    {
        public SoccerLeagueContext (DbContextOptions<SoccerLeagueContext> options) : base(options) { }

        public DbSet<Team> Team { get; set; } = default!;
        public DbSet<Season> Season { get; set; } = default!;
        public DbSet<Match> Match { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<SeasonTeamBridge>()
                .HasKey(b => new { b.SeasonId, b.TeamId });
            modelBuilder.Entity<SeasonTeamBridge>()
                .HasOne(b => b.Season)
                .WithMany(b => b.TeamBridges)
                .HasForeignKey(b => b.SeasonId);
            modelBuilder.Entity<SeasonTeamBridge>()
                .HasOne(b => b.Team)
                .WithMany(b => b.SeasonBridges)
                .HasForeignKey(b => b.TeamId);

            modelBuilder.Entity<Season>().HasData(new Season { Id = 1, Name = "2021 Summer", StartDate = new DateTime(2021,5,2)});
            modelBuilder.Entity<Season>().HasData(new Season { Id = 2, Name = "2021 Fall", StartDate = new DateTime(2021, 9, 12) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 3, Name = "2021 Winter 1", StartDate = new DateTime(2021, 11, 28) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 4, Name = "2021 Winter 2", StartDate = new DateTime(2022, 2, 20) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 5, Name = "2022 Summer", StartDate = new DateTime(2022, 5, 15) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 6, Name = "2022 Fall", StartDate = new DateTime(2022, 9, 11) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 7, Name = "2022 Winter 1", StartDate = new DateTime(2022, 11, 20) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 8, Name = "2022 Winter 2", StartDate = new DateTime(2023, 2, 5) });
            modelBuilder.Entity<Season>().HasData(new Season { Id = 9, Name = "2023 Summer", StartDate = new DateTime(2023, 5, 21) });

            modelBuilder.Entity<Team>().HasData(new Team { Id = 1, Color = "Gold", Name = "Goal Diggers"});
            modelBuilder.Entity<Team>().HasData(new Team { Id = 2, Color = null, Name = "Saigon FC" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 3, Color = null, Name = "UmBros" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 4, Color = null, Name = "Internationals" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 5, Color = "Red", Name = "Liverpool" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 6, Color = null, Name = "Deportivo Argento" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 7, Color = null, Name = "Noonan" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 8, Color = null, Name = "Ajax" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 9, Color = null, Name = "Reds FC" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 10, Color = null, Name = "Nile Crocodiles" });
            modelBuilder.Entity<Team>().HasData(new Team { Id = 11, Color = null, Name = "Unreal" });
            
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 1 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 2 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 3 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 4 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 5 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 9, TeamId = 6 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 1 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 7 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 8 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 3 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 6 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 9 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 10 });
            modelBuilder.Entity<SeasonTeamBridge>().HasData(new SeasonTeamBridge { SeasonId = 8, TeamId = 11 });

            modelBuilder.Entity<Match>().HasData(new Match { Id = 1, HomeTeamId = 1, AwayTeamId = 3, HomeTeamScore = 6, AwayTeamScore = 2, SeasonId = 9, Start = new DateTime(2023, 6, 4) });
            modelBuilder.Entity<Match>().HasData(new Match { Id = 2, HomeTeamId = 2, AwayTeamId = 5, HomeTeamScore = 5, AwayTeamScore = 4, SeasonId = 9, Start = new DateTime(2023, 6, 4) });
            modelBuilder.Entity<Match>().HasData(new Match { Id = 3, HomeTeamId = 4, AwayTeamId = 6, HomeTeamScore = 2, AwayTeamScore = 0, SeasonId = 9, Start = new DateTime(2023, 6, 4) });

            modelBuilder.Entity<Match>().HasData(new Match { Id = 4, HomeTeamId = 1, AwayTeamId = 5, HomeTeamScore = 3, AwayTeamScore = 4, SeasonId = 9, Start = new DateTime(2023, 5, 21) });
            modelBuilder.Entity<Match>().HasData(new Match { Id = 5, HomeTeamId = 6, AwayTeamId = 3, HomeTeamScore = 1, AwayTeamScore = 5, SeasonId = 9, Start = new DateTime(2023, 5, 21) });
            modelBuilder.Entity<Match>().HasData(new Match { Id = 6, HomeTeamId = 4, AwayTeamId = 2, HomeTeamScore = 2, AwayTeamScore = 3, SeasonId = 9, Start = new DateTime(2023, 5, 21) });
            
            modelBuilder.Entity<Match>().HasData(new Match { Id = 7, HomeTeamId = 1, AwayTeamId = 11, HomeTeamScore = 3, AwayTeamScore = 3, SeasonId = 8, Start = new DateTime(2023, 2, 5) });
        }
    }
}
