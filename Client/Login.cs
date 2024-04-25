using Client.Services;
using Shared.Requests;
using Shared.Responses;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Test()
        {
            //GreetingService s = new GreetingService();
            //string? message = await s.GetGreetingMessage();
            //string? message = "success";
            //if (message != null)
            //{
            //    //MessageBox.Show(message);
            //    //this.Hide();
            //    //this.Dispose();
            //    frmBet frmBet = new frmBet();
            //    frmBet.Show();
            //    //this.Close();

            //}

            UserRequest userRequest = new UserRequest();
            userRequest.Name = "User1";
            userRequest.PhoneNumber = "1234567890";
            userRequest.DateOfBirth = DateTime.Now;

            UserService userService = new UserService();
            //await userService.AddUserAsync(userRequest);
            //var user = await userService.GetUserByPhoneNumber(userRequest.PhoneNumber);
            var userbets = await userService.GetUserBets(3);
            if (userbets != null)
            {
                Console.WriteLine("");
            }

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            var user = await userService.GetUserByPhoneNumber(txtPhoneNumber.Text);
            if (user != null)
            {
                frmBet frmBet = new frmBet();
                frmBet.SetUserId((int)user.Id);
                frmBet.Show();
                //this.Close();
            }
        }

        private async void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            var user = await userService.GetUserByPhoneNumber(txtPhoneNumber.Text);
            if (user != null)
            {
                txtName.Text = user.Name;
                dtDateOfBirth.Value = user.DateOfBirth;
            }
            //else
            //{
            //    txtName.Text = "";
            //    dtDateOfBirth.Value = DateTime.Now;
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please input Name");
                return;
            }

            if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Please input Phone Number");
                return;
            }

            UserService userService = new UserService();
            var user = await userService.GetUserByPhoneNumber(txtPhoneNumber.Text);
            if (user == null)
            {
                UserRequest userRequest = new UserRequest
                {
                    Name = txtName.Text,
                    DateOfBirth = dtDateOfBirth.Value,
                    PhoneNumber = txtPhoneNumber.Text
                };
                await userService.AddUserAsync(userRequest);
                MessageBox.Show("Register successfull!");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
