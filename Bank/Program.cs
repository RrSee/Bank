public class CEO
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string position { get; set; }
    public int salary { get; set; }

    public CEO(Guid id, string name, string surname, int age, string position, int salary)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.position = position;
        this.salary = salary;
    }

    void control()
    {
        Console.WriteLine("Control");
    }

    void organize()
    {
        Console.WriteLine("Organize");
    }

    void makeMeeting()
    {
        Console.WriteLine("Meeting");
    }

    void decresasePercentage(int percent)
    {
        Console.Write("Faiz: ");
        Console.Write(percent);
    }

}

public class Worker
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string position { get; set; }
    public int salary { get; set; }
    public DateOnly startTime { get; set; }
    public DateOnly endTime { get; set; }
    public List<Operation> operationss { get; set; }

    public Worker(Guid id, string name, string surname, int age, string position, int salary, DateOnly startTime, DateOnly endTime)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.position = position;
        this.salary = salary;
        this.startTime = startTime;
        this.endTime = endTime;
    }

    void operations()
    {
        for (int i = 0; i < operationss.Count; i++)
        {
            Console.WriteLine(operationss[i]);
        }
    }

    void addOperations(Operation operation)
    {
        operationss.Add(operation);
    }
}

public class Manager
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string position { get; set; }
    public int salary { get; set; }

    public Manager(Guid id, string name, string surname, int age, string position, int salary, List<Worker> workers, List<CEO> ceos, List<Manager> managers)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.position = position;
        this.salary = salary;
    }

    void calculateSalaries(Bank bank)
    {
        bank.calculateSalaries();
    }
}

public class Operation
{
    public Guid id { get; set; }
    public string processName { get; set; }
    public DateOnly DateTime { get; set; }

    public Operation(Guid id, string processName, DateOnly dateTime)
    {
        this.id = id;
        this.processName = processName;
        DateTime = dateTime;
    }

}

public class Credit
{
    public Guid id { get; set; }
    public Client client { get; set; }
    public int amount { get; set; }
    public int percent { get; set; }
    public string month { get; set; }

    public Credit(Guid id, Client client, int amount, int percent, string month)
    {
        this.id = id;
        this.client = client;
        this.amount = amount;
        this.percent = percent;
        this.month = month;
    }

    void calculatePercent()
    {
        int x;
        int totall;
        x = (amount * 25) / 100;
        totall = amount + x;
        Console.WriteLine(totall);
    }

    void payment()
    {
        calculatePercent();
    }

    public void show()
    {
        Console.Write("id: ");
        Console.WriteLine(id);
        Console.Write("client: ");
        Console.WriteLine(client);
        Console.Write("amount: ");
        Console.WriteLine(amount);
    }

}

public class Client
{

    public Guid id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string liveAddress { get; set; }
    public string workAddress { get; set; }
    public int salary { get; set; }

    public Client(Guid id, string name, string surname, int age, string liveAddress, string workAddress, int salary)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.liveAddress = liveAddress;
        this.workAddress = workAddress;
        this.salary = salary;
    }
}

public class Bank
{
    public string NAME { get; set; }
    public int Budget { get; set; }
    public List<Worker> workers { get; set; }
    public List<CEO> ceos { get; set; }
    public List<Manager> managers { get; set; }
    public List<Client> clients { get; set; }
    public List<Credit> credits { get; set; }

    void showClientCredit(string name)
    {
        foreach(Credit credit in credits)
        {
            if (name == credit.client.name)
            {
                Console.WriteLine(credit.amount);
            }
        }
    }

    void payCredit(Client client, int money)
    {
        foreach (Credit credit in credits)
        {
            if (client ==  credit.client)
            {
                if (money <= credit.amount)
                {
                    credit.amount -= money;
                }
                else
                {
                    Console.WriteLine("Cox Mebleg!!!");
                }
            }
        }
    }

    void showAllCredits()
    {
        foreach(Credit credit in credits)
        {
            credit.show();
        }
    }

    public void calculateSalaries()
    {
        int total = 0;

        foreach (Worker worker in workers)
        {
            total += worker.salary;
        }

        foreach (CEO ceo in ceos)
        {
            total += ceo.salary;
        }

        foreach (Manager manager in managers)
        {
            total += manager.salary;
        }

        Console.WriteLine("Total Salaries: " + total);
    }
}
