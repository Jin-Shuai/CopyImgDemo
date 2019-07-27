using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using HalconDotNet;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace CopyImgDemo
{

    //定义界面参数
    public class PublicSetting
    {
        //定义图像拷贝前的路劲
        public string ImgBeforePath;
        //定义图像拷贝前的路劲
        public string ImgAfterPath ;
        //定义图像模式
        public int ImgModel ;
        //定义配置参数路劲
        public string IniPath ;

        public PublicSetting()
        {
            //定义图像拷贝前的路劲
            ImgBeforePath = "D:/Image/A";
            //定义图像拷贝前的路劲
             ImgAfterPath = "D:/Image/B";
            //定义图像模式
             ImgModel = 0;
            //定义配置参数路劲
            IniPath = Application.StartupPath + "Set.ini";
        }
    }

    //定义2个标定线程
    public class ThreadCalibration
    {
        //定义线程启动标志位
        public bool m_bBusy1;
        public bool m_bBusy2;

        //定义线程
        public Thread m_GrabThread1;
        public Thread m_GrabThread2;

        public ThreadCalibration()
        {
            m_bBusy1 = false;
            m_bBusy2 = false;
        }
    }

    public class ParamSet
    {
        #region //单例模式
        private static ParamSet _instance = null;
        public static ParamSet Instance()
        {
            if (_instance == null)
            {
                _instance = new ParamSet();
            }
            return _instance;
        }
        #endregion

        #region //Ini文件读写
        //声明读写INI文件的API函数  
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                    int size, string filePath);
        //复制内存
        [DllImport("Kernel32.dll")]
        private static extern void CopyMemory(int dest, int source, int size);

        //保存参数到ini文件  
        public void IniWriteValue(string Section, string Key, string Value, string Path)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        //读取ini文件中的参数   
        public string IniReadValue(string Section, string Key, string Path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
        #endregion

        #region //实例化定义的变量
        public PublicSetting publicSet = new PublicSetting();
        public ThreadCalibration ThreadCalibration = new ThreadCalibration();
        #endregion
    }
}
