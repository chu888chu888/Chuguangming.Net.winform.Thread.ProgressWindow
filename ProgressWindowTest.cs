using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProgressWindow
{
    public partial class ProgressWindowTest : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressWindowTest"/> class.
        /// </summary>
        public ProgressWindowTest()
        {
            this.Hide();
            SplashWindowForm splashWindowForm = new SplashWindowForm();
            splashWindowForm.Text = "测试工作";
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(SplashDoWork), splashWindowForm);
            splashWindowForm.ShowDialog();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonTest control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonTest_Click(object sender, EventArgs e)
        {
            ProgressWindowForm progressWindowForm = new ProgressWindowForm();
            progressWindowForm.Text = "测试工作";
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(DoSomeWork), progressWindowForm);
            progressWindowForm.ShowDialog();
        }

        /// <summary>
        /// Does some work.
        /// </summary>
        /// <param name="status">The status.</param>
        private void DoSomeWork(object status)
        {
            ProgressWindowForm progressWindowForm = status as ProgressWindowForm;
            try
            {
                progressWindowForm.BeginThread(0, 1000);
                for (int i = 0; i < 1000; ++i)
                {
                    progressWindowForm.SetDisplayText(String.Format("处理第{0}条....", i));
                    progressWindowForm.StepTo(i);
                    if (progressWindowForm.IsAborting)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(100);
                    if (progressWindowForm.IsAborting)
                    {
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Environment.NewLine + exception.StackTrace);
            }
            finally
            {
                if (progressWindowForm != null)
                {
                    progressWindowForm.End();
                }
            }
        }

        /// <summary>
        /// Does some work.
        /// </summary>
        /// <param name="status">The status.</param>
        private void SplashDoWork(object status)
        {
            SplashWindowForm splashWindowForm = status as SplashWindowForm;
            try
            {
                splashWindowForm.BeginThread(0, 300);
                for (int i = 0; i < 100; ++i)
                {
                    splashWindowForm.SetDisplayText("加载启动项1....");
                    splashWindowForm.StepTo(i);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(100);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                }

                for (int i = 100; i < 200; ++i)
                {
                    splashWindowForm.SetDisplayText("加载启动项2....");
                    splashWindowForm.StepTo(i);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(100);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                }

                for (int i = 200; i < 300; ++i)
                {
                    splashWindowForm.SetDisplayText("加载启动项3....");
                    splashWindowForm.StepTo(i);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(100);
                    if (splashWindowForm.IsAborting)
                    {
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Environment.NewLine + exception.StackTrace);
            }
            finally
            {
                if (splashWindowForm != null)
                {
                    splashWindowForm.End();
                }
            }
        }
    }
}
