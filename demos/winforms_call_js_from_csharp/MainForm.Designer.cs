﻿namespace winforms_call_js_from_csharp
{
    partial class MainForm
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
            ShowBrowserBtn = new Button();
            SuspendLayout();
            // 
            // ShowBrowserBtn
            // 
            ShowBrowserBtn.Dock = DockStyle.Fill;
            ShowBrowserBtn.Location = new Point(10, 10);
            ShowBrowserBtn.Name = "ShowBrowserBtn";
            ShowBrowserBtn.Size = new Size(277, 23);
            ShowBrowserBtn.TabIndex = 0;
            ShowBrowserBtn.Text = "Show browser";
            ShowBrowserBtn.UseVisualStyleBackColor = true;
            ShowBrowserBtn.Click += this.ShowBrowserBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 43);
            Controls.Add(ShowBrowserBtn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "call_js_from_csharp";
            ResumeLayout(false);
        }

        #endregion

        private Button ShowBrowserBtn;
    }
}
