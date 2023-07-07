namespace HW6_CSharpProfessional
{
    internal class Program
    {
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

            var maxValue = list.GetMax(mV => int.Parse(mV));

            Console.WriteLine($"Максимальное значение: {maxValue}");
            Console.WriteLine("----------------------------------");

            // пп.2 - 3
            string filesPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Директория {filesPath}:");
            TraversingFileDir traversingFileDir = new (filesPath);

            // подписываемся на событие нахождения файла
            traversingFileDir.FileFound += traversingFileDir.TraversingFileDir_FileFound;
            // пп.4 подписываемся на событие отмены поиска
            traversingFileDir.Сancellation += traversingFileDir.TraversingFileDir_Сancellation;

            // ищем файлы в диреткории filesPath
            traversingFileDir.FileSearch();

            Console.WriteLine("----------------------------------");




            
            Console.ReadKey();

        }
    }
}