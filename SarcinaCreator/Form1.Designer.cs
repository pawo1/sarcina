
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.nuWidth = new System.Windows.Forms.NumericUpDown();
            this.nuHeight = new System.Windows.Forms.NumericUpDown();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbObj = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIsPlayer = new System.Windows.Forms.CheckBox();
            this.cbIsWall = new System.Windows.Forms.CheckBox();
            this.cbMoveable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nuSpriteId = new System.Windows.Forms.NumericUpDown();
            this.btnSaveProps = new System.Windows.Forms.Button();
            this.cbPortal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPortalConn = new System.Windows.Forms.ComboBox();
            this.btnPortalSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbButton = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTerminal = new System.Windows.Forms.ComboBox();
            this.btnSaveButton = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSpriteId)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbMap
            // 
            this.rtbMap.Location = new System.Drawing.Point(12, 32);
            this.rtbMap.Name = "rtbMap";
            this.rtbMap.Size = new System.Drawing.Size(449, 229);
            this.rtbMap.TabIndex = 0;
            this.rtbMap.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(567, 367);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 29);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // nuWidth
            // 
            this.nuWidth.Location = new System.Drawing.Point(547, 7);
            this.nuWidth.Name = "nuWidth";
            this.nuWidth.Size = new System.Drawing.Size(150, 27);
            this.nuWidth.TabIndex = 7;
            // 
            // nuHeight
            // 
            this.nuHeight.Location = new System.Drawing.Point(547, 40);
            this.nuHeight.Name = "nuHeight";
            this.nuHeight.Size = new System.Drawing.Size(150, 27);
            this.nuHeight.TabIndex = 8;
            // 
            // rtbPreview
            // 
            this.rtbPreview.Enabled = false;
            this.rtbPreview.Location = new System.Drawing.Point(12, 308);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.Size = new System.Drawing.Size(449, 229);
            this.rtbPreview.TabIndex = 9;
            this.rtbPreview.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Preview";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(467, 367);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 29);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // cbObj
            // 
            this.cbObj.FormattingEnabled = true;
            this.cbObj.Location = new System.Drawing.Point(526, 129);
            this.cbObj.Name = "cbObj";
            this.cbObj.Size = new System.Drawing.Size(151, 28);
            this.cbObj.TabIndex = 12;
            this.cbObj.SelectedIndexChanged += new System.EventHandler(this.cbObj_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Obiekt";
            // 
            // cbIsPlayer
            // 
            this.cbIsPlayer.AutoSize = true;
            this.cbIsPlayer.Location = new System.Drawing.Point(467, 172);
            this.cbIsPlayer.Name = "cbIsPlayer";
            this.cbIsPlayer.Size = new System.Drawing.Size(81, 24);
            this.cbIsPlayer.TabIndex = 14;
            this.cbIsPlayer.Text = "isPlayer";
            this.cbIsPlayer.UseVisualStyleBackColor = true;
            // 
            // cbIsWall
            // 
            this.cbIsWall.AutoSize = true;
            this.cbIsWall.Location = new System.Drawing.Point(467, 202);
            this.cbIsWall.Name = "cbIsWall";
            this.cbIsWall.Size = new System.Drawing.Size(70, 24);
            this.cbIsWall.TabIndex = 15;
            this.cbIsWall.Text = "isWall";
            this.cbIsWall.UseVisualStyleBackColor = true;
            // 
            // cbMoveable
            // 
            this.cbMoveable.AutoSize = true;
            this.cbMoveable.Location = new System.Drawing.Point(467, 232);
            this.cbMoveable.Name = "cbMoveable";
            this.cbMoveable.Size = new System.Drawing.Size(107, 24);
            this.cbMoveable.TabIndex = 16;
            this.cbMoveable.Text = "isMoveable";
            this.cbMoveable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "SpriteId";
            // 
            // nuSpriteId
            // 
            this.nuSpriteId.Location = new System.Drawing.Point(534, 269);
            this.nuSpriteId.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nuSpriteId.Name = "nuSpriteId";
            this.nuSpriteId.Size = new System.Drawing.Size(150, 27);
            this.nuSpriteId.TabIndex = 18;
            // 
            // btnSaveProps
            // 
            this.btnSaveProps.Location = new System.Drawing.Point(526, 302);
            this.btnSaveProps.Name = "btnSaveProps";
            this.btnSaveProps.Size = new System.Drawing.Size(94, 29);
            this.btnSaveProps.TabIndex = 19;
            this.btnSaveProps.Text = "Save";
            this.btnSaveProps.UseVisualStyleBackColor = true;
            this.btnSaveProps.Click += new System.EventHandler(this.btnSaveProps_Click);
            // 
            // cbPortal
            // 
            this.cbPortal.FormattingEnabled = true;
            this.cbPortal.Location = new System.Drawing.Point(778, 22);
            this.cbPortal.Name = "cbPortal";
            this.cbPortal.Size = new System.Drawing.Size(151, 28);
            this.cbPortal.TabIndex = 20;
            this.cbPortal.SelectedIndexChanged += new System.EventHandler(this.cbPortal_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(723, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "portal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(723, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Connected portal";
            // 
            // cbPortalConn
            // 
            this.cbPortalConn.FormattingEnabled = true;
            this.cbPortalConn.Location = new System.Drawing.Point(778, 76);
            this.cbPortalConn.Name = "cbPortalConn";
            this.cbPortalConn.Size = new System.Drawing.Size(151, 28);
            this.cbPortalConn.TabIndex = 23;
            // 
            // btnPortalSave
            // 
            this.btnPortalSave.Location = new System.Drawing.Point(835, 110);
            this.btnPortalSave.Name = "btnPortalSave";
            this.btnPortalSave.Size = new System.Drawing.Size(94, 29);
            this.btnPortalSave.TabIndex = 19;
            this.btnPortalSave.Text = "Save";
            this.btnPortalSave.UseVisualStyleBackColor = true;
            this.btnPortalSave.Click += new System.EventHandler(this.btnSavePortal_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(739, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Button";
            // 
            // cbButton
            // 
            this.cbButton.FormattingEnabled = true;
            this.cbButton.Location = new System.Drawing.Point(798, 187);
            this.cbButton.Name = "cbButton";
            this.cbButton.Size = new System.Drawing.Size(151, 28);
            this.cbButton.TabIndex = 25;
            this.cbButton.SelectedIndexChanged += new System.EventHandler(this.cbButton_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(739, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "ConnectedTerminal";
            // 
            // cbTerminal
            // 
            this.cbTerminal.FormattingEnabled = true;
            this.cbTerminal.Location = new System.Drawing.Point(798, 241);
            this.cbTerminal.Name = "cbTerminal";
            this.cbTerminal.Size = new System.Drawing.Size(151, 28);
            this.cbTerminal.TabIndex = 27;
            // 
            // btnSaveButton
            // 
            this.btnSaveButton.Location = new System.Drawing.Point(835, 276);
            this.btnSaveButton.Name = "btnSaveButton";
            this.btnSaveButton.Size = new System.Drawing.Size(94, 29);
            this.btnSaveButton.TabIndex = 28;
            this.btnSaveButton.Text = "Save";
            this.btnSaveButton.UseVisualStyleBackColor = true;
            this.btnSaveButton.Click += new System.EventHandler(this.btnSaveButton_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(467, 402);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(409, 27);
            this.tbPath.TabIndex = 29;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(881, 402);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(94, 29);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.Text = "browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(714, 367);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(881, 505);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(94, 29);
            this.btnHelp.TabIndex = 32;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 546);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnSaveButton);
            this.Controls.Add(this.cbTerminal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbPortalConn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbPortal);
            this.Controls.Add(this.btnPortalSave);
            this.Controls.Add(this.btnSaveProps);
            this.Controls.Add(this.nuSpriteId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbMoveable);
            this.Controls.Add(this.cbIsWall);
            this.Controls.Add(this.cbIsPlayer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbObj);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbPreview);
            this.Controls.Add(this.nuHeight);
            this.Controls.Add(this.nuWidth);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbMap);
            this.Name = "Form1";
            this.Text = "Designer";
            ((System.ComponentModel.ISupportInitialize)(this.nuWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSpriteId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nuWidth;
        private System.Windows.Forms.NumericUpDown nuHeight;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cbObj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbIsPlayer;
        private System.Windows.Forms.CheckBox cbIsWall;
        private System.Windows.Forms.CheckBox cbMoveable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuSpriteId;
        private System.Windows.Forms.Button btnSaveProps;
        private System.Windows.Forms.ComboBox cbPortal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPortalConn;
        private System.Windows.Forms.Button btnPortalSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTerminal;
        private System.Windows.Forms.Button btnSaveButton;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
    }
}

