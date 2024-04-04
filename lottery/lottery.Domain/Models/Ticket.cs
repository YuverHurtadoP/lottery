using System;
using System.Collections.Generic;

namespace lottery.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ProductId { get; set; }

    public int Number { get; set; }

    public virtual Product Product { get; set; } = null!;
}
