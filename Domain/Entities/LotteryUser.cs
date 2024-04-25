using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LotteryUser : BaseEntity
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }
        
        public LotteryUser()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = "Admin";
            UpdatedDate = DateTime.Now;
            UpdatedBy = "Admin";
        }
    }
}
