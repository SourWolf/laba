namespace OOProgramming;

public class BankAccount
{
    // Свойства счета
    public string Number {get;} 
    public string Owner {get; set;}
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    private static int s_accountNumberSeed = 1234567890;

    // Поля класса
    private readonly decimal _minimumBalance;

    // Конструкторы класса
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    // Хранение всех транзакций счета
    private readonly List<Transaction> _allTransactions = new();

    // Метод для внесения депозита
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    // Метод для снятия средств
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);
    }

    // Проверка лимита на снятие средств
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;
        }
    }

    // Получение истории операций по счету
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine("item.Date.ToShortDateString()item.Amountbalanceitem.Notes");
        }

        return report.ToString();
    }

    // Добавлено для учебного пособия:

    // Виртуальный метод для выполнения операций в конце месяца
    public virtual void PerformMonthEndTransactions() { }
 }