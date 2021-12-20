
using System;

namespace DesktopUI
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.resultListView = new System.Windows.Forms.ListView();
            this.threadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.generatedString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.threadNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.threadNumberNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(97, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of threads:";
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startButton.BackColor = System.Drawing.Color.LightGray;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.startButton.Location = new System.Drawing.Point(310, 26);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(116, 35);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.Start);
            // 
            // resultListView
            // 
            this.resultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.resultListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.resultListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.threadID,
            this.generatedString});
            this.resultListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.resultListView.ForeColor = System.Drawing.Color.White;
            this.resultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(176, 86);
            this.resultListView.MinimumSize = new System.Drawing.Size(305, 200);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(305, 425);
            this.resultListView.TabIndex = 3;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            // 
            // threadID
            // 
            this.threadID.Text = "Thread ID";
            this.threadID.Width = 100;
            // 
            // generatedString
            // 
            this.generatedString.Text = "Generated String";
            this.generatedString.Width = 200;
            // 
            // threadNumberNumericUpDown
            // 
            this.threadNumberNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.threadNumberNumericUpDown.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.threadNumberNumericUpDown.Location = new System.Drawing.Point(246, 30);
            this.threadNumberNumericUpDown.Name = "threadNumberNumericUpDown";
            this.threadNumberNumericUpDown.Size = new System.Drawing.Size(52, 27);
            this.threadNumberNumericUpDown.TabIndex = 1;
            // 
            // stopButton
            // 
            this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stopButton.BackColor = System.Drawing.Color.Tomato;
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.stopButton.Location = new System.Drawing.Point(432, 26);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(116, 35);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.Stop);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(653, 543);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.threadNumberNumericUpDown);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(470, 400);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multithreaded String Generator";
            ((System.ComponentModel.ISupportInitialize)(this.threadNumberNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.NumericUpDown threadNumberNumericUpDown;
        private System.Windows.Forms.ColumnHeader threadID;
        private System.Windows.Forms.ColumnHeader generatedString;
        private System.Windows.Forms.Button stopButton;
    }
}

