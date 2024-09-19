using KeepCalm_KeepTrack.Database;

namespace KeepCalm_KeepTrack.Client
{
    public partial class MainForm : Form
    {
        public readonly SqlDatabase db;

        public MainForm()
        {
            InitializeComponent();

            db = new SqlDatabase();
        }



        private void OnAddProjectButtonClicked(object sender, EventArgs e)
        {
            AddProjectForm addProjectForm = new AddProjectForm(this);
            addProjectForm.ShowDialog();
        }

        private void OnAddTaskButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnAddTimeFrameButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnMainFormLoaded(object sender, EventArgs e)
        {
            
        }

        private Label CreateTitleLabel()
        {

        }
    }
}
