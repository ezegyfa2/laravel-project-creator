using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaravelProjectCreator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new CreatorForm());
            /*LocalhostDatabaseConnection localhostDatabaseConnection = new LocalhostDatabaseConnection("test");
            var creator = new Creator("test2", @"D:\Projektek\laragon\www", localhostDatabaseConnection);
            creator.Create(AdminType.BlueAdmin);
            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " (A teljes uzenet a Hibajelentes.txt-ben talalhato)");
                hibaJelentesKeszites(e);
            }*/
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
