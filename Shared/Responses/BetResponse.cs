namespace Shared.Responses
{
    public class BetResponse
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int BetNumber { get; set; }

        public DateTime SlotTime { get; set; }

        public int WinningNumber { get; set; }

    }
}
