using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainTextReader
{
    public partial class frmXml : Form
    {
        string strFileName;
        Stream myStream;


        public frmXml()
        {
            InitializeComponent();
        }

        private void pbArrowBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipalScreen frm1 = new frmPrincipalScreen();
            frm1.ShowDialog();
        }

        private void createDataGrid()
        {
            try
            {
                dgvPrincipal.DataSource = null;
                dgvPrincipal.Rows.Clear();
                dgvPrincipal.Columns.Clear();
                dgvPrincipal.Refresh();

                if (new FileInfo(strFileName).Length == 0)
                {
                    DialogResult dr = MessageBox.Show($"Do you want add the basic XML structure to the file?" + Environment.NewLine + "Otherwise, it cannot be represented until you add an structure.", "Empty file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        using (StreamWriter sw = new StreamWriter(strFileName))
                        {
                            sw.WriteLine("<root>");
                            sw.WriteLine("<element>");
                            sw.WriteLine("</element>");
                            sw.WriteLine("</root>");
                            sw.Close();

                            rtbPrincipal.Text = File.ReadAllText(strFileName);

                            createDataGrid();
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                DataSet ds = new DataSet();

                ds.ReadXml(strFileName);
                dgvPrincipal.DataSource = ds.Tables[0];
                rtbPrincipal.Text = File.ReadAllText(strFileName);
            }
            catch (Exception ex)
            {
                rtbPrincipal.Text = File.ReadAllText(strFileName);
                MessageBox.Show($"Something went wrong with the representation, please check the structure and save it again. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (strFileName != "" && strFileName != null)
            {
                DialogResult dr = MessageBox.Show($"Do you want to close this file and create a new one?", "File status", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    rtbPrincipal.Clear();
                    dgvPrincipal.Rows.Clear();
                    dgvPrincipal.Columns.Clear();
                    dgvPrincipal.Refresh();
                    myStream.Close();

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = " Extensible Markup Language|*.xml";
                    saveFileDialog.DefaultExt = "xml";
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
                        createDataGrid();
                        lblPath.Text = strFileName;
                    }
                }
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = " Extensible Markup Language|*.xml";
                saveFileDialog.DefaultExt = "xml";
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
                    createDataGrid();
                    lblPath.Text = strFileName;
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Extensible Markup Language| *.xml";
            openFileDialog.DefaultExt = "xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    strFileName = openFileDialog.FileName;
                    lblPath.Text = strFileName;

                    myStream.Close();
                }
                createDataGrid();
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
                MessageBox.Show($"File saved.", "File status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                createDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"You need to open or create a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    dgvPrincipal.DataSource = null;
                    dgvPrincipal.Rows.Clear();
                    dgvPrincipal.Columns.Clear();
                    dgvPrincipal.Refresh();

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
