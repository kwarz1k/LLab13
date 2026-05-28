using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace LLab13.Model
{
    public static class BinaryFile
    {
        private static string path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "lakes.bin");
        public static void Save(List<Lake> lakes)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.Create);
                using var writer = new BinaryWriter(fs);

                foreach (var lake in lakes)
                {
                    writer.Write(lake.Name);
                    writer.Write(lake.Country);
                    writer.Write(lake.Depth);
                    writer.Write(lake.Salinity);
                }

                MessageBox.Show($"Сохранено {lakes.Count} озёр на рабочий стол!\n{path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }
    }
}
