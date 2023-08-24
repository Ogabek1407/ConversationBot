using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using ConversationBot.Damoin.Enum;

namespace ConversationBot.Damoin.Entitys;

public class Client:ModelBase
{
    [Column("user_id")]
    public long UserId { get; set; }
    [NotMapped]
    public virtual User user { get; set; }
    [Column("nick_name")]
    public string NickName { get; set; }
    [Column("is_premium")] 
    public bool isPremium { get; set; }
    [Column("user_name")]
    public string Username { get; set; }
    [Column("status")]
    public ClientStatus Status { get; set; }
    [NotMapped]
    public virtual IEnumerable<Board> Boards { get; set; }
    [NotMapped]
    public virtual IEnumerable<Conversation> Conversations { get; set; }
    [NotMapped]
    public virtual IEnumerable<Message> Messages { get; set; }
}