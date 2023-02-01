using LaravelProjectCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LaravelProjectCreator
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
                    new LocalhostDatabaseConnection(projectNameTextBox.Text),
                    nodeModulesPathTextBox.Text,
                    laravelModulesTextBox.Text
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
                projectsPathTextBox.Text = configs[0];
            }
            if (configs.Count > 1)
            {
                nodeModulesPathTextBox.Text = configs[1];
            }
            if (configs.Count > 2)
            {
                laravelModulesTextBox.Text = configs[2];
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
            File.WriteAllText("config.txt", Config);
        }

        private void nodeModulesPathTextBox_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("config.txt", Config);
        }

        private void laravelModulesTextBox_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("config.txt", Config);
        }

        public string Config
        {
            get
            {
                return projectsPathTextBox.Text + "\r\n" + nodeModulesPathTextBox.Text + "\r\n" + laravelModulesTextBox.Text;
            }
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