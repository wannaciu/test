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
    public partial class StuffForm : Form
    {
        public StuffForm()
        {
            InitializeComponent();
        }
        int nOpentype = 0; //0:默认，1：添加，2：修改
        int nRowIndex = -1;
        int intindex = 0;//记录行索引
        SqlConnection conn;//声明一个SqlConnection变量
        SqlDataAdapter adapter;//声明一个SqlDataAdapter变量
        private void Infosql_Load(object sender, EventArgs e)
        {
            //实例化SqlConnection变量conn，连接数据库
            conn = new SqlConnection("server=st13;database=HRMS;uid=sa;pwd=sql123");
            //实例化SqlDataAdapter对象
            SqlDataAdapter sda = new SqlDataAdapter("select * from tb_emp", conn);
            DataSet ds = new DataSet();				//实例化DataSet对象
            sda.Fill(ds);							//使用SqlDataAdapter对象的Fill方法填充DataSet
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView1控件的数据源
            dataGridView1.RowHeadersVisible = false;//禁止显示行标题
            //使用for循环设置控件的列宽
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 84;
            }
            dataGridView1.Columns[0].ReadOnly = true;	//将控件设置为只读
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
                     if (dbUpdate())							//判断dbUpdate方法返回的值是否为true
            {
                MessageBox.Show("修改成功！");		//弹出提示
            }
            Infosql_Load(sender,e);
        }
        private Boolean dbUpdate()					//建立一个Boolean类型的方法dbUpdate
        {
            string strSql = "select * from tb_emp";	//声明SQL语句
            DataTable dtUpdate = new DataTable();	//实例化DataTable
            //dtUpdate = this.dbconn(strSql);			//调用dbconn方法
            dtUpdate.Rows.Clear();					//调用Clear方法
            DataTable dtShow = new DataTable();		//实例化DataTable
            dtShow = (DataTable)this.dataGridView1.DataSource;
            dtUpdate.ImportRow(dtShow.Rows[intindex]);//使用ImportRow方法复制dtShow中的值
            try
            {
                SqlCommandBuilder CommandBuiler;	//声明SqlCommandBuilder变量
                CommandBuiler = new SqlCommandBuilder(this.adapter);
                this.adapter.Update(dtUpdate);		//调用Update方法更新数据
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());//出现异常弹出提示
                return false;
            }
            dtUpdate.AcceptChanges();				//提交更改
            return true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intindex = e.RowIndex;//记录当前行号
        }

        private void picSelectButton_Click(object sender, EventArgs e)
        {
        }

    }
    
}
