namespace ChatApp
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
            this.listChat = new System.Windows.Forms.ListBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.connectToServerBox = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chatserverIpLabel = new System.Windows.Forms.Label();
            this.txtServerIp = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.connectToServerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listChat
            // 
            this.listChat.FormattingEnabled = true;
            this.listChat.ItemHeight = 15;
            this.listChat.Location = new System.Drawing.Point(12, 12);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(521, 304);
            this.listChat.TabIndex = 0;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(539, 12);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(191, 57);
            this.btnListen.TabIndex = 1;
            this.btnListen.Text = "btnListen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // connectToServerBox
            // 
            this.connectToServerBox.Controls.Add(this.btnConnect);
            this.connectToServerBox.Controls.Add(this.chatserverIpLabel);
            this.connectToServerBox.Controls.Add(this.txtServerIp);
            this.connectToServerBox.Location = new System.Drawing.Point(539, 86);
            this.connectToServerBox.Name = "connectToServerBox";
            this.connectToServerBox.Size = new System.Drawing.Size(191, 142);
            this.connectToServerBox.TabIndex = 2;
            this.connectToServerBox.TabStop = false;
            this.connectToServerBox.Text = "Connect to Server:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 96);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(172, 28);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chatserverIpLabel
            // 
            this.chatserverIpLabel.AutoSize = true;
            this.chatserverIpLabel.Location = new System.Drawing.Point(6, 40);
            this.chatserverIpLabel.Name = "chatserverIpLabel";
            this.chatserverIpLabel.Size = new System.Drawing.Size(79, 15);
            this.chatserverIpLabel.TabIndex = 1;
            this.chatserverIpLabel.Text = "Chatserver IP:";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(6, 58);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(172, 23);
            this.txtServerIp.TabIndex = 0;
            this.txtServerIp.Text = "txtServerIp";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 336);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(440, 23);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "txtMessage";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(458, 335);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 24);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 384);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.connectToServerBox);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.listChat);
            this.Name = "Form1";
            this.Text = "NOTS Chat Client";
            this.connectToServerBox.ResumeLayout(false);
            this.connectToServerBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listChat;
        private Button btnListen;
        private GroupBox connectToServerBox;
        private Button btnConnect;
        private Label chatserverIpLabel;
        private TextBox txtServerIp;
        private TextBox txtMessage;
        private Button btnSend;
    }
}