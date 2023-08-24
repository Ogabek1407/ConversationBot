using System.ComponentModel.DataAnnotations.Schema;

namespace ConversationBot.Damoin.Entitys;

public class ModelBase
{
    [Column("id")]
    public long Id { get; set; }
}