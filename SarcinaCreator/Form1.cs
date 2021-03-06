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

        Map map;
        private Map Map { 
            set
            {
                map = value;
                OnMapChanged();
            }
            get => map; }

        List<Portal> portals = new List<Portal>();
        List<VectorObject> portalsStr = new List<VectorObject>();

        List<Sarcina.Objects.Button> buttons = new List<Sarcina.Objects.Button>();
        List<VectorObject> buttonsStr = new List<VectorObject>();

        List<Terminal> terminals = new List<Terminal>();
        List<VectorObject> terminalsStr = new List<VectorObject>();

        public Form1()
        {
            InitializeComponent();

            tbPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\map.json";

            ResetDict();
        }
        private void ResetDict()
        {
            dict.Clear();
            GameObject o = new Player();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Wall();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Box();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Grass();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });

            o = new Objective();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new NamedBox();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Sarcina.Objects.Button();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Portal();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });
            o = new Terminal();
            dict.Add(o.GetType().Name,
                new GameObjectProps()
                {
                    IsControlledByPlayer = o.IsControlledByPlayer,
                    IsMoveable = o.IsMoveable,
                    IsWall = o.IsWall,
                    SpriteId = o.SpriteId
                });

            cbObj.Items.Clear();
            foreach (var kv in dict)
            {
                cbObj.Items.Add(kv.Key);
            }

            cbObj.SelectedIndex = 0;
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
            portalsStr.Add(new VectorObject(-1, -1));

            cbButton.Items.Clear();
            cbTerminal.Items.Clear();
            cbTerminal.Items.Add("--- (-1,-1)");
            terminalsStr.Add(new VectorObject(-1, -1));

            if (map != null)
            {
                rtbPreview.AppendText(map.GetDisplay());

                for (int i = 0; i < map.Height; ++i)
                {
                    for (int j = 0; j < map.Width; ++j)
                    {
                        Portal p = map.Grid[i][j].GetPortal();
                        if (p != null)
                        {
                            portals.Add(p);
                            portalsStr.Add(new VectorObject(j, i));
                            cbPortal.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                            cbPortalConn.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }

                        Terminal t = map.Grid[i][j].GetTerminal();
                        if (t != null)
                        {
                            terminals.Add(t);
                            terminalsStr.Add(new VectorObject(j, i));
                            cbTerminal.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }

                        Sarcina.Objects.Button b = map.Grid[i][j].GetButton();
                        if (b != null)
                        {
                            buttons.Add(b);
                            buttonsStr.Add(new VectorObject(j, i));
                            cbButton.Items.Add(String.Format("(x:{0}, y:{1})", j, i));
                        }
                    }
                }
            }
            if (cbPortal.Items.Count > 0)
                cbPortal.SelectedIndex = 0;
            else
            {
                cbPortal.Text = "";
                cbPortal.SelectedIndex = -1;
            }
            if (cbPortalConn.Items.Count <= 1)
            {
                cbPortalConn.Text = "";
                cbPortalConn.SelectedIndex = -1;
            }

            if (cbButton.Items.Count > 0)
                cbButton.SelectedIndex = 0;
            else
            {
                cbButton.Text = "";
                cbButton.SelectedIndex = -1;
            }
            if (cbTerminal.Items.Count <= 1)
            {
                cbTerminal.Text = "";
                cbTerminal.SelectedIndex = -1;
            }

            cbObj.SelectedIndex = 0;
            cbObj_SelectedIndexChanged(null, null);
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
                int j = 0, maxj = 0;

                foreach (var line in rtbMap.Lines)
                {
                    string str = line;
                    
                    str = str.Trim();
                    str = Regex.Replace(line, @"\s+", " ");
                    if (!String.IsNullOrWhiteSpace(str))
                    {
                        j = 0;
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
                                case 'N':
                                    go = new NamedBox();
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
                                    ++j;
                                    continue;
                                default:
                                    go = null;
                                    break;
                            }
                            if (go != null)
                                map.Grid[i][j].Add(go);
                        }
                        if (!Regex.IsMatch(str, @"\s$")) ++j;
                        if (j > maxj) maxj = j;
                        i++;
                    }
                }

                nuHeight.Value = i;
                nuWidth.Value = maxj;
                GameObject.UpdateDictionary(CopyDict(dict));
            }
            catch (Exception e)
            {
                rtbPreview.AppendText(e.Message);
            }

            return map;
        }

        private void SetMapFromJson(string json)
        {
            Map = null;
            Map = Map.GetFromJson(json);
            nuHeight.Value = map.Height;
            nuWidth.Value = map.Width;

            rtbPreview.Text = rtbMap.Text = Map.GetDisplay();

            dict.Clear();
            dict = CopyDict(GameObject.GetDictionary());

            OnMapChanged();

            cbObj.SelectedIndex = 0;
        }

        private Dictionary<string, GameObjectProps> CopyDict(Dictionary<string, GameObjectProps> original)
        {
            Dictionary<string, GameObjectProps> copy = new Dictionary<string, GameObjectProps>();
            copy = original.ToDictionary(entry => entry.Key, entry => (GameObjectProps)entry.Value.Clone()); // deep copy
            return copy;
        }

        /// ================   EVENTS

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                rtbPreview.Clear();
                //Map = GenerateMap(); // removed since forgets all connections
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
        
        private void OnMapChanged(object sender, EventArgs e)
        {
            rtbPreview.Clear();
            Map = GenerateMap();
            rtbPreview.Text = rtbMap.Text = Map.GetDisplay();
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



        private void cbPortal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbPortal.SelectedIndex;

            Portal p = portals[index];

            VectorObject connp = p.ConnectedPortal;

            int connix = portalsStr.FindIndex(e => e.X == connp.X && e.Y == connp.Y);

            cbPortalConn.SelectedIndex = connix;

        }

        private void OnConnectedPortalChanged(object sender, EventArgs e)
        {
            try
            {
                int ix = cbPortal.SelectedIndex;
                int connix = cbPortalConn.SelectedIndex;

                Portal p = portals[ix];
                VectorObject vec = portalsStr[connix];
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

            VectorObject connp = b.ConnectedTerminal;

            int connix = terminalsStr.FindIndex(e => e.X == connp.X && e.Y == connp.Y);

            cbTerminal.SelectedIndex = connix;
        }

        private void OnConnectedTerminalChanged(object sender, EventArgs e)
        {
            try
            {
                int ix = cbButton.SelectedIndex;
                int connix = cbTerminal.SelectedIndex;

                Sarcina.Objects.Button b = buttons[ix];
                VectorObject vec = terminalsStr[connix];
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
                    SetMapFromJson(json);
                }
            }
        }
       
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                    "Player    \t\tP\n"+
                    "Portal    \t\tX\n" +
                    "NamedBox\t\tN\n" +
                    "Box       \t\tB\n" +
                    "Wall      \t\tW\n" +
                    "Grass     \t\tG\n" +
                    "Objective \t\tO\n" +
                    "Terminal  \t\tT\n" +
                    "Button    \t\t_\n"
                );
        }

        private void rtbMap_TextChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(sender.ToString());
            rtbPreview.Clear();
            //Map = GenerateMap();
        }

        // => saving object properties
        private void btnSaveObjects_Click(object sender, EventArgs e)
        {
            UpdateObjectProperties();
        }
        private void OnObjectPropertyChanged(object sender, EventArgs e)
        {
            UpdateObjectProperties();
        }
        private void OnObjectPropertyChanged(object sender, KeyPressEventArgs e)
        {
            UpdateObjectProperties();
        }
        private void UpdateObjectProperties()
        {
            string key = (string)cbObj.SelectedItem;
            dict[key].IsControlledByPlayer = cbIsPlayer.Checked;
            dict[key].IsMoveable = cbMoveable.Checked;
            dict[key].IsWall = cbIsWall.Checked;
            dict[key].SpriteId = (int)nuSpriteId.Value;

            GameObject.UpdateDictionary(CopyDict(dict));
        }
        // <= saving object properties
    }
}
