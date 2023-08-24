using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using ConversationBot.Damoin.Enum;

namespace ConversationBot.Damoin.Entitys;

public class Conversation:ModelBase
{
    [Column("create_date_time")]
    public DateTime CreateTime { get; set; }
    [Column("end_date_time")]
    public DateTime EndTime { get; set; }
    [Column("first_client_id")] 
    public long FirstClientId { get; set; }
    [NotMapped]
    public virtual Client FirstClient { get; set; }
    [Column("last_client_id")]
    public long LastClientId { get; set; }
    [NotMapped]
    public virtual Client LastClient { get; set; }
    [Column("status")]
    public ConversationStatus Status { get; set; }
    [NotMapped]
    public virtual IEnumerable<Message> Messages { get; set; }
}