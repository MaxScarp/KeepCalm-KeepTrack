using KeepCalm_KeepTrack.Database.Entities;

namespace KeepCalm_KeepTrack.Client
{
    public static class ButtonFactory
    {
        public static Button CreateButton(EntityBaseClass entity)
        {
            Button button = new Button();

            switch (entity)
            {
                case ProjectEntity:
                    ConfigureProjectButton(button);
                    break;
                case TaskEntity:
                    ConfigureTaskButton(button);
                    break;
            }

            return button;
        }

        private static void ConfigureProjectButton(Button button)
        {
            button.BackColor = Color.Black;
            button.AutoSize = true;
            button.UseVisualStyleBackColor = false;
        }

        private static void ConfigureTaskButton(Button button)
        {
            button.BackColor = Color.Black;
            button.AutoSize = true;
            button.UseVisualStyleBackColor = false;
        }
    }
}
