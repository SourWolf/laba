namespace OOProgramming;

public class GiftCardAccount : BankAccount
{
    // Поле для хранения ежемесячного депозита
    private readonly decimal _monthlyDeposit = 0m;

    // Конструктор класса GiftCardAccount
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;
    // Переопределенный метод для выполнения операций в конце месяца
    public override void PerformMonthEndTransactions()
    {
        // Если установлен ежемесячный депозит, добавляем его
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
        }
    }

}
