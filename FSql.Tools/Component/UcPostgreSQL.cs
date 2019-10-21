﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace FreeSqlTools.Component
{
    public partial class UcPostgreSQL : UserControlBase
    {
        public UcPostgreSQL()
        {
            InitializeComponent();
            InitLostFocus(this, this.highlighter1);
        }
        public override void SaveDataConnection()
        {
            if (!Validator(this.highlighter1)) return;
            new DataBaseInfo
            {
                Id = Guid.NewGuid(),
                Host = textBoxX2.Text,
                Name = textBoxX1.Text,
                DbName = textBoxX6.Text,
                Port = textBoxX3.Text,
                DataType = FreeSql.DataType.PostgreSQL,
                UserId = textBoxX4.Text,
                Pwd = textBoxX5.Text
            }.Add();
        }

        public override void TestDataConnection()
        {
            if (!Validator(this.highlighter1)) return;
            var connString = G.GetConnectionString(FreeSql.DataType.PostgreSQL, textBoxX4.Text,
            textBoxX5.Text, textBoxX2.Text, textBoxX6.Text, textBoxX3.Text);
            try
            {
                var fsql = new FreeSql.FreeSqlBuilder()
                   .UseConnectionString(FreeSql.DataType.PostgreSQL,
                   connString).Build();
                fsql.DbFirst.GetDatabases();
                MessageBoxEx.Show("数据库连接成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                TaskDialog.Show("错误提示", eTaskDialogIcon.BlueStop, "数据库连接失败", $" 原因：{e.Message}\n 连接串：{connString}\n", eTaskDialogButton.Ok);
            }

        }
    }
}
