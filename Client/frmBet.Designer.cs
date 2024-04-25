namespace Client
{
    partial class frmBet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGVBetResult = new DataGridView();
            label1 = new Label();
            txtBetNumber = new TextBox();
            btnBet = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVBetResult).BeginInit();
            SuspendLayout();
            // 
            // dataGVBetResult
            // 
            dataGVBetResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVBetResult.Location = new Point(389, 47);
            dataGVBetResult.Name = "dataGVBetResult";
            dataGVBetResult.Size = new Size(571, 279);
            dataGVBetResult.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 50);
            label1.Name = "label1";
            label1.Size = new Size(145, 15);
            label1.TabIndex = 1;
            label1.Text = "Input bet number (1 -> 9):";
            // 
            // txtBetNumber
            // 
            txtBetNumber.Location = new Point(177, 47);
            txtBetNumber.Name = "txtBetNumber";
            txtBetNumber.Size = new Size(179, 23);
            txtBetNumber.TabIndex = 2;
            // 
            // btnBet
            // 
            btnBet.Location = new Point(177, 91);
            btnBet.Name = "btnBet";
            btnBet.Size = new Size(75, 23);
            btnBet.TabIndex = 3;
            btnBet.Text = "Bet";
            btnBet.UseVisualStyleBackColor = true;
            btnBet.Click += btnBet_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(885, 349);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmBet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 384);
            Controls.Add(btnClose);
            Controls.Add(btnBet);
            Controls.Add(txtBetNumber);
            Controls.Add(label1);
            Controls.Add(dataGVBetResult);
            MaximizeBox = false;
            Name = "frmBet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rooster Lottery - Bet";
            Load += frmBet_Load;
            ((System.ComponentModel.ISupportInitialize)dataGVBetResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGVBetResult;
        private Label label1;
        private TextBox txtBetNumber;
        private Button btnBet;
        private Button btnClose;
    }
}
