/* Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. */
/////////////////////////////////////////////////////////////////////////////////
// Код основной программы.
Console.Clear();
int[,] array = GetArray();
PrintArray(array);
double[] result = FindResult(array);
Console.WriteLine($"Среднее арифметическое каждого столбца:\n{String.Join("\t ", result)}");
//////////////////////////////////////////////////////////////////////////////////
//////// Описание методов.
// Создаём двуменый массив случайной размерности [2-10, 2-10], заполненный случайными двузначными целыми числами от 0 до 10.
int [,] GetArray()
{
    int m = new Random().Next(2, 11);
    int n = new Random().Next(2, 11);
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(0, 11);
        }
    }
    return result;
}
// Выводим в консоль элементы массива построчно.
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
// Вычисляем среднее арифмитическое элементов в столбцах массива, результаты записываем в новый одномерный массив, который возвращает метод.
double[] FindResult(int[,] inArray)
{
    double[] arrayForResult = new double[inArray.GetLength(1)];
    for (int j = 0; j < inArray.GetLength(1); j++)
    {
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            arrayForResult[j] += inArray[i, j]; // Получаем сумму всех элементов в столбце j.
        }
        arrayForResult[j] = Math.Round(arrayForResult[j] / inArray.GetLength(0), 1); // Получаем ср. арифметическое при делении суммы на количество строк.
    }
    return arrayForResult;
}