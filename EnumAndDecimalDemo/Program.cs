using System;

namespace EnumAndDecimalDemo
{
    class Program
    {
        enum E { }
        static void Foo(Action<int> x) { Console.WriteLine("int"); }
        static void Foo(Action<E> x) { Console.WriteLine("E"); }
        static void Foo<T>(Action<T> x) { Console.WriteLine("T"); }
        static void Main(string[] args)
        {
            // Диапазон значение типа decimal (-7.9 x 1028 to 7.9 x 1028) / (100 to 28).
            // Таким образом 1e-30m для decimal равно нулю.
            //
            // Согласно спецификации языка C# (6.1.3 Implicit enumeration conversions) 
            // значение 0 любого примитивного типа может быть неявно преобразовано в любой 
            // перечислимый тип.
            //
            // При выборе метода из перегруженных методов (Overload Resolution)
            // компилятор может выбрать только Foo(Action<E> x), так 
            // неявно decimal нельзя преобразовать в int,
            // а для использования Foo<T>(Action<T> x) компилятор требует явного указания
            // типа аргумента, т. е.: Foo((decimal x) => x = 1e-30m).

            Foo(x => x = 1e-30m);
        }
    }
}
