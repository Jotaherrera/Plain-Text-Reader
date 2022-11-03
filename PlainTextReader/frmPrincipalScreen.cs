namespace PlainTextReader
{
    public partial class frmPrincipalScreen : Form
    {
        public frmPrincipalScreen()
        {
            InitializeComponent();

        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTxt frmTxt = new frmTxt();
            frmTxt.Show();
        }

        private void btnCsv_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCsv frmCsv = new frmCsv();
            frmCsv.Show();
        }

        private void btnRtf_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRtf frmRtf = new frmRtf();
            frmRtf.Show();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmXml frmXml = new frmXml();
            frmXml.Show();
        }
    }
}