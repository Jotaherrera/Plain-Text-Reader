using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace PlainTextReader
{
    public partial class frmCsv : Form
    {
        string strFileName;
        Stream myStream;
        char[] delimiterChars = { ';', ',' };

        public frmCsv()
        {
            InitializeComponent();
        }

        private void createDataGrid()
        {
            dgvPrincipal.Rows.Clear();
            dgvPrincipal.Columns.Clear();
            dgvPrincipal.Refresh();

            if (new FileInfo(strFileName).Length == 0)
            {
                MessageBox.Show($"This file may be empty", "File status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] headers = new string[0];
            string[] values = new string[0];
            string line;
            int lineCounter = 0;

            string line1 = File.ReadLines(strFileName).First();
            headers = line1.Split(delimiterChars).ToArray();

            dgvPrincipal.ColumnCount = headers.Length;

            for (var i = 0; i < headers.Length; i++)
            {
                dgvPrincipal.Columns[i].Name = headers[i];
            }

            StreamReader streamReader = new StreamReader(strFileName);

            while ((line = streamReader.ReadLine()) != null)
            {
                if (lineCounter > 0)
                {
                    values = line.Split(delimiterChars);

                    dgvPrincipal.Rows.Add(values.ToArray());
                }

                lineCounter++;
            }
            streamReader.Close();
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
                    dgvPrincipal.Rows.Clear();
                    dgvPrincipal.Columns.Clear();
                    dgvPrincipal.Refresh();
                    myStream.Close();

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Comma Separated Value|*.csv";
                    saveFileDialog.DefaultExt = "csv";
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
                saveFileDialog.Filter = "Comma Separated Value|*.csv";
                saveFileDialog.DefaultExt = "csv";
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
            openFileDialog.Filter = "Comma Separated Value| *.csv";
            openFileDialog.DefaultExt = "csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    strFileName = openFileDialog.FileName;
                    lblPath.Text = strFileName;

                    createDataGrid();

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
                createDataGrid();
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
