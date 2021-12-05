
namespace wolfRideApp
{
    partial class PassengerHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPickup = new System.Windows.Forms.Button();
            this.btnBalance = new System.Windows.Forms.Button();
            this.btnApplyDrive = new System.Windows.Forms.Button();
            this.btnContact = new System.Windows.Forms.Button();
            this.txtWelcome = new System.Windows.Forms.Label();
            this.btnCurrentBalance = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(473, 370);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPickup
            // 
            this.btnPickup.Location = new System.Drawing.Point(260, 180);
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(113, 23);
            this.btnPickup.TabIndex = 1;
            this.btnPickup.Text = "Request Pickup";
            this.btnPickup.UseVisualStyleBackColor = true;
            // 
            // btnBalance
            // 
            this.btnBalance.Location = new System.Drawing.Point(261, 231);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(112, 23);
            this.btnBalance.TabIndex = 2;
            this.btnBalance.Text = "Add Funds";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // btnApplyDrive
            // 
            this.btnApplyDrive.Location = new System.Drawing.Point(257, 370);
            this.btnApplyDrive.Name = "btnApplyDrive";
            this.btnApplyDrive.Size = new System.Drawing.Size(113, 23);
            this.btnApplyDrive.TabIndex = 3;
            this.btnApplyDrive.Text = "Apply To Be Driver";
            this.btnApplyDrive.UseVisualStyleBackColor = true;
            // 
            // btnContact
            // 
            this.btnContact.Location = new System.Drawing.Point(56, 370);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(112, 23);
            this.btnContact.TabIndex = 4;
            this.btnContact.Text = "Contact Admin";
            this.btnContact.UseVisualStyleBackColor = true;
            // 
            // txtWelcome
            // 
            this.txtWelcome.AutoSize = true;
            this.txtWelcome.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtWelcome.Location = new System.Drawing.Point(243, 19);
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.Size = new System.Drawing.Size(141, 31);
            this.txtWelcome.TabIndex = 5;
            this.txtWelcome.Text = "Welcome";
            // 
            // btnCurrentBalance
            // 
            this.btnCurrentBalance.Location = new System.Drawing.Point(261, 290);
            this.btnCurrentBalance.Name = "btnCurrentBalance";
            this.btnCurrentBalance.Size = new System.Drawing.Size(112, 23);
            this.btnCurrentBalance.TabIndex = 6;
            this.btnCurrentBalance.Text = "Current Balance";
            this.btnCurrentBalance.UseVisualStyleBackColor = true;
            this.btnCurrentBalance.Click += new System.EventHandler(this.btnCurrentBalance_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(243, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(95, 31);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "Name";
            // 
            // PassengerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(605, 409);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCurrentBalance);
            this.Controls.Add(this.txtWelcome);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.btnApplyDrive);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.btnPickup);
            this.Controls.Add(this.btnLogout);
            this.Name = "PassengerHome";
            this.Text = "Passenger Home Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPickup;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnApplyDrive;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Label l;
        public System.Windows.Forms.Label txtWelcome;
        private System.Windows.Forms.Button btnCurrentBalance;
        private System.Windows.Forms.Label txtName;
    }
}