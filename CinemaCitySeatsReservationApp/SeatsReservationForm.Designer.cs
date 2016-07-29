namespace CinemaCitySeatsReservationApp
{
    partial class SeatsReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatsReservationForm));
            this.Theater_combobox = new System.Windows.Forms.ComboBox();
            this.movies_combobox = new System.Windows.Forms.ComboBox();
            this.dates_combobox = new System.Windows.Forms.ComboBox();
            this.times_combobox = new System.Windows.Forms.ComboBox();
            this.order_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Theater_combobox
            // 
            this.Theater_combobox.AllowDrop = true;
            this.Theater_combobox.FormattingEnabled = true;
            this.Theater_combobox.Items.AddRange(new object[] {
            "סינמה סיטי כפר-סבא",
            "סינמה סיטי גלילות",
            "סינמה סיטי ירושלים",
            "סינמה סיטי ראשל\"צ",
            "סינמה פארק",
            "סינמה רענן"});
            this.Theater_combobox.Location = new System.Drawing.Point(187, 118);
            this.Theater_combobox.Name = "Theater_combobox";
            this.Theater_combobox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Theater_combobox.Size = new System.Drawing.Size(300, 21);
            this.Theater_combobox.TabIndex = 0;
            this.Theater_combobox.Text = "בחר קולנוע";
            this.Theater_combobox.SelectedIndexChanged += new System.EventHandler(this.Theater_combobox_SelectedIndexChanged);
            // 
            // movies_combobox
            // 
            this.movies_combobox.FormattingEnabled = true;
            this.movies_combobox.Location = new System.Drawing.Point(187, 168);
            this.movies_combobox.Name = "movies_combobox";
            this.movies_combobox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.movies_combobox.Size = new System.Drawing.Size(300, 21);
            this.movies_combobox.TabIndex = 1;
            this.movies_combobox.Text = "בחר סרט";
            this.movies_combobox.SelectedIndexChanged += new System.EventHandler(this.movies_combobox_SelectedIndexChanged);
            // 
            // dates_combobox
            // 
            this.dates_combobox.FormattingEnabled = true;
            this.dates_combobox.Location = new System.Drawing.Point(187, 218);
            this.dates_combobox.Name = "dates_combobox";
            this.dates_combobox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dates_combobox.Size = new System.Drawing.Size(300, 21);
            this.dates_combobox.TabIndex = 2;
            this.dates_combobox.Text = "בחר תאריך";
            this.dates_combobox.SelectedIndexChanged += new System.EventHandler(this.dates_combobox_SelectedIndexChanged);
            // 
            // times_combobox
            // 
            this.times_combobox.FormattingEnabled = true;
            this.times_combobox.Location = new System.Drawing.Point(187, 268);
            this.times_combobox.Name = "times_combobox";
            this.times_combobox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.times_combobox.Size = new System.Drawing.Size(300, 21);
            this.times_combobox.TabIndex = 3;
            this.times_combobox.Text = "בחר שעה";
            this.times_combobox.SelectedIndexChanged += new System.EventHandler(this.times_combobox_SelectedIndexChanged);
            // 
            // order_btn
            // 
            this.order_btn.Enabled = false;
            this.order_btn.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.order_btn.ForeColor = System.Drawing.Color.Navy;
            this.order_btn.Location = new System.Drawing.Point(277, 340);
            this.order_btn.Name = "order_btn";
            this.order_btn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.order_btn.Size = new System.Drawing.Size(120, 30);
            this.order_btn.TabIndex = 4;
            this.order_btn.Text = "הזמן !";
            this.order_btn.UseVisualStyleBackColor = true;
            this.order_btn.Click += new System.EventHandler(this.order_btn_Click);
            // 
            // SeatsReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(659, 411);
            this.Controls.Add(this.order_btn);
            this.Controls.Add(this.times_combobox);
            this.Controls.Add(this.dates_combobox);
            this.Controls.Add(this.movies_combobox);
            this.Controls.Add(this.Theater_combobox);
            this.MaximumSize = new System.Drawing.Size(675, 450);
            this.MinimumSize = new System.Drawing.Size(675, 450);
            this.Name = "SeatsReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seats Reservation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Theater_combobox;
        private System.Windows.Forms.ComboBox movies_combobox;
        private System.Windows.Forms.ComboBox dates_combobox;
        private System.Windows.Forms.ComboBox times_combobox;
        private System.Windows.Forms.Button order_btn;
    }
}

