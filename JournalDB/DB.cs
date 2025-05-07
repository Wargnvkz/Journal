using System.Data.Entity;
using System.Text;
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace JournalDB
{
    public class DB : DbContext
    {
        public DB() : base("Journal")
        {
            Database.SetInitializer<DB>(new DBInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<JournalType> JournalTypes { get; set; }
        public DbSet<JournalTypeUserTypeRight> JournalTypeUserTypeRights { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageFile> MessageFiles { get; set; }

        public static List<User> GetUsersAvailableForComputerName(string ComputerName)
        {
            using (var db = new DB())
            {
                return db.Users.Where(u => String.IsNullOrEmpty(u.AutoLogonComputerNames) || u.AutoLogonComputerNames.Contains(ComputerName) || u.AutoLogonComputerNames.Contains("*")).ToList();
            }
        }
        public static User CheckUserPassword(string UserName, string PasswordHash)
        {
            using (var db = new DB())
            {
                return db.Users.Where(u => u.UserName == UserName && u.PasswordHash == PasswordHash).SingleOrDefault();
            }
        }

        public static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        public void RefreshContext()
        {
            try
            {
                var undetachedEntriesCopy = this.ChangeTracker.Entries()
                    .Where(e => e.State != EntityState.Detached)
                    .ToList();

                foreach (var entry in undetachedEntriesCopy)
                    entry.State = EntityState.Detached;
            }
            catch { }
        }
    }
    public class DBInitializer : CreateDatabaseIfNotExists<DB>
    {
        #region SQLReasonsFill

        string[] sqls = new string[] {
@"
SET IDENTITY_INSERT [dbo].[UserTypes] ON 
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (1, N'Администраторы')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (2, N'Главный инженер')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (3, N'Начальник цеха')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (4, N'Начальник службы эксплуатации')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (5, N'Системный администратор')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (6, N'Программист')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (7, N'Начальник смены')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (8, N'Оператор')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (9, N'Инженер службы эксплуатации')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (10, N'Технолог')
INSERT [dbo].[UserTypes] ([UserTypeID], [UserTypeName]) VALUES (11, N'Инженер по технике безопасности')
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
",
@"
SET IDENTITY_INSERT [dbo].[JournalTypes] ON 
INSERT [dbo].[JournalTypes] ([JournalTypeID], [JournalTypeName]) VALUES (1, N'Журнал смен')
INSERT [dbo].[JournalTypes] ([JournalTypeID], [JournalTypeName]) VALUES (2, N'Журнал службы эксплуатации')
INSERT [dbo].[JournalTypes] ([JournalTypeID], [JournalTypeName]) VALUES (3, N'Журнал технологов')
SET IDENTITY_INSERT [dbo].[JournalTypes] OFF
",
            };
        #endregion
        protected override void Seed(DB context)
        {
            base.Seed(context);
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 1, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 2, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 3, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 4, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 5, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 6, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 7, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 8, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 9, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 1, UserTypeID = 10, bUserTypeRight = 0 });

            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 1, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 2, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 3, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 4, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 5, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 6, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 7, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 8, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 9, bUserTypeRight = 0 });
            context.JournalTypeUserTypeRights.Add(new JournalTypeUserTypeRight() { JournalTypeID = 2, UserTypeID = 10, bUserTypeRight = 0 });

            foreach (var sql in sqls)
                context.Database.ExecuteSqlCommand(sql);
            context.SaveChanges();
            var userTypeAdmin = context.UserTypes.Where(ut => ut.UserTypeID == 1).First();
            var adminUser = new User() { UserName = "Admin", PasswordHash = DB.Hash("Admin"), AutoLogonComputerNames = "*" };
            adminUser.UserTypes.Add(userTypeAdmin);
            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }

}
