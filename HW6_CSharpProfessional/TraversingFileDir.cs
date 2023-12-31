﻿using System;
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
        /// <summary>
        /// Свойство контролирующее отмену поиска файлов
        /// </summary>
        public bool StopSearch { get; set; } = false;

        private readonly string _path;
        public TraversingFileDir(string path)
        {
            _path = path;   
        }

        public event EventHandler<FileArgs>? FileFound;
        public event Action? Сancellation;
        public event EventHandler<string>? MaxSize;

        /// <summary>
        /// Переребор файлов
        /// </summary>
        /// <param name="path">директория</param>
        public void FileSearch()
        {
            var files = new DirectoryInfo(_path).EnumerateFiles();

            var i = 0;
            var j = 5;

            List<string> list = new();
     
            // поиск файла с максимальным размером
            foreach (var file in files)
            {
                if (i < j)
                {
                    var length = new FileInfo(file.FullName).Length.ToString();
                    list.Add(length);
                }
            }

            var maxValue = list.GetMax(mV => float.Parse(mV));


            foreach (var file in files)
            {
                i++;
                if (i < j)
                {
                    long length = new FileInfo(file.FullName).Length;
       
                    if (length.ToString() == maxValue)
                    {
                        MaxSize?.Invoke(this, "cамый большой ");
                    }

                    FileFound?.Invoke(this, new FileArgs(file.Name, length));
                }
                else
                {
                    StopSearch = true;
                    Сancellation?.Invoke();
                }

                if (StopSearch) break;
            }    
        }



    }
}
