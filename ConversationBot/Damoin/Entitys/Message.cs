using System.ComponentModel.DataAnnotations.Schema;
using ConversationBot.Damoin.Enum;

namespace ConversationBot.Damoin.Entitys;

public class Message:ModelBase
{
    [Column("content")]
    public object Content { get; set; }
    [Column("from_id")]
    public long fromId { get; set; }
    [NotMapped]
    public virtual Client From { get; set; }
    [Column("time")]
    public DateTime Time { get; set; }
    [Column("board_id")]
    public long? BoardId { get; set; }
    [NotMapped]
    public virtual Board? Board { get; set; }
    [Column("conversation_id")]
    public long? ConversationId { get; set; }
    [NotMapped]
    public virtual Conversation Conversation { get; set; }
    [Column("message_type")]
    public MessageType MessageType { get; set; }
    [Column("message_status")]
    public MessageStatus Status { get; set; }
}