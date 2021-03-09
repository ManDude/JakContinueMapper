
namespace JakContinueMapper
{
    partial class SymbolTableForm
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
            this.lblContList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContList.Location = new System.Drawing.Point(13, 13);
            this.lblContList.Name = "lblContList";
            this.lblContList.Size = new System.Drawing.Size(252, 15);
            this.lblContList.TabIndex = 1;
            this.lblContList.Text = "symbol-name-that-is-very-long-i-mean-really";
            this.lblContList.Visible = false;
            // 
            // SymbolTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 370);
            this.ControlBox = false;
            this.Controls.Add(this.lblContList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolTableForm";
            this.Text = "SymbolTableForm - click booleans to toggle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContList;
    }
}