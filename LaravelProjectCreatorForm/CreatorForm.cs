using LaravelProjectCreator;

namespace LaravelProjectCreatorForm
{
    public partial class CreatorForm : Form
    {
        Creator creator
        {
            get
            {
                return new Creator(
                    projectNameTextBox.Text,
                    projectsPathTextBox.Text,
                    vueComponentsPathTextBox.Text,
                    laravelModulesTextBox.Text,
                    new LocalhostDatabaseConnection(projectNameTextBox.Text)
                );
            }
        }

        AdminType adminType
        {
            get
            {
                switch (adminTemplateComboBox.SelectedIndex)
                {
                    case 0:
                        return AdminType.Nothing;
                    case 1:
                        return AdminType.BlueAdmin;
                    default:
                        throw new Exception("Invalid admin type");
                }
            }
        }

        public CreatorForm()
        {
            InitializeComponent();
            adminTemplateComboBox.SelectedIndex = 1;
            List<string> configs = File.ReadLines("config.txt").ToList();
            if (configs.Count > 0)
            {
                projectsPathTextBox.Text = File.ReadLines("config.txt").First();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            creator.Create(adminType);
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " (A teljes uzenet a Hibajelentes.txt-ben talalhato)");
                hibaJelentesKeszites(ex);
            }
        }

        private void projectsPathTextBox_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("config.txt", projectsPathTextBox.Text);
        }

        private static void hibaJelentesKeszites(Exception e)
        {
            try
            {
                using (StreamWriter hibaJelentesKiiro = new StreamWriter("Hibajelentes.txt", true))
                {
                    hibaJelentesKiiro.WriteLine(DateTime.Now);
                    hibaJelentesKiiro.WriteLine(e.ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hiba lepett fel a jelentes keszitese kozben");
            }
        }
    }
}