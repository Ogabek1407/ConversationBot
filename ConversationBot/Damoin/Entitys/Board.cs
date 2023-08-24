using System.ComponentModel.DataAnnotations.Schema;

namespace ConversationBot.Damoin.Entitys;

public class Board:ModelBase
{
    [Column("owner_id")]
    public long OwnerId { get; set; }
    [NotMapped]
    public virtual Client Owner { get; set; }
    [Column("nick_name")]
    public string Nickname { get; set; }
    [NotMapped]
    public virtual IEnumerable<Message> Messages { get; set; }

}