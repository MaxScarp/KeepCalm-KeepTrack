using KeepCalm_KeepTrack.Database;
using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public partial class ShowTotalTimeForm : Form
    {
        public event EventHandler? OnCustomClosed;

        private const string NO_NAME_FOUND = "EMPTY";
        private const string NO_DESCRIPTION_FOUND = "EMPTY";

        private readonly ProjectEntity projectEntity;

        private readonly SqlDatabase db;

        public ShowTotalTimeForm(ProjectEntity projectEntity, SqlDatabase db)
        {
            InitializeComponent();

            this.projectEntity = projectEntity;

            this.db = db;
        }

        private void OnShowTotalTimeFormLoaded(object sender, EventArgs e)
        {
            //TODO esegui query e popola i vari campi della form
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);

            Close();
        }

        private void OnShowTotalTimeFormClosing(object sender, FormClosingEventArgs e)
        {
            OnCustomClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
