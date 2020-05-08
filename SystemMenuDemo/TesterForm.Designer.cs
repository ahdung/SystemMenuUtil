namespace SystemMenuDemo
{
    partial class TesterForm
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
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNewDropDownText = new System.Windows.Forms.TextBox();
            this.txbNewItemText = new System.Windows.Forms.TextBox();
            this.btnAddDropDown = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnAddSeparator = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbStandardItem = new System.Windows.Forms.ComboBox();
            this.nudItem = new System.Windows.Forms.NumericUpDown();
            this.rbByStandardItem = new System.Windows.Forms.RadioButton();
            this.rbByInput = new System.Windows.Forms.RadioButton();
            this.ckbByPosition = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSetItemEnabled = new System.Windows.Forms.Button();
            this.btnSetItemChecked = new System.Windows.Forms.Button();
            this.btnSetItemText = new System.Windows.Forms.Button();
            this.txbChangeItemText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGetSystemMenuHandle = new System.Windows.Forms.Button();
            this.btnGetMenuItemCount = new System.Windows.Forms.Button();
            this.btnGetItemInfos = new System.Windows.Forms.Button();
            this.btnGetItemInfo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "子菜单项1";
            this.menuItem1.Click += new System.EventHandler(this.subMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "子菜单项2";
            this.menuItem2.Click += new System.EventHandler(this.subMenuItem_Click);
            // 
            // txbOutput
            // 
            this.txbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOutput.Location = new System.Drawing.Point(12, 306);
            this.txbOutput.Multiline = true;
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbOutput.Size = new System.Drawing.Size(889, 330);
            this.txbOutput.TabIndex = 2;
            this.txbOutput.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输出：";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(6, 56);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(207, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbNewDropDownText);
            this.groupBox1.Controls.Add(this.txbNewItemText);
            this.groupBox1.Controls.Add(this.btnAddDropDown);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.btnAddSeparator);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加";
            // 
            // txbNewDropDownText
            // 
            this.txbNewDropDownText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNewDropDownText.Location = new System.Drawing.Point(6, 58);
            this.txbNewDropDownText.Name = "txbNewDropDownText";
            this.txbNewDropDownText.Size = new System.Drawing.Size(104, 21);
            this.txbNewDropDownText.TabIndex = 2;
            this.txbNewDropDownText.Text = "展开项";
            // 
            // txbNewItemText
            // 
            this.txbNewItemText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNewItemText.Location = new System.Drawing.Point(6, 29);
            this.txbNewItemText.Name = "txbNewItemText";
            this.txbNewItemText.Size = new System.Drawing.Size(104, 21);
            this.txbNewItemText.TabIndex = 0;
            this.txbNewItemText.Text = "普通项";
            // 
            // btnAddDropDown
            // 
            this.btnAddDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDropDown.Location = new System.Drawing.Point(116, 56);
            this.btnAddDropDown.Name = "btnAddDropDown";
            this.btnAddDropDown.Size = new System.Drawing.Size(95, 23);
            this.btnAddDropDown.TabIndex = 3;
            this.btnAddDropDown.Text = "AddDropDown";
            this.btnAddDropDown.UseVisualStyleBackColor = true;
            this.btnAddDropDown.Click += new System.EventHandler(this.btnAddDropDown_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(116, 27);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(95, 23);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "AddItem";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnAddSeparator
            // 
            this.btnAddSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSeparator.Location = new System.Drawing.Point(6, 85);
            this.btnAddSeparator.Name = "btnAddSeparator";
            this.btnAddSeparator.Size = new System.Drawing.Size(205, 23);
            this.btnAddSeparator.TabIndex = 4;
            this.btnAddSeparator.Text = "AddSeparator";
            this.btnAddSeparator.UseVisualStyleBackColor = true;
            this.btnAddSeparator.Click += new System.EventHandler(this.btnAddSeparator_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbStandardItem);
            this.groupBox2.Controls.Add(this.nudItem);
            this.groupBox2.Controls.Add(this.rbByStandardItem);
            this.groupBox2.Controls.Add(this.rbByInput);
            this.groupBox2.Controls.Add(this.ckbByPosition);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 91);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标项（下面的增删改查都是基于这个项来进行）";
            // 
            // cmbStandardItem
            // 
            this.cmbStandardItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStandardItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStandardItem.Enabled = false;
            this.cmbStandardItem.FormattingEnabled = true;
            this.cmbStandardItem.Location = new System.Drawing.Point(129, 55);
            this.cmbStandardItem.Name = "cmbStandardItem";
            this.cmbStandardItem.Size = new System.Drawing.Size(120, 20);
            this.cmbStandardItem.Sorted = true;
            this.cmbStandardItem.TabIndex = 4;
            // 
            // nudItem
            // 
            this.nudItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudItem.Location = new System.Drawing.Point(129, 25);
            this.nudItem.Name = "nudItem";
            this.nudItem.Size = new System.Drawing.Size(120, 21);
            this.nudItem.TabIndex = 1;
            // 
            // rbByStandardItem
            // 
            this.rbByStandardItem.AutoSize = true;
            this.rbByStandardItem.Location = new System.Drawing.Point(11, 56);
            this.rbByStandardItem.Name = "rbByStandardItem";
            this.rbByStandardItem.Size = new System.Drawing.Size(83, 16);
            this.rbByStandardItem.TabIndex = 3;
            this.rbByStandardItem.Text = "根据标准项";
            this.rbByStandardItem.UseVisualStyleBackColor = true;
            this.rbByStandardItem.CheckedChanged += new System.EventHandler(this.rbBy_CheckedChanged);
            // 
            // rbByInput
            // 
            this.rbByInput.AutoSize = true;
            this.rbByInput.Checked = true;
            this.rbByInput.Location = new System.Drawing.Point(11, 28);
            this.rbByInput.Name = "rbByInput";
            this.rbByInput.Size = new System.Drawing.Size(95, 16);
            this.rbByInput.TabIndex = 0;
            this.rbByInput.TabStop = true;
            this.rbByInput.Text = "根据位置或ID";
            this.rbByInput.UseVisualStyleBackColor = true;
            this.rbByInput.CheckedChanged += new System.EventHandler(this.rbBy_CheckedChanged);
            // 
            // ckbByPosition
            // 
            this.ckbByPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbByPosition.AutoSize = true;
            this.ckbByPosition.Checked = true;
            this.ckbByPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbByPosition.Location = new System.Drawing.Point(262, 29);
            this.ckbByPosition.Name = "ckbByPosition";
            this.ckbByPosition.Size = new System.Drawing.Size(294, 16);
            this.ckbByPosition.TabIndex = 2;
            this.ckbByPosition.Text = "byPosition （打勾表示是位置，不打勾表示是ID）";
            this.ckbByPosition.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSetItemEnabled);
            this.groupBox3.Controls.Add(this.btnSetItemChecked);
            this.groupBox3.Controls.Add(this.btnSetItemText);
            this.groupBox3.Controls.Add(this.txbChangeItemText);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(226, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 151);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "修改";
            // 
            // btnSetItemEnabled
            // 
            this.btnSetItemEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetItemEnabled.Location = new System.Drawing.Point(6, 85);
            this.btnSetItemEnabled.Name = "btnSetItemEnabled";
            this.btnSetItemEnabled.Size = new System.Drawing.Size(205, 23);
            this.btnSetItemEnabled.TabIndex = 3;
            this.btnSetItemEnabled.Text = "SetItemEnabled";
            this.btnSetItemEnabled.UseVisualStyleBackColor = true;
            this.btnSetItemEnabled.Click += new System.EventHandler(this.btnSetItemEnabled_Click);
            // 
            // btnSetItemChecked
            // 
            this.btnSetItemChecked.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetItemChecked.Location = new System.Drawing.Point(6, 56);
            this.btnSetItemChecked.Name = "btnSetItemChecked";
            this.btnSetItemChecked.Size = new System.Drawing.Size(205, 23);
            this.btnSetItemChecked.TabIndex = 2;
            this.btnSetItemChecked.Text = "SetItemChecked";
            this.btnSetItemChecked.UseVisualStyleBackColor = true;
            this.btnSetItemChecked.Click += new System.EventHandler(this.btnSetItemChecked_Click);
            // 
            // btnSetItemText
            // 
            this.btnSetItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetItemText.Location = new System.Drawing.Point(110, 27);
            this.btnSetItemText.Name = "btnSetItemText";
            this.btnSetItemText.Size = new System.Drawing.Size(101, 23);
            this.btnSetItemText.TabIndex = 1;
            this.btnSetItemText.Text = "SetItemText";
            this.btnSetItemText.UseVisualStyleBackColor = true;
            this.btnSetItemText.Click += new System.EventHandler(this.btnSetItemText_Click);
            // 
            // txbChangeItemText
            // 
            this.txbChangeItemText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbChangeItemText.Location = new System.Drawing.Point(6, 29);
            this.txbChangeItemText.Name = "txbChangeItemText";
            this.txbChangeItemText.Size = new System.Drawing.Size(98, 21);
            this.txbChangeItemText.TabIndex = 0;
            this.txbChangeItemText.Text = "新文本";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemoveItem);
            this.groupBox4.Controls.Add(this.btnReset);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(449, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 151);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "删除";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItem.Location = new System.Drawing.Point(6, 27);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(205, 23);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "RemoveItem";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnGetSystemMenuHandle);
            this.groupBox5.Controls.Add(this.btnGetMenuItemCount);
            this.groupBox5.Controls.Add(this.btnGetItemInfos);
            this.groupBox5.Controls.Add(this.btnGetItemInfo);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(672, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(220, 151);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "获取";
            // 
            // btnGetSystemMenuHandle
            // 
            this.btnGetSystemMenuHandle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSystemMenuHandle.Location = new System.Drawing.Point(6, 114);
            this.btnGetSystemMenuHandle.Name = "btnGetSystemMenuHandle";
            this.btnGetSystemMenuHandle.Size = new System.Drawing.Size(208, 23);
            this.btnGetSystemMenuHandle.TabIndex = 3;
            this.btnGetSystemMenuHandle.Text = "GetSystemMenuHandle";
            this.btnGetSystemMenuHandle.UseVisualStyleBackColor = true;
            this.btnGetSystemMenuHandle.Click += new System.EventHandler(this.btnGetSystemMenuHandle_Click);
            // 
            // btnGetMenuItemCount
            // 
            this.btnGetMenuItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetMenuItemCount.Location = new System.Drawing.Point(6, 85);
            this.btnGetMenuItemCount.Name = "btnGetMenuItemCount";
            this.btnGetMenuItemCount.Size = new System.Drawing.Size(208, 23);
            this.btnGetMenuItemCount.TabIndex = 2;
            this.btnGetMenuItemCount.Text = "GetMenuItemCount";
            this.btnGetMenuItemCount.UseVisualStyleBackColor = true;
            this.btnGetMenuItemCount.Click += new System.EventHandler(this.btnGetMenuItemCount_Click);
            // 
            // btnGetItemInfos
            // 
            this.btnGetItemInfos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetItemInfos.Location = new System.Drawing.Point(6, 56);
            this.btnGetItemInfos.Name = "btnGetItemInfos";
            this.btnGetItemInfos.Size = new System.Drawing.Size(208, 23);
            this.btnGetItemInfos.TabIndex = 1;
            this.btnGetItemInfos.Text = "GetItemInfos";
            this.btnGetItemInfos.UseVisualStyleBackColor = true;
            this.btnGetItemInfos.Click += new System.EventHandler(this.btnGetItemInfos_Click);
            // 
            // btnGetItemInfo
            // 
            this.btnGetItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetItemInfo.Location = new System.Drawing.Point(6, 27);
            this.btnGetItemInfo.Name = "btnGetItemInfo";
            this.btnGetItemInfo.Size = new System.Drawing.Size(208, 23);
            this.btnGetItemInfo.TabIndex = 0;
            this.btnGetItemInfo.Text = "GetItemInfo";
            this.btnGetItemInfo.UseVisualStyleBackColor = true;
            this.btnGetItemInfo.Click += new System.EventHandler(this.btnGetItemInfo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 116);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 157);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // linkClear
            // 
            this.linkClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkClear.AutoSize = true;
            this.linkClear.Location = new System.Drawing.Point(872, 291);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(29, 12);
            this.linkClear.TabIndex = 3;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "清空";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            // 
            // TesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 662);
            this.Controls.Add(this.linkClear);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbOutput);
            this.DoubleBuffered = true;
            this.Name = "TesterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester (在这里点右键看效果)";
            this.Load += new System.EventHandler(this.TesterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbByPosition;
        private System.Windows.Forms.TextBox txbNewItemText;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSetItemText;
        private System.Windows.Forms.TextBox txbChangeItemText;
        private System.Windows.Forms.Button btnSetItemEnabled;
        private System.Windows.Forms.Button btnSetItemChecked;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.ComboBox cmbStandardItem;
        private System.Windows.Forms.NumericUpDown nudItem;
        private System.Windows.Forms.RadioButton rbByStandardItem;
        private System.Windows.Forms.RadioButton rbByInput;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnGetItemInfo;
        private System.Windows.Forms.TextBox txbNewDropDownText;
        private System.Windows.Forms.Button btnAddDropDown;
        private System.Windows.Forms.Button btnAddSeparator;
        private System.Windows.Forms.Button btnGetItemInfos;
        private System.Windows.Forms.Button btnGetMenuItemCount;
        private System.Windows.Forms.Button btnGetSystemMenuHandle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkClear;
    }
}

