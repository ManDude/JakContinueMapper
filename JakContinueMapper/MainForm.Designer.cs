
namespace JakContinueMapper
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
            this.fraEmu = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dpdGame = new System.Windows.Forms.ComboBox();
            this.fraGame = new System.Windows.Forms.GroupBox();
            this.btnSymbolTable = new System.Windows.Forms.Button();
            this.lblPos = new System.Windows.Forms.Label();
            this.btnToggleContForm = new System.Windows.Forms.Button();
            this.lblContinueMedianDist = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpdLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblContinueName2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblContinueName1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.fraEmu.SuspendLayout();
            this.fraGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraEmu
            // 
            this.fraEmu.Controls.Add(this.label2);
            this.fraEmu.Controls.Add(this.dpdGame);
            this.fraEmu.Location = new System.Drawing.Point(12, 12);
            this.fraEmu.Name = "fraEmu";
            this.fraEmu.Size = new System.Drawing.Size(281, 54);
            this.fraEmu.TabIndex = 0;
            this.fraEmu.TabStop = false;
            this.fraEmu.Text = "Emulator - pcsx2.exe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game";
            // 
            // dpdGame
            // 
            this.dpdGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpdGame.FormattingEnabled = true;
            this.dpdGame.Location = new System.Drawing.Point(100, 22);
            this.dpdGame.Name = "dpdGame";
            this.dpdGame.Size = new System.Drawing.Size(175, 23);
            this.dpdGame.TabIndex = 2;
            this.dpdGame.SelectedIndexChanged += new System.EventHandler(this.dpdGame_SelectedIndexChanged);
            // 
            // fraGame
            // 
            this.fraGame.Controls.Add(this.btnSymbolTable);
            this.fraGame.Controls.Add(this.lblPos);
            this.fraGame.Controls.Add(this.btnToggleContForm);
            this.fraGame.Controls.Add(this.lblContinueMedianDist);
            this.fraGame.Controls.Add(this.label1);
            this.fraGame.Controls.Add(this.dpdLevel);
            this.fraGame.Controls.Add(this.label5);
            this.fraGame.Controls.Add(this.lblContinueName2);
            this.fraGame.Controls.Add(this.label7);
            this.fraGame.Controls.Add(this.lblContinueName1);
            this.fraGame.Controls.Add(this.label4);
            this.fraGame.Controls.Add(this.label3);
            this.fraGame.Location = new System.Drawing.Point(12, 72);
            this.fraGame.Name = "fraGame";
            this.fraGame.Size = new System.Drawing.Size(281, 186);
            this.fraGame.TabIndex = 1;
            this.fraGame.TabStop = false;
            this.fraGame.Text = "Game";
            this.fraGame.Visible = false;
            // 
            // btnSymbolTable
            // 
            this.btnSymbolTable.Location = new System.Drawing.Point(147, 154);
            this.btnSymbolTable.Name = "btnSymbolTable";
            this.btnSymbolTable.Size = new System.Drawing.Size(128, 23);
            this.btnSymbolTable.TabIndex = 12;
            this.btnSymbolTable.Text = "Symbols (Advanced)";
            this.btnSymbolTable.UseVisualStyleBackColor = true;
            this.btnSymbolTable.Click += new System.EventHandler(this.btnSymbolTable_Click);
            // 
            // lblPos
            // 
            this.lblPos.Location = new System.Drawing.Point(100, 19);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(175, 53);
            this.lblPos.TabIndex = 11;
            this.lblPos.Text = "X:\r\nY:\r\nZ:";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToggleContForm
            // 
            this.btnToggleContForm.Location = new System.Drawing.Point(6, 154);
            this.btnToggleContForm.Name = "btnToggleContForm";
            this.btnToggleContForm.Size = new System.Drawing.Size(135, 23);
            this.btnToggleContForm.TabIndex = 10;
            this.btnToggleContForm.Text = "Show All Checkpoints";
            this.btnToggleContForm.UseVisualStyleBackColor = true;
            this.btnToggleContForm.Click += new System.EventHandler(this.btnToggleContForm_Click);
            // 
            // lblContinueMedianDist
            // 
            this.lblContinueMedianDist.AutoSize = true;
            this.lblContinueMedianDist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContinueMedianDist.Location = new System.Drawing.Point(100, 136);
            this.lblContinueMedianDist.Name = "lblContinueMedianDist";
            this.lblContinueMedianDist.Size = new System.Drawing.Size(63, 15);
            this.lblContinueMedianDist.TabIndex = 9;
            this.lblContinueMedianDist.Text = "<meters>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dist. to median:";
            // 
            // dpdLevel
            // 
            this.dpdLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpdLevel.FormattingEnabled = true;
            this.dpdLevel.Items.AddRange(new object[] {
            "Geyser Rock (tra)",
            "Sandover Village (vi1)",
            "Sentinel Beach (bea)",
            "Forbidden Jungle (jun)",
            "Jungle Temple (jub)",
            "Misty Island (mis)",
            "Fire Canyon (fir)",
            "Rock Village (vi2)",
            "Precursor Basin (rol)",
            "Lost Precursor City Top (sun)",
            "Lost Precursor City Bottom (sub)",
            "Boggy Swamp (swa)",
            "Mountain Pass (ogr)",
            "Volcanic Crater (vi3)",
            "Snowy Mountain (sno)",
            "Spider Cave Main Cave (mai)",
            "Spider Cave Dark Cave (dar)",
            "Spider Cave Robo Cave (rob)",
            "Lava Tube (lav)",
            "Gol and Maia\'s Citadel (cit)",
            "Final Boss (fin)"});
            this.dpdLevel.Location = new System.Drawing.Point(100, 80);
            this.dpdLevel.Name = "dpdLevel";
            this.dpdLevel.Size = new System.Drawing.Size(175, 23);
            this.dpdLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Stored Level";
            // 
            // lblContinueName2
            // 
            this.lblContinueName2.AutoSize = true;
            this.lblContinueName2.Location = new System.Drawing.Point(100, 121);
            this.lblContinueName2.Name = "lblContinueName2";
            this.lblContinueName2.Size = new System.Drawing.Size(70, 15);
            this.lblContinueName2.TabIndex = 5;
            this.lblContinueName2.Text = "<continue>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "2nd Closest:";
            // 
            // lblContinueName1
            // 
            this.lblContinueName1.AutoSize = true;
            this.lblContinueName1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContinueName1.Location = new System.Drawing.Point(100, 106);
            this.lblContinueName1.Name = "lblContinueName1";
            this.lblContinueName1.Size = new System.Drawing.Size(72, 15);
            this.lblContinueName1.TabIndex = 3;
            this.lblContinueName1.Text = "<continue>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Closest:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 53);
            this.label3.TabIndex = 1;
            this.label3.Text = "Position";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(-6, -2);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(22, 24);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "E";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblError.Visible = false;
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAbout.Location = new System.Drawing.Point(299, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(50, 25);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 269);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.fraGame);
            this.Controls.Add(this.fraEmu);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Jak Continue Mapper - Live \"idle deload\" testing!";
            this.fraEmu.ResumeLayout(false);
            this.fraEmu.PerformLayout();
            this.fraGame.ResumeLayout(false);
            this.fraGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox fraEmu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dpdGame;
        private System.Windows.Forms.GroupBox fraGame;
        private System.Windows.Forms.Label lblContinueName2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblContinueName1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dpdLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblContinueMedianDist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggleContForm;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Button btnSymbolTable;
    }
}

