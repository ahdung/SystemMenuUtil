using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AhDung.WinForm
{
    /*
     * 窗体菜单又叫窗口菜单、系统菜单、标题菜单或控制菜单，就是在窗口标题栏右键出现的、包含还原/最小化/关闭等项的那个，
     * 这个菜单是可以添加自定义项的，本方案就是用来方便对该菜单进行改造，往里面添加/删除/修改自定义项。
     */

    //未实现：
    // - 快捷键
    // - 单选项
    // - 项图标

    /// <summary>
    /// 窗体菜单工具类
    /// <para>- 【建议】在窗体<see cref="Form.OnHandleCreated(EventArgs)"/>中添加菜单项，并在<see cref="Form.OnHandleDestroyed(EventArgs)"/>中调用<see cref="Reset(Form)"/>重置菜单项</para>
    /// <para>- 很多方法接受的hMenu参数是一个菜单句柄，表示要操作的是哪个窗体菜单，可通过<see cref="GetSystemMenuHandle(Form)"/>方法获得</para>
    /// <para>- 展开项的子菜单是一个<see cref="ContextMenu"/>，该组件可能默认不会在工具箱中列出（不是<see cref="ContextMenuStrip"/>），所以你需要先将它添加进工具箱</para>
    /// <para>- 子菜单的创建和销毁由你负责，本工具不会销毁它，无论是删除其父项还是重置整个窗体菜单</para>
    /// </summary>
    public static class SystemMenuUtil
    {
        //以菜单项ID为索引，存储自定义的菜单项。
        //因为菜单项占用ID资源，所以删除菜单项时需调用其Dispose，并从该容器中移除
        static Dictionary<int, SystemMenuItem> _customizedItems;
        static Dictionary<int, SystemMenuItem> CustomizedItems => _customizedItems ?? (_customizedItems = new Dictionary<int, SystemMenuItem>());

        const int ERROR_INVALID_WINDOW_HANDLE = 1400;
        const int ERROR_INVALID_MENU_HANDLE = 1401;
        const int ERROR_MENU_ITEM_NOT_FOUND = 1456;

        /// <summary>
        /// 获取窗体菜单句柄
        /// <para>【注意】菜单句柄会因窗体句柄改变、调用<see cref="Reset(Form)"/>等原因发生变化，故不建议缓存该句柄</para>
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="Win32Exception" />
        public static IntPtr GetSystemMenuHandle(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            return GetSystemMenu(form.Handle, false);
        }

        /// <summary>
        /// 添加分隔条并返回其ID
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static int AddSeparator(IntPtr hMenu, SystemMenuStandardItem beforeItem) =>
            AddSeparator(hMenu, (int)beforeItem, false);

        /// <summary>
        /// 添加分隔条并返回其ID
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static int AddSeparator(IntPtr hMenu, int beforeItem = -1, bool byPosition = true) =>
            AddItem(hMenu, "-", beforeItem: beforeItem, byPosition: byPosition);

        /// <summary>
        /// 添加展开项（能展开子菜单的项）并返回其ID
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static int AddDropDown(IntPtr hMenu, string text, ContextMenu subMenu, SystemMenuStandardItem beforeItem) =>
            AddDropDown(hMenu, text, subMenu, (int)beforeItem, false);

        /// <summary>
        /// 添加展开项（能展开子菜单的项）并返回其ID
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static int AddDropDown(IntPtr hMenu, string text, ContextMenu subMenu, int beforeItem = -1, bool byPosition = true) =>
            AddItem(hMenu, text, null, subMenu, beforeItem, byPosition);

        /// <summary>
        /// 添加菜单项并返回其ID
        /// </summary>
        /// <param name="hMenu">要操作的菜单句柄</param>
        /// <param name="text">菜单项文本。当文本为"-"时，会视为分隔条；当文本指定为<see cref="string.Empty"/>时，为避免可能引起的其它项的快捷键不可用的问题，会将文本更改为一个空格</param>
        /// <param name="onClick">点击事件处理程序</param>
        /// <param name="subMenu">子菜单。赋值此参数将使<paramref name="onClick"/>参数失效，即不会触发点击事件</param>
        /// <param name="beforeItem">要插在哪个标准项的前边</param>
        /// <param name="isChecked">是否勾选。注意项的勾选状态并不会因点击自动切换，需自行响应<paramref name="onClick"/>事件并用<see cref="SetItemChecked(IntPtr, int, bool, bool)"/>处理</param>
        /// <param name="enabled">是否可用</param>
        /// <exception cref="Win32Exception" />
        public static int AddItem(IntPtr hMenu, string text, EventHandler<SystemMenuItemEventArgs> onClick, ContextMenu subMenu, SystemMenuStandardItem beforeItem, bool isChecked = false, bool enabled = true) =>
            AddItem(hMenu, text, onClick, subMenu, (int)beforeItem, false, isChecked, enabled);

        /// <summary>
        /// 添加菜单项并返回其ID
        /// </summary>
        /// <param name="hMenu">要操作的菜单句柄</param>
        /// <param name="text">菜单项文本。当文本为"-"时，会视为分隔条；当文本指定为<see cref="string.Empty"/>时，为避免可能引起的其它项的快捷键不可用的问题，会将文本更改为一个空格</param>
        /// <param name="onClick">点击事件处理程序</param>
        /// <param name="subMenu">子菜单。赋值此参数将使<paramref name="onClick"/>参数失效，即不会触发点击事件</param>
        /// <param name="beforeItem">要插在哪一项的前边。该参数可以是那个项的位置索引，也可以是其ID，由<paramref name="byPosition"/>参数解释。若找不到项，则在末尾添加</param>
        /// <param name="byPosition">是否将<paramref name="beforeItem"/>参数解释为位置，为否则表示是ID</param>
        /// <param name="isChecked">是否勾选。注意项的勾选状态并不会因点击自动切换，需自行响应<paramref name="onClick"/>事件并用<see cref="SetItemChecked(IntPtr, int, bool, bool)"/>处理</param>
        /// <param name="enabled">是否可用</param>
        /// <exception cref="Win32Exception" />
        public static int AddItem(IntPtr hMenu, string text, EventHandler<SystemMenuItemEventArgs> onClick = null, ContextMenu subMenu = null, int beforeItem = -1, bool byPosition = true, bool isChecked = false, bool enabled = true)
        {
            //先检测菜单句柄有效性，避免无谓的ID分配
            if (!IsMenu(hMenu))
            {
                throw new Win32Exception(ERROR_INVALID_MENU_HANDLE);
            }

            var info = new MENUITEMINFO
            {
                fMask = 0x2 //MIIM_ID
                      | 0x1 //MIIM_STATE
                      | 0x4 //MIIM_SUBMENU
                      | 0x40 //MIIM_STRING
                      | 0x100 //MIIM_FTYPE
            };

            var mi = new SystemMenuItem(hMenu, onClick);
            info.wID = mi.Id;

            if (text == "-")
            {
                info.fType |= 0x800; //MFT_SEPARATOR
            }
            else
            {
                // Windows issue: Items with empty captions sometimes block keyboard
                // access to other items in same menu.
                info.dwTypeData = string.IsNullOrEmpty(text) ? " " : text;
            }

            if (isChecked)
            {
                info.fState |= 0x8;
            }

            if (!enabled)
            {
                info.fState |= 0x3;
            }

            if (subMenu != null)
            {
                info.hSubMenu = subMenu.Handle;
            }

            //添加成功再将项放进容器
            if (InsertMenuItem(hMenu, beforeItem, byPosition, info))
            {
                CustomizedItems[mi.Id] = mi;
            }
            else
            {
                mi.Dispose();
                throw new Win32Exception();
            }

            return info.wID;
        }

        /// <summary>
        /// 删除菜单项。对于展开项，本方法并不会连带销毁子菜单
        /// <para>【注意】删除标准项后窗体将失去对应能力</para>
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static void RemoveItem(IntPtr hMenu, SystemMenuStandardItem item) => RemoveItem(hMenu, (int)item, false);

        /// <summary>
        /// 删除菜单项。对于展开项，本方法并不会连带销毁子菜单
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static void RemoveItem(IntPtr hMenu, int item, bool byPosition)
        {
            if (byPosition)
            {
                var info = GetMenuItemInfo(hMenu, item, true);
                if (info == null)
                {
                    return;
                }

                item = info.wID;
            }

            RemoveMenu(hMenu, item, false);

            if (CustomizedItems.TryGetValue(item, out var mi) && mi.ParentMenuHandle == hMenu)
            {
                CustomizedItems.Remove(item);
                mi.Dispose();
            }
        }

        /// <summary>
        /// 设置菜单项文本
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static void SetItemText(IntPtr hMenu, int item, bool byPosition, string text)
        {
            var info = new MENUITEMINFO
            {
                fMask = 0x40, //MIIM_STRING
                dwTypeData = string.IsNullOrEmpty(text) ? " " : text
            };

            SetItemInfo(hMenu, (uint)item, byPosition, info);
        }

        /// <summary>
        /// 设置菜单项勾选状态
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static void SetItemChecked(IntPtr hMenu, int item, bool byPosition, bool isChecked)
        {
            var result = CheckMenuItem(hMenu, (uint)item, (uint)((byPosition ? 0x400 : 0) | (isChecked ? 0x8 : 0)));
            if (result == -1)
            {
                if (IsMenu(hMenu))
                {
                    throw new Win32Exception(ERROR_MENU_ITEM_NOT_FOUND);
                }

                throw new Win32Exception(ERROR_INVALID_MENU_HANDLE);
            }
        }

        /// <summary>
        /// 设置菜单项可用状态
        /// </summary>
        public static void SetItemEnabled(IntPtr hMenu, int item, bool byPosition, bool enabled)
        {
            var result = EnableMenuItem(hMenu, (uint)item, (uint)((byPosition ? 0x400 : 0) | (enabled ? 0 : 1)));
            if (result == -1)
            {
                //该API能正确反馈无效句柄，但不能反馈项不存在
                var code = Marshal.GetLastWin32Error();
                if (code != ERROR_INVALID_MENU_HANDLE)
                {
                    code = ERROR_MENU_ITEM_NOT_FOUND;
                }

                throw new Win32Exception(code);
            }
        }

        /// <summary>
        /// 获取菜单项信息。项不存在会返回null
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static SystemMenuItemInfo GetItemInfo(IntPtr hMenu, int item, bool byPosition) =>
            ConvertMenuItemInfo(GetMenuItemInfo(hMenu, item, byPosition), hMenu);

        /// <summary>
        /// 获取所有菜单项信息（含标准项和分隔条）
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static IEnumerable<SystemMenuItemInfo> GetItemInfos(IntPtr hMenu)
        {
            foreach (var info in GetMenuItemInfos(hMenu))
            {
                yield return ConvertMenuItemInfo(info, hMenu);
            }
        }

        /// <summary>
        /// 菜单项计数（含标准项和分隔条）
        /// </summary>
        /// <exception cref="Win32Exception" />
        public static int GetMenuItemCount(IntPtr hMenu)
        {
            var count = NativeGetMenuItemCount(hMenu);
            if (count < 0)
            {
                throw new Win32Exception();
            }

            return count;
        }

        /// <summary>
        /// 重置窗体菜单
        /// <para>【注意】重置后窗体菜单句柄会改变</para>
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public static void Reset(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (form.IsHandleCreated)
            {
                //重置之前先把展开项删除，目的是分离子菜单，不然重置时会连子菜单一起销毁，但子菜单也许还用于别的地方
                //直接置空展开项的子菜单不行，那样也会销毁子菜单
                var hMenu = GetSystemMenuHandle(form);
                var dropDownItems = new List<MENUITEMINFO>();
                foreach (var info in GetMenuItemInfos(hMenu))
                {
                    if (info.hSubMenu != IntPtr.Zero)
                    {
                        dropDownItems.Add(info);
                    }
                }

                foreach (var info in dropDownItems)
                {
                    RemoveMenu(hMenu, info.wID, false); //这里不必管CustomizedItems，下面会清理
                }

                GetSystemMenu(form.Handle, true);
            }

            //删除所属菜单已经失效的项
            var shouldRemoveItems = new List<SystemMenuItem>();
            foreach (var item in CustomizedItems.Values)
            {
                if (!IsMenu(item.ParentMenuHandle))
                {
                    shouldRemoveItems.Add(item);
                }
            }

            foreach (var item in shouldRemoveItems)
            {
                CustomizedItems.Remove(item.Id);
                item.Dispose();
            }
        }

        static SystemMenuItemInfo ConvertMenuItemInfo(MENUITEMINFO info, IntPtr parentMenuHandle)
        {
            if (info == null)
            {
                return null;
            }

            var newInfo = new SystemMenuItemInfo
            {
                Checked = (info.fState & 8) == 8,
                Enabled = (info.fState & 3) != 3,
                Id = info.wID,
                SubMenuHandle = info.hSubMenu,
                Type = (SystemMenuItemType)info.fType,
                ParentMenuHandle = parentMenuHandle
            };

            //菜单项的文本和快捷键是以一个TAB作分隔
            var texts = info.dwTypeData?.Split('\t') ?? new[] { "" };
            newInfo.Text = texts[0];

            try
            {
                if (texts.Length > 1 && TypeDescriptor.GetConverter(typeof(Keys)).ConvertFromString(texts[1]) is Keys keys)
                {
                    newInfo.Shortcut = (Shortcut)keys;
                }
            }
            catch
            {
                // ignored
            }

            return newInfo;
        }

#pragma warning disable 649
        // ReSharper disable UnusedMember.Local
        // ReSharper disable NotAccessedField.Local
        [StructLayout(LayoutKind.Sequential)]
        class MENUITEMINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MENUITEMINFO));
            public int fMask;
            public int fType;
            public int fState;
            public int wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public string dwTypeData;
            public int cch;
            public IntPtr hbmpItem;
        }
        // ReSharper restore NotAccessedField.Local
        // ReSharper restore UnusedMember.Local
#pragma warning restore 649

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool InsertMenuItem(IntPtr hMenu, int uItem, bool fByPosition, MENUITEMINFO lpmii);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetSystemMenu")]
        static extern IntPtr NativeGetSystemMenu(IntPtr hWnd, bool bRevert);

        static IntPtr GetSystemMenu(IntPtr hWnd, bool reset)
        {
            var hMenu = NativeGetSystemMenu(hWnd, reset);

            if (!reset && Marshal.GetLastWin32Error() == ERROR_INVALID_WINDOW_HANDLE)
            {
                throw new Win32Exception(ERROR_INVALID_WINDOW_HANDLE);
            }

            return hMenu;
        }

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetMenuItemInfo")]
        static extern bool NativeGetMenuItemInfo(IntPtr hMenu, uint item, bool fByPosition, [In, Out] MENUITEMINFO info);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetMenuItemCount")]
        static extern int NativeGetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        /// <summary>
        /// 菜单句柄无效会抛异常，项不存在则忽略
        /// </summary>
        static void RemoveMenu(IntPtr hMenu, int item, bool byPosition)
        {
            if (!RemoveMenu(hMenu, (uint)item, (uint)(byPosition ? 0x400 : 0)))
            {
                var code = Marshal.GetLastWin32Error();
                if (code == ERROR_INVALID_MENU_HANDLE)
                {
                    throw new Win32Exception(code);
                }
            }
        }

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "SetMenuItemInfo")]
        static extern bool NativeSetMenuItemInfo(IntPtr hMenu, uint item, bool fByPosition, MENUITEMINFO info);

        static void SetItemInfo(IntPtr hMenu, uint item, bool byPosition, MENUITEMINFO info)
        {
            if (!NativeSetMenuItemInfo(hMenu, item, byPosition, info))
            {
                throw new Win32Exception();
            }
        }

        static IEnumerable<MENUITEMINFO> GetMenuItemInfos(IntPtr hMenu)
        {
            var count = GetMenuItemCount(hMenu);

            for (int i = 0; i < count; i++)
            {
                yield return GetMenuItemInfo(hMenu, i, true);
            }
        }

        /// <summary>
        /// 菜单句柄无效会抛异常，项不存在返回null
        /// </summary>
        static MENUITEMINFO GetMenuItemInfo(IntPtr hMenu, int item, bool byPosition)
        {
            var info = new MENUITEMINFO
            {
                fMask = 0x2 //MIIM_ID
                      | 0x1 //MIIM_STATE
                      | 0x4 //MIIM_SUBMENU
                      | 0x40 //MIIM_STRING
                      | 0x100 //MIIM_FTYPE，不要用MIIM_TYPE
            };

            try
            {
                //第一次执行得到cch（菜单文本字节数）
                RetrieveInfo(hMenu, item, byPosition, info);

                info.cch++; //将字节数+1，以容纳\0
                info.dwTypeData = new string('\0', info.cch); //并开辟好接收空间

                //再次执行得到准确的菜单文本
                RetrieveInfo(hMenu, item, byPosition, info);

                return info;
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == ERROR_MENU_ITEM_NOT_FOUND)
            {
                return null;
            }

            void RetrieveInfo(IntPtr hMenu_, int item_, bool byPosition_, MENUITEMINFO info_)
            {
                if (!NativeGetMenuItemInfo(hMenu_, (uint)item_, byPosition_, info_))
                {
                    //该API能正确反馈项不存在，但不能反馈句柄无效
                    var code = Marshal.GetLastWin32Error();
                    if (code != ERROR_MENU_ITEM_NOT_FOUND)
                    {
                        code = ERROR_INVALID_MENU_HANDLE;
                    }

                    throw new Win32Exception(code);
                }
            }
        }

        [DllImport("user32.dll")]
        static extern int CheckMenuItem(IntPtr hMenu, uint uIDCheckItem, uint uCheck);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        static extern bool IsMenu(IntPtr hMenu);

        //for Debug
        //public static void Debug()
        //{
        //    var cmds = typeof(Form).Assembly.GetType("System.Windows.Forms.Command")
        //        .GetField("cmds", BindingFlags.Static | BindingFlags.NonPublic)
        //        .GetValue(null);

        //    var items = _customizedItems;

        //    ; //breakpoint on here
        //}

        //菜单项
        class SystemMenuItem : ICommandExecutor, IDisposable
        {
            static Type _typeOfCommand;
            static Type TypeOfCommand => _typeOfCommand ?? (_typeOfCommand = typeof(Form).Assembly.GetType("System.Windows.Forms.Command"));
            static PropertyInfo _idPropertyOfCommand;
            static PropertyInfo IdPropertyOfCommand => _idPropertyOfCommand ?? (_idPropertyOfCommand = TypeOfCommand.GetProperty("ID"));
            static MethodInfo _disposeMethodOfCommand;
            static MethodInfo DisposeMethodOfCommand => _disposeMethodOfCommand ?? (_disposeMethodOfCommand = TypeOfCommand.GetMethod("Dispose"));

            readonly EventHandler<SystemMenuItemEventArgs> _onClick;

            object _cmd;

            public IntPtr ParentMenuHandle { get; }

            public event EventHandler<SystemMenuItemEventArgs> Click;

            public int Id { get; }

            public SystemMenuItem(IntPtr hMenu, EventHandler<SystemMenuItemEventArgs> onClick)
            {
                ParentMenuHandle = hMenu;
                Id = AcquireId();
                _onClick = onClick;
                Click += _onClick;
            }

            int AcquireId()
            {
                _cmd = Activator.CreateInstance(TypeOfCommand, this);
                return (int)IdPropertyOfCommand.GetValue(_cmd, null);
            }

            void ICommandExecutor.Execute()
            {
                var info = GetItemInfo(ParentMenuHandle, Id, false);
                Click?.Invoke(null, new SystemMenuItemEventArgs(info));
            }

            public void Dispose()
            {
                Click -= _onClick;
                DisposeMethodOfCommand.Invoke(_cmd, null);
                _cmd = null;
            }
        }
    }

    /// <summary>
    /// 标准窗体菜单项
    /// </summary>
    public enum SystemMenuStandardItem
    {
        Restore = 0xF120,
        Move = 0xF010,
        Size = 0xF000,
        Minimize = 0xF020,
        Maximize = 0xF030,
        Close = 0xF060
    }

    /// <summary>
    /// 系统菜单项类型
    /// </summary>
    [Flags]
    public enum SystemMenuItemType
    {
        String,
        Bitmap = 0x4,
        MenuBarBreak = 0x20,
        MenuBreak = 0x40,
        OwnerDraw = 0x100,
        RadioCheck = 0x200,
        RightJustify = 0x4000,
        RightOrder = 0x2000,
        Separator = 0x800,
    }

    /// <summary>
    /// 系统菜单项信息
    /// </summary>
    public class SystemMenuItemInfo
    {
        public SystemMenuItemType Type { get; set; }

        /// <summary>
        /// 唯一标识。同时也是命令ID
        /// </summary>
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }

        public bool Enabled { get; set; }

        public IntPtr SubMenuHandle { get; set; }

        public Shortcut Shortcut { get; set; }

        /// <summary>
        /// 所属菜单的句柄
        /// </summary>
        public IntPtr ParentMenuHandle { get; set; }
    }

    /// <summary>
    /// 菜单项事件数据类
    /// </summary>
    public class SystemMenuItemEventArgs : EventArgs
    {
        /// <summary>
        /// 获取引发事件的菜单项的信息
        /// </summary>
        public SystemMenuItemInfo Info { get; }

        public SystemMenuItemEventArgs(SystemMenuItemInfo info)
        {
            Info = info;
        }
    }
}
