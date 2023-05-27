using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BelRusApiV2.Models.EfModels;

public partial class BelayaRusV5Context : DbContext
{
    public BelayaRusV5Context()
    {
    }

    public BelayaRusV5Context(DbContextOptions<BelayaRusV5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountCard> AccountCards { get; set; }

    public virtual DbSet<ActivitySphere> ActivitySpheres { get; set; }

    public virtual DbSet<Authorizatio> Authorizatios { get; set; }

    public virtual DbSet<ChleniUzla> ChleniUzlas { get; set; }

    public virtual DbSet<ContactInformation> ContactInformations { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JournalAudit> JournalAudits { get; set; }

    public virtual DbSet<KickedMember> KickedMembers { get; set; }

    public virtual DbSet<MemberStatus> MemberStatuses { get; set; }

    public virtual DbSet<Movement> Movements { get; set; }

    public virtual DbSet<PartyCardStatus> PartyCardStatuses { get; set; }

    public virtual DbSet<PartyPosition> PartyPositions { get; set; }

    public virtual DbSet<PausedUser> PausedUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SocialCategory> SocialCategories { get; set; }

    public virtual DbSet<Uzel> Uzels { get; set; }

    public virtual DbSet<Vetka> Vetkas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BelayaRusV5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountCard>(entity =>
        {
            entity.ToTable("AccountCard");

            entity.Property(e => e.Birhday).HasColumnType("date");
            entity.Property(e => e.IssueDatePartyCard).HasColumnType("date");
            entity.Property(e => e.LastLoginDate).HasColumnType("date");
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(50);
            entity.Property(e => e.PartyEntryDate).HasColumnType("date");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhotoPath).HasMaxLength(75);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.ActivitySphere).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.ActivitySphereId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountCard_ActivitySphere");

            entity.HasOne(d => d.Education).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.EducationId)
                .HasConstraintName("FK_AccountCard_Education");

            entity.HasOne(d => d.MembershipStatus).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.MembershipStatusId)
                .HasConstraintName("FK_AccountCard_MemberStatus");

