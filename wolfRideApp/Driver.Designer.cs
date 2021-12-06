
namespace wolfRideApp
{
    partial class Driver
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
            this.txtHome = new System.Windows.Forms.Label();
            this.btnWaiting = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.btnRemoveVehicle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVehicles = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnFillRider = new System.Windows.Forms.Button();
            this.btnMyRiders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHome
            // 
            this.txtHome.AutoSize = true;
            this.txtHome.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHome.Location = new System.Drawing.Point(21, 9);
            this.txtHome.Name = "txtHome";
            this.txtHome.Size = new System.Drawing.Size(105, 31);
            this.txtHome.TabIndex = 0;
            this.txtHome.Text = "Driver";
            // 
            // btnWaiting
            // 
            this.btnWaiting.Location = new System.Drawing.Point(28, 60);
            this.btnWaiting.Name = "btnWaiting";
            this.btnWaiting.Size = new System.Drawing.Size(98, 23);
            this.btnWaiting.TabIndex = 1;
            this.btnWaiting.Text = "Riders Waiting";
            this.btnWaiting.UseVisualStyleBackColor = true;
            this.btnWaiting.Click += new System.EventHandler(this.btnWaiting_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Location = new System.Drawing.Point(28, 89);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(98, 23);
            this.btnAddVehicle.TabIndex = 2;
            this.btnAddVehicle.Text = "Add Vehicle";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            // 
            // btnRemoveVehicle
            // 
            this.btnRemoveVehicle.Location = new System.Drawing.Point(28, 118);
            this.btnRemoveVehicle.Name = "btnRemoveVehicle";
            this.btnRemoveVehicle.Size = new System.Drawing.Size(98, 23);
            this.btnRemoveVehicle.TabIndex = 3;
            this.btnRemoveVehicle.Text = "Remove Vehicle";
            this.btnRemoveVehicle.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(162, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(240, 197);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // btnVehicles
            // 
            this.btnVehicles.Location = new System.Drawing.Point(28, 147);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(98, 23);
            this.btnVehicles.TabIndex = 5;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.UseVisualStyleBackColor = true;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Location = new System.Drawing.Point(28, 234);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(98, 23);
            this.btnSignOut.TabIndex = 6;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnFillRider
            // 
            this.btnFillRider.Location = new System.Drawing.Point(28, 176);
            this.btnFillRider.Name = "btnFillRider";
            this.btnFillRider.Size = new System.Drawing.Size(98, 23);
            this.btnFillRider.TabIndex = 7;
            this.btnFillRider.Text = "Fill Rider";
            this.btnFillRider.UseVisualStyleBackColor = true;
            // 
            // btnMyRiders
            // 
            this.btnMyRiders.Location = new System.Drawing.Point(28, 205);
            this.btnMyRiders.Name = "btnMyRiders";
            this.btnMyRiders.Size = new System.Drawing.Size(98, 23);
            this.btnMyRiders.TabIndex = 8;
            this.btnMyRiders.Text = "My Riders";
            this.btnMyRiders.UseVisualStyleBackColor = true;
            this.btnMyRiders.Click += new System.EventHandler(this.btnMyRiders_Click);
            // 
            // Driver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(446, 289);
            this.Controls.Add(this.btnMyRiders);
            this.Controls.Add(this.btnFillRider);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnVehicles);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRemoveVehicle);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.btnWaiting);
            this.Controls.Add(this.txtHome);
            this.Name = "Driver";
            this.Text = "Driver Home Screen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHome;
        private System.Windows.Forms.Button btnWaiting;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Button btnRemoveVehicle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnFillRider;
        private System.Windows.Forms.Button btnMyRiders;
    }
}