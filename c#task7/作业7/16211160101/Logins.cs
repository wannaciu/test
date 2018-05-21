using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Logins : Form
    {
        //设置登录判断标记
        public int islogged = 0;

        public Logins()
        {
            InitializeComponent();
        }
        //登录
        private void login_Click(object sender, EventArgs e)
        {
            //数据库连接、判断
            try
            {
                string constr = "server=st13;database=HRMS;uid=sa;pwd=sql123";
                SqlConnection conn = new SqlConnection(constr);//创建一个连接对象             
                conn.Open();   //打开连接
                if (conn.State == ConnectionState.Open)//判断是否打开连接//或文本不为空
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    //设置conmandtext属性，设置查询语句
                    cmd.CommandText = "select * from tb_Login where Name='" + username.Text.Trim() + "' and Password='" + userpwd.Text.Trim() + "'";
                    //将commandText属性设置为Text，使其只执行sql语句文本形式
                    cmd.CommandType = CommandType.Text;
                    //使用ExcuteScalar方法获取指定数据表中的数据数量
                    islogged = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                MessageBox.Show("连接失败！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Information);//登录失败

            }
            if (islogged < 1)
            {
                MessageBox.Show("用户不存在或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Information);//登录失败

            }
            else   //页面跳转
            {
                this.Close();
            }
        }

        //退出此界面
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
