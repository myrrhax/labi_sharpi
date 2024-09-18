class Program
{
    public static void Main(String[] args)
    {
        Task2();
        return;
        Console.WriteLine("Введите массив строк (для остановки ввода введите stop): ");
        int cnt = 0;
        int maxCount = 10;
        string[] array = new string[maxCount];
        while (true)
        {
            string? input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input) || String.IsNullOrEmpty(input)) continue;
            if (input == "stop") break;
            if (cnt == maxCount)
            {
                maxCount *= 2;
                string[] newArray = new string[maxCount];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                    array = newArray;
                }
            }
            array[cnt++] = input;
        }

        Console.WriteLine("Введенный массив: ");
        for (int i = 0; i < cnt; i++)
        {
            Console.WriteLine(array[i]);
        }

        Console.WriteLine("Сортируем массив");

        for (int i = 0; i <  cnt; i++)
        {
            for (int j = 0; j < cnt; j++)
            {
                if (array[i].Length < array[j].Length)
                {
                    string t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
        }

        Console.WriteLine("Введенный массив: ");
        for (int i = 0; i < cnt; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    static void Task2()
    {
        Console.WriteLine("Введите двумерный массив 5x5");

        int[,] arr = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    Console.WriteLine($"Введите ({i}, {j})");
                    int input = int.Parse(Console.ReadLine());
                    arr[i, j] = input;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неправильный ввод");
                    return;
                }
            }            
        }
        int x = arr[0, 0];
        for (int i = 1; i < 3; i++)
        {
            if (x != arr[i,i])
            {
                Console.WriteLine("Не все элементы на диагонали равны");
                return;
            }
        }
        Console.WriteLine("Все элементы на диагонали равны");
    }
}