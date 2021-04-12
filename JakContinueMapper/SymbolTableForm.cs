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
        private bool search_query = false;
        private int search_index = 0;
        private string search_term;
        Label lblPageNum;
        Button btnPrev;
        Button btnNext;
        TextBox txtSearch;
        private Font fontRegular;
        private Font fontItalic;
        private Font fontBold;

        internal const int ContListHeight = 25;
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
                                         lblContList.Location.Y + i%ContListHeight * (lblContList.Height + 0)),
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
            fontRegular = new Font(labels[0].Font, FontStyle.Regular);
            fontItalic = new Font(fontRegular, FontStyle.Italic);
            fontBold = new Font(fontRegular, FontStyle.Bold);

            Width = 16 + 250 * 4;
            lblPageNum = new Label()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((Width-10)/2-75, max_height+6),
                AutoSize = false,
                Width = 150
            };
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
            max_height = Math.Max(lblPageNum.Location.Y+lblPageNum.Height, max_height);
            txtSearch = new TextBox()
            {
                Location = new Point((Width-10)/2-75, max_height+6)
            };
            txtSearch.Width = 150;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.TextChanged += txtSearch_TextChanged;
            max_height = Math.Max(txtSearch.Location.Y+txtSearch.Height, max_height);
            Controls.Add(lblPageNum);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(txtSearch);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search_index = 0;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    search_term = txtSearch.Text;
                    search_query = !string.IsNullOrWhiteSpace(search_term);
                    break;
            }
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

            if (search_query)
            {
                for (int i = search_index; i < UsableSymbolCount; ++i)
                {
                    int name_addr = GetSymbolVal(symbolnameptrs, i);
                    string name;
                    if ((name_addr & 0xF) == 4 && name_addr < 0x8000000)
                    {
                        name = emu.ReadCString(name_addr + 4);
                    }
                    else
                        continue;
                    if (name.Contains(search_term))
                    {
                        search_index = i+1;
                        pagenum = i / entries_per_page;
                        ValidatePageNav();
                        search_query = false;
                        break;
                    }
                }
                if (search_query)
                {
                    search_index = 0;
                    search_query = false;
                }
            }

            for (int i = 0, symbolindex = pagenum * entries_per_page; i < entries_per_page; ++i, ++symbolindex)
            {
                Label lbl = labels[i];
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
                        lbl.Font = fontItalic;
                        if ((int)lbl.Tag == 1)
                        {
                            lbl.Tag = 0;
                            emu.WriteInt32(addrSymbolTable + addr, (uint)goal_true);
                            lbl.ForeColor = Color.LimeGreen;
                        }
                        else
                            lbl.ForeColor = Color.Red;
                    }
                    else if (val == goal_true)
                    {
                        lbl.Font = fontItalic;
                        if ((int)lbl.Tag == 1)
                        {
                            lbl.Tag = 0;
                            emu.WriteInt32(addrSymbolTable + addr, (uint)goal_false);
                            lbl.ForeColor = Color.Red;
                        }
                        else
                            lbl.ForeColor = Color.LimeGreen;
                    }
                    else
                    {
                        lbl.Font = fontRegular;
                        lbl.ForeColor = Color.Black;
                    }
                    if (symbolindex == search_index-1)
                    {
                        lbl.Font = fontBold;
                    }
                }
                else
                {
                    lbl.Visible = false;
                }
            }
        }
    }
}
