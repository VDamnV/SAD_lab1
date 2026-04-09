using System;
using GameSimulator.Models;
using GameSimulator.Games;
using GameSimulator.UI;

// Налаштування консолі для коректного відображення української мови
Console.OutputEncoding = System.Text.Encoding.UTF8;
ConsoleLogger.LogMessage("=== СИМУЛЯТОР ІГОР ЗАПУЩЕНО ===\n");

// 1. Створюємо комп'ютер гравця (з достатньою кількістю пам'яті та підключенням до Інтернету)
var myPcSpecs = new SystemRequirements { CpuCores = 8, RamMB = 16384, GpuMemoryMB = 8192, FreeHddSpaceMB = 500000 };
var myPc = new PC(myPcSpecs, hasInternet: true);

// 2. Створюємо ігри різних жанрів
var ck3 = new StrategyGame("Crusader Kings III", new SystemRequirements { CpuCores = 4, RamMB = 8192, GpuMemoryMB = 4096 }, 10000);
var assetto = new SimulatorGame("Assetto Corsa", new SystemRequirements { CpuCores = 4, RamMB = 8192, GpuMemoryMB = 2048 }, 15000);
var casino = new OnlineCasino("NoWin Casino", new SystemRequirements { CpuCores = 2, RamMB = 4096, GpuMemoryMB = 512 });

// ВАЖЛИВО: Підписуємо наш обробник UI на події зміни стану в іграх!
ck3.OnGameStateChanged += ConsoleLogger.LogMessage;
assetto.OnGameStateChanged += ConsoleLogger.LogMessage;
casino.OnGameStateChanged += ConsoleLogger.LogMessage;

// 3. Створюємо гравця та додаємо ігри до його бібліотеки
var player = new Player("Студент");
player.AddGame(ck3);
player.AddGame(assetto);
player.AddGame(casino);

Console.WriteLine("\n[Натисніть Enter, щоб розпочати демонстрацію...]");
Console.ReadLine();

// --- СЦЕНАРІЙ 1 ---
Console.WriteLine("\n--- СЦЕНАРІЙ 1: Спроба запуску без інсталяції ---");
player.StartGame(ck3, myPc); // Має видати помилку, бо стратегія ще не встановлена
Console.WriteLine("\n[Натисніть Enter для переходу до наступного кроку...]");
Console.ReadLine();

// --- СЦЕНАРІЙ 2 ---
Console.WriteLine("\n--- СЦЕНАРІЙ 2: Інсталяція, запуск та збереження гри ---");
ck3.Install(myPc.Specs.FreeHddSpaceMB);
player.StartGame(ck3, myPc);
ck3.Play();
ck3.Save();
Console.WriteLine("\n[Натисніть Enter для переходу до наступного кроку...]");
Console.ReadLine();

// --- СЦЕНАРІЙ 3 ---
Console.WriteLine("\n--- СЦЕНАРІЙ 3: Блокування одночасного запуску двох ігор ---");
player.StartGame(assetto, myPc); // Має видати помилку, бо CK3 ще запущена
Console.WriteLine("\n[Натисніть Enter для переходу до наступного кроку...]");
Console.ReadLine();

// --- СЦЕНАРІЙ 4 ---
Console.WriteLine("\n--- СЦЕНАРІЙ 4: Робота з периферією (кермо у симуляторі) ---");
ck3.Stop(); // Зупиняємо поточну гру, щоб звільнити систему
assetto.Install(myPc.Specs.FreeHddSpaceMB);

var logitechWheel = new SteeringWheel("Logitech G29");
assetto.ConnectSteeringWheel(logitechWheel); // Підключаємо кермо

player.StartGame(assetto, myPc);
assetto.Play(); // Граємо з підключеним кермом

assetto.DisconnectSteeringWheel();
assetto.Play(); // Граємо вже без керма (якість падає)
assetto.Stop();
Console.WriteLine("\n[Натисніть Enter для переходу до наступного кроку...]");
Console.ReadLine();

// --- СЦЕНАРІЙ 5 ---
Console.WriteLine("\n--- СЦЕНАРІЙ 5: Браузерна онлайн-гра (без інсталяції) ---");
player.StartGame(casino, myPc); // Запускається одразу, перевіряється лише Інтернет
casino.Play();
casino.Stop();
Console.WriteLine("\n[Натисніть Enter для завершення...]");
Console.ReadLine();

ConsoleLogger.LogMessage("\n=== ДЕМОНСТРАЦІЮ УСПІШНО ЗАВЕРШЕНО ===");