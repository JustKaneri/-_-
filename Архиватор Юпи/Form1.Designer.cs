namespace Архиватор_Юпи
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fPack = new System.Windows.Forms.ToolStripMenuItem();
            this.fUnPack = new System.Windows.Forms.ToolStripMenuItem();
            this.fDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.fExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mPropertis = new System.Windows.Forms.ToolStripMenuItem();
            this.pAddExet = new System.Windows.Forms.ToolStripMenuItem();
            this.pAddKonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.hHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.hInform = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPack = new System.Windows.Forms.ToolStripButton();
            this.tsUnPack = new System.Windows.Forms.ToolStripButton();
            this.tsDelet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmPack = new System.Windows.Forms.ToolStripMenuItem();
            this.CmUnpack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.CmDel = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mPropertis,
            this.mHelper});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mFile
            // 
            this.mFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fPack,
            this.fUnPack,
            this.fDel,
            this.toolStripMenuItem1,
            this.fExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(60, 24);
            this.mFile.Text = "Файл";
            // 
            // fPack
            // 
            this.fPack.Image = ((System.Drawing.Image)(resources.GetObject("fPack.Image")));
            this.fPack.Name = "fPack";
            this.fPack.Size = new System.Drawing.Size(159, 26);
            this.fPack.Text = "Упаковать";
            this.fPack.Click += new System.EventHandler(this.fPack_Click);
            // 
            // fUnPack
            // 
            this.fUnPack.Image = ((System.Drawing.Image)(resources.GetObject("fUnPack.Image")));
            this.fUnPack.Name = "fUnPack";
            this.fUnPack.Size = new System.Drawing.Size(159, 26);
            this.fUnPack.Text = "Извлечь";
            this.fUnPack.Click += new System.EventHandler(this.fUnPack_Click);
            // 
            // fDel
            // 
            this.fDel.Image = ((System.Drawing.Image)(resources.GetObject("fDel.Image")));
            this.fDel.Name = "fDel";
            this.fDel.Size = new System.Drawing.Size(159, 26);
            this.fDel.Text = "Удалить";
            this.fDel.Click += new System.EventHandler(this.fDel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 6);
            // 
            // fExit
            // 
            this.fExit.Image = ((System.Drawing.Image)(resources.GetObject("fExit.Image")));
            this.fExit.Name = "fExit";
            this.fExit.Size = new System.Drawing.Size(159, 26);
            this.fExit.Text = "Выход";
            this.fExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // mPropertis
            // 
            this.mPropertis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mPropertis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pAddExet,
            this.pAddKonMenu});
            this.mPropertis.Name = "mPropertis";
            this.mPropertis.Size = new System.Drawing.Size(105, 24);
            this.mPropertis.Text = "Параметры";
            this.mPropertis.DropDownOpened += new System.EventHandler(this.mPropertis_DropDownOpened);
            // 
            // pAddExet
            // 
            this.pAddExet.CheckOnClick = true;
            this.pAddExet.Name = "pAddExet";
            this.pAddExet.Size = new System.Drawing.Size(437, 26);
            this.pAddExet.Text = "Ассоциировать разрешение .upi с приложением";
            this.pAddExet.CheckedChanged += new System.EventHandler(this.pAddExet_CheckedChanged);
            // 
            // pAddKonMenu
            // 
            this.pAddKonMenu.CheckOnClick = true;
            this.pAddKonMenu.Name = "pAddKonMenu";
            this.pAddKonMenu.Size = new System.Drawing.Size(437, 26);
            this.pAddKonMenu.Text = "Добавить в контекстное меню";
            this.pAddKonMenu.CheckedChanged += new System.EventHandler(this.pAddKonMenu_CheckedChanged);
            // 
            // mHelper
            // 
            this.mHelper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mHelper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hHelp,
            this.hInform});
            this.mHelper.Name = "mHelper";
            this.mHelper.Size = new System.Drawing.Size(81, 24);
            this.mHelper.Text = "Справка";
            // 
            // hHelp
            // 
            this.hHelp.Name = "hHelp";
            this.hHelp.Size = new System.Drawing.Size(181, 26);
            this.hHelp.Text = "Помощь";
            // 
            // hInform
            // 
            this.hInform.Name = "hInform";
            this.hInform.Size = new System.Drawing.Size(181, 26);
            this.hInform.Text = "О программе";
            this.hInform.Click += new System.EventHandler(this.hInform_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPack,
            this.tsUnPack,
            this.tsDelet,
            this.toolStripSeparator2,
            this.toolStripSeparator1,
            this.tsExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 47);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsPack
            // 
            this.tsPack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPack.Image = ((System.Drawing.Image)(resources.GetObject("tsPack.Image")));
            this.tsPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPack.Name = "tsPack";
            this.tsPack.Size = new System.Drawing.Size(44, 44);
            this.tsPack.Text = "toolStripButton1";
            this.tsPack.ToolTipText = "упаковать файл в архив.";
            this.tsPack.Click += new System.EventHandler(this.fPack_Click);
            // 
            // tsUnPack
            // 
            this.tsUnPack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUnPack.Image = ((System.Drawing.Image)(resources.GetObject("tsUnPack.Image")));
            this.tsUnPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnPack.Name = "tsUnPack";
            this.tsUnPack.Size = new System.Drawing.Size(44, 44);
            this.tsUnPack.Text = "toolStripButton2";
            this.tsUnPack.ToolTipText = "Извлечь файл из архива.";
            this.tsUnPack.Click += new System.EventHandler(this.fUnPack_Click);
            // 
            // tsDelet
            // 
            this.tsDelet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelet.Image = ((System.Drawing.Image)(resources.GetObject("tsDelet.Image")));
            this.tsDelet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelet.Name = "tsDelet";
            this.tsDelet.Size = new System.Drawing.Size(44, 44);
            this.tsDelet.Text = "toolStripButton3";
            this.tsDelet.ToolTipText = "Удалить файл";
            this.tsDelet.Click += new System.EventHandler(this.fDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // tsExit
            // 
            this.tsExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(44, 44);
            this.tsExit.Text = "toolStripButton4";
            this.tsExit.ToolTipText = "Выход";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 75);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(971, 522);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(270, 518);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DC.ico");
            this.imageList1.Images.SetKeyName(1, "DW.ico");
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(689, 518);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Размер";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата и время";
            this.columnHeader3.Width = 250;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmPack,
            this.CmUnpack,
            this.toolStripMenuItem2,
            this.CmDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 88);
            // 
            // CmPack
            // 
            this.CmPack.Image = ((System.Drawing.Image)(resources.GetObject("CmPack.Image")));
            this.CmPack.Name = "CmPack";
            this.CmPack.Size = new System.Drawing.Size(157, 26);
            this.CmPack.Text = "Упаковать";
            this.CmPack.Click += new System.EventHandler(this.fPack_Click);
            // 
            // CmUnpack
            // 
            this.CmUnpack.Image = ((System.Drawing.Image)(resources.GetObject("CmUnpack.Image")));
            this.CmUnpack.Name = "CmUnpack";
            this.CmUnpack.Size = new System.Drawing.Size(157, 26);
            this.CmUnpack.Text = "Извлечь";
            this.CmUnpack.Click += new System.EventHandler(this.fUnPack_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 6);
            // 
            // CmDel
            // 
            this.CmDel.Image = ((System.Drawing.Image)(resources.GetObject("CmDel.Image")));
            this.CmDel.Name = "CmDel";
            this.CmDel.Size = new System.Drawing.Size(157, 26);
            this.CmDel.Text = "Удалить";
            this.CmDel.Click += new System.EventHandler(this.fDel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 597);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(797, 515);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Архиватор Юпи";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem fPack;
        private System.Windows.Forms.ToolStripMenuItem fUnPack;
        private System.Windows.Forms.ToolStripMenuItem fDel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fExit;
        private System.Windows.Forms.ToolStripMenuItem mPropertis;
        private System.Windows.Forms.ToolStripMenuItem pAddExet;
        private System.Windows.Forms.ToolStripMenuItem pAddKonMenu;
        private System.Windows.Forms.ToolStripMenuItem mHelper;
        private System.Windows.Forms.ToolStripMenuItem hHelp;
        private System.Windows.Forms.ToolStripMenuItem hInform;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsPack;
        private System.Windows.Forms.ToolStripButton tsUnPack;
        private System.Windows.Forms.ToolStripButton tsDelet;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CmPack;
        private System.Windows.Forms.ToolStripMenuItem CmUnpack;
        private System.Windows.Forms.ToolStripMenuItem CmDel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.StatusStrip statusStrip1;
    }
}

