using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CSharpProfessional
{
    /// <summary>
    /// Класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
    /// </summary>
    public class TraversingFileDir
    {
        public event EventHandler<FileArgs>? FileFound;
        public event Action? Сancellation;

        /// <summary>
        /// Переребор файлов
        /// </summary>
        /// <param name="path">директория</param>
        public void FileSearch(string path)
        {
            var files = new DirectoryInfo(path).EnumerateFiles();

            foreach (var file in files)
            {
                FileFound?.Invoke(this, new FileArgs(file.Name));
            }    
 
        }

        /// <summary>
        /// Событие при нахождении каждого файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TraversingFileDir_FileFound(object? sender, FileArgs e)
        {
            Console.WriteLine($"Найден файл: {e.Name}");
        }

    }
}
