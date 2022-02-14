
namespace SarcinaCreator
{
    partial class Form1
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
            this.rtbMap = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.nuWidth = new System.Windows.Forms.NumericUpDown();
            this.nuHeight = new System.Windows.Forms.NumericUpDown();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbObj = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsPlayer = new System.Windows.Forms.CheckBox();
            this.cbIsWall = new System.Windows.Forms.CheckBox();
            this.cbMoveable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nuSpriteId = new System.Windows.Forms.NumericUpDown();
            this.cbPortal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPortalConn = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbButton = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTerminal = new System.Windows.Forms.ComboBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabMap = new System.Windows.Forms.TabControl();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.nuWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSpriteId)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.tabPagePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMap
            // 
            this.rtbMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMap.Location = new System.Drawing.Point(6, 6);
            this.rtbMap.Name = "rtbMap";
            this.rtbMap.Size = new System.Drawing.Size(1336, 549);
            this.rtbMap.TabIndex = 0;
            this.rtbMap.Text = "";
            this.rtbMap.TextChanged += new System.EventHandler(this.rtbMap_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(826, 787);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(124, 90);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // nuWidth
            // 
            this.nuWidth.Location = new System.Drawing.Point(64, 21);
            this.nuWidth.Name = "nuWidth";
            this.nuWidth.Size = new System.Drawing.Size(150, 27);
            this.nuWidth.TabIndex = 7;
            // 
            // nuHeight
            // 
            this.nuHeight.Location = new System.Drawing.Point(64, 54);
            this.nuHeight.Name = "nuHeight";
            this.nuHeight.Size = new System.Drawing.Size(150, 27);
            this.nuHeight.TabIndex = 8;
            // 
            // rtbPreview
            // 
            this.rtbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPreview.Enabled = false;
            this.rtbPreview.Location = new System.Drawing.Point(3, 6);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.Size = new System.Drawing.Size(1339, 549);
            this.rtbPreview.TabIndex = 9;
            this.rtbPreview.Text = "";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(6, 87);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 29);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.OnMapChanged);
            // 
            // cbObj
            // 
            this.cbObj.FormattingEnabled = true;
            this.cbObj.Location = new System.Drawing.Point(80, 15);
            this.cbObj.Name = "cbObj";
            this.cbObj.Size = new System.Drawing.Size(151, 28);
            this.cbObj.TabIndex = 12;
            this.cbObj.SelectedIndexChanged += new System.EventHandler(this.cbObj_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Object";
            // 
            // cbIsPlayer
            // 
            this.cbIsPlayer.AutoSize = true;
            this.cbIsPlayer.Location = new System.Drawing.Point(13, 87);
            this.cbIsPlayer.Name = "cbIsPlayer";
            this.cbIsPlayer.Size = new System.Drawing.Size(81, 24);
            this.cbIsPlayer.TabIndex = 14;
            this.cbIsPlayer.Text = "isPlayer";
            this.cbIsPlayer.UseVisualStyleBackColor = true;
            this.cbIsPlayer.CheckedChanged += new System.EventHandler(this.OnObjectPropertyChanged);
            // 
            // cbIsWall
            // 
            this.cbIsWall.AutoSize = true;
            this.cbIsWall.Location = new System.Drawing.Point(13, 117);
            this.cbIsWall.Name = "cbIsWall";
            this.cbIsWall.Size = new System.Drawing.Size(70, 24);
            this.cbIsWall.TabIndex = 15;
            this.cbIsWall.Text = "isWall";
            this.cbIsWall.UseVisualStyleBackColor = true;
            this.cbIsWall.CheckedChanged += new System.EventHandler(this.OnObjectPropertyChanged);
            // 
            // cbMoveable
            // 
            this.cbMoveable.AutoSize = true;
            this.cbMoveable.Location = new System.Drawing.Point(100, 87);
            this.cbMoveable.Name = "cbMoveable";
            this.cbMoveable.Size = new System.Drawing.Size(107, 24);
            this.cbMoveable.TabIndex = 16;
            this.cbMoveable.Text = "isMoveable";
            this.cbMoveable.UseVisualStyleBackColor = true;
            this.cbMoveable.CheckedChanged += new System.EventHandler(this.OnObjectPropertyChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "SpriteId";
            // 
            // nuSpriteId
            // 
            this.nuSpriteId.Location = new System.Drawing.Point(80, 54);
            this.nuSpriteId.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nuSpriteId.Name = "nuSpriteId";
            this.nuSpriteId.Size = new System.Drawing.Size(150, 27);
            this.nuSpriteId.TabIndex = 18;
            this.nuSpriteId.ValueChanged += new System.EventHandler(this.OnObjectPropertyChanged);
            // 
            // cbPortal
            // 
            this.cbPortal.FormattingEnabled = true;
            this.cbPortal.Location = new System.Drawing.Point(63, 20);
            this.cbPortal.Name = "cbPortal";
            this.cbPortal.Size = new System.Drawing.Size(151, 28);
            this.cbPortal.TabIndex = 20;
            this.cbPortal.SelectedIndexChanged += new System.EventHandler(this.cbPortal_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "portal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Connected portal";
            // 
            // cbPortalConn
            // 
            this.cbPortalConn.FormattingEnabled = true;
            this.cbPortalConn.Location = new System.Drawing.Point(63, 74);
            this.cbPortalConn.Name = "cbPortalConn";
            this.cbPortalConn.Size = new System.Drawing.Size(151, 28);
            this.cbPortalConn.TabIndex = 23;
            this.cbPortalConn.SelectedIndexChanged += new System.EventHandler(this.OnConnectedPortalChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Button";
            // 
            // cbButton
            // 
            this.cbButton.FormattingEnabled = true;
            this.cbButton.Location = new System.Drawing.Point(65, 20);
            this.cbButton.Name = "cbButton";
            this.cbButton.Size = new System.Drawing.Size(151, 28);
            this.cbButton.TabIndex = 25;
            this.cbButton.SelectedIndexChanged += new System.EventHandler(this.cbButton_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "ConnectedTerminal";
            // 
            // cbTerminal
            // 
            this.cbTerminal.FormattingEnabled = true;
            this.cbTerminal.Location = new System.Drawing.Point(65, 74);
            this.cbTerminal.Name = "cbTerminal";
            this.cbTerminal.Size = new System.Drawing.Size(151, 28);
            this.cbTerminal.TabIndex = 27;
            this.cbTerminal.SelectedIndexChanged += new System.EventHandler(this.OnConnectedTerminalChanged);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(6, 60);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(790, 27);
            this.tbPath.TabIndex = 29;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(702, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(94, 29);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(602, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(989, 848);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 29);
            this.btnHelp.TabIndex = 32;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbPortalConn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbPortal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(552, 616);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 154);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Portals";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbButton);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbTerminal);
            this.groupBox2.Location = new System.Drawing.Point(820, 616);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 154);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Button-Terminal";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbObj);
            this.groupBox3.Controls.Add(this.cbIsPlayer);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nuSpriteId);
            this.groupBox3.Controls.Add(this.cbIsWall);
            this.groupBox3.Controls.Add(this.cbMoveable);
            this.groupBox3.Location = new System.Drawing.Point(282, 616);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 154);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objects";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.nuWidth);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.nuHeight);
            this.groupBox4.Controls.Add(this.btnPreview);
            this.groupBox4.Location = new System.Drawing.Point(12, 612);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 158);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Map";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Saving path:";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.tbPath);
            this.groupBox5.Controls.Add(this.btnLoad);
            this.groupBox5.Controls.Add(this.btnBrowse);
            this.groupBox5.Location = new System.Drawing.Point(12, 776);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(802, 103);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Files";
            // 
            // tabMap
            // 
            this.tabMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMap.Controls.Add(this.tabPageMap);
            this.tabMap.Controls.Add(this.tabPagePreview);
            this.tabMap.Location = new System.Drawing.Point(12, 12);
            this.tabMap.Name = "tabMap";
            this.tabMap.SelectedIndex = 0;
            this.tabMap.Size = new System.Drawing.Size(1356, 594);
            this.tabMap.TabIndex = 40;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.rtbMap);
            this.tabPageMap.Location = new System.Drawing.Point(4, 29);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(1348, 561);
            this.tabPageMap.TabIndex = 0;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.rtbPreview);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 29);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(1348, 561);
            this.tabPagePreview.TabIndex = 1;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 889);
            this.Controls.Add(this.tabMap);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Designer";
            ((System.ComponentModel.ISupportInitialize)(this.nuWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSpriteId)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabMap.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.tabPagePreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nuWidth;
        private System.Windows.Forms.NumericUpDown nuHeight;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cbObj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbIsPlayer;
        private System.Windows.Forms.CheckBox cbIsWall;
        private System.Windows.Forms.CheckBox cbMoveable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuSpriteId;
        private System.Windows.Forms.ComboBox cbPortal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPortalConn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTerminal;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabMap;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.TabPage tabPagePreview;
    }
}

