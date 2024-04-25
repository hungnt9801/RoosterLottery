namespace Shared.Responses
{
    public class UserBetResponse
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime BetTime { get; set; }

        public int BetNumber { get; set; }

        public int WinningNumber { get; set; }
    }
}