            entity.HasOne(d => d.PartyCardStatus).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.PartyCardStatusId)
                .HasConstraintName("FK_AccountCard_PartyCardStatus");

            entity.HasOne(d => d.PartyPosition).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.PartyPositionId)
                .HasConstraintName("FK_AccountCard_PartyPosition");

            entity.HasOne(d => d.SocialCategory).WithMany(p => p.AccountCards)
                .HasForeignKey(d => d.SocialCategoryId)
                .HasConstraintName("FK_AccountCard_SocialCategory");
        });

        modelBuilder.Entity<ActivitySphere>(entity =>
        {
            entity.ToTable("ActivitySphere");

            entity.Property(e => e.Sphere).HasMaxLength(50);
        });

        modelBuilder.Entity<Authorizatio>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("Authorizatio");

            entity.HasIndex(e => e.Login, "UQ__Authoriz__5E55825BC4CF211F").IsUnique();

            entity.HasIndex(e => e.Password, "UQ__Authoriz__87909B15AC1B448D").IsUnique();

            entity.Property(e => e.MemberId).ValueGeneratedNever();
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithOne(p => p.Authorizatio)
                .HasForeignKey<Authorizatio>(d => d.MemberId)
                .HasConstraintName("FK_Authorizatio_AccountCard");

            entity.HasOne(d => d.Role).WithMany(p => p.Authorizatios)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Authorizatio_Role");
        });

        modelBuilder.Entity<ChleniUzla>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("ChleniUzla");

            entity.Property(e => e.MemberId).ValueGeneratedNever();

            entity.HasOne(d => d.Member).WithOne(p => p.ChleniUzla)
                .HasForeignKey<ChleniUzla>(d => d.MemberId)
                .HasConstraintName("FK_ChleniUzla_AccountCard");

            entity.HasOne(d => d.Uzel).WithMany(p => p.ChleniUzlas)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.UzelId)
                .HasConstraintName("FK_ChleniUzla_Uzel");
        });

        modelBuilder.Entity<ContactInformation>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("ContactInformation");

            entity.Property(e => e.MemberId).ValueGeneratedNever();
            entity.Property(e => e.LivingAddress).HasMaxLength(50);
            entity.Property(e => e.RegistrationAddress).HasMaxLength(50);
            entity.Property(e => e.TelephoneNumber).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithOne(p => p.ContactInformation)
                .HasForeignKey<ContactInformation>(d => d.MemberId)
                .HasConstraintName("FK_ContactInformation_AccountCard");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.ToTable("Education");

            entity.Property(e => e.Grade).HasMaxLength(50);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("Job");

            entity.Property(e => e.MemberId).ValueGeneratedNever();
            entity.Property(e => e.Place).HasMaxLength(50);
            entity.Property(e => e.Post).HasMaxLength(10);

            entity.HasOne(d => d.Member).WithOne(p => p.Job)
                .HasForeignKey<Job>(d => d.MemberId)
                .HasConstraintName("FK_Job_AccountCard");
        });

        modelBuilder.Entity<JournalAudit>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("JournalAudit");

            entity.Property(e => e.MemberId).ValueGeneratedNever();
            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.Data).HasMaxLength(50);
            entity.Property(e => e.Target).HasMaxLength(100);

            entity.HasOne(d => d.Member).WithOne(p => p.JournalAudit)
                .HasForeignKey<JournalAudit>(d => d.MemberId)
                .HasConstraintName("FK_JournalAuditActor_AccountCard");
        });

        modelBuilder.Entity<KickedMember>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("memberId");
            entity.Property(e => e.KickDate)
                .HasColumnType("date")
                .HasColumnName("kickDate");

            entity.HasOne(d => d.Member).WithOne(p => p.KickedMember)
                .HasForeignKey<KickedMember>(d => d.MemberId)
                .HasConstraintName("FK_KickedMembers_AccountCard");
        });

        modelBuilder.Entity<MemberStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("MemberStatus");

            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Movement>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.WhereFromMove, e.WhereToMove });

            entity.HasOne(d => d.Member).WithMany(p => p.Movements)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Movements_AccountCard");

            entity.HasOne(d => d.WhereFromMoveNavigation).WithMany(p => p.MovementWhereFromMoveNavigations)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.WhereFromMove)
                .HasConstraintName("FK_Movements_Uzel");

            entity.HasOne(d => d.WhereToMoveNavigation).WithMany(p => p.MovementWhereToMoveNavigations)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.WhereToMove)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movements_Uzel1");
        });

        modelBuilder.Entity<PartyCardStatus>(entity =>
        {
            entity.ToTable("PartyCardStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<PartyPosition>(entity =>
        {
            entity.ToTable("PartyPosition");

            entity.Property(e => e.Position).HasMaxLength(70);
        });

        modelBuilder.Entity<PausedUser>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("memberId");
            entity.Property(e => e.PauseDate)
                .HasColumnType("date")
                .HasColumnName("pauseDate");

            entity.HasOne(d => d.Member).WithOne(p => p.PausedUser)
                .HasForeignKey<PausedUser>(d => d.MemberId)
                .HasConstraintName("FK_PausedUsers_AccountCard");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<SocialCategory>(entity =>
        {
            entity.ToTable("SocialCategory");

            entity.Property(e => e.Category).HasMaxLength(50);
        });

        modelBuilder.Entity<Uzel>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.VetkaId });

            entity.ToTable("Uzel");

            entity.HasIndex(e => e.Id, "UQ__Uzel__3214EC066C4E30D8").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nazva)
                .HasMaxLength(50)
                .HasColumnName("nazva");

            entity.HasOne(d => d.Vetka).WithMany(p => p.Uzels)
                .HasForeignKey(d => d.VetkaId)
                .HasConstraintName("FK_Uzel_Vetka");
        });

        modelBuilder.Entity<Vetka>(entity =>
        {
            entity.ToTable("Vetka");

            entity.Property(e => e.Nazva)
                .HasMaxLength(50)
                .HasColumnName("nazva");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
