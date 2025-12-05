using System;
using System.Text;

namespace LabWorkCycles
{
    // 1. Структура з мінімум 4 полями різних типів
    struct Product
    {
        public string Name;         // Назва
        public string Category;     // Категорія
        public double Price;        // Ціна
        public int Quantity;        // Кількість на складі

        // Конструктор для зручної ініціалізації
        public Product(string name, string category, double price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // 2. Система входу (Login System) з використанням do-while
            string correctPassword = "admin";
            string enteredPassword;
            int attempts = 0;
            const int maxAttempts = 3;
            bool accessGranted = false;

            Console.WriteLine("=== Система входу ===");
            do
            {
                Console.Write($"Спроба {attempts + 1}/{maxAttempts}. Введіть пароль: ");
                enteredPassword = Console.ReadLine();

                if (enteredPassword == correctPassword)
                {
                    accessGranted = true;
                    Console.WriteLine("Доступ дозволено!\n");
                }
                else
                {
                    Console.WriteLine("Невірний пароль.");
                    attempts++;
                }

            } while (!accessGranted && attempts < maxAttempts);

            // Якщо спроби вичерпано — завершуємо програму
            if (!accessGranted)
            {
                Console.WriteLine("Вичерпано ліміт спроб. Програма завершує роботу.");
                return; 
            }

            // Масив для зберігання товарів (мінімум 5 елементів)
            Product[] products = new Product[5];
            int productCount = 0; // Лічильник фактично доданих товарів

            // 3. Головне меню з використанням while
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Ввести дані про товари (цикл for)");
                Console.WriteLine("2. Показати всі товари");
                Console.WriteLine("3. Показати статистику (сума, середнє, min/max)");
                Console.WriteLine("4. Знайти товар дорожче певної суми (break)");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InputProducts(products, ref productCount);
                        break;
                    case "2":
                        DisplayProducts(products, productCount);
                        break;
                    case "3":
                        ShowStatistics(products, productCount);
                        break;
                    case "4":
                        FindExpensiveProduct(products, productCount);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Вихід з програми...");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        // Метод для введення даних (використання циклу for та обробки помилок)
        static void InputProducts(Product[] products, ref int currentCount)
        {
            Console.WriteLine("\n--- Введення даних про товари ---");
            
            // Вводимо 5 товарів (або менше, якщо масив вже частково заповнений)
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"\nТовар #{i + 1}");

                try
                {
                    Console.Write("Назва: ");
                    string name = Console.ReadLine();

                    Console.Write("Категорія: ");
                    string category = Console.ReadLine();

                    Console.Write("Ціна (грн): ");
                    // Обробка помилок при введенні чисел
                    if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
                    {
                        Console.WriteLine("Помилка: Некоректна ціна. Товар пропущено.");
                        continue; // continue: пропускаємо цю ітерацію, переходимо до наступної
                    }

                    Console.Write("Кількість: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                    {
                        Console.WriteLine("Помилка: Некоректна кількість. Товар пропущено.");
                        continue; 
                    }

                    // Використання конструктора
                    products[i] = new Product(name, category, price, quantity);
                    currentCount++; // Збільшуємо лічильник успішно доданих товарів
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Критична помилка введення: {ex.Message}");
                }
            }
            Console.WriteLine("\nВведення завершено.");
        }

        static void DisplayProducts(Product[] products, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Список товарів порожній.");
                return;
            }

            Console.WriteLine("\n--- Список товарів ---");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}", "Назва", "Категорія", "Ціна", "Кількість");
            
            for (int i = 0; i < products.Length; i++)
            {
                // Перевірка на порожній об'єкт (якщо назва null/empty, пропускаємо)
                if (string.IsNullOrEmpty(products[i].Name)) 
                    continue;

                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}", 
                    products[i].Name, products[i].Category, products[i].Price, products[i].Quantity);
            }
        }

        // Функція статистики (Сума, Середнє, Min/Max, Count if)
        static void ShowStatistics(Product[] products, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Дані відсутні для розрахунку статистики.");
                return;
            }

            double totalSum = 0;
            double maxPrice = double.MinValue;
            double minPrice = double.MaxValue;
            int itemsOver500 = 0;

            for (int i = 0; i < products.Length; i++)
            {
                // continue: пропускаємо порожні елементи масиву
                if (string.IsNullOrEmpty(products[i].Name)) continue;

                // Загальна вартість запасів (ціна * кількість)
                totalSum += products[i].Price * products[i].Quantity;

                // Пошук Min/Max
                if (products[i].Price > maxPrice) maxPrice = products[i].Price;
                if (products[i].Price < minPrice) minPrice = products[i].Price;

                // Умова: ціна > 500
                if (products[i].Price > 500) itemsOver500++;
            }

            double averagePrice = count > 0 ? totalSum / count : 0; // Умовне середнє (тут як приклад середньої вартості на позицію)

            Console.WriteLine("\n--- Статистика ---");
            Console.WriteLine($"Загальна вартість складу: {totalSum} грн");
            Console.WriteLine($"Середня вартість позиції: {totalSum/count:F2} грн"); // Простий розрахунок середнього
            Console.WriteLine($"Найдешевший товар: {minPrice} грн");
            Console.WriteLine($"Найдорожчий товар: {maxPrice} грн");
            Console.WriteLine($"Кількість товарів дорожче 500 грн: {itemsOver500}");
        }

        // Приклад використання break
        static void FindExpensiveProduct(Product[] products, int count)
        {
            Console.Write("\nВведіть поріг ціни для пошуку: ");
            if (double.TryParse(Console.ReadLine(), out double threshold))
            {
                bool found = false;
                for (int i = 0; i < products.Length; i++)
                {
                    if (string.IsNullOrEmpty(products[i].Name)) continue;

                    if (products[i].Price > threshold)
                    {
                        Console.WriteLine($"Знайдено перший товар дорожче {threshold}: {products[i].Name} ({products[i].Price} грн)");
                        found = true;
                        break; // break: зупиняємо пошук після першого знайденого елемента
                    }
                }
                if (!found) Console.WriteLine("Товарів з такою ціною не знайдено.");
            }
        }
    }
}