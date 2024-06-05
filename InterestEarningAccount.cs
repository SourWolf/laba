namespace OOProgramming;

public class InterestEarningAccount : BankAccount

{
    // Конструктор класса InterestEarningAccount, наследующий от BankAccount
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {}

    // Переопределенный метод для выполнения операций в конце месяца
    public override void PerformMonthEndTransactions()
    {
      // Проверяем баланс и начисляем проценты, если баланс больше 500
      if (Balance > 500m)
      {
                decimal interest = Balance * 0.02m; // Рассчитываем проценты
                MakeDeposit(interest, DateTime.Now, "apply monthly interest"); // Добавляем проценты на счет
      }
    }
 }
