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

        private Font fontRegular;
        private Font fontItalic;
        private Font fontBold;

        internal const int ContListHeight = 19;
        public ContinueForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            int i = 0;
            foreach (var kvp in MainForm.continues)
            {
                foreach (GameContinue cont in kvp.Value)
                {
                    Label lbl = new Label() {
                        Location = new Point(lblContList.Location.X+i/ContListHeight*240,
                                             lblContList.Location.Y+i%ContListHeight*(lblContList.Height+5)),
                        Text = cont.Name,
                        Size = new Size(240, lblContList.Height),
                        Tag = cont };
                    Width = Math.Max(lbl.Location.X+lbl.Width, Width);
                    Height = Math.Max(lbl.Location.Y+lbl.Height+3+45, Height);
                    Controls.Add(lbl);
                    labels.Add(lbl);
                    ++i;
                }
            }
            fontRegular = new Font(labels[0].Font, FontStyle.Regular);
            fontItalic = new Font(fontRegular, FontStyle.Italic);
            fontBold = new Font(fontRegular, FontStyle.Bold);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Location = new Point(main.Location.X + main.Width, main.Location.Y);
        }

        public void UpdateAllContinues(string level, float tgt_x, float tgt_y, float tgt_z, GameContinue closest)
        {
            foreach (var lbl in labels)
            {
                GameContinue cont = (GameContinue)lbl.Tag;
                if (cont.Level != level)
                    lbl.Font = fontItalic;
                else if (cont == closest)
                    lbl.Font = fontBold;
                else
                    lbl.Font = fontRegular;
                lbl.Text = $"{cont.Name}: {MathExt.Dist3D(tgt_x, tgt_y, tgt_z, cont.X, cont.Y, cont.Z)/4096}";
            }
        }
    }
}
