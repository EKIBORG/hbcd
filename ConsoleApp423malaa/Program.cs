using System;

namespace ShopSystem
{
    class Program
    {
        // Головна точка входу в програму
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Щоб коректно відображалась кирилиця
            Console.Title = "Лабораторна робота: Магазин Електроніки";
            
            Console.WriteLine("Вітаємо у системі керування магазином!");
            ShowMenu(); // Запуск рекурсивного меню
        }

        // --- ГОЛОВНЕ МЕНЮ (Рекурсивна функція) ---
        static void ShowMenu()
        {
            Console.WriteLine("\n--- ГОЛОВНЕ МЕНЮ ---");
            Console.WriteLine("1. Переглянути товари (Каталог)");
            Console.WriteLine("2. Розрахувати вартість покупки (з Лаб. 1)");
            Console.WriteLine("3. Інформація про магазин");
            Console.WriteLine("4. Налаштування");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            try
            {
                // Зчитуємо вибір користувача
                int choice = int.Parse(Console.ReadLine());

                // Обробка вибору через switch
                switch (choice)
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        CalculatePurchase(); // Інтеграція коду з попередньої роботи
                        break;
                    case 3:
                        ShowShopInfo();
                        break;
                    case 4:
                        ShowSettings(); // Це функція-заглушка
                        break;
                    case 0:
                        Console.WriteLine("Дякуємо, що скористалися нашою системою. До побачення!");
                        return; // Вихід з рекурсії, завершення програми
                    default:
                        Console.WriteLine("Помилка: Невірний номер пункту меню. Спробуйте ще раз.");
                        break;
                }
            }
            catch (FormatException)
            {
                // Обробка помилки, якщо ввели літери замість цифр
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Будь ласка, введіть числове значення!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Обробка будь-яких інших непередбачених помилок
                Console.WriteLine($"Виникла непередбачена помилка: {ex.Message}");
            }

            // Рекурсивний виклик меню (повернення користувача до вибору)
            ShowMenu();
        }

        // --- ФУНКЦІЇ РЕАЛІЗАЦІЇ ПУНКТІВ МЕНЮ ---

        // Пункт 1: Перегляд товарів (Проста реалізація)
        static void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("--- КАТАЛОГ ТОВАРІВ ---");
            Console.WriteLine("1. Ноутбук Gaming Pro - 45000 грн");
            Console.WriteLine("2. Мишка бездротова - 800 грн");
            Console.WriteLine("3. Клавіатура механічна - 2500 грн");
            Console.WriteLine("4. Монітор 27 дюймів - 9000 грн");
            Console.WriteLine("\nНатисніть Enter, щоб повернутися...");
            Console.ReadLine();
        }

        // Пункт 2: Розрахунок (Логіка з Лабораторної №1 + параметри ref/out)
        static void CalculatePurchase()
        {
            Console.Clear();
            Console.WriteLine("--- КАЛЬКУЛЯТОР ПОКУПКИ ---");

            try
            {
                Console.Write("Введіть ціну товару (грн): ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Введіть кількість (шт): ");
                int quantity = int.Parse(Console.ReadLine());

                if (price < 0 || quantity < 0)
                {
                    Console.WriteLine("Помилка: Числа не можуть бути від'ємними.");
                    return;
                }

                double total;
                // Виклик допоміжної функції для розрахунку
                CalculateTotal(price, quantity, out total);

                Console.WriteLine($"Загальна сума без знижки: {total} грн");

                // Застосування знижки, якщо сума велика (змінюємо total через ref)
                ApplyDiscount(ref total);

                Console.WriteLine($"Сума до сплати (зі знижкою): {total} грн");
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка введення даних! Потрібно вводити числа.");
            }
            
            Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
            Console.ReadLine();
        }

        // Допоміжна функція з параметром out
        static void CalculateTotal(double p, int q, out double result)
        {
            result = p * q;
        }

        // Допоміжна функція з параметром ref (змінює існуючу змінну)
        static void ApplyDiscount(ref double sum)
        {
            if (sum > 10000)
            {
                Console.WriteLine("Ваша покупка більше 10000 грн. Вам надано знижку 10%!");
                sum = sum * 0.9;
            }
            else
            {
                Console.WriteLine("Знижка не передбачена (сума менше 10000 грн).");
            }
        }

        // Пункт 3: Інформація
        static void ShowShopInfo()
        {
            Console.WriteLine("\n[Інфо]: Магазин 'IT-Світ'. Працюємо з 09:00 до 21:00. Тел: 555-1234");
        }

        // Пункт 4: Налаштування (Заглушка)
        static void ShowSettings()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[Увага]: Функція 'Налаштування' знаходиться в розробці.");
            Console.ResetColor();
        }
    }
}