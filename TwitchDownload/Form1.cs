using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("All Videos");
            comboBox1.Items.Add("Highlights");
            comboBox1.SelectedIndex = comboBox1.FindStringExact("All Videos");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dirButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderDialog.ShowDialog())
            {
                dlLocation.Text = folderDialog.SelectedPath;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (channelId.Text.Trim() == "") 
            {
                channelId.BackColor = Color.FromArgb(255, 200, 200);
                return;
            }

            if (authorization.Text.Trim() == "")
            {
                authorization.BackColor = Color.FromArgb(255, 200, 200);
                return;
            }


            if (dlLocation.Text.Trim() == "")
            {
                dlLocation.BackColor = Color.FromArgb(255, 200, 200);
                return;
            }

            download downloadForm = new download(channelId.Text, authorization.Text, dlLocation.Text, maxLength.Text, comboBox1.SelectedItem.ToString());
            this.Hide();
            downloadForm.ShowDialog();
            this.Close();
        }

        private void channelId_TextChanged(object sender, EventArgs e)
        {
            channelId.BackColor = Color.White;
        }

        private void authorization_TextChanged(object sender, EventArgs e)
        {
            authorization.BackColor = Color.White;
        }

        private void dlLocation_TextChanged(object sender, EventArgs e)
        {
            dlLocation.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
