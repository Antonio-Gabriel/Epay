namespace ePay
{
    partial class MsgBoxOk
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
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.messageIcon = new System.Windows.Forms.PictureBox();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Poppins Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(19, 94);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(41, 26);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Text";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(17, 57);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 37);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Mensagem";
            // 
            // messageIcon
            // 
            this.messageIcon.Location = new System.Drawing.Point(272, 30);
            this.messageIcon.Name = "messageIcon";
            this.messageIcon.Size = new System.Drawing.Size(224, 211);
            this.messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.messageIcon.TabIndex = 6;
            this.messageIcon.TabStop = false;
            // 
            // btnOK2
            // 
            this.btnOK2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(83)))));
            this.btnOK2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(83)))));
            this.btnOK2.FlatAppearance.BorderSize = 0;
            this.btnOK2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK2.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK2.Location = new System.Drawing.Point(24, 199);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(128, 42);
            this.btnOK2.TabIndex = 9;
            this.btnOK2.Text = "&OK";
            this.btnOK2.UseVisualStyleBackColor = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 8;
            this.gunaElipse1.TargetControl = this.btnOK2;
            // 
            // MsgBoxOk
            // 
            this.AcceptButton = this.btnOK2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(513, 270);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.messageIcon);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 309);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(529, 309);
            this.Name = "MsgBoxOk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MsgBoxOk";
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.PictureBox messageIcon;
        private System.Windows.Forms.Button btnOK2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}