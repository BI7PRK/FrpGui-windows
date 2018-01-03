namespace FrpGui_windows
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.del = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.itemType = new System.Windows.Forms.ComboBox();
            this.configItems = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.testConsole = new System.Windows.Forms.TextBox();
            this.killAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.runfrps = new System.Windows.Forms.Button();
            this.loadfrps = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.runfrpc = new System.Windows.Forms.Button();
            this.loadfrpc = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.stopBtm = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.unstalBtm = new System.Windows.Forms.Button();
            this.instalBtm = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertyGrid1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(362, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户端";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.Location = new System.Drawing.Point(166, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(193, 325);
            this.propertyGrid1.TabIndex = 1;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.del);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Controls.Add(this.itemType);
            this.groupBox1.Controls.Add(this.configItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置项";
            // 
            // del
            // 
            this.del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.del.Enabled = false;
            this.del.Location = new System.Drawing.Point(113, 297);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(39, 23);
            this.del.TabIndex = 3;
            this.del.Text = "删除";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.Location = new System.Drawing.Point(68, 297);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(39, 23);
            this.add.TabIndex = 2;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // itemType
            // 
            this.itemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemType.FormattingEnabled = true;
            this.itemType.Location = new System.Drawing.Point(6, 299);
            this.itemType.Name = "itemType";
            this.itemType.Size = new System.Drawing.Size(56, 20);
            this.itemType.TabIndex = 1;
            // 
            // configItems
            // 
            this.configItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.configItems.HideSelection = false;
            this.configItems.Location = new System.Drawing.Point(3, 17);
            this.configItems.Name = "configItems";
            this.configItems.Size = new System.Drawing.Size(151, 274);
            this.configItems.TabIndex = 0;
            this.configItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.configItems_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGrid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(362, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "服务端";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(356, 325);
            this.propertyGrid2.TabIndex = 2;
            this.propertyGrid2.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid2_PropertyValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.testConsole);
            this.tabPage3.Controls.Add(this.killAll);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(362, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "测试 ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // testConsole
            // 
            this.testConsole.BackColor = System.Drawing.Color.Black;
            this.testConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.testConsole.Location = new System.Drawing.Point(8, 57);
            this.testConsole.Multiline = true;
            this.testConsole.Name = "testConsole";
            this.testConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.testConsole.Size = new System.Drawing.Size(351, 268);
            this.testConsole.TabIndex = 5;
            // 
            // killAll
            // 
            this.killAll.Location = new System.Drawing.Point(304, 22);
            this.killAll.Name = "killAll";
            this.killAll.Size = new System.Drawing.Size(51, 23);
            this.killAll.TabIndex = 4;
            this.killAll.Text = "Kill";
            this.killAll.UseVisualStyleBackColor = true;
            this.killAll.Click += new System.EventHandler(this.killAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.runfrps);
            this.groupBox3.Controls.Add(this.loadfrps);
            this.groupBox3.Location = new System.Drawing.Point(156, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(142, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "frps";
            // 
            // runfrps
            // 
            this.runfrps.Location = new System.Drawing.Point(15, 16);
            this.runfrps.Name = "runfrps";
            this.runfrps.Size = new System.Drawing.Size(51, 23);
            this.runfrps.TabIndex = 0;
            this.runfrps.Text = "启动frpc";
            this.runfrps.UseVisualStyleBackColor = true;
            this.runfrps.Click += new System.EventHandler(this.runfrps_Click);
            // 
            // loadfrps
            // 
            this.loadfrps.Location = new System.Drawing.Point(72, 16);
            this.loadfrps.Name = "loadfrps";
            this.loadfrps.Size = new System.Drawing.Size(51, 23);
            this.loadfrps.TabIndex = 1;
            this.loadfrps.Text = "重载";
            this.loadfrps.UseVisualStyleBackColor = true;
            this.loadfrps.Click += new System.EventHandler(this.loadfrps_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.runfrpc);
            this.groupBox2.Controls.Add(this.loadfrpc);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "frpc";
            // 
            // runfrpc
            // 
            this.runfrpc.Location = new System.Drawing.Point(15, 16);
            this.runfrpc.Name = "runfrpc";
            this.runfrpc.Size = new System.Drawing.Size(51, 23);
            this.runfrpc.TabIndex = 0;
            this.runfrpc.Text = "启动frpc";
            this.runfrpc.UseVisualStyleBackColor = true;
            this.runfrpc.Click += new System.EventHandler(this.runfrpc_Click);
            // 
            // loadfrpc
            // 
            this.loadfrpc.Location = new System.Drawing.Point(72, 16);
            this.loadfrpc.Name = "loadfrpc";
            this.loadfrpc.Size = new System.Drawing.Size(51, 23);
            this.loadfrpc.TabIndex = 1;
            this.loadfrpc.Text = "重载";
            this.loadfrpc.UseVisualStyleBackColor = true;
            this.loadfrpc.Click += new System.EventHandler(this.loadfrpc_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.stopBtm);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.unstalBtm);
            this.tabPage4.Controls.Add(this.instalBtm);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(362, 331);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "服务";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 273);
            this.textBox1.TabIndex = 0;
            // 
            // stopBtm
            // 
            this.stopBtm.Location = new System.Drawing.Point(139, 9);
            this.stopBtm.Name = "stopBtm";
            this.stopBtm.Size = new System.Drawing.Size(45, 23);
            this.stopBtm.TabIndex = 18;
            this.stopBtm.Text = "运行";
            this.stopBtm.UseVisualStyleBackColor = true;
            this.stopBtm.Click += new System.EventHandler(this.Start_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(73, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 12);
            this.linkLabel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "服务状态:";
            // 
            // unstalBtm
            // 
            this.unstalBtm.Location = new System.Drawing.Point(309, 9);
            this.unstalBtm.Name = "unstalBtm";
            this.unstalBtm.Size = new System.Drawing.Size(45, 23);
            this.unstalBtm.TabIndex = 15;
            this.unstalBtm.Text = "卸载";
            this.unstalBtm.UseVisualStyleBackColor = true;
            this.unstalBtm.Click += new System.EventHandler(this.unstalBtm_Click);
            // 
            // instalBtm
            // 
            this.instalBtm.Enabled = false;
            this.instalBtm.Location = new System.Drawing.Point(258, 9);
            this.instalBtm.Name = "instalBtm";
            this.instalBtm.Size = new System.Drawing.Size(45, 23);
            this.instalBtm.TabIndex = 14;
            this.instalBtm.Text = "安装";
            this.instalBtm.UseVisualStyleBackColor = true;
            this.instalBtm.Click += new System.EventHandler(this.instalBtm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 357);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frp配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView configItems;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.ComboBox itemType;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button loadfrpc;
        private System.Windows.Forms.Button runfrpc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button runfrps;
        private System.Windows.Forms.Button loadfrps;
        private System.Windows.Forms.Button killAll;
        private System.Windows.Forms.TextBox testConsole;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button stopBtm;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button unstalBtm;
        private System.Windows.Forms.Button instalBtm;
    }
}

