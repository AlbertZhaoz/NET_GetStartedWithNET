using CommandExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowershellExtensions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WechatHelper.CheckIsLogin();
            ////MessageBox.Show(temp.ToString());

        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Title = "请选择要执行的脚本文件";
            openFileDialog.RestoreDirectory = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件完整路径
                var filePath = openFileDialog.FileName;
                this.textBox1.Text = filePath;
                //获取对话框中所选文件的文件名和扩展名，文件名不包括路径
                string fileName = openFileDialog.SafeFileName;
                this.textBox2.AppendText($"您选择的脚本文件为:{openFileDialog.SafeFileName}\n\r");
                this.textBox2.AppendText("\n\r");
                this.textBox2.AppendText($"脚本文件内容为:\n\r");
                this.textBox2.AppendText("\n\r");
                using (FileStream fsRead = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                  //定义二进制数组
                  byte[] buffer = new byte[1024 * 1024 * 5];
                  //从流中读取字节
                  int r = fsRead.Read(buffer, 0, buffer.Length);
                  this.textBox2.AppendText($"{Encoding.Default.GetString(buffer, 0, r)}\n\r");
                  this.textBox2.AppendText("\n\r");
                }
            }

        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.textBox1.Text))
            {
                this.textBox2.AppendText("开始执行脚本\n\r");
                this.textBox2.AppendText("\n\r");
                AlbertZhaoCommand.ExecuteCmd(this.textBox1.Text, Application.StartupPath);
                foreach (var item in AlbertZhaoCommand.DataReceiveList)
                {
                    this.textBox2.AppendText($"{item}");
                    this.textBox2.AppendText("\n\r");
                }
            }
            else
            {
                MessageBox.Show("请选择脚本文件再点击执行");
            }
            

        }
    }
}
