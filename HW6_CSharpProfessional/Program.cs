namespace HW6_CSharpProfessional
{
    internal class Program
    {
        public static  TraversingFileDir TraversingFileDirProperty{ get; set; }
        static void Main(string[] args)
        {
            // пп.1 
            List<string> list = new();
            
            for (int i = 0; i < 10; i++)
            {
                var randomValue = new Random();
                var val = randomValue.Next(1, 100);

                list.Add(val.ToString());
            }

            Console.WriteLine($"Рандомная коллекция: {string.Join(", ", list)}");

            var maxValue = list.GetMax(mV => float.Parse(mV));

            Console.WriteLine($"Максимальное значение: {maxValue}");
            Console.WriteLine("----------------------------------");

            // пп.2 - 5
            string filesPath = Directory.GetCurrentDirectory();

            TraversingFileDir traversingFileDir = new (filesPath);

            // подписываемся на событие нахождения файла
            traversingFileDir.FileFound += TraversingFileDir_FileFound;

            // подписываемся на событие отмены поиска по условию
            traversingFileDir.Сancellation += TraversingFileDir_Сancellation;
            TraversingFileDirProperty = traversingFileDir;
            // подписываемся на событие нахождения самого большого файла
            traversingFileDir.MaxSize += TraversingFileDir_MaxSize;

            // ищем файлы в диреткории filesPath
            traversingFileDir.FileSearch();

            Console.WriteLine("----------------------------------");


            Console.WriteLine("Нажмите клавишу для закрытия программы");
            Console.ReadKey();

            traversingFileDir.Сancellation -= TraversingFileDir_Сancellation;
            traversingFileDir.MaxSize -= TraversingFileDir_MaxSize;
        }


        /// <summary>
        /// Событие при нахождении каждого файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TraversingFileDir_FileFound(object? sender, FileArgs e)
        {
            Console.WriteLine($"файл: {e.Name} - {e.Length} байт");
        }

        /// <summary>
        /// Событие отмены поиска
        /// </summary>
        public static void TraversingFileDir_Сancellation()
        {
            TraversingFileDirProperty.FileFound -= TraversingFileDir_FileFound;
            Console.WriteLine("Отмена");
        }

        /// <summary>
        /// Событие поиска самого большого файла
        /// </summary>
        public static void TraversingFileDir_MaxSize(object? sender, string fileSize)
        {
            Console.Write($"{fileSize}");
        }





    }
}