
public partial class Program
{
    public static void Main(string[] args)
    {
        //коллекция для наборов данных
        Dictionary<int[], char[][]> Tasks = new Dictionary<int[], char[][]>();

        int countTasks = 0;

        using (StreamReader sr = new StreamReader(File.OpenRead("input.txt")))
        {
            //считываем количество наборов входных данных
            countTasks = int.Parse(sr.ReadLine());

            //заполняем наборы данных 
            for (int k = 0; k < countTasks; k++)
            {
                string param = sr.ReadLine();
                string[] tokens = param.Split(' ');

                Tasks.Add(new int[2] { int.Parse(tokens[0]), int.Parse(tokens[1]) }, new char[int.Parse(tokens[0])][]);

                for (int i = 0; i < int.Parse(tokens[0]); i++)
                {
                    string elem = sr.ReadLine();
                    char[] points = elem.ToCharArray();

                    Tasks.ElementAt(k).Value[i] = points;
                }
            }
        }

        //получаем состояние поля после потопа
        foreach (var task in Tasks)
        {
            bool[] check = new bool[task.Key[0]];

            //опускаем каменные блоки до тех пока все не опустятся 
            while (check.Any(x => x == false))
            {
                for (int i = 0; i < task.Key[0]; i++)
                {
                    check[i] = true;

                    //не выходим за рамки массива вниз
                    if (i + 1 != task.Key[0])
                    {
                        for (int j = 0; j < task.Key[1]; j++)
                        {
                            //если под камнем есть пустая клетка
                            if (task.Value[i][j] == '*' && task.Value[i + 1][j] == '.')
                            {
                                //меняем камень и пустую клетку местами
                                task.Value[i][j] = '.';
                                task.Value[i + 1][j] = '*';

                                //если дошли до сюда, то опускание еще происходит
                                check[i] = false;
                            }
                        }
                    }
                }
            }

            //выполняем потоп
            for (int i = 0; i < task.Key[0]; i++)
            {
                //крайний левый
                int start = 0;
                //и крайний правый каменные блоки в строке
                int end = 0;

                //ищем их координаты
                for (int j = 0; j < task.Key[1]; j++)
                {
                    if (task.Value[i][j] == '*')
                    {
                        start = j;

                        for (int k = j + 1; k < task.Key[1]; k++)
                        {
                            j++;
                            if (task.Value[i][k] == '*')
                            {
                                end = k;
                            }
                        }
                    }
                }

                //заполняем между ними водой
                if (start != end)
                {
                    for (int t = start + 1; t < end; t++)
                    {
                        if (task.Value[i][t] != '*')
                            task.Value[i][t] = '~';
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(File.Open("output.txt", FileMode.Append)))
            {
                for (int k = 0; k < task.Key[0]; k++)
                {
                    for (int j = 0; j < task.Key[1]; j++)
                    {
                        sw.Write(task.Value[k][j]);
                    }
                    sw.Write('\n');
                }

                sw.Write('\n');
            }
        }
    }
}