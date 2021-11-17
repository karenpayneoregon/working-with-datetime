using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleHelpers.Classes
{
    public static class ConsoleUtils
    {

        /// <summary>
        /// Center console window in monitor
        /// </summary>
        public static void CenterConsole()
        {
            IntPtr hWin = GetConsoleWindow();
            RECT rc;

            GetWindowRect(hWin, out rc);

            var scr = Screen.FromPoint(new Point(rc.left, rc.top));
            int workingAreaLeft = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.right - rc.left)) / 2;
            int workingAreaTop = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.bottom - rc.top)) / 2;

            MoveWindow(hWin, workingAreaLeft, workingAreaTop, rc.right - rc.left, rc.bottom - rc.top, false);
        }

        #region P/Invoke declarations
        private struct RECT { public int left, top, right, bottom; }
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);
        #endregion
    }
}
