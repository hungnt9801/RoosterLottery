using Client.Services;
using Shared.Requests;
using Shared.Responses;
using System.Data;
using System.Security.Cryptography;

namespace Client
{
    public partial class frmBet : Form
    {
        private int m_userId;
        public frmBet()
        {
            InitializeComponent();
        }

        private void frmBet_Load(object sender, EventArgs e)
        {
            DisplayBetResult();
        }

        public bool SetUserId(int userId)
        {
            m_userId = userId;
            return true;
        }

        private async Task DisplayBetResult()
        {
            UserService userService = new UserService();
            var userbets = await userService.GetUserBets(m_userId);

            // Create a DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Date of birth", typeof(DateTime));
            dataTable.Columns.Add("Phone Number", typeof(string));
            dataTable.Columns.Add("Bet Number", typeof(int));
            dataTable.Columns.Add("Winning Number", typeof(int));

            // Add data to the DataTable
            foreach (UserBetResponse userbet in userbets)
            {
                dataTable.Rows.Add(userbet.Name, userbet.DateOfBirth, userbet.PhoneNumber, userbet.BetNumber, userbet.WinningNumber);
            }
            // Set the DataSource property of the DataGridView
            dataGVBetResult.DataSource = dataTable;
            //dataGVBetResult.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);
        }

        public bool IsValidBetNumber()
        {
            string betNumber = txtBetNumber.Text;
            if (string.IsNullOrEmpty(betNumber))
            {
                return false;
            }

            if (betNumber.Length != 1)
            {
                return false;
            }

            char digit = betNumber[0];
            return char.IsDigit(digit) && digit >= '1' && digit <= '9';
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (!IsValidBetNumber())
                return;

            BetService betService = new BetService();

            BetRequest betRequest = new BetRequest
            {
                UserId = m_userId,
                BetNumber = int.Parse(txtBetNumber.Text),
                //BetNumber = 5,
                BetTime = DateTime.Now
            };
            
            var ret = betService.AddBetAsync(betRequest);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
