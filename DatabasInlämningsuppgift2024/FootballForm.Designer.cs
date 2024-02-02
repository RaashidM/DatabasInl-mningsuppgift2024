namespace DatabasInlämningsuppgift2024
{
    partial class Form1
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
            matchListBox = new ListBox();
            searchBox = new TextBox();
            searchButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            label1 = new Label();
            teamInfo = new Label();
            matchDetailsListBox = new ListBox();
            updateBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // matchListBox
            // 
            matchListBox.FormattingEnabled = true;
            matchListBox.ItemHeight = 32;
            matchListBox.Location = new Point(12, 12);
            matchListBox.Name = "matchListBox";
            matchListBox.Size = new Size(705, 740);
            matchListBox.TabIndex = 0;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(848, 334);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(322, 39);
            searchBox.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(935, 399);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(150, 46);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(935, 598);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(150, 46);
            updateButton.TabIndex = 3;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(935, 706);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(150, 46);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(848, 270);
            label1.Name = "label1";
            label1.Size = new Size(322, 32);
            label1.TabIndex = 5;
            label1.Text = "Search For Matches Using Id:";
            // 
            // teamInfo
            // 
            teamInfo.AutoSize = true;
            teamInfo.Location = new Point(619, 735);
            teamInfo.Name = "teamInfo";
            teamInfo.Size = new Size(0, 32);
            teamInfo.TabIndex = 6;
            // 
            // matchDetailsListBox
            // 
            matchDetailsListBox.FormattingEnabled = true;
            matchDetailsListBox.ItemHeight = 32;
            matchDetailsListBox.Location = new Point(1305, 16);
            matchDetailsListBox.Name = "matchDetailsListBox";
            matchDetailsListBox.Size = new Size(718, 740);
            matchDetailsListBox.TabIndex = 7;
            // 
            // updateBox
            // 
            updateBox.Location = new Point(848, 544);
            updateBox.Name = "updateBox";
            updateBox.Size = new Size(322, 39);
            updateBox.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(917, 490);
            label2.Name = "label2";
            label2.Size = new Size(185, 32);
            label2.TabIndex = 9;
            label2.Text = "Update Date To:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2035, 795);
            Controls.Add(label2);
            Controls.Add(updateBox);
            Controls.Add(matchDetailsListBox);
            Controls.Add(teamInfo);
            Controls.Add(label1);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(searchButton);
            Controls.Add(searchBox);
            Controls.Add(matchListBox);
            Name = "Form1";
            Text = "Football Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox matchListBox;
        private TextBox searchBox;
        private Button searchButton;
        private Button updateButton;
        private Button deleteButton;
        private Label label1;
        private Label teamInfo;
        private ListBox matchDetailsListBox;
        private TextBox updateBox;
        private Label label2;
    }
}
