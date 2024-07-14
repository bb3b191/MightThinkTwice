namespace MightThinkTwice
{
    partial class MightThinkTwice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MightThinkTwice));
            btnStart = new Button();
            btnStop = new Button();
            lbxProgams = new ListBox();
            btnAdd = new Button();
            lblUseRestrict = new Label();
            rbtnUse = new RadioButton();
            rbtnRestrict = new RadioButton();
            lblStartTime = new Label();
            lblEndTime = new Label();
            lbxStartTime = new ListBox();
            lbxEndTime = new ListBox();
            lbxRules = new ListBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(195, 359);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(444, 364);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lbxProgams
            // 
            lbxProgams.FormattingEnabled = true;
            lbxProgams.ItemHeight = 15;
            lbxProgams.Location = new Point(44, 43);
            lbxProgams.Name = "lbxProgams";
            lbxProgams.Size = new Size(250, 199);
            lbxProgams.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(682, 126);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblUseRestrict
            // 
            lblUseRestrict.AutoSize = true;
            lblUseRestrict.Location = new Point(320, 100);
            lblUseRestrict.Name = "lblUseRestrict";
            lblUseRestrict.Size = new Size(82, 15);
            lblUseRestrict.TabIndex = 4;
            lblUseRestrict.Text = "Use or Restrict";
            // 
            // rbtnUse
            // 
            rbtnUse.AutoSize = true;
            rbtnUse.Location = new Point(320, 119);
            rbtnUse.Name = "rbtnUse";
            rbtnUse.Size = new Size(44, 19);
            rbtnUse.TabIndex = 5;
            rbtnUse.TabStop = true;
            rbtnUse.Text = "Use";
            rbtnUse.UseVisualStyleBackColor = true;
            // 
            // rbtnRestrict
            // 
            rbtnRestrict.AutoSize = true;
            rbtnRestrict.Location = new Point(320, 144);
            rbtnRestrict.Name = "rbtnRestrict";
            rbtnRestrict.Size = new Size(64, 19);
            rbtnRestrict.TabIndex = 6;
            rbtnRestrict.TabStop = true;
            rbtnRestrict.Text = "Restrict";
            rbtnRestrict.UseVisualStyleBackColor = true;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(440, 100);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(60, 15);
            lblStartTime.TabIndex = 7;
            lblStartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(556, 100);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(56, 15);
            lblEndTime.TabIndex = 8;
            lblEndTime.Text = "End Time";
            // 
            // lbxStartTime
            // 
            lbxStartTime.FormattingEnabled = true;
            lbxStartTime.ItemHeight = 15;
            lbxStartTime.Location = new Point(440, 126);
            lbxStartTime.Name = "lbxStartTime";
            lbxStartTime.Size = new Size(95, 139);
            lbxStartTime.TabIndex = 9;
            // 
            // lbxEndTime
            // 
            lbxEndTime.FormattingEnabled = true;
            lbxEndTime.ItemHeight = 15;
            lbxEndTime.Location = new Point(556, 126);
            lbxEndTime.Name = "lbxEndTime";
            lbxEndTime.Size = new Size(93, 139);
            lbxEndTime.TabIndex = 10;
            // 
            // lbxRules
            // 
            lbxRules.FormattingEnabled = true;
            lbxRules.ItemHeight = 15;
            lbxRules.Location = new Point(44, 267);
            lbxRules.Name = "lbxRules";
            lbxRules.Size = new Size(250, 49);
            lbxRules.TabIndex = 11;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(325, 288);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete Rule";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // MightThinkTwice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(lbxRules);
            Controls.Add(lbxEndTime);
            Controls.Add(lbxStartTime);
            Controls.Add(lblEndTime);
            Controls.Add(lblStartTime);
            Controls.Add(rbtnRestrict);
            Controls.Add(rbtnUse);
            Controls.Add(lblUseRestrict);
            Controls.Add(btnAdd);
            Controls.Add(lbxProgams);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MightThinkTwice";
            Text = "Might Think Twice";
            FormClosed += MightThinkTwice_FormClosed;
            Load += MightThinkTwice_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private ListBox lbxProgams;
        private Button btnAdd;
        private Label lblUseRestrict;
        private RadioButton rbtnUse;
        private RadioButton rbtnRestrict;
        private Label lblStartTime;
        private Label lblEndTime;
        private ListBox lbxStartTime;
        private ListBox lbxEndTime;
        private ListBox lbxRules;
        private Button btnDelete;
    }
}
