using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static JakContinueMapper.GameMemory;

namespace JakContinueMapper
{
    public partial class SymbolTableForm : Form
    {
        private int pagenum = 0;
        private int pagemax;
        private List<Label> labels = new List<Label>();
        Label lblPageNum;
        Button btnPrev;
        Button btnNext;

        internal const int ContListHeight = 28;
        internal const int entries_per_page = ContListHeight * 4;
        public SymbolTableForm()
        {
            InitializeComponent();

            int max_height = 0;
            for (int i = 0; i < entries_per_page; ++i)
            {
                Label lbl = new Label()
                {
                    Location = new Point(lblContList.Location.X + i/ContListHeight * 250,
                                         lblContList.Location.Y + i%ContListHeight * (lblContList.Height + 6)),
                    Text = "#f",
                    Visible = false,
                    Size = new Size(250, lblContList.Height),
                    Tag = 0
                };
                lbl.Click += (sender, e) =>
                {
                    lbl.Tag = 1;
                };
                max_height = Math.Max(lbl.Location.Y+lbl.Height, max_height);
                Controls.Add(lbl);
                labels.Add(lbl);
            }

            Width = 16 + 250 * 4;
            lblPageNum = new Label()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((Width-10)/2-75, max_height+6),
                AutoSize = false
            };
            lblPageNum.Size = new Size(150, lblPageNum.Height);
            btnPrev = new Button()
            {
                Text = "<",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = new Point(lblPageNum.Location.X-6, max_height+6)
            };
            btnNext = new Button()
            {
                Text = ">",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = new Point(lblPageNum.Location.X+lblPageNum.Width+6, max_height+6)
            };
            max_height = Math.Max(lblPageNum.Location.Y+ lblPageNum.Height, max_height);
            Controls.Add(lblPageNum);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            btnPrev.Location = new Point(btnPrev.Location.X - btnPrev.Width, btnPrev.Location.Y);

            pagemax = (UsableSymbolCount + entries_per_page - 1) / entries_per_page;

            { btnPrev.Click += (sender, e) =>
            {
                --pagenum;
                ValidatePageNav();
            };}
            { btnNext.Click += (sender, e) =>
            {
                ++pagenum;
                ValidatePageNav();
            };}

            ValidatePageNav();

            Height = Math.Max(max_height+6+45, Height);
        }

        internal void ValidatePageNav()
        {
            if (pagenum <= 0) pagenum = 0;
            else if (pagenum >= pagemax) pagenum = pagemax - 1;

            btnPrev.Enabled = pagenum > 0;
            btnNext.Enabled = pagenum < pagemax - 1;

            lblPageNum.Text = $"Page {pagenum + 1}/{pagemax}";
        }

        internal int GetSymbolAddr(int index)
        {
            return (SymbolTableOffset + index*8)%(UsableSymbolCount*8);
        }

        internal int GetSymbolVal(byte[] symboltable, int index)
        {
            return BitConverter.ToInt32(symboltable, GetSymbolAddr(index));
        }

        public void UpdateSymbols(EmuMemory emu, GameAddr addrSymbolTable)
        {
            emu.ReadMem(addrSymbolTable, 0x10000, out byte[] symboltable);
            emu.ReadMem(addrSymbolTable + 65336, 0x10000, out byte[] symbolnameptrs);

            int goal_false = GetSymbolVal(symboltable, 0);
            int goal_true = GetSymbolVal(symboltable, 1);
            for (int i = 0; i < entries_per_page; ++i)
            {
                Label lbl = labels[i];
                int symbolindex = pagenum*entries_per_page + i;
                if (symbolindex < UsableSymbolCount)
                {
                    lbl.Visible = true;
                    int name = GetSymbolVal(symbolnameptrs, symbolindex);
                    if ((name & 0xF) == 4 && name < 0x8000000)
                    {
                        lbl.Text = emu.ReadCString(name + 4);
                    }
                    else if (name == 0)
                        lbl.Visible = false;
                    else
                        throw new Exception("symbol had invalid name addr " + name.ToString("X"));
                    int val = GetSymbolVal(symboltable, symbolindex);
                    int addr = GetSymbolAddr(symbolindex);
                    if (val == goal_false)
                    {
                        if ((int)lbl.Tag == 1)
                        {
                            lbl.Tag = 0;
                            emu.WriteInt32(addrSymbolTable + addr, (uint)goal_true);
                            lbl.ForeColor = Color.Green;
                        }
                        else
                            lbl.ForeColor = Color.Red;
                    }
                    else if (val == goal_true)
                    {
                        if ((int)lbl.Tag == 1)
                        {
                            lbl.Tag = 0;
                            emu.WriteInt32(addrSymbolTable + addr, (uint)goal_false);
                            lbl.ForeColor = Color.Red;
                        }
                        else
                            lbl.ForeColor = Color.Green;
                    }
                    else
                        lbl.ForeColor = Color.Black;
                }
                else
                {
                    lbl.Visible = false;
                }
            }
        }
    }
}
