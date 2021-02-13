
namespace JakContinueMapper
{
    partial class ContinueForm
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
            this.lblContList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblContList
            // 
            this.lblContList.AutoSize = true;
            this.lblContList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContList.Location = new System.Drawing.Point(13, 13);
            this.lblContList.Name = "lblContList";
            this.lblContList.Size = new System.Drawing.Size(221, 15);
            this.lblContList.TabIndex = 0;
            this.lblContList.Text = "citadel-generator-start: 99999.999999";
            this.lblContList.Visible = false;
            // 
            // ContinueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 143);
            this.ControlBox = false;
            this.Controls.Add(this.lblContList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContinueForm";
            this.Text = "ContinueForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContList;
    }
}