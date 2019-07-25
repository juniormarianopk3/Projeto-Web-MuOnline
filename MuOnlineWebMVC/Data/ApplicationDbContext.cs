using System;
using Microsoft.EntityFrameworkCore;

namespace MuOnlineWebMVC.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AccountCharacter> AccountCharacter { get; set; }
        public virtual DbSet<Blocking> Blocking { get; set; }
        public virtual DbSet<BlockingLog> BlockingLog { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<DefaultClassType> DefaultClassType { get; set; }
        public virtual DbSet<ExtWareHouse> ExtWareHouse { get; set; }
        public virtual DbSet<GameServerInfo> GameServerInfo { get; set; }
        public virtual DbSet<Guild> Guild { get; set; }
        public virtual DbSet<GuildMember> GuildMember { get; set; }
        public virtual DbSet<MembInfo> MembInfo { get; set; }
        public virtual DbSet<MembStat> MembStat { get; set; }
        public virtual DbSet<OptionData> OptionData { get; set; }
        public virtual DbSet<ViCurrInfo> ViCurrInfo { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountCharacter>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId1)
                    .HasColumnName("GameID1")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameId2)
                    .HasColumnName("GameID2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameId3)
                    .HasColumnName("GameID3")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameId4)
                    .HasColumnName("GameID4")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameId5)
                    .HasColumnName("GameID5")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GameIdc)
                    .HasColumnName("GameIDC")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoveCnt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Number).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Blocking>(entity =>
            {
                entity.HasKey(e => e.BlockGuid);

                entity.ToTable("BLOCKING");

                entity.Property(e => e.BlockGuid).HasColumnName("block_guid");

                entity.Property(e => e.ApplDays)
                    .IsRequired()
                    .HasColumnName("appl_days")
                    .HasColumnType("char(8)");

                entity.Property(e => e.CharName)
                    .HasColumnName("char_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ctl1Code)
                    .IsRequired()
                    .HasColumnName("ctl1_code")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.MembCont)
                    .HasColumnName("memb_cont")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MembGuid).HasColumnName("memb_guid");

                entity.Property(e => e.RelsDays)
                    .IsRequired()
                    .HasColumnName("rels_days")
                    .HasColumnType("char(8)");

                entity.Property(e => e.ServGuid).HasColumnName("serv_guid");

                entity.Property(e => e.TakeCode)
                    .IsRequired()
                    .HasColumnName("take_code")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TakeCont)
                    .IsRequired()
                    .HasColumnName("take_cont")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BlockingLog>(entity =>
            {
                entity.HasKey(e => new { e.ApplDays, e.AdminGuid, e.DistCode });

                entity.ToTable("BLOCKING_LOG");

                entity.Property(e => e.ApplDays)
                    .HasColumnName("appl_days")
                    .HasColumnType("datetime");

                entity.Property(e => e.AdminGuid).HasColumnName("admin_guid");

                entity.Property(e => e.DistCode)
                    .HasColumnName("dist_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasColumnName("admin_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockGuid).HasColumnName("block_guid");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Image)
                .HasDefaultValueSql("nophoto.jpg")
                .IsRequired();



                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("AccountID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CLevel)
                    .HasColumnName("cLevel")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ChatLimitTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.CtlCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.DbVersion).HasDefaultValueSql("((0))");

                entity.Property(e => e.Experience).HasDefaultValueSql("((0))");

                entity.Property(e => e.FruitPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.Inventory).HasMaxLength(1728);

                entity.Property(e => e.Ldate)
                    .HasColumnName("LDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Leadership).HasDefaultValueSql("((0))");

                entity.Property(e => e.MagicList).HasMaxLength(180);

                entity.Property(e => e.MapDir).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mdate)
                    .HasColumnName("MDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Money).HasDefaultValueSql("((0))");

                entity.Property(e => e.MrSemanal).HasDefaultValueSql("((0))");

                entity.Property(e => e.MrTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.PkCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.PkHeroSemanal).HasDefaultValueSql("((0))");

                entity.Property(e => e.PkHeroTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.PkLevel).HasDefaultValueSql("((3))");

                entity.Property(e => e.PkTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quest)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Resets).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResetsWeek).HasDefaultValueSql("((0))");

            });

            modelBuilder.Entity<DefaultClassType>(entity =>
            {
                entity.HasKey(e => e.Class);

                entity.Property(e => e.Inventory).HasMaxLength(1728);

                entity.Property(e => e.Leadership).HasDefaultValueSql("((0))");

                entity.Property(e => e.Level).HasDefaultValueSql("((0))");

                entity.Property(e => e.LevelUpPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.MagicList).HasMaxLength(180);

                entity.Property(e => e.Quest).HasMaxLength(50);
            });

            modelBuilder.Entity<ExtWareHouse>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Number });

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndUseDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Items).HasMaxLength(1920);

                entity.Property(e => e.Money).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pw)
                    .HasColumnName("pw")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<GameServerInfo>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Number).HasDefaultValueSql("((0))");

                entity.Property(e => e.ZenCount).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Guild>(entity =>
            {
                entity.HasKey(e => e.GId);

                entity.Property(e => e.GId)
                    .HasColumnName("G_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GCount).HasColumnName("G_Count");

                entity.Property(e => e.GMark)
                    .HasColumnName("G_Mark")
                    .HasMaxLength(32);

                entity.Property(e => e.GMaster)
                    .HasColumnName("G_Master")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GName)
                    .IsRequired()
                    .HasColumnName("G_Name")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GNotice)
                    .HasColumnName("G_Notice")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.GRival).HasColumnName("G_Rival");

                entity.Property(e => e.GScore).HasColumnName("G_Score");

                entity.Property(e => e.GScoreWeek).HasColumnName("G_ScoreWeek");

                entity.Property(e => e.GType).HasColumnName("G_Type");

                entity.Property(e => e.GUnion).HasColumnName("G_Union");
            });

            modelBuilder.Entity<GuildMember>(entity =>
            {
                entity.HasKey(e => e.GId);

                entity.Property(e => e.GId)
                    .HasColumnName("G_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GLevel).HasColumnName("G_Level");

                entity.Property(e => e.GName)
                    .IsRequired()
                    .HasColumnName("G_Name")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GStatus).HasColumnName("G_Status");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MembInfo>(entity =>
            {
                entity.HasKey(e => e.MembGuid)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MEMB_INFO");

                entity.Property(e => e.MembGuid).HasColumnName("memb_guid");

                entity.Property(e => e.AccountVip)
                    .HasColumnName("AccountVIP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AddrDeta)
                    .HasColumnName("addr_deta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddrInfo)
                    .HasColumnName("addr_info")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApplDays)
                    .HasColumnName("appl_days")
                    .HasColumnType("datetime");

                entity.Property(e => e.BlocCode)
                    .IsRequired()
                    .HasColumnName("bloc_code")
                    .HasColumnType("char(1)");

                entity.Property(e => e.BlocDate)
                    .HasColumnName("bloc_date")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Cash).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cspoints)
                    .HasColumnName("CSPoints")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ctl1Code)
                    .IsRequired()
                    .HasColumnName("ctl1_code")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Expired)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FpasAnsw)
                    .HasColumnName("fpas_answ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FpasQues)
                    .HasColumnName("fpas_ques")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gold).HasDefaultValueSql("((0))");

                entity.Property(e => e.Jf)
                    .HasColumnName("jf")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JobCode)
                    .HasColumnName("job__code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.LastIp)
                    .HasColumnName("last_ip")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastS)
                    .HasColumnName("last_s")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MailAddr)
                    .HasColumnName("mail_addr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailChek)
                    .HasColumnName("mail_chek")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MembId)
                    .IsRequired()
                    .HasColumnName("memb___id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MembName)
                    .IsRequired()
                    .HasColumnName("memb_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MembPwd)
                    .IsRequired()
                    .HasColumnName("memb__pwd")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Member)
                    .HasColumnName("member")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModiDays)
                    .HasColumnName("modi_days")
                    .HasColumnType("datetime");

                entity.Property(e => e.OutDays)
                    .HasColumnName("out__days")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhonNumb)
                    .HasColumnName("phon_numb")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasColumnName("post_code")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Rcb)
                    .HasColumnName("rcb")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SmsT)
                    .HasColumnName("sms_t")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SnoNumb)
                    .IsRequired()
                    .HasColumnName("sno__numb")
                    .HasColumnType("char(18)");

                entity.Property(e => e.TelNumb)
                    .HasColumnName("tel__numb")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrueDays)
                    .HasColumnName("true_days")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vip).HasDefaultValueSql("((0))");

                entity.Property(e => e.VipBegin)
                    .HasColumnName("VIP_Begin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VipFree)
                    .HasColumnName("vip_free")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VipInteger)
                    .HasColumnName("VIP_Integer")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VipTime)
                    .HasColumnName("VIP_Time")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Zy)
                    .HasColumnName("ZY")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MembStat>(entity =>
            {
                entity.HasKey(e => e.MembId);

                entity.ToTable("MEMB_STAT");

                entity.Property(e => e.MembId)
                    .HasColumnName("memb___id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConnectTm)
                    .HasColumnName("ConnectTM")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DisConnectTm)
                    .HasColumnName("DisConnectTM")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OnlineHours).HasDefaultValueSql("((0))");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OptionData>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SkillKey).HasColumnType("binary(10)");
            });

            modelBuilder.Entity<ViCurrInfo>(entity =>
            {
                entity.HasKey(e => e.MembGuid);

                entity.ToTable("VI_CURR_INFO");

                entity.Property(e => e.MembGuid)
                    .HasColumnName("memb_guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillHour).HasColumnName("Bill_Hour");

                entity.Property(e => e.BillSection).HasColumnName("Bill_Section");

                entity.Property(e => e.BillValue).HasColumnName("Bill_Value");

                entity.Property(e => e.ChekCode)
                    .IsRequired()
                    .HasColumnName("chek_code")
                    .HasMaxLength(1);

                entity.Property(e => e.EndsDays)
                    .HasColumnName("ends_days")
                    .HasMaxLength(8);

                entity.Property(e => e.IncreaseDays).HasColumnName("Increase_Days");

                entity.Property(e => e.MembId)
                    .IsRequired()
                    .HasColumnName("memb___id")
                    .HasMaxLength(10);

                entity.Property(e => e.MembName)
                    .IsRequired()
                    .HasColumnName("memb_name")
                    .HasMaxLength(10);

                entity.Property(e => e.SnoNumb)
                    .IsRequired()
                    .HasColumnName("sno__numb")
                    .HasMaxLength(18);

                entity.Property(e => e.SurplusMinute)
                    .HasColumnName("Surplus_Minute")
                    .HasColumnType("datetime");

                entity.Property(e => e.SurplusPoint).HasColumnName("Surplus_Point");

                entity.Property(e => e.UsedTime).HasColumnName("used_time");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("warehouse");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DbVersion).HasDefaultValueSql("((0))");

                entity.Property(e => e.EndUseDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Items).HasMaxLength(1920);

                entity.Property(e => e.Money).HasDefaultValueSql("((0))");

                entity.Property(e => e.Number).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pw)
                    .HasColumnName("pw")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Total).HasDefaultValueSql("((0))");

                entity.Property(e => e.Vaults).HasDefaultValueSql("((0))");
            });
        }
    }
}
