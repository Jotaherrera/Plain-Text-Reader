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
using static System.Net.Mime.MediaTypeNames;

namespace PlainTextReader
{
    public partial class frmRtf : Form
    {
        string strFileName;
        public frmRtf()
        {
            InitializeComponent();
        }
        private void pbArrowBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipalScreen frm1 = new frmPrincipalScreen();
            frm1.ShowDialog();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fdRft.ShowDialog() == DialogResult.OK)
            {
                rtbPrincipal.SelectionFont = fdRft.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (cdRft.ShowDialog() == DialogResult.OK)
            {
                rtbPrincipal.SelectionColor = cdRft.Color;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (strFileName != "" && strFileName != null)
            {
                DialogResult dr = MessageBox.Show($"Do you want to close this file and create a new one? ", "File status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    rtbPrincipal.Clear();
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Rich Text Format|*.rtf";
                    saveFileDialog.DefaultExt = "rtf";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        strFileName = saveFileDialog.FileName;
                        lblPath.Text = strFileName;
                        rtbPrincipal.SaveFile(strFileName, RichTextBoxStreamType.RichText);
                        MessageBox.Show($"File saved", "File status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblPath.Text = strFileName;
                    }
                }
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Format|*.rtf";
                saveFileDialog.DefaultExt = "rtf";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strFileName = saveFileDialog.FileName;
                    lblPath.Text = strFileName;
                    rtbPrincipal.SaveFile(strFileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show($"File saved", "File status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format|*.rtf";
            openFileDialog.DefaultExt = "rtf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = openFileDialog.FileName;
                lblPath.Text = strFileName;
                rtbPrincipal.LoadFile(strFileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbPrincipal.SaveFile(strFileName, RichTextBoxStreamType.RichText);
                MessageBox.Show($"File saved", "File status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"You need to open or create a file first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Do you want to delete the file?", "File status", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    rtbPrincipal.Clear();
                    File.Delete(strFileName);
                    strFileName = "";
                    lblPath.Text = strFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"You have not opened any file. Open a file and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
