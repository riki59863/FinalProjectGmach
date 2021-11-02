using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL‏
{
    public partial class gmach1112020Context : DbContext
    {
        public gmach1112020Context()
        {
        }

        public gmach1112020Context(DbContextOptions<gmach1112020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BankBranches> BankBranches { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<CurrencyType> CurrencyType { get; set; }
        public virtual DbSet<Deposits> Deposits { get; set; }
        public virtual DbSet<DirectDebit> DirectDebit { get; set; }
        public virtual DbSet<FeeDescription> FeeDescription { get; set; }
        public virtual DbSet<Guarnty> Guarnty { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<MangerDetails> MangerDetails { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Warning> Warning { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QRH7NBI;Database=gmach 1/11/2020;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankCode).HasColumnName("bankCode");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(50);

                entity.Property(e => e.BranchNumber).HasColumnName("branchNumber");
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bankName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreditCardExpiry)
                    .HasColumnName("creditCardExpiry")
                    .HasColumnType("date");

                entity.Property(e => e.CreditCardNumber)
                    .IsRequired()
                    .HasColumnName("creditCardNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.CreditCardNumberPlain)
                    .IsRequired()
                    .HasColumnName("creditCardNumberPlain")
                    .HasMaxLength(50);

                entity.Property(e => e.CreditCardType).HasColumnName("creditCardType");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.GatewayKey)
                    .HasColumnName("gatewayKey")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Optlock).HasColumnName("optlock");
            });

            modelBuilder.Entity<CurrencyType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedLast)
                    .HasColumnName("updatedLast")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValueInShkalim).HasColumnName("valueInShkalim");
            });

            modelBuilder.Entity<Deposits>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CreditCardId).HasColumnName("creditCardId");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DirectDebitId).HasColumnName("directDebitId");

                entity.Property(e => e.HebrewDate)
                    .HasColumnName("hebrewDate")
                    .HasMaxLength(50);

                entity.Property(e => e.HebrewReturnDate)
                    .HasColumnName("hebrewReturnDate")
                    .HasMaxLength(50);

                entity.Property(e => e.ReturnDate)
                    .HasColumnName("returnDate")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK_Deposits_CreditCard1");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposits_CurrencyType1");

                entity.HasOne(d => d.DirectDebit)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.DirectDebitId)
                    .HasConstraintName("FK_Deposits_DirectDebit1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposits_User1");
            });

            modelBuilder.Entity<DirectDebit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.BankId).HasColumnName("bankId");

                entity.Property(e => e.CollectionDay).HasColumnName("collectionDay");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyId).HasColumnName("currencyId");

                entity.Property(e => e.DirectDebitFile).HasColumnName("directDebitFile");

                entity.Property(e => e.DirectDebitSum).HasColumnName("directDebitSum");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("finishDate")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.NumberAccount).HasColumnName("numberAccount");

                entity.Property(e => e.NumberBranchId).HasColumnName("numberBranchId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.Target).HasColumnName("target");

                entity.Property(e => e.TotalSum).HasColumnName("totalSum");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.DirectDebit)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DirectDebit_Banks1");

                entity.HasOne(d => d.NumberBranch)
                    .WithMany(p => p.DirectDebit)
                    .HasForeignKey(d => d.NumberBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DirectDebit_BankBranches1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DirectDebit)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DirectDebit_User1");
            });

            modelBuilder.Entity<FeeDescription>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Guarnty>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Guarnty)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guarnty_User1");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreditCardId).HasColumnName("creditCardId");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DirectDebitId).HasColumnName("directDebitId");

                entity.Property(e => e.FirstRepaymentDate)
                    .HasColumnName("firstRepaymentDate")
                    .HasColumnType("date");

                entity.Property(e => e.GuarantyId1).HasColumnName("guarantyId1");

                entity.Property(e => e.GuarantyId2).HasColumnName("guarantyId2");

                entity.Property(e => e.GuarantyId3).HasColumnName("guarantyId3");

                entity.Property(e => e.GuarantyId4).HasColumnName("guarantyId4");

                entity.Property(e => e.GuarantyId5).HasColumnName("guarantyId5");

                entity.Property(e => e.HebrewDate)
                    .HasColumnName("hebrewDate")
                    .HasMaxLength(50);

                entity.Property(e => e.HebrewRepaymentDate)
                    .HasColumnName("hebrewRepaymentDate")
                    .HasMaxLength(50);

                entity.Property(e => e.MonthlyPaymentDay).HasColumnName("monthlyPaymentDay");

                entity.Property(e => e.MonthlyPaymentSum).HasColumnName("monthlyPaymentSum");

                entity.Property(e => e.PaidUp).HasColumnName("paidUp");

                entity.Property(e => e.PaymentsIndex).HasColumnName("paymentsIndex");

                entity.Property(e => e.PaymentsNumber).HasColumnName("paymentsNumber");

                entity.Property(e => e.RepaymentDate)
                    .HasColumnName("repaymentDate")
                    .HasColumnType("date");

                entity.Property(e => e.RepaymentManner).HasColumnName("repaymentManner");

                entity.Property(e => e.Shtar)
                    .IsRequired()
                    .HasColumnName("shtar")
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK_Loan_CreditCard1");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_CurrencyType");

                entity.HasOne(d => d.DirectDebit)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.DirectDebitId)
                    .HasConstraintName("FK_Loan_DirectDebit");

                entity.HasOne(d => d.GuarantyId1Navigation)
                    .WithMany(p => p.LoanGuarantyId1Navigation)
                    .HasForeignKey(d => d.GuarantyId1)
                    .HasConstraintName("FK_Loan_Guarnty");

                entity.HasOne(d => d.GuarantyId2Navigation)
                    .WithMany(p => p.LoanGuarantyId2Navigation)
                    .HasForeignKey(d => d.GuarantyId2)
                    .HasConstraintName("FK_Loan_Guarnty1");

                entity.HasOne(d => d.GuarantyId3Navigation)
                    .WithMany(p => p.LoanGuarantyId3Navigation)
                    .HasForeignKey(d => d.GuarantyId3)
                    .HasConstraintName("FK_Loan_Guarnty2");

                entity.HasOne(d => d.GuarantyId4Navigation)
                    .WithMany(p => p.LoanGuarantyId4Navigation)
                    .HasForeignKey(d => d.GuarantyId4)
                    .HasConstraintName("FK_Loan_Guarnty3");

                entity.HasOne(d => d.GuarantyId5Navigation)
                    .WithMany(p => p.LoanGuarantyId5Navigation)
                    .HasForeignKey(d => d.GuarantyId5)
                    .HasConstraintName("FK_Loan_Guarnty4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_User");
            });

            modelBuilder.Entity<MangerDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.TelephoneNumber)
                    .HasColumnName("telephoneNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.CreditCardId).HasColumnName("creditCardId");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DirectDebitId).HasColumnName("directDebitId");

                entity.Property(e => e.ExchangeRate).HasColumnName("exchangeRate");

                entity.Property(e => e.HebrewPaymentDate)
                    .HasColumnName("hebrewPaymentDate")
                    .HasMaxLength(50);

                entity.Property(e => e.InputDate)
                    .HasColumnName("inputDate")
                    .HasColumnType("date");

                entity.Property(e => e.LoanId).HasColumnName("loanId");

                entity.Property(e => e.MethodId).HasColumnName("methodId");

                entity.Property(e => e.NumOfPayments).HasColumnName("numOfPayments");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK_Payment_CreditCard1");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_CurrencyType");

                entity.HasOne(d => d.DirectDebit)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.DirectDebitId)
                    .HasConstraintName("FK_Payment_DirectDebit");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Loan");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.MethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentMethod");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_User");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnName("method")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasColumnName("cellphoneNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.DepositId).HasColumnName("depositId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasColumnName("identityNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.LoanId).HasColumnName("loanId");

                entity.Property(e => e.TelephoneNumber)
                    .HasColumnName("telephoneNumber")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Deposit)
                    .WithMany(p => p.UserNavigation)
                    .HasForeignKey(d => d.DepositId)
                    .HasConstraintName("FK_User_Deposits");

                entity.HasOne(d => d.LoanNavigation)
                    .WithMany(p => p.UserNavigation)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_User_Loan");
            });

            modelBuilder.Entity<Warning>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoanId).HasColumnName("loanId");

                entity.Property(e => e.WarningDate)
                    .HasColumnName("warningDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Warning)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warning_Loan1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
