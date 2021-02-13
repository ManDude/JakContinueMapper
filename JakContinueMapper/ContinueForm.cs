using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JakContinueMapper
{
    public partial class ContinueForm : Form
    {
        private MainForm main;
        private List<Label> labels = new List<Label>();

        public ContinueForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            int i = 0;
            foreach (var kvp in MainForm.continues)
            {
                foreach (GameContinue cont in kvp.Value)
                {
                    Label lbl = new Label() { Location = new Point(lblContList.Location.X+i/20*240, lblContList.Location.Y+i%20*(lblContList.Height+5)), Text = cont.Name + ": 00000.000000", Size = new Size(240, lblContList.Height) };
                    Width = Math.Max(lbl.Location.X+lbl.Width, Width);
                    Height = Math.Max(lbl.Location.Y+lbl.Height+3+45, Height);
                    Controls.Add(lbl);
                    labels.Add(lbl);
                    ++i;
                }
            }
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Location = new Point(main.Location.X + main.Width, main.Location.Y);
        }

        public void UpdateAllContinues(string level, float tgt_x, float tgt_y, float tgt_z, GameContinue closest)
        {
            int i = 0;
            foreach (var kvp in MainForm.continues)
            {
                foreach (GameContinue cont in kvp.Value)
                {
                    Label lbl = labels[i++];
                    if (kvp.Key != level)
                    {
                        lbl.Font = new Font(lbl.Font, FontStyle.Italic);
                    }
                    else
                    {
                        lbl.Font = new Font(lbl.Font, cont == closest ? FontStyle.Bold : FontStyle.Regular);
                    }
                    lbl.Text = cont.Name + $": {MathExt.Dist3D(tgt_x, tgt_y, tgt_z, cont.X, cont.Y, cont.Z)/4096}";
                }
            }
        }
    }
}
