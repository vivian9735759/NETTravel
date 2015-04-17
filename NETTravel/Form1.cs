using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NETTravel.DataObjects;
using System.Threading;
using System.Threading.Tasks;

namespace NETTravel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void SunMingZi()
        {
            List<int> jixiang = new List<int>()
            {
                1, 3, 5, 7, 8, 11, 13, 15, 16, 18, 21, 23, 24, 25, 31,
                32, 33, 35, 37, 39, 41, 45, 47, 48, 52, 57, 61, 63, 65, 
                67, 68, 81
            };

            List<int> shouling = new List<int>()
            {
                3, 13, 16, 21, 23, 29, 31, 37, 39, 41, 45, 47
            };

            List<int> caifu = new List<int>()
            {
                15, 16, 24, 29, 32, 33, 41, 52
            };

            List<int> caineng = new List<int>()
            {
                13, 14, 18, 26, 29, 33, 35, 38, 48
            };

            List<int> bad = new List<int>()
            {
                2, 4, 9, 10, 12, 14, 19, 20, 22, 26, 27, 28, 30, 34, 36, 38,
                40, 42, 43, 44, 46, 49, 50, 51, 53, 54, 56, 58, 59, 60, 62, 64, 
                66, 69, 70, 71, 72, 73, 74, 75, 76, 77 , 78, 79, 80
            };

            List<int> mu = new List<int>() { 1, 2 };
            List<int> huo = new List<int>() { 3, 4, };
            List<int> tu = new List<int>() { 5, 6 };
            List<int> jin = new List<int> { 7, 8 };
            List<int> shui = new List<int> { 9, 0 };



            string message = string.Empty;
            int tian = 11;
            for (int ming1 = 5; ming1 <= 20; ming1++)
            {
                for (int ming2 = 5; ming2 <= 20; ming2++)
                {
                    int di = ming1 + ming2;
                    int ren = tian + ming1 - 1;
                    int zong = tian + ming1 + ming2 - 1;
                    int wai = zong - ren + 1;

                    if (!bad.Contains(di) &&
                        !bad.Contains(ren) &&
                        !bad.Contains(zong) &&
                        !bad.Contains(wai) &&
                        (jixiang.Contains(di) || shouling.Contains(di) || caifu.Contains(di) || caineng.Contains(di)) &&
                        (jixiang.Contains(ren) || shouling.Contains(ren) || caifu.Contains(ren) || caineng.Contains(ren)) &&
                        (jixiang.Contains(zong) || shouling.Contains(zong) || caifu.Contains(zong) || caineng.Contains(zong)) &&
                        (jixiang.Contains(wai) || shouling.Contains(wai) || caifu.Contains(wai) || caineng.Contains(wai)) &&
                        ((mu.Contains(tian % 10) && mu.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && mu.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && mu.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && huo.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && huo.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && shui.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && shui.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (mu.Contains(tian % 10) && shui.Contains(ren % 10) && shui.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && mu.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && mu.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && mu.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && huo.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && huo.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && tu.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && tu.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (huo.Contains(tian % 10) && tu.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && huo.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && huo.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && huo.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && tu.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && tu.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && tu.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && jin.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && jin.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (tu.Contains(tian % 10) && jin.Contains(ren % 10) && shui.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && tu.Contains(ren % 10) && huo.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && tu.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && tu.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && jin.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && shui.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (jin.Contains(tian % 10) && shui.Contains(ren % 10) && jin.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && mu.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && mu.Contains(ren % 10) && shui.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && jin.Contains(ren % 10) && tu.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && jin.Contains(ren % 10) && shui.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && shui.Contains(ren % 10) && mu.Contains(di % 10)) ||
                        (shui.Contains(tian % 10) && shui.Contains(ren % 10) && jin.Contains(di % 10))))
                    {
                        message += "ming1 = " + ming1 + ", ming2 = " + ming2 + ", tian = " + tian + ", ren = " + ren + ", di = " + di + ", wai = " + wai + ", zong = " + zong + "\n";
                    }
                }
            }

            MessageBox.Show(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CashSuper cs = CashFactory.createCashAccept(cboType.SelectedItem.ToString());
            //double result = cs.acceptCash(double.Parse(tbxPrice.Text) * double.Parse(tbxUnit.Text));
            //MessageBox.Show(result.ToString());

            CashContext cc = new CashContext(cboType.SelectedItem.ToString());
            double result = cc.GetResult(double.Parse(tbxPrice.Text) * double.Parse(tbxUnit.Text));
            MessageBox.Show(result.ToString());
        }

        #region MultiThread

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshUI("Main UI: Thread ID = " + Thread.CurrentThread.ManagedThreadId);

            ThreadPool.QueueUserWorkItem(s =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    RefreshUI("ThreadPool(" + i + "): Thread ID = " + Thread.CurrentThread.ManagedThreadId);
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshUI("Main UI: Thread ID = " + Thread.CurrentThread.ManagedThreadId);

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    RefreshUI("NewThread(" + i + "): Thread ID = " + Thread.CurrentThread.ManagedThreadId);
                }
            }).Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshUI("Main UI: Thread ID = " + Thread.CurrentThread.ManagedThreadId);

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    RefreshUI("Task(" + i + "): Thread ID = " + Thread.CurrentThread.ManagedThreadId);
                }
            });
        }

        private void RefreshUI(string message)
        {
            if (listBox1.InvokeRequired)
                listBox1.Invoke(new Action<string>(RefreshUI), new[] { message });
            else
                listBox1.Items.Add(message);
        }

        #endregion 

        private void button5_Click(object sender, EventArgs e)
        {
            UsingLocalVariableInCallbackCode.Test(10);
        }
    }
}



