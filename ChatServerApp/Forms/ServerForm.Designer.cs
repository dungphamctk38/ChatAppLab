namespace ChatServerApp.Forms
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.logGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(22, 18);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 15);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(57, 15);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(86, 23);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "9000";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(151, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(98, 25);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start Server";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.statusLabel.Location = new System.Drawing.Point(265, 19);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(84, 15);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Server is idle...";
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.clearButton);
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(22, 50);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(614, 305);
            this.logGroupBox.TabIndex = 4;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(512, 271);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(92, 25);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(10, 22);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(594, 241);
            this.logTextBox.TabIndex = 0;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(22, 368);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(31, 15);
            this.textLabel.TabIndex = 5;
            this.textLabel.Text = "Text:";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(57, 365);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(579, 23);
            this.messageTextBox.TabIndex = 6;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(544, 397);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(92, 28);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // ServerForm
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 437);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Server";
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
