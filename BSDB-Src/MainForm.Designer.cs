namespace Mercenary
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadfromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptBSDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptBSDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nifEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fUnCompressedSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fAttributes = new System.Windows.Forms.Label();
            this.fLastWrite = new System.Windows.Forms.Label();
            this.fCompressionType = new System.Windows.Forms.Label();
            this.fCompressionSize = new System.Windows.Forms.Label();
            this.fSize = new System.Windows.Forms.Label();
            this.fPath = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ZipTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.pathToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadfromToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.encryptBSDBToolStripMenuItem,
            this.decryptBSDBToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Enabled = false;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadfromToolStripMenuItem
            // 
            this.loadfromToolStripMenuItem.Image = global::Mercenary.Properties.Resources.load;
            this.loadfromToolStripMenuItem.Name = "loadfromToolStripMenuItem";
            this.loadfromToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.loadfromToolStripMenuItem.Text = "Load From";
            this.loadfromToolStripMenuItem.Click += new System.EventHandler(this.loadfromToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // encryptBSDBToolStripMenuItem
            // 
            this.encryptBSDBToolStripMenuItem.Image = global::Mercenary.Properties.Resources.encrypt;
            this.encryptBSDBToolStripMenuItem.Name = "encryptBSDBToolStripMenuItem";
            this.encryptBSDBToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.encryptBSDBToolStripMenuItem.Text = "Encrypt BSDB";
            this.encryptBSDBToolStripMenuItem.Click += new System.EventHandler(this.encryptBSDBToolStripMenuItem_Click);
            // 
            // decryptBSDBToolStripMenuItem
            // 
            this.decryptBSDBToolStripMenuItem.Image = global::Mercenary.Properties.Resources.decrypt;
            this.decryptBSDBToolStripMenuItem.Name = "decryptBSDBToolStripMenuItem";
            this.decryptBSDBToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.decryptBSDBToolStripMenuItem.Text = "Decrypt BSDB";
            this.decryptBSDBToolStripMenuItem.Click += new System.EventHandler(this.decryptBSDBToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponEditorToolStripMenuItem,
            this.nifEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 26);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // weaponEditorToolStripMenuItem
            // 
            this.weaponEditorToolStripMenuItem.Enabled = false;
            this.weaponEditorToolStripMenuItem.Image = global::Mercenary.Properties.Resources.weaponEditor;
            this.weaponEditorToolStripMenuItem.Name = "weaponEditorToolStripMenuItem";
            this.weaponEditorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.weaponEditorToolStripMenuItem.Text = "Weapon Editor";
            this.weaponEditorToolStripMenuItem.Click += new System.EventHandler(this.weaponEditorToolStripMenuItem_Click);
            // 
            // nifEditorToolStripMenuItem
            // 
            this.nifEditorToolStripMenuItem.Enabled = false;
            this.nifEditorToolStripMenuItem.Image = global::Mercenary.Properties.Resources.nifEditor;
            this.nifEditorToolStripMenuItem.Name = "nifEditorToolStripMenuItem";
            this.nifEditorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nifEditorToolStripMenuItem.Text = "Wallhack Packs";
            this.nifEditorToolStripMenuItem.Click += new System.EventHandler(this.nifEditorToolStripMenuItem_Click);
            // 
            // pathToolStripMenuItem
            // 
            this.pathToolStripMenuItem.Name = "pathToolStripMenuItem";
            this.pathToolStripMenuItem.Size = new System.Drawing.Size(51, 26);
            this.pathToolStripMenuItem.Text = "Path";
            this.pathToolStripMenuItem.Click += new System.EventHandler(this.pathToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.fAQToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Image = global::Mercenary.Properties.Resources.about;
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.fAQToolStripMenuItem.Text = "FAQ";
            this.fAQToolStripMenuItem.Click += new System.EventHandler(this.fAQToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1046, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(34, 20);
            this.statusLabel.Text = "Idle";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 76);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.extractToolStripMenuItem.Text = "Extract";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fUnCompressedSize);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.fAttributes);
            this.panel1.Controls.Add(this.fLastWrite);
            this.panel1.Controls.Add(this.fCompressionType);
            this.panel1.Controls.Add(this.fCompressionSize);
            this.panel1.Controls.Add(this.fSize);
            this.panel1.Controls.Add(this.fPath);
            this.panel1.Controls.Add(this.fName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ZipTreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 377);
            this.panel1.TabIndex = 20;
            // 
            // fUnCompressedSize
            // 
            this.fUnCompressedSize.AutoSize = true;
            this.fUnCompressedSize.Location = new System.Drawing.Point(685, 195);
            this.fUnCompressedSize.Name = "fUnCompressedSize";
            this.fUnCompressedSize.Size = new System.Drawing.Size(30, 16);
            this.fUnCompressedSize.TabIndex = 36;
            this.fUnCompressedSize.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(504, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "UnCompressed Size : ";
            // 
            // fAttributes
            // 
            this.fAttributes.AutoSize = true;
            this.fAttributes.Location = new System.Drawing.Point(685, 340);
            this.fAttributes.Name = "fAttributes";
            this.fAttributes.Size = new System.Drawing.Size(30, 16);
            this.fAttributes.TabIndex = 34;
            this.fAttributes.Text = "N/A";
            // 
            // fLastWrite
            // 
            this.fLastWrite.AutoSize = true;
            this.fLastWrite.Location = new System.Drawing.Point(685, 289);
            this.fLastWrite.Name = "fLastWrite";
            this.fLastWrite.Size = new System.Drawing.Size(30, 16);
            this.fLastWrite.TabIndex = 33;
            this.fLastWrite.Text = "N/A";
            // 
            // fCompressionType
            // 
            this.fCompressionType.AutoSize = true;
            this.fCompressionType.Location = new System.Drawing.Point(685, 240);
            this.fCompressionType.Name = "fCompressionType";
            this.fCompressionType.Size = new System.Drawing.Size(30, 16);
            this.fCompressionType.TabIndex = 32;
            this.fCompressionType.Text = "N/A";
            // 
            // fCompressionSize
            // 
            this.fCompressionSize.AutoSize = true;
            this.fCompressionSize.Location = new System.Drawing.Point(685, 148);
            this.fCompressionSize.Name = "fCompressionSize";
            this.fCompressionSize.Size = new System.Drawing.Size(30, 16);
            this.fCompressionSize.TabIndex = 31;
            this.fCompressionSize.Text = "N/A";
            // 
            // fSize
            // 
            this.fSize.AutoSize = true;
            this.fSize.Location = new System.Drawing.Point(685, 102);
            this.fSize.Name = "fSize";
            this.fSize.Size = new System.Drawing.Size(30, 16);
            this.fSize.TabIndex = 30;
            this.fSize.Text = "N/A";
            // 
            // fPath
            // 
            this.fPath.AutoSize = true;
            this.fPath.Location = new System.Drawing.Point(685, 52);
            this.fPath.Name = "fPath";
            this.fPath.Size = new System.Drawing.Size(30, 16);
            this.fPath.TabIndex = 29;
            this.fPath.Text = "N/A";
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.Location = new System.Drawing.Point(685, 8);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(30, 16);
            this.fName.TabIndex = 28;
            this.fName.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Full Path : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Attributes :   ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Compression Type :  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Last Write Time : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Compressed Size : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Size : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "FileName :";
            // 
            // ZipTreeView
            // 
            this.ZipTreeView.Location = new System.Drawing.Point(0, 3);
            this.ZipTreeView.Name = "ZipTreeView";
            this.ZipTreeView.Size = new System.Drawing.Size(489, 373);
            this.ZipTreeView.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 433);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BSDB V3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadfromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptBSDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptBSDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nifEditorToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fUnCompressedSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label fAttributes;
        private System.Windows.Forms.Label fLastWrite;
        private System.Windows.Forms.Label fCompressionType;
        private System.Windows.Forms.Label fCompressionSize;
        private System.Windows.Forms.Label fSize;
        private System.Windows.Forms.Label fPath;
        private System.Windows.Forms.Label fName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView ZipTreeView;
    }
}

