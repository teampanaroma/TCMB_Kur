using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tcmb_kurlari
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string altinXml = "http://www.kulcealtin.com/serbestxml/";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.Clear();
                dataSet.ReadXml(altinXml);
                dataGridView1.DataSource = dataSet.Tables[1];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message + @" tipinde çok tuhaf hatalar mevcut. Olmadı bir kapatıp açın.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}