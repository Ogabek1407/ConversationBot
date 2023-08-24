using ConversationBot.Damoin.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ConversationBot.DataContext;

public class DataContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }
    

    public DataContext()
    {
        
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string connectionString = Settings.dbConnectionString;

        optionsBuilder.UseNpgsql(connectionString);
        base.OnConfiguring(optionsBuilder);

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("Conversation");

        // Client one Board Many
        modelBuilder.Entity<Client>().
            HasMany(x => x.Boards).
            WithOne(x => x.Owner).HasForeignKey(x => x.OwnerId);
        
        // Client one Conversation Many firstclient
        modelBuilder.Entity<Client>().
            HasMany(x => x.Conversations).
            WithOne(x => x.FirstClient)
            .HasForeignKey(x => x.FirstClientId);
        
        // Client one Conversation Many lastClient
        modelBuilder.Entity<Client>().
            HasMany(x => x.Conversations).
            WithOne(x => x.LastClient)
            .HasForeignKey(x => x.LastClientId);
        
        
        // Client one Message Many
        modelBuilder.Entity<Client>().
            HasMany(x => x.Messages).
            WithOne(x => x.From).
            HasForeignKey(x => x.fromId);

        
        // Client one User One
        modelBuilder.Entity<Client>().
            HasOne(x => x.user).
            WithOne(x => x.Client).
            HasForeignKey<User>(x => x.ClientId);


        modelBuilder.Entity<Client>().Property(x => x.UserId).IsUnicode();

        modelBuilder.Entity<Client>().Property(x => x.NickName).IsUnicode();

        modelBuilder.Entity<Client>().Property(x => x.Username).IsUnicode();
        
        
        // Board one Message many 
        modelBuilder.Entity<Board>().
            HasMany(x => x.Messages).
            WithOne(x => x.Board).
            HasForeignKey(x => x.BoardId);

        modelBuilder.Entity<Board>().
            Property(x => x.Nickname).
            IsUnicode();

        // Conversation one Message many
        modelBuilder.Entity<Conversation>().
            HasMany(x => x.Messages).
            WithOne(x => x.Conversation).
            HasForeignKey(x => x.ConversationId);
        
        
        


        base.OnModelCreating(modelBuilder);
        
    }
}