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
    public partial class Auto_Turret_Main_Page : Form
    {
        public Auto_Turret_Main_Page()
        {
            InitializeComponent();
        }

        private void DatabaseRecepticle_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void GetData_Button_Click(object sender, EventArgs e)
        {

            SearchParametersData searchParameters = new SearchParametersData();

            using (CreateSummary createSummary = new CreateSummary())
            {
                var result = createSummary.ShowDialog();

                if (createSummary.DialogResult ==DialogResult.OK)
                {
                    searchParameters = createSummary.SearchParameters;
                    DataBaseAccessController controller = new DataBaseAccessController(searchParameters);
                    controller.PullFromDatabase(controller.GetDatabaseString());
                    List<TurretnameEventtypeEventtimeData> databaseResults = controller.TurretEvents;
                    AddToListView(databaseResults);
                }
            
            }
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            DatabaseRecepticle.Items.Clear();
        }

        private void Wifi_Connect_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void Exit_Application_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Auto_Turret_Main_Page_Load(object sender, EventArgs e)
        {

        }

        private void AddToListView(List<TurretnameEventtypeEventtimeData> databaseResponse)
        {
            DatabaseRecepticle.Items.Clear();

            for(int i = 0; i<databaseResponse.Count;i++)
            {
                string eventTimeString = Convert.ToString(databaseResponse[i].EventTime);
                string[] row = { databaseResponse[i].TurretName, databaseResponse[i].EventType, eventTimeString };
                ListViewItem listViewItem = new ListViewItem(row);
                DatabaseRecepticle.Items.Add(listViewItem);
            }  
        }
    }
}
