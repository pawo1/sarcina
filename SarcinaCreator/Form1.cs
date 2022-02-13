using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sarcina.Maps;
using Sarcina.Objects;

namespace SarcinaCreator
{
    public partial class Form1 : Form
    {
        Dictionary<string, GameObjectProps> dict = new Dictionary<string, GameObjectProps>();
        Dictionary<string, GameObject> dictGo = new Dictionary<string, GameObject>();

        Map map;
        Map Map { 
            set
            {
                map = value;
                OnMapChanged();
            }
            get => map; }

        List<Portal> portals = new List<Portal>();
        List<Vector2> portalsStr = new List<Vector2>();

        List<Sarcina.Objects.Button> buttons = new List<Sarcina.Objects.Button>();
        List<Vector2> buttonsStr = new List<Vector2>();

        List<Terminal> terminals = new List<Terminal>();
        List<Vector2> terminalsStr = new List<Vector2>();

        public Form1()
        {
            InitializeComponent();

            tbPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\map.json";

            GameObject o = new Player();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            dictGo.Add(o.GetType().Name, o);
            o = new Wall();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            dictGo.Add(o.GetType().Name, o);
            o = new Box();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            dictGo.Add(o.GetType().Name, o);
            o = new Grass();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            dictGo.Add(o.GetType().Name, o);

            o = new Objective();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });

            foreach (var kv in dict)
            {
                cbObj.Items.Add(kv.Key);
            }

            cbObj.SelectedIndex = 0;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                GameObject.UpdateDictionary(dict);
                string json = Map.GetJson();
                File.WriteAllText(tbPath.Text, json);

                MessageBox.Show("Zapisano!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMapChanged()
        {
            portals.Clear();
            portalsStr.Clear();
            terminals.Clear();
            terminalsStr.Clear();
            buttons.Clear();
            buttonsStr.Clear();

            cbPortal.Items.Clear();
            cbPortalConn.Items.Clear();
            cbPortalConn.Items.Add("--- (-1,-1)");
            portalsStr.Add(new Vector2(-1, -1));

            cbButton.Items.Clear();
            cbTerminal.Items.Clear();
            cbTerminal.Items.Add("--- (-1,-1)");
            terminalsStr.Add(new Vector2(-1, -1));

            if (Map != null)
            {
                rtbPreview.AppendText(Map.GetDisplay());

                for (int i = 0; i < Map.Height; ++i)
                {
                    for (int j = 0; j < Map.Width; ++j)
                    {
                        Portal p = Map.Grid[i][j].GetPortal();
                        if (p != null)
                        {
                            portals.Add(p);
                            portalsStr.Add(new Vector2(j, i));
                            cbPortal.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                            cbPortalConn.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }

                        Terminal t = Map.Grid[i][j].GetTerminal();
                        if (t != null)
                        {
                            terminals.Add(t);
                            terminalsStr.Add(new Vector2(j, i));
                            cbTerminal.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }

                        Sarcina.Objects.Button b = Map.Grid[i][j].GetButton();
                        if (b != null)
                        {
                            buttons.Add(b);
                            buttonsStr.Add(new Vector2(j, i));
                            cbButton.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }
                    }
                }
            }
            if (cbPortal.Items.Count > 0)
                cbPortal.SelectedIndex = 0;
            if (cbButton.Items.Count > 0)
                cbButton.SelectedIndex = 0;
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            rtbPreview.Clear();
            Map = GenerateMap();
        }

        private Map GenerateMap()
        {
            Map map = null;
            try
            {
                int width = (int)nuWidth.Value;
                int height = (int)nuHeight.Value;

                map = new Map(height, width);

                int i = 0;
                int j = 0;

                foreach (var line in rtbMap.Lines)
                {
                    string str = line;
                    j = 0;
                    str = str.Trim();
                    str = Regex.Replace(line, @"\s+", " ");
                    foreach (char c in str)
                    {
                        GameObject go;

                        switch (c)
                        {
                            case 'P':
                                go = new Player();
                                break;
                            case 'X':
                                go = new Portal();
                                break;
                            case 'B':
                                go = new Box();
                                break;
                            case 'W':
                                go = new Wall();
                                break;
                            case 'G':
                                go = new Grass();
                                break;
                            case 'O':
                                go = new Objective();
                                break;
                            case 'T':
                                go = new Terminal();
                                break;
                            case '_':
                                go = new Sarcina.Objects.Button();
                                break;

                            case ' ':
                                j++;
                                continue;
                            default:
                                go = null;
                                break;
                        }
                        if (go != null)
                            map.Grid[i][j].Add(go);
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                rtbPreview.AppendText(e.Message);
            }

            return map;
        }

        private void cbObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = (string)cbObj.SelectedItem;
            GameObjectProps gop = dict[key];
            cbIsPlayer.Checked = gop.IsControlledByPlayer;
            cbIsWall.Checked = gop.IsWall;
            cbMoveable.Checked = gop.IsMoveable;
            nuSpriteId.Value = gop.SpriteId;

        }

        private void btnSaveProps_Click(object sender, EventArgs e)
        {
            string key = (string)cbObj.SelectedItem;
            dict[key].IsControlledByPlayer = cbIsPlayer.Checked;
            dict[key].IsMoveable = cbMoveable.Checked;
            dict[key].IsWall = cbIsWall.Checked;
            dict[key].SpriteId = (int)nuSpriteId.Value;

        }

        private void cbPortal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbPortal.SelectedIndex;

            Portal p = portals[index];

            Vector2 connp = p.ConnectedPortal;

            int connix = portalsStr.FindIndex(e => e.X == connp.X && e.Y == connp.Y);

            cbPortalConn.SelectedIndex = connix;

        }

        private void btnSavePortal_Click(object sender, EventArgs e)
        {
            try
            {
                int ix = cbPortal.SelectedIndex;
                int connix = cbPortalConn.SelectedIndex;

                Portal p = portals[ix];
                Vector2 vec = portalsStr[connix];
                p.ConnectedPortal = vec;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbButton.SelectedIndex;

            Sarcina.Objects.Button b = buttons[index];

            Vector2 connp = b.ConnectedTerminal;

            int connix = terminalsStr.FindIndex(e => e.X == connp.X && e.Y == connp.Y);

            cbTerminal.SelectedIndex = connix;
        }

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int ix = cbButton.SelectedIndex;
                int connix = cbTerminal.SelectedIndex;

                Sarcina.Objects.Button b = buttons[ix];
                Vector2 vec = terminalsStr[connix];
                b.ConnectedTerminal = vec;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbPath.Text = fbd.SelectedPath + "\\map.json";
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "json files (*.json)|";
                ofd.Multiselect = false;
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    tbPath.Text = ofd.FileName;

                    string json = File.ReadAllText(ofd.FileName);
                    Map = Map.GetFromJson(json);
                    rtbMap.Clear();
                    rtbMap.Text = Map.GetDisplay();
                }
            }
        }
    }
}
