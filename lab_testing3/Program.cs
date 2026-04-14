using lab_testing3;
using System;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static void Main()
    {
        string name;

        name = "МОСКВА_ГРУПП";
        Build b = new Build(name, 5, 70, 470, 65, 535);
        int v1 = b.SumBuild();

        name = "Барнаул_ГРУПП";
        SecondBuild sb = new SecondBuild(name, 5, 70, 470, 1, 65, 535, 0);
        int v2 = sb.SumBuild();

        name = "МОСКВА-Барнаул_ГРУПП";
        ComboBuild cb = new ComboBuild(name, 5, 70, 470, 65, 535, 0);
        int v3 = cb.SumBuild();

        Console.WriteLine("МОСКВА_ГРУПП стоимость: " + v1);
        Console.WriteLine("Барнаул_ГРУПП стоимость: " + v2);
        Console.WriteLine("МОСКВА-Барнаул_ГРУПП стоимость: " + v3);
    }
}
