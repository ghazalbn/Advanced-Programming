using Microsoft.EntityFrameworkCore;
using MyProj.Shared.Data;

namespace MyProj.Server
{
    public class ModelContext : DbContext
    {
        public DbSet<Professor> Professors {get;set;}
        public DbSet<Comment> Comments {get;set;}
        public DbSet<Booklet> Booklets {get;set;}
        public DbSet<Student> Students {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=professor.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>().HasData(
                // Computer
                new Professor ("مهرداد آشتیانی", "مهندسی کامپیوتر", 1),
                new Professor ("رضا انتظاری", "مهندسی کامپیوتر", 2),
                new Professor ("سعید پارسا", "مهندسی کامپیوتر", 3),
                new Professor ("مرضیه ملکی مجد", "مهندسی کامپیوتر", 4),
                new Professor ("صالح اعتمادی", "مهندسی کامپیوتر", 5),
        
                // sanaye
                new Professor ("فرناز برزین پور", "مهندسی صنایع", 6),
                new Professor ("رسول نورالنساء", "مهندسی صنایع", 7),
                new Professor ("محمد سعیدی مهرآباد", "مهندسی صنایع", 8),
                new Professor ("مهدی حیدری", "مهندسی صنایع", 9),

                // bargh
                new Professor ("کریم محمدی", "مهندسی برق", 10),
                new Professor ("محمدنژاد", "مهندسی برق", 11),
                new Professor ("موسوی میرکلایی", "مهندسی برق", 12),
                new Professor ("یاوند حسنی", "مهندسی برق", 13),

                // memari
                new Professor ("مصطفی بهزادفر", "معماری و شهرسازی", 14),
                new Professor ("محسن فیضی", "معماری و شهرسازی", 15),
                new Professor ("اصغر محمدمرادی", "معماری و شهرسازی", 16),
                new Professor ("محسن وفامهر", "معماری و شهرسازی", 17),

                // pishraft
                new Professor ("محسن وفامهر", "مهندسی پیشرفت", 18),

                // khodro
                new Professor ("محسن وفامهر", "مهندسی خودرو", 19),

                // rahahan
                new Professor ("محسن وفامهر", "مهندسی راه آهن", 20),

                // shimi
                new Professor ("محسن وفامهر", "مهندسی شیمی", 21),

                // omran
                new Professor ("محسن وفامهر", "مهندسی عمران", 22),

                // machanic
                new Professor ("محسن وفامهر", "مهندسی مکانیک", 23),

                // mavad
                new Professor ("محسن وفامهر", "مهندسی مواد و متالوژی", 24),

                // riazi:)
                new Professor ("محسن وفامهر", "ریاضی", 25),

                // physic
                new Professor ("محسن وفامهر", "فیزیک", 26),

                // zaban
                new Professor ("محسن وفامهر", "زبان", 27),

                // tarbiat badani
                new Professor ("محسن وفامهر", "تربیت بدنی", 28),

                // maaref
                new Professor ("محسن وفامهر", "معارف", 29)
            );
            modelBuilder.Entity<Booklet>().HasData(
                // computer
                new Booklet (1, "مهندسی کامپیوتر", "گسسته", "وصال حکمی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (2, "مهندسی کامپیوتر", "گسسته", "رضا انتظاری ملکی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (3, "مهندسی کامپیوتر", "مبانی کامپیوتر", "صالح اعتمادی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (4, "مهندسی کامپیوتر", "مبانی کامپیوتر", "مرضیه ملکی مجد", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (5, "مهندسی کامپیوتر", "طراحی بازیهای کامپیوتری", "زینب موحدی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (6, "مهندسی کامپیوتر", "برنامه نویسی پیشرفته", "صالح اعتمادی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (7, "مهندسی کامپیوتر","برنامه نویسی پیشرفته", "مرضیه ملکی مجد", "Nadjafikhah - Calculus II - Persian.pdf"),

                // riazi
                new Booklet (8, "ریاضی", "ریاضی2", "سمانه مشهدی", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (9, "ریاضی", "ریاضی2", "مهدی نجفی خواه", "Nadjafikhah - Calculus II - Persian.pdf"),
                new Booklet (10, "ریاضی", "ریاضی2", "محمد یعقوبی فر", "Nadjafikhah - Calculus II - Persian.pdf")


            );            
        }
    }
}