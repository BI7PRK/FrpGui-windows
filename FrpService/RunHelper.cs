using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FrpService
{
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public class SECURITY_ATTRIBUTES
    {
        public int nLength;
        public string lpSecurityDescriptor;
        public bool bInheritHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFO
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public int lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwYSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public int wShowWindow;
        public int cbReserved2;
        public byte lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    public class RunHelper
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern bool CreateProcess(
             StringBuilder lpApplicationName, 
             StringBuilder lpCommandLine,
             SECURITY_ATTRIBUTES lpProcessAttributes,
             SECURITY_ATTRIBUTES lpThreadAttributes,
             bool bInheritHandles,
             int dwCreationFlags,
             StringBuilder lpEnvironment,
             StringBuilder lpCurrentDirectory,
             ref STARTUPINFO lpStartupInfo,
             ref PROCESS_INFORMATION lpProcessInformation
             );

        #region Win32 Api : WaitForSingleObject
        //检测一个系统核心对象(线程，事件，信号)的信号状态，当对象执行时间超过dwMilliseconds就返回，否则就一直等待对象返回信号
        [DllImport("Kernel32.dll")]
        public static extern uint WaitForSingleObject(System.IntPtr hHandle, uint dwMilliseconds);

        #endregion

        #region Win32 Api : CloseHandle
        //关闭一个内核对象,释放对象占有的系统资源。其中包括文件、文件映射、进程、线程、安全和同步对象等
        [DllImport("Kernel32.dll")]
        public static extern bool CloseHandle(System.IntPtr hObject);

        #endregion       

        #region Win32 Api : GetExitCodeProcess
        //获取一个已中断进程的退出代码,非零表示成功，零表示失败。
        //参数hProcess，想获取退出代码的一个进程的句柄，参数lpExitCode，用于装载进程退出代码的一个长整数变量。
        [DllImport("Kernel32.dll")]
        static extern bool GetExitCodeProcess(System.IntPtr hProcess, ref uint lpExitCode);

        #endregion
    }
}
