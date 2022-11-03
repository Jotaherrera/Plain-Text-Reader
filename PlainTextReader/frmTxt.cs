using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainTextReader
{
    public partial class frmTxt : Form
    {
        string strFileName;
        Stream myStream;
        public frmTxt()
        {
            InitializeComponent();
        }
        private void pbArrowBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipalScreen frm1 = new frmPrincipalScreen();
            frm1.ShowDialog();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (strFileName != "" && strFileName != null)
            {
                DialogResult dr = MessageBox.Show($"Do you want to close this file and create a new one? ", "File status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    rtbPrincipal.Clear();
                    myStream.Close();

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files|*.txt|Rich Text Format|*.rtf|Extensible Markup Language|*.xml|Comma Separated Value|*.csv|All files|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        strFileName = saveFileDialog.FileName;
                        using (myStream = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                        using (StreamWriter sw = new StreamWriter(myStream))
                        {
                            sw.Write(rtbPrincipal.Text);
                            sw.Close();
                        }
                        lblPath.Text = strFileName;
                    }
                }
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files|*.txt|Rich Text Format|*.rtf|Extensible Markup Language|*.xml|Comma Separated Value|*.csv|All files|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strFileName = saveFileDialog.FileName;
                    using (myStream = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(myStream))
                    {
                        sw.Write(rtbPrincipal.Text);
                        sw.Close();
                    }
                    lblPath.Text = strFileName;
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|Extensible Markup Language|*.xml|Comma Separated Value| *.csv|All files|*.*";
            openFileDialog.DefaultExt = "txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    strFileName = openFileDialog.FileName;
                    lblPath.Text = strFileName;
                    rtbPrincipal.Text = File.ReadAllText(strFileName);
                    myStream.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(strFileName);
                sw.Write(rtbPrincipal.Text);
                sw.Close();
                lblPath.Text = strFileName;
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
                    myStream.Close();
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
