namespace OOProgramming;

class LineOfCreditAccount : BankAccount
{
 
    // Конструктор класса LineOfCreditAccount, наследующий от BankAccount
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {}

    // Переопределенный метод для выполнения операций в конце месяца
    public override void PerformMonthEndTransactions()
    {
        if (Balance < 0)
        {
            // Преобразуем отрицательный баланс для расчета положительной процентной ставки:
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }

    // Защищенный метод для проверки лимита снятия и применения комиссии за овердрафт
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;

}
