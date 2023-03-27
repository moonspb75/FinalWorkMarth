/* Задача:
1. Создать репозиторий на GitHub
2. Нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части,
если вы выделяете ее в отдельный метод)
3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md)
4. Написать программу, решающую поставленную задачу
5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так, что все залито
одним коммитом, как минимум этапы 2, 3 и 4 должны быть расположены в разных коммитах)
Задача: Написать программу, которая из имеющегося массива строк формирует массив из строк, длина
которых меньше либо равна 3 символа.
Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
Примеры:
["hello", "2", "world", ":-)"]-> ["2", ":-)"]
["1234", "1567", "-2", "computer science"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> */

// Метод преобразования введенной пользователем в консоль строки в массив строк

  string [] ConvertToArrayString (string ArrayIn)
{
  int sizeWord = 0;                                  // Размер одной строки
  int indexArrayOut = 0;                             // Счетчик, который необходим для преобразования размера массива согласно размеру заполненных ячеек
  int sizeArrayIn = ArrayIn.Length-1;                // Для сокращения арифметических действий в циклах
  string tempString = String.Empty;                  // Строка, собирающая элементы между пробелами
  string [] tempArray = new string [ArrayIn.Length]; // Временный массив, принимающий строки, удовлятворяющие заявленным требованиям
  for (int i = 0; i < ArrayIn.Length; i++)
  {      
    if (ArrayIn[i] == ' ')
    {
      if (sizeWord != 0)
      {                     
        tempArray[indexArrayOut] = tempString;
        indexArrayOut++;                        
      }
      sizeWord = 0;
      tempString = String.Empty;
    }
    else
    {
      sizeWord++;
      tempString += ArrayIn[i];
      if (i == sizeArrayIn && sizeWord != 0)
      {
            tempArray[indexArrayOut] = tempString;
            indexArrayOut++;
      }  
    }  
  }
  string [] arrayNewOut = new string [indexArrayOut]; // Массив, размерности, соответствующий количеству заполненных ячеек
  for (int j = 0; j < indexArrayOut; j++)
  {
    arrayNewOut[j] = tempArray[j];
  }
  return arrayNewOut;
}

// Метод принимает массив строк и возвращает массив строк с указанной длинной символов

  string [] ArrayRowsThreeElements (string [] ArrayIn)
  {
    int flagSize = 3;                                     // Ограничитель количества символов в слове
    int indexArrayOut = 0;                                // Счетчик, который необходим для преобразования размера массива согласно размеру заполненных ячеек
    int lengthArrayIn = ArrayIn.GetLength(0);             // Для сокращения арифметических действий в циклах и читаемости кода
    string [] tempArray = new string [lengthArrayIn];     // Временный массив, принимающий строки, удовлятворяющие заявленным требованиям
    for (int i = 0; i < lengthArrayIn; i++)
    {      
      if (Convert.ToInt32(ArrayIn[i].Length) <= flagSize)
      {
        tempArray[indexArrayOut] = ArrayIn[i];
        if(i != lengthArrayIn)    indexArrayOut++;
      }    
    }
    string [] arrayOut = new string [indexArrayOut];      // Массив, размерности, соответствующий количеству заполненных ячеек
    for (int j = 0; j < indexArrayOut; j++)
    {
      arrayOut[j] = tempArray[j];
    }
    return arrayOut;
  }

// Метод выводит массив в консоль

void ShowArray (string [] arrayIn)
{  
    int sizeRowArray = arrayIn.Length-1;    
    int i = 0;
    System.Console.Write("[");    
    if (sizeRowArray < 0) System.Console.Write("*/");
    else
    {
      for (; i < sizeRowArray; i++)
      { 
        System.Console.Write($"\"{arrayIn[i]}\", "); 
      }
      System.Console.Write($"\"{arrayIn[sizeRowArray]}\"");
    }
      System.Console.Write("]");
}

/* Выполнение программы:
1. Демонстрация массива, заданного на старте алгоритма:*/

string [] useProgrammArrayString = new string [] {"папа", "он", "мама", "дед", ";)"};
System.Console.WriteLine();
System.Console.WriteLine("Пользовательский демонстрационный массив строк, заданный на старте алгоритма:");
ShowArray(useProgrammArrayString);
System.Console.WriteLine();
System.Console.WriteLine("Преобразованный массив строк, длиной не более 3 символа:");
ShowArray(ArrayRowsThreeElements(useProgrammArrayString));
System.Console.WriteLine();

// 2. Введение пользователем массива в консоль:

System.Console.WriteLine("Введите массив строк через пробел:");
string useConsoleString = Convert.ToString(Console.ReadLine()) ?? String.Empty;
string [] useConsoleArrayString = ConvertToArrayString(useConsoleString);
System.Console.WriteLine("Пользовательский массив, введенный из консоли:");
ShowArray(useConsoleArrayString);
System.Console.WriteLine();
System.Console.WriteLine("Преобразованный массив строк, длиной не более 3 символа:");
ShowArray(ArrayRowsThreeElements(useConsoleArrayString));
