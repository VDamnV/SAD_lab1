using System;
using GameSimulator.Interfaces;
using GameSimulator.Models;

namespace GameSimulator.Games;

// Клас є абстрактним, бо ми не можемо створити просто "Гру", 
// це має бути конкретний жанр (Стратегія, Симулятор тощо)
public abstract class GameBase : IGame, ISaveable
{
    public string Title { get; }
    public string Genre { get; }
    public SystemRequirements MinRequirements { get; }
    public bool IsRunning { get; protected set; }
    public bool HasSavedState { get; protected set; }

    // Подія для зв'язку з UI (вимога лабораторної)
    public event Action<string>? OnGameStateChanged;

    protected GameBase(string title, string genre, SystemRequirements minRequirements)
    {
        Title = title;
        Genre = genre;
        MinRequirements = minRequirements;
    }

    // Захищений метод для зручного виклику події з класів-спадкоємців
    protected void NotifyStateChanged(string message)
    {
        OnGameStateChanged?.Invoke(message);
    }

    // Реалізація запуску гри (Template Method)
    public virtual void Start(PC computer)
    {
        if (IsRunning)
        {
            NotifyStateChanged("Гра вже запущена.");
            return;
        }

        // Викликаємо абстрактний метод, який реалізують нащадки
        if (!CheckPrerequisites(computer))
        {
            NotifyStateChanged("Запуск скасовано: не виконані системні вимоги або передумови.");
            return;
        }

        IsRunning = true;
        NotifyStateChanged("Гру успішно запущено.");
    }

    public virtual void Stop()
    {
        if (!IsRunning) return;
        IsRunning = false;
        NotifyStateChanged("Гру зупинено.");
    }

    // Логіка збереження/завантаження спільна для всіх ігор (вимога: "В кожній грі можна зберегти поточний стан")
    public virtual void Save()
    {
        if (!IsRunning)
        {
            NotifyStateChanged("Помилка збереження: неможливо використовувати функціонал, доки гру не запущено.");
            return;
        }
        HasSavedState = true;
        NotifyStateChanged("Поточний стан гри збережено.");
    }

    public virtual void Load()
    {
        if (!IsRunning)
        {
            NotifyStateChanged("Помилка завантаження: неможливо використовувати функціонал, доки гру не запущено.");
            return;
        }
        if (!HasSavedState)
        {
            NotifyStateChanged("Помилка: немає збережених станів для завантаження.");
            return;
        }
        NotifyStateChanged("Збережений стан успішно завантажено.");
    }

    public void Play()
    {
        if (!IsRunning)
        {
            NotifyStateChanged("Помилка: неможливо грати в незапущену гру.");
            return;
        }
        ExecutePlayAction();
    }

    // --- АБСТРАКТНІ МЕТОДИ ---
    // Кожна конкретна гра повинна реалізувати свої правила перевірки ПК
    protected abstract bool CheckPrerequisites(PC computer);
    
    // Кожна гра має свій унікальний ігровий процес
    protected abstract void ExecutePlayAction();
}