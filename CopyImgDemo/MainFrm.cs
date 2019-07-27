using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using HalconDotNet;
using System.Threading;
using System.Collections;
using System.IO;


namespace CopyImgDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }
        //实例化公共类
        ParamSet PS = new ParamSet();

        private void MainFrm_Load(object sender, EventArgs e)
        {//窗体加载 软件初始化
            Read_Parameter();
        }

        private void btnBeforeCopy_Click(object sender, EventArgs e)
        {//图像拷贝前路劲
            //创建FolderBrowserDialog对象
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();
            //判断是否选择文件夹
            if (FBDialog.ShowDialog() == DialogResult.OK)
            {
                //记录选择的文件夹
                PS.publicSet.ImgBeforePath = FBDialog.SelectedPath;
                if (PS.publicSet.ImgBeforePath.EndsWith("\\"))
                {
                    tbBeforeCopy.Text = PS.publicSet.ImgBeforePath;//显示选择的文件夹
                }
                else
                {
                    tbBeforeCopy.Text = PS.publicSet.ImgBeforePath + "\\";//显示选择的文件夹
                }
            }
        }

        private void btnAfterCopy_Click(object sender, EventArgs e)
        {//图像拷贝后路劲
         //创建FolderBrowserDialog对象
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();
            //判断是否选择文件夹
            if (FBDialog.ShowDialog() == DialogResult.OK)
            {
                //记录选择的文件夹
                PS.publicSet.ImgAfterPath = FBDialog.SelectedPath;
                if (PS.publicSet.ImgBeforePath.EndsWith("\\"))
                {
                    tbAfterCopy.Text = PS.publicSet.ImgAfterPath;//显示选择的文件夹
                }
                else
                {
                    tbAfterCopy.Text = PS.publicSet.ImgAfterPath + "\\";//显示选择的文件夹
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {//开始按钮
            PS.ThreadCalibration.m_bBusy1 = true;
            //开辟一个线程
            PS.ThreadCalibration.m_GrabThread1 = new Thread(new ThreadStart(GrabImageThread));
            //开始线程
            PS.ThreadCalibration.m_GrabThread1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {//停止检测
            PS.ThreadCalibration.m_bBusy1 = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {//保存设置
            Save_Parameter();
        }

        public void GrabImageThread()
        {//线程采图
            while (PS.ThreadCalibration.m_bBusy1)
            {
                //定义图形变量
                HObject ho_ImageA1H = null, ho_ImageA2H = null;
                HObject ho_ImageA3H = null, ho_ImageA4H = null, ho_ImageB1H = null;
                HObject ho_ImageB2H = null, ho_ImageB3H = null, ho_ImageB4H = null;
                HObject ho_ImageC1H = null, ho_ImageC2H = null, ho_ImageC3H = null;
                HObject ho_ImageC4H = null, ho_Image = null;

                //定义数据变量
                HTuple hv_Dirs_AR = new HTuple();
                HTuple hv_Files_AR = new HTuple(), hv_Index = new HTuple();
                HTuple hv_idir = new HTuple(), hv_findex = new HTuple();
                HTuple hv_filefolder = new HTuple(), hv_ifilename = new HTuple();
                HTuple hv_strar = new HTuple(), hv_Length = new HTuple();
                HTuple hv_BarCode = new HTuple(), hv_A1H = new HTuple();
                HTuple hv_A2H = new HTuple(), hv_A3H = new HTuple(), hv_A4H = new HTuple();
                HTuple hv_B1H = new HTuple(), hv_B2H = new HTuple(), hv_B3H = new HTuple();
                HTuple hv_B4H = new HTuple(), hv_C1H = new HTuple(), hv_C2H = new HTuple();
                HTuple hv_C3H = new HTuple(), hv_C4H = new HTuple();

                try
                {
                    HOperatorSet.GenEmptyObj(out ho_ImageA1H);
                    HOperatorSet.GenEmptyObj(out ho_ImageA2H);
                    HOperatorSet.GenEmptyObj(out ho_ImageA3H);
                    HOperatorSet.GenEmptyObj(out ho_ImageA4H);
                    HOperatorSet.GenEmptyObj(out ho_ImageB1H);
                    HOperatorSet.GenEmptyObj(out ho_ImageB2H);
                    HOperatorSet.GenEmptyObj(out ho_ImageB3H);
                    HOperatorSet.GenEmptyObj(out ho_ImageB4H);
                    HOperatorSet.GenEmptyObj(out ho_ImageC1H);
                    HOperatorSet.GenEmptyObj(out ho_ImageC2H);
                    HOperatorSet.GenEmptyObj(out ho_ImageC3H);
                    HOperatorSet.GenEmptyObj(out ho_ImageC4H);
                    HOperatorSet.GenEmptyObj(out ho_Image);

                    HOperatorSet.ListFiles(tbBeforeCopy.Text, ((new HTuple("directories")).TupleConcat("files")).TupleConcat("follow_links"), out hv_Dirs_AR);



                    if (rbMultipleImg.Checked)
                    {




                        for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Dirs_AR.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                        {
                            hv_idir = hv_Dirs_AR.TupleSelect(hv_Index);
                            hv_Files_AR = hv_Files_AR.TupleConcat(hv_idir);
                        }

                        for (hv_findex = 0; (int)hv_findex <= (int)((new HTuple(hv_Files_AR.TupleLength()
                                )) - 1); hv_findex = (int)hv_findex + 1)
                        {
                            hv_filefolder = hv_Files_AR.TupleSelect(hv_findex);
                            //分割字符串
                            hv_ifilename = hv_Files_AR.TupleSelect(hv_findex);
                            HOperatorSet.TupleSplit(hv_ifilename, "\\", out hv_strar);
                            HOperatorSet.TupleLength(hv_strar, out hv_Length);
                            hv_BarCode = hv_strar.TupleSelect(hv_Length - 1);

                            hv_A1H = (hv_filefolder + hv_BarCode) + "_A1H.JPG";

                            hv_A2H = (hv_filefolder + hv_BarCode) + "_A2H.JPG";
                            hv_A3H = (hv_filefolder + hv_BarCode) + "_A3H.JPG";
                            hv_A4H = (hv_filefolder + hv_BarCode) + "_A4H.JPG";
                            ho_ImageA1H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageA1H, hv_A1H);
                            ho_ImageA2H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageA2H, hv_A2H);
                            ho_ImageA3H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageA3H, hv_A3H);
                            ho_ImageA4H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageA4H, hv_A4H);
                            HOperatorSet.WriteImage(ho_ImageA1H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_A1H");
                            HOperatorSet.WriteImage(ho_ImageA2H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_A2H");
                            HOperatorSet.WriteImage(ho_ImageA3H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_A3H");
                            HOperatorSet.WriteImage(ho_ImageA4H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_A4H");
                            HOperatorSet.WaitSeconds(2);

                            hv_B1H = (hv_filefolder + hv_BarCode) + "_B1H.JPG";
                            hv_B2H = (hv_filefolder + hv_BarCode) + "_B2H.JPG";
                            hv_B3H = (hv_filefolder + hv_BarCode) + "_B3H.JPG";
                            hv_B4H = (hv_filefolder + hv_BarCode) + "_B4H.JPG";
                            ho_ImageB1H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageB1H, hv_B1H);
                            ho_ImageB2H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageB2H, hv_B2H);
                            ho_ImageB3H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageB3H, hv_B3H);
                            ho_ImageB4H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageB4H, hv_B4H);
                            HOperatorSet.WriteImage(ho_ImageB1H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_B1H");
                            HOperatorSet.WriteImage(ho_ImageB2H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_B2H");
                            HOperatorSet.WriteImage(ho_ImageB3H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_B3H");
                            HOperatorSet.WriteImage(ho_ImageB4H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_B4H");
                            HOperatorSet.WaitSeconds(2);

                            hv_C1H = (hv_filefolder + hv_BarCode) + "_C1H.JPG";
                            hv_C2H = (hv_filefolder + hv_BarCode) + "_C2H.JPG";
                            hv_C3H = (hv_filefolder + hv_BarCode) + "_C3H.JPG";
                            hv_C4H = (hv_filefolder + hv_BarCode) + "_C4H.JPG";
                            ho_ImageC1H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageC1H, hv_C1H);
                            ho_ImageC2H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageC2H, hv_C2H);
                            ho_ImageC3H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageC3H, hv_C3H);
                            ho_ImageC4H.Dispose();
                            HOperatorSet.ReadImage(out ho_ImageC4H, hv_C4H);
                            HOperatorSet.WriteImage(ho_ImageC1H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_C1H");
                            HOperatorSet.WriteImage(ho_ImageC2H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_C2H");
                            HOperatorSet.WriteImage(ho_ImageC3H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_C3H");
                            HOperatorSet.WriteImage(ho_ImageC4H, "jpg", 0, ((tbAfterCopy.Text + "/") + hv_BarCode) + "_C4H");
                            Thread.Sleep(4000);

                            if (!PS.ThreadCalibration.m_bBusy1)
                            {
                                break;
                            }
                        }

                    }
                    else
                    {

                        HOperatorSet.TupleRegexpSelect(hv_Dirs_AR, (new HTuple("\\.(bmp|jpg)$")).TupleConcat(
                              "ignore_case"), out hv_Dirs_AR);

                        for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Dirs_AR.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                        {
                            ho_Image.Dispose();
                            HOperatorSet.ReadImage(out ho_Image, hv_Dirs_AR.TupleSelect(hv_Index));

                            //分割字符串
                            hv_ifilename = hv_Dirs_AR.TupleSelect(hv_Index);
                            HOperatorSet.TupleSplit(hv_ifilename, "\\", out hv_strar);
                            HOperatorSet.TupleLength(hv_strar, out hv_Length);
                            hv_BarCode = hv_strar.TupleSelect(hv_Length - 1);

                            HOperatorSet.WriteImage(ho_Image, "jpg", 0, (tbAfterCopy.Text + "/") + hv_BarCode);
                            Thread.Sleep(4000);
                            if (!PS.ThreadCalibration.m_bBusy1)
                            {
                                break;
                            }
                        }
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();           
                }               
                catch (System.Exception)
                {
                    Thread.Sleep(10);
                }
                finally
                {
                    ho_ImageA1H.Dispose();
                    ho_ImageA2H.Dispose();
                    ho_ImageA3H.Dispose();
                    ho_ImageA4H.Dispose();
                    ho_ImageB1H.Dispose();
                    ho_ImageB2H.Dispose();
                    ho_ImageB3H.Dispose();
                    ho_ImageB4H.Dispose();
                    ho_ImageC1H.Dispose();
                    ho_ImageC2H.Dispose();
                    ho_ImageC3H.Dispose();
                    ho_ImageC4H.Dispose();
                    ho_Image.Dispose();
                }
            }
            PS.ThreadCalibration.m_GrabThread1.Abort();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {//窗体关闭前 进行一些操作
            PS.ThreadCalibration.m_bBusy1 = false;
            //关闭所有窗体
            Application.Exit();
        }

        public void Read_Parameter()
        {//读取设置参数
            tbBeforeCopy.Text = PS.IniReadValue("图像拷贝前路径", "ImgBeforePath", PS.publicSet.IniPath);
            tbAfterCopy.Text = PS.IniReadValue("图像拷贝后路径", "ImgAfterPath", PS.publicSet.IniPath);

            PS.publicSet.ImgModel = Convert.ToInt32(PS.IniReadValue("图像模式", "ImgModel", PS.publicSet.IniPath));
            if (PS.publicSet.ImgModel == 0)
            {
                rbSingleImg.Checked = true;
                rbMultipleImg.Checked = false;
            }
            else
            {
                rbSingleImg.Checked = false;
                rbMultipleImg.Checked = true;
            }
        }

        public void Save_Parameter()
        {//保存设置参数
            PS.IniWriteValue("图像拷贝前路径", "ImgBeforePath", tbBeforeCopy.Text, PS.publicSet.IniPath);
            PS.IniWriteValue("图像拷贝后路径", "ImgAfterPath", tbAfterCopy.Text, PS.publicSet.IniPath);

            if (rbSingleImg.Checked)
            {
                PS.publicSet.ImgModel = 0;
            }
            else
            {
                PS.publicSet.ImgModel = 1;
            }
            PS.IniWriteValue("图像模式", "ImgModel", Convert.ToString(PS.publicSet.ImgModel), PS.publicSet.IniPath);
        }
    }
}
