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
        public bool StopSearch { get; set; } = false;
        private readonly string _path;
        public TraversingFileDir(string path)
        {
            _path = path;   
        }

        public event EventHandler<FileArgs>? FileFound;
        public event Action? Сancellation;

        /// <summary>
        /// Переребор файлов
        /// </summary>
        /// <param name="path">директория</param>
        public void FileSearch()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();

            var i = 0;

            foreach (var file in files)
            {
                i++;
                if (i < 4)
                {
                    FileFound?.Invoke(this, new FileArgs(file.Name));
                }
                else
                {
                    StopSearch = true;
                    Сancellation?.Invoke();
                }

                if (StopSearch) break;
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

        /// <summary>
        /// Событие отмены поиска
        /// </summary>
        public void TraversingFileDir_Сancellation()
        {
            FileFound -= TraversingFileDir_FileFound;
            Console.WriteLine($"Отмена");
        }

    }
}
