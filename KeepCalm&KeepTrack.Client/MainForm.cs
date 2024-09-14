using KeepCalm_KeepTrack.Database;

namespace KeepCalm_KeepTrack.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnMainFormLoaded(object sender, EventArgs e)
        {
            ApplicationDbContextFactory dbFactory = new ApplicationDbContextFactory();

            using (ApplicationDbContext db = dbFactory.CreateDbContext())
            {
                db.ProjectTable.ToList();
            }
        }
    }
}
