using AhDung.WinForm;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace SystemMenuDemo
{
    public partial class TesterForm : Form
    {
        IntPtr HMenu => SystemMenuUtil.GetSystemMenuHandle(this);

        public TesterForm()
        {
            InitializeComponent();
        }

        private void TesterForm_Load(object sender, EventArgs e)
        {
            nudItem.Maximum = int.MaxValue;
            nudItem.Minimum = int.MinValue;
            nudItem.Value = -1;

            cmbStandardItem.Items.AddRange(Enum.GetNames(typeof(SystemMenuStandardItem)));
            cmbStandardItem.SelectedIndex = 0;
        }

        private void rbBy_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && !rb.Checked)
            {
                return;
            }

            nudItem.Enabled = rbByInput.Checked;
            ckbByPosition.Enabled = rbByInput.Checked;

            cmbStandardItem.Enabled = rbByStandardItem.Checked;
        }

        //建议在该方法内添加菜单项。用HandleCreated事件也行
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            //取得窗体菜单句柄
            var hMenu = SystemMenuUtil.GetSystemMenuHandle(this);

            //添加分隔条
            SystemMenuUtil.AddSeparator(hMenu);

            //添加普通项
            SystemMenuUtil.AddItem(hMenu, "普通项", item_Clicked);

            //添加一个能展开子菜单的项在【关闭】之上
            SystemMenuUtil.AddDropDown(hMenu, "展开菜单", contextMenu1, SystemMenuStandardItem.Close);

            //再添加一个勾选项演示勾选状态的处理
            SystemMenuUtil.AddItem(hMenu, "窗口置顶", (_, ee) =>
            {
                //注意这里获取到的是项原本的勾选状态
                var isChecked = ee.Info.Checked;

                //所以原本是勾选的话，意味着要取消置顶，反之亦然
                TopMost = !isChecked;
                WriteMessage($"窗口已{(isChecked ? "取消" : "")}置顶");

                //最后切换勾选状态
                SystemMenuUtil.SetItemChecked(ee.Info.ParentMenuHandle, ee.Info.Id, false, !isChecked);
            });

            SystemMenuUtil.AddItem(hMenu, "作者主页", (_, __) => Process.Start("https://www.cnblogs.com/ahdung/p/SystemMenuUtil.html"));
        }

        //建议在该方法内重置菜单项。主要目的是释放无效项占用的资源，用HandleDestroyed事件也行
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            SystemMenuUtil.Reset(this);
        }

        void item_Clicked(object sender, SystemMenuItemEventArgs e)
        {
            WriteItemInfo(e.Info);
        }

        private void subMenuItem_Click(object sender, EventArgs e)
        {
            WriteMessage($"{(sender as MenuItem)?.Text ?? "sub menu item"} was clicked.");
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txbOutput.Clear();
        }

        static string FormatItemInfo(SystemMenuItemInfo info)
        {
            return $@"Id: {info.Id}
Text: {info.Text}
Type: {info.Type}
Checked: {info.Checked}
Enabled: {info.Enabled}
Shortcut: {TypeDescriptor.GetConverter(typeof(Keys)).ConvertToString((Keys)info.Shortcut)}
ParentMenuHandle: {info.ParentMenuHandle}
SubMenuHandle: {info.SubMenuHandle}";
        }

        void WriteItemInfo(SystemMenuItemInfo info)
        {
            WriteMessage(info == null ? "项不存在！" : FormatItemInfo(info));
        }

        public void WriteMessage(string message)
        {
            if (txbOutput.TextLength != 0)
            {
                txbOutput.AppendText($"--------------------------------------------{Environment.NewLine}");
            }

            txbOutput.AppendText($"{message}{Environment.NewLine}");
        }

        int DetermineItem(out bool byPosition)
        {
            if (rbByInput.Checked)
            {
                byPosition = ckbByPosition.Checked;
                return decimal.ToInt32(nudItem.Value);
            }

            byPosition = false;
            return (int)Enum.Parse(typeof(SystemMenuStandardItem), cmbStandardItem.SelectedItem.ToString());
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var id = SystemMenuUtil.AddItem(HMenu, txbNewItemText.Text, item_Clicked, null, DetermineItem(out var byPosition), byPosition);
            WriteMessage($"已添加普通项【{txbNewItemText.Text}】，ID: {id}");
        }

        private void btnAddDropDown_Click(object sender, EventArgs e)
        {
            var id = SystemMenuUtil.AddDropDown(HMenu, txbNewDropDownText.Text, contextMenu1, DetermineItem(out var byPosition), byPosition);
            WriteMessage($"已添加展开项【{txbNewDropDownText.Text}】，ID: {id}");
        }

        private void btnAddSeparator_Click(object sender, EventArgs e)
        {
            var id = SystemMenuUtil.AddSeparator(HMenu, DetermineItem(out var byPosition), byPosition);
            WriteMessage($"已添加分隔条，ID: {id}");
        }

        private void btnSetItemText_Click(object sender, EventArgs e)
        {
            SystemMenuUtil.SetItemText(HMenu, DetermineItem(out var byPosition), byPosition, txbChangeItemText.Text);
            WriteMessage($"项文本已修改为【{txbChangeItemText.Text}】");
        }

        private void btnSetItemChecked_Click(object sender, EventArgs e)
        {
            var item = DetermineItem(out var byPosition);

            var info = SystemMenuUtil.GetItemInfo(HMenu, item, byPosition);
            if (info == null)
            {
                WriteMessage("项不存在！");
                return;
            }

            SystemMenuUtil.SetItemChecked(HMenu, item, byPosition, !info.Checked);

            WriteMessage($"项已{(info.Checked ? "取消" : "")}勾选");
        }

        private void btnSetItemEnabled_Click(object sender, EventArgs e)
        {
            var item = DetermineItem(out var byPosition);

            var info = SystemMenuUtil.GetItemInfo(HMenu, item, byPosition);
            if (info == null)
            {
                WriteMessage("项不存在！");
                return;
            }

            SystemMenuUtil.SetItemEnabled(HMenu, item, byPosition, !info.Enabled);

            WriteMessage($"项已{(info.Enabled ? "禁用" : "启用")}");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            SystemMenuUtil.RemoveItem(HMenu, DetermineItem(out var byPosition), byPosition);
            WriteMessage("项已移除");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SystemMenuUtil.Reset(this);
            WriteMessage("窗体菜单已重置");
        }

        private void btnGetItemInfo_Click(object sender, EventArgs e)
        {
            var info = SystemMenuUtil.GetItemInfo(HMenu, DetermineItem(out var byPosition), byPosition);
            WriteItemInfo(info);
        }

        private void btnGetItemInfos_Click(object sender, EventArgs e)
        {
            var i = 0;
            foreach (var info in SystemMenuUtil.GetItemInfos(HMenu))
            {
                WriteMessage($"#{i++}{Environment.NewLine}{FormatItemInfo(info)}");
            }
        }

        private void btnGetMenuItemCount_Click(object sender, EventArgs e)
        {
            var count = SystemMenuUtil.GetMenuItemCount(HMenu);
            WriteMessage($"当前窗体菜单共有 {count} 项");
        }

        private void btnGetSystemMenuHandle_Click(object sender, EventArgs e)
        {
            WriteMessage($"当前窗体菜单句柄: {SystemMenuUtil.GetSystemMenuHandle(this)}");
        }

    }
}
