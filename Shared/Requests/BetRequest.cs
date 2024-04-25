namespace Shared.Requests
{
    public class BetRequest
    {
        public long UserId { get; set; }

        public int BetNumber { get; set; }

        public DateTime BetTime { get; set; }
    }
}
