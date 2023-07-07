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

            var maxValue = list.GetMax(mV => float.Parse(mV));

            Console.WriteLine($"Максимальное значение: {maxValue}");
            Console.WriteLine("----------------------------------");

            // пп.2 - 5
            string filesPath = Directory.GetCurrentDirectory();

            TraversingFileDir traversingFileDir = new (filesPath);

            // подписываемся на событие нахождения файла
            traversingFileDir.FileFound += traversingFileDir.TraversingFileDir_FileFound;

            // подписываемся на событие отмены поиска по условию
            traversingFileDir.Сancellation += traversingFileDir.TraversingFileDir_Сancellation;

            // подписываемся на событие нахождения самого большого файла
            traversingFileDir.MaxSize += traversingFileDir.TraversingFileDir_MaxSize;

            // ищем файлы в диреткории filesPath
            traversingFileDir.FileSearch();

            Console.WriteLine("----------------------------------");


            Console.WriteLine("Нажмите клавишу для закрытия программы");
            Console.ReadKey();

            traversingFileDir.Сancellation -= traversingFileDir.TraversingFileDir_Сancellation;
            traversingFileDir.MaxSize -= traversingFileDir.TraversingFileDir_MaxSize;
        }
    }
}