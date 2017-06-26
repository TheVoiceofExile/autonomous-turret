using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Turret
{
    public partial class CreateSummary : Form
    {
        public List<string> Dates;
        public CreateSummary()
        {
            InitializeComponent();
            
        }

        private void CreateSummary_Load(object sender, EventArgs e)
        {
            FromDate.Value = DateTime.Today.AddDays(0);
            ToDate.Value = DateTime.Today.AddDays(0);
            Dates = new List<string>();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CreateSummaryButton_Click(object sender, EventArgs e)
        {
            Dates.Add(FromDate.Value.ToString("yyyy-MM-dd"));
            Dates.Add(ToDate.Value.ToString("yyyy-MM-dd"));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
