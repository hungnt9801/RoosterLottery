using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RoosterLottery.Domain.Entities
{
    public class DialOpenLottery : BaseEntity
    {
        public long Id { get; set; }

        public int SlotTimeHourId { get; set; }

        public DateTime OpenTime { get; set; }

        public int WinningNumber { get; set; }
    }
}

    