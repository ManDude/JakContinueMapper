using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JakContinueMapper
{
    public partial class MainForm : Form
    {
        public Emulators.PCSX2 Emulator { get; set; }
        public GameMemoryAttribute Game { get; set; }

        private GameAddr addrTargetPos;
        private GameAddr addrSymbolTable;
        private Timer memtimer;
        private ContinueForm continueForm;
        private SymbolTableForm symbolTableForm;

        public static Dictionary<string, List<GameContinue>> continues = new Dictionary<string, List<GameContinue>>()
        {
            { "mis", new List<GameContinue>() {
                new GameContinue("misty-start", 164316.7813f, 15128.57617f, 3390588f),
                new GameContinue("misty-silo", -672503f, 82131.35156f, 3651465.75f),
                new GameContinue("misty-silo2", -898000.0625f, 98038.17188f, 4162091f),
                new GameContinue("misty-backside", -304192.7188f, 33270.98828f, 4646525f),
                new GameContinue("misty-bike", 302533.4375f, 35901.84766f, 4138967.75f)
            }},
            { "fir", new List<GameContinue>() {
                new GameContinue("firecanyon-start", -87377.10156f, 126444.75f, -681697.25f),
                new GameContinue("firecanyon-end", 1360576.125f, 126976f, -5839533.5f)
            }},
            { "vi2", new List<GameContinue>() {
                new GameContinue("village2-start", 1460961.25f, 108562.0234f, -6161391f),
                new GameContinue("village2-dock", 1264346.75f, 19451.49414f, -6833563.5f)
            }},
            { "sun", new List<GameContinue>() {
                new GameContinue("sunken-start", 2229231.25f, -1019912.188f, -6788748.5f),
                new GameContinue("sunken1", 3062988.5f, -536575.5625f, -6527484f),
                new GameContinue("sunken2", 3133625.5f, -569343.5625f, -6909587.5f),
                new GameContinue("sunken-tube1", 2649601.75f, -569343.5625f, -7132970f)
            }},
            { "sub", new List<GameContinue>() {
                new GameContinue("sunkenb-start", 2229231.25f, -1019912.188f, -6788748.5f),
                new GameContinue("sunkenb-helix", 2466572.75f, -1838989.25f, -7299582f)
            }},
            { "swa", new List<GameContinue>() {
                new GameContinue("swamp-start", 1842537.25f, 21027.22656f, -7333297.5f),
                new GameContinue("swamp-dock1", 1360386.875f, 5823.692871f, -8218890f),
                new GameContinue("swamp-cave1", 1553700.5f, 1835.417603f, -8258429.5f),
                new GameContinue("swamp-dock2", 1645872.375f, 36495.76953f, -8427323f),
                new GameContinue("swamp-cave2", 2037539.25f, 1103.871948f, -8560013f),
                new GameContinue("swamp-game", 2612289.25f, -2047.590454f, -8315907.5f),
                new GameContinue("swamp-cave3", 2011811.375f, 3711.795166f, -7923027f)
            }},
            { "ogr", new List<GameContinue>() {
                new GameContinue("ogre-start", 849775.8125f, 163962.875f, -7301166.5f),
                new GameContinue("ogre-race", 841424.875f, 163801.0938f, -8205419.5f),
                new GameContinue("ogre-end", 3971233.5f, 141227.625f, -13935735f)
            }},
            { "vi3", new List<GameContinue>() {
                new GameContinue("village3-start", 4468021.5f, 186608.0313f, -14054268f),
                new GameContinue("village3-farside", 4423744f, 198723.5781f, -14530641f)
            }},
            { "mai", new List<GameContinue>() {
                new GameContinue("maincave-start", 4420967f, 33006.38672f, -13154230f),
                new GameContinue("maincave-to-darkcave", 4172175.75f, 154223.8281f, -12445165f),
                new GameContinue("maincave-to-robocave", 4760896.5f, 44221.23438f, -12409880f)
            }},
            { "rob", new List<GameContinue>() {
                new GameContinue("robocave-start", 5208223.5f, 69697.94531f, -11781496f),
                new GameContinue("robocave-bottom", 5435461.5f, -97111.24219f, -11588379f)
            }},
            { "sno", new List<GameContinue>() {
                new GameContinue("snow-start", 4256260f, 983713.8125f, -14182752f),
                new GameContinue("snow-by-ice-lake", 3151164.5f, 1049638.125f, -14246464f),
                new GameContinue("snow-flut-flut", 2481850f, 1054709.375f, -13922438f),
                new GameContinue("snow-across-from-flut", 2721898.5f, 1049845f, -13743428f),
                new GameContinue("snow-outside-cave", 3200864.25f, 907400.375f, -13676660f),
                new GameContinue("snow-outside-fort", 3431014f, 901474.6875f, -13600187f),
                new GameContinue("snow-fort", 3430875.25f, 897149.3125f, -13397581f),
                new GameContinue("snow-pass-to-fort", 3751044.75f, 917612.125f, -13828696f)
            }},
            { "lav", new List<GameContinue>() {
                new GameContinue("lavatube-start", 5511317f, 159871.7969f, -14621239f),
                new GameContinue("lavatube-middle", 9081441f, -3935.846436f, -14056285f),
                new GameContinue("lavatube-after-ribbon", 9954895f, 390513.0625f, -16548614f),
                new GameContinue("lavatube-end", 11479892f, -163656.5f, -18266490f)
            }},
            { "cit", new List<GameContinue>() {
                new GameContinue("citadel-entrance", 11443969f, -154216.0313f, -18472782f),
                new GameContinue("citadel-start", 11442706f, -142755.8438f, -18869044f),
                new GameContinue("citadel-launch-start", 10827551f, -94047.02344f, -18946718f),
                new GameContinue("citadel-launch-end", 11047507f, -81514.08594f, -19495960f),
                new GameContinue("citadel-plat-start", 11443470f, -120194.6641f, -19845628f),
                new GameContinue("citadel-plat-end", 11269726f, -12132.35156f, -19614712f),
                new GameContinue("citadel-generator-start", 12138031f, -36900.86328f, -18933304f),
                new GameContinue("citadel-generator-end", 11837483f, -20177.71484f, -19506848f),
                new GameContinue("citadel-elevator", 11447961f, 234055.2656f, -19169000f)
            }},
            { "fin", new List<GameContinue>() {
                new GameContinue("finalboss-start", 11548456f, 2215872f, -19409498f),
                new GameContinue("finalboss-fight", 12288335f, 1970461.875f, -19848522f)
            }}
        };

        internal static Dictionary<string, GameMemoryAttribute> games = new Dictionary<string, GameMemoryAttribute>();
        internal void PopulateGamesList()
        {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var t in a.GetExportedTypes())
                {
                    foreach (GameMemoryAttribute attr in t.GetCustomAttributes(typeof(GameMemoryAttribute), false))
                    {
                        games.Add(attr.Name, attr);
                        dpdGame.Items.Add(attr.Name);
                    }
                }
            }
        }

        internal void SetContinueLevels()
        {
            foreach (var kvp in continues)
            {
                foreach (GameContinue cont in kvp.Value)
                {
                    cont.Level = kvp.Key;
                }
            }
        }

        public MainForm()
        {
            Emulator = new Emulators.PCSX2();
            InitializeComponent();
            MinimumSize = Size;
            continueForm = new ContinueForm(this);
            symbolTableForm = new SymbolTableForm();
            //continueForm.Show();
            PopulateGamesList();
            SetContinueLevels();

            memtimer = new Timer
            {
                Enabled = false,
                Interval = 16
            };
            memtimer.Tick += (object sender, EventArgs e) =>
            {
                Emulator.UpdateProcess("pcsx2");
                if (Emulator.ProcessIsValid)
                {
                    try
                    {
                        Emulator.ReadFloat3(addrTargetPos, out float tgt_x, out float tgt_y, out float tgt_z);
                        lblPos.Text = $"X: {tgt_x/4096} ({tgt_x})\nY: {tgt_y/4096} ({tgt_y})\nZ: {tgt_z/4096} ({tgt_z})";

                        GameContinue close1 = null, close2 = null;
                        string level = (string)dpdLevel.SelectedItem;
                        level = level.Substring(level.LastIndexOf('(')+1, level.LastIndexOf(')')-(level.LastIndexOf('(')+1));
                        foreach (var kvp in continues)
                        {
                            if (kvp.Key == level)
                            {
                                foreach (GameContinue cont in kvp.Value)
                                {
                                    float dist = MathExt.Dist3D(tgt_x, tgt_y, tgt_z, cont.X, cont.Y, cont.Z);
                                    if (close1 == null)
                                    {
                                        close1 = cont;
                                    }
                                    else if (dist < MathExt.Dist3D(tgt_x, tgt_y, tgt_z, close1.X, close1.Y, close1.Z))
                                    {
                                        close2 = close1;
                                        close1 = cont;
                                    }
                                    else if (close2 == null || dist < MathExt.Dist3D(tgt_x, tgt_y, tgt_z, close2.X, close2.Y, close2.Z))
                                    {
                                        close2 = cont;
                                    }
                                }
                                break;
                            }
                        }
                        if (close1 == null)
                            lblContinueName1.Text = "(no available checkpoint)";
                        else
                            lblContinueName1.Text = $"{close1.Name} ({MathExt.Dist3D(tgt_x, tgt_y, tgt_z, close1.X, close1.Y, close1.Z)/4096}m)";
                        if (close1 != null && close2 == null)
                            lblContinueName2.Text = "(idle deload has no effect)";
                        else if (close2 == null)
                            lblContinueName2.Text = "(no available checkpoint)";
                        else
                            lblContinueName2.Text = $"{close2.Name} ({MathExt.Dist3D(tgt_x, tgt_y, tgt_z, close2.X, close2.Y, close2.Z)/4096}m)";
                        if (close1 != null && close2 != null)
                        {
                            float mx = (close1.X + close2.X) / 2;
                            float my = (close1.Y + close2.Y) / 2;
                            float mz = (close1.Z + close2.Z) / 2;
                            float vx = close2.X - close1.X;
                            float vy = close2.Y - close1.Y;
                            float vz = close2.Z - close1.Z;
                            float bp = mx*vx + my*vy + mz*vz;
                            float d = -(vx*tgt_x + vy*tgt_y + vz*tgt_z - bp)/(float)Math.Sqrt(vx*vx+vy*vy+vz*vz);
                            lblContinueMedianDist.Text = $"{d/4096}m ({d})";
                        }
                        else
                        {
                            lblContinueMedianDist.Text = "(no second checkpoint)";
                        }
                        if (continueForm.Visible) continueForm.UpdateAllContinues(level, tgt_x, tgt_y, tgt_z, close1);
                        if (symbolTableForm.Visible) {
                            Emulator.ReadMem(addrSymbolTable, 0x10000, out byte[] symboltable);
                            Emulator.ReadMem(addrSymbolTable+65336, 0x10000, out byte[] symbolnameptrs);
                            symbolTableForm.UpdateSymbols(Emulator, addrSymbolTable);
                        }

                        lblError.Visible = false;
                        fraGame.Visible = true;
                    }
                    catch (Win32Exception ex)
                    {
                        lblError.Text = $"ERROR: {ex.Message}\n\nMake sure the settings are correct!";
                        lblError.Location = fraGame.Location;
                        lblError.Size = fraGame.Size;
                        lblError.Visible = true;
                        fraGame.Visible = false;
                    }
                }
                else
                {
                    lblError.Text = "Process could not be found, or is in an invalid state.\nGame may not be booted up, or emulator is unsupported.";
                    lblError.Location = fraGame.Location;
                    lblError.Size = fraGame.Size;
                    lblError.Visible = true;
                    fraGame.Visible = false;
                }
            };

            dpdGame.SelectedIndex = 1;
            dpdLevel.SelectedIndex = 0;
        }

        internal void SetGame(GameMemoryAttribute game)
        {
            if (Game == null || Game != game) // game changed
            {
                memtimer.Enabled = false;
                // update current game and addresses
                Game = game;
                addrTargetPos = new GameAddr(Game.TargetPos);
                addrSymbolTable = new GameAddr(Game.SymbolTable);
                memtimer.Enabled = true;
            }
        }

        private void dpdGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGame(games[(string)dpdGame.SelectedItem]);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            continueForm.Location = new Point(Location.X + Width, Location.Y);
        }

        private void btnToggleContForm_Click(object sender, EventArgs e)
        {
            if (!continueForm.Visible)
            {
                continueForm.Show();
                btnToggleContForm.Text = "Hide All Checkpoints";
            }
            else
            {
                continueForm.Hide();
                btnToggleContForm.Text = "Show All Checkpoints";
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "A tool to instantly visualize your Jak & Daxter idle deload results.\n\nThis tool is based on the original calculator made by Kuitar and blahpy.\n\nVersion 1.3 by mandude/dass @ github.com", "JakContinueMapper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSymbolTable_Click(object sender, EventArgs e)
        {
            if (!symbolTableForm.Visible)
            {
                symbolTableForm.Show();
            }
            else
            {
                symbolTableForm.Hide();
            }
        }
    }
}
