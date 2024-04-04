using lottery.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Application.InterfaceLotteryUseCase
{
    public interface ILotteryTicketUseCase
    {
        string AddTicket(int idProduct);
    }
}
