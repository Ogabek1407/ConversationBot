using System.ComponentModel.DataAnnotations.Schema;

namespace ConversationBot.Damoin.Entitys;

public class User:ModelBase
{
    [Column("password")]
    public string Password { get; set; }
    [Column("login")]
    public string Login { get; set; }
    [Column("telegram_chat_id")]
    public long TelegramChatId { get; set; }
    [Column("client_id")]
    public long? ClientId { get; set; }
    [NotMapped]
    public virtual Client Client { get; set; }
    
}