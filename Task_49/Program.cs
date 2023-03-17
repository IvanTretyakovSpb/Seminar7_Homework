/* Задача 50: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет */
/////////////////////////////////////////////////////////////////////////////////
// Код основной программы.
Console.Clear();
int positionI = GetNumberFromUser("Укажите для искомого элемента двумерного массива порядковый номер строки: ", "Ошибка ввода!");
int positionJ = GetNumberFromUser("Укажите для искомого элемента двумерного массива порядковый номер столбца: ", "Ошибка ввода!");
int[,] array = GetArray();
PrintResultFindElement(array, positionI, positionJ);
//////////////////////////////////////////////////////////////////////////////////
//////// Описание методов.
// Запрашивает у пользователя целое положительное число.
int GetNumberFromUser(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
        {
            return userNumber - 1; // Вычитаем 1 из введенного пользователем числа, т.к. номера строк и столбцов в массиве начинаются с 0.
        }
        Console.WriteLine(errorMessage);
    }
}
// Создаём двуменый массив случайной размерности [1-20, 1-20], заполненный случайными двузначными целыми числами от -99 до 99.
int [,] GetArray()
{
    int m = new Random().Next(1, 21);
    int n = new Random().Next(1, 21);
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(-99, 100);
        }
    }
    return result;
}
// Выводим в консоль элементы массива построчно и результаты поиска элемента массива по заданным позициям.
void PrintResultFindElement(int[,] inArray, int m, int n)
{
    int findElement = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
            if((i == m) && (j == n)) findElement = inArray[i, j]; // Присваиваем значение искомого элемента переменной, иначе остается значение 0.
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    string message = (findElement == 0)?"такого элемента в массиве нет":$"{findElement}";
    Console.WriteLine($"{m + 1}, {n + 1} -> {message}"); // Прибавляем 1 к индексам искомого элемента, чтобы вернуться к введенным пользователем числам.
}
