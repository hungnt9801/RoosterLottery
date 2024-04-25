
using Microsoft.AspNetCore.Http.HttpResults;

namespace Domain.Entities
{
    public class Bet : BaseEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int BetNumber { get; set; }

        public DateTime BetTime { get; set; }

        public int SlotTimeHourId { get; set; }

        public Bet()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = "Admin";
            UpdatedDate = DateTime.Now;
            UpdatedBy = "Admin";
        }
    }
}
