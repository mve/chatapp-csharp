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
            this.listChat.ItemHeight = 20;
            this.listChat.Location = new System.Drawing.Point(14, 16);
            this.listChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(595, 404);
            this.listChat.TabIndex = 0;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(616, 16);
            this.btnListen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(218, 76);
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
            this.connectToServerBox.Location = new System.Drawing.Point(616, 115);
            this.connectToServerBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectToServerBox.Name = "connectToServerBox";
            this.connectToServerBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectToServerBox.Size = new System.Drawing.Size(218, 189);
            this.connectToServerBox.TabIndex = 2;
            this.connectToServerBox.TabStop = false;
            this.connectToServerBox.Text = "Connect to Server:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 128);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(197, 37);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // chatserverIpLabel
            // 
            this.chatserverIpLabel.AutoSize = true;
            this.chatserverIpLabel.Location = new System.Drawing.Point(7, 53);
            this.chatserverIpLabel.Name = "chatserverIpLabel";
            this.chatserverIpLabel.Size = new System.Drawing.Size(97, 20);
            this.chatserverIpLabel.TabIndex = 1;
            this.chatserverIpLabel.Text = "Chatserver IP:";
            // 
            // txtServerIp
            // 
            this.txtServerIp.Location = new System.Drawing.Point(7, 77);
            this.txtServerIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServerIp.Name = "txtServerIp";
            this.txtServerIp.Size = new System.Drawing.Size(196, 27);
            this.txtServerIp.TabIndex = 0;
            this.txtServerIp.Text = "txtServerIp";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(14, 448);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(502, 27);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "txtMessage";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(523, 447);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 512);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.connectToServerBox);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.listChat);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "NotS WI - Chat Applicatie";
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