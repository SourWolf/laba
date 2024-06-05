namespace OOProgramming;

public class Transaction // Объявление публичного класса Transaction.
{
    public decimal Amount { get; } // Свойство Amount для хранения суммы транзакции.
    public DateTime Date { get; } // Свойство Date для хранения даты транзакции.
    public string Notes { get; } // Свойство Notes для хранения заметок к транзакции.

    public Transaction(decimal amount, DateTime date, string note) // Конструктор класса Transaction, который принимает параметры amount, date и note и инициализирует соответствующие свойства класса.
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}
