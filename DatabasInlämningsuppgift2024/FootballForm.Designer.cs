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
            SuspendLayout();
            // 
            // matchListBox
            // 
            matchListBox.FormattingEnabled = true;
            matchListBox.ItemHeight = 32;
            matchListBox.Location = new Point(12, 12);
            matchListBox.Name = "matchListBox";
            matchListBox.Size = new Size(395, 740);
            matchListBox.TabIndex = 0;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(589, 524);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(322, 39);
            searchBox.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(678, 597);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(150, 46);
            searchButton.TabIndex = 2;
            searchButton.Text = "button1";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 795);
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
    }
}
