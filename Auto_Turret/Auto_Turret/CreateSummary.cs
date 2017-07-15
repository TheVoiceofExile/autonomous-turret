using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Auto_Turret
{
    public partial class CreateSummary : Form
    {
        public SearchParametersData SearchParameters;
        public CreateSummary()
        {
            InitializeComponent();
            
        }

        private void CreateSummary_Load(object sender, EventArgs e)
        {
            FromDate.Value = DateTime.Today.AddDays(0);
            ToDate.Value = DateTime.Today.AddDays(0);
            SearchParameters = new SearchParametersData();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CreateSummaryButton_Click(object sender, EventArgs e)
        {
            ToDate.Value = ToDate.Value.AddDays(1);
            SearchParameters.FromDate = FromDate.Value.ToString("yyyy-MM-dd");
            SearchParameters.ToDate =  ToDate.Value.ToString("yyyy-MM-dd");
            Debug.WriteLine(ToDate.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
