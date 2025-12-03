using System;

class Program
{
    static void Main()
    {
        double p1 = 19800.00;
        double p2 = 41300.00;
        double p3 = 52000.00;
        double p4 = 68000.00;
        double p5 = 81000.00;

        string car1 = "Orion Nova";
        string car2 = "Atlas Ridge";
        string car3 = "Voltara Pulse";
        string car4 = "Momentum GT";
        string car5 = "Prestige Elite";

        double unit1, unit2, unit3, unit4, unit5;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("В наявності такі авто:"); 
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(car1 + " " + p1 + " $;"); 
        Console.WriteLine(car2 + " " + p2 + " $;"); 
        Console.WriteLine(car3 + " " + p3 + " $;"); 
        Console.WriteLine(car4 + " " + p4 + " $;"); 
        Console.WriteLine(car5 + " " + p5 + " $;");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Потрібно " + car1 + " (шт.)"); 
        unit1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Потрібно " + car2 + " (шт.)"); 
        unit2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Потрібно " + car3 + " (шт.)"); 
        unit3 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Потрібно " + car4 + " (шт.)"); 
        unit4 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Потрібно " + car5 + " (шт.)"); 
        unit5 = Convert.ToDouble(Console.ReadLine());
        Console.ResetColor();

        double cost1 = p1 * unit1;
        double cost2 = p2 * unit2;
        double cost3 = p3 * unit3;
        double cost4 = p4 * unit4;
        double cost5 = p5 * unit5;

        double discount = new Random().NextDouble() * 10;
        double discountT = Math.Round(discount, 2);

        double sum = cost1 + cost2 + cost3 + cost4 + cost5;
        double total = sum * (1 - discount / 100);

        total = Math.Round(total, 2);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Деталізація замовлення:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Вартість " + car1 + " за одиницю "  + p1 + "$" + ". Загальна: " + cost1 + " $.");
        Console.WriteLine("Вартість " + car2 + " за одиницю "  + p2 + "$" + ". Загальна: " + cost2 + " $.");
        Console.WriteLine("Вартість " + car3 + " за одиницю " + p3 + "$" + ". Загальна: " + cost3 + " $.");
        Console.WriteLine("Вартість " + car4 + " за одиницю "  + p4 + "$" + ". Загальна: " + cost4 + " $.");
        Console.WriteLine("Вартість " + car5 + " за одиницю " + p5 + "$" + ". Загальна: " + cost5 + " $.");    
      
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Знижка: " + discountT + " %");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Загальна вартість замовлення: " + total + " $.");

        Console.ReadKey();
    }
}
