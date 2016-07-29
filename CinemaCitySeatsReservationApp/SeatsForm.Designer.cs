namespace CinemaCitySeatsReservationApp
{
    partial class SeatsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatsForm));
            this.row_textbox = new System.Windows.Forms.TextBox();
            this.row_lbl = new System.Windows.Forms.Label();
            this.seats_lbl = new System.Windows.Forms.Label();
            this.seats_textbox = new System.Windows.Forms.TextBox();
            this.order_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // row_textbox
            // 
            this.row_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.row_textbox.Location = new System.Drawing.Point(228, 129);
            this.row_textbox.Name = "row_textbox";
            this.row_textbox.Size = new System.Drawing.Size(130, 26);
            this.row_textbox.TabIndex = 0;
            // 
            // row_lbl
            // 
            this.row_lbl.AutoSize = true;
            this.row_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.row_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.row_lbl.Location = new System.Drawing.Point(374, 132);
            this.row_lbl.Name = "row_lbl";
            this.row_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.row_lbl.Size = new System.Drawing.Size(52, 20);
            this.row_lbl.TabIndex = 1;
            this.row_lbl.Text = "שורה:";
            // 
            // seats_lbl
            // 
            this.seats_lbl.AutoSize = true;
            this.seats_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.seats_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.seats_lbl.Location = new System.Drawing.Point(374, 175);
            this.seats_lbl.Name = "seats_lbl";
            this.seats_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.seats_lbl.Size = new System.Drawing.Size(61, 20);
            this.seats_lbl.TabIndex = 3;
            this.seats_lbl.Text = "כסאות:";
            // 
            // seats_textbox
            // 
            this.seats_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.seats_textbox.Location = new System.Drawing.Point(228, 172);
            this.seats_textbox.Name = "seats_textbox";
            this.seats_textbox.Size = new System.Drawing.Size(130, 26);
            this.seats_textbox.TabIndex = 2;
            this.seats_textbox.TextChanged += new System.EventHandler(this.seats_textbox_TextChanged);
            // 
            // order_btn
            // 
            this.order_btn.Enabled = false;
            this.order_btn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.order_btn.ForeColor = System.Drawing.Color.Navy;
            this.order_btn.Location = new System.Drawing.Point(274, 262);
            this.order_btn.Name = "order_btn";
            this.order_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.order_btn.Size = new System.Drawing.Size(120, 30);
            this.order_btn.TabIndex = 5;
            this.order_btn.Text = "הזמן !";
            this.order_btn.UseVisualStyleBackColor = true;
            this.order_btn.Click += new System.EventHandler(this.order_btn_Click);
            // 
            // SeatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(659, 411);
            this.Controls.Add(this.order_btn);
            this.Controls.Add(this.seats_lbl);
            this.Controls.Add(this.seats_textbox);
            this.Controls.Add(this.row_lbl);
            this.Controls.Add(this.row_textbox);
            this.MaximumSize = new System.Drawing.Size(675, 450);
            this.MinimumSize = new System.Drawing.Size(675, 450);
            this.Name = "SeatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeatsForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox row_textbox;
        private System.Windows.Forms.Label row_lbl;
        private System.Windows.Forms.Label seats_lbl;
        private System.Windows.Forms.TextBox seats_textbox;
        private System.Windows.Forms.Button order_btn;
    }
}