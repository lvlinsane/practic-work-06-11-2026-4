Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(new Car("Toyota", "Camry", 2020, 0, 5, 8));
vehicles.Add(new Car("Lada", "Vesta", 2018, 0, 5, 8));
vehicles.Add(new Truck("KAMAZ", "5490", 2019, 0, 20000));
vehicles.Add(new Truck("Volvo", "FH", 2012, 0, 25000));
vehicles.Add(new Bus("MAN", "Lion's City", 2021, 0, 40));
vehicles.Add(new Bus("Ikarus", "280", 1995, 0, 60));

Console.WriteLine("=== Список всех транспортных средств ===");
Console.WriteLine();

foreach (Vehicle v in vehicles)
{
    v.DisplayInfo();
    Console.WriteLine("----------------------------");
}

Console.WriteLine();
Console.WriteLine("=== Поиск по идентификатору ===");
Console.WriteLine();

int[] searchIds = { 3, 99 };

foreach (int searchId in searchIds)
{
    Vehicle found = null;

    foreach (Vehicle v in vehicles)
    {
        if (v.Id == searchId)
        {
            found = v;
        }
    }

    if (found != null)
    {
        Console.WriteLine("Найден транспорт с ID " + searchId + ":");
        found.DisplayInfo();
    }
    else
    {
        Console.WriteLine("Транспорт с ID " + searchId + " не найден");
    }

    Console.WriteLine();
}

int cars = 0;
int trucks = 0;
int buses = 0;

foreach (Vehicle v in vehicles)
{
    if (v is Car)
    {
        cars++;
    }
    else if (v is Truck)
    {
        trucks++;
    }
    else if (v is Bus)
    {
        buses++;
    }
}

Console.WriteLine("=== Количество транспорта по типам ===");
Console.WriteLine();
Console.WriteLine("Легковых автомобилей: " + cars);
Console.WriteLine("Грузовых автомобилей: " + trucks);
Console.WriteLine("Автобусов: " + buses);
Console.WriteLine("Всего: " + vehicles.Count);
Console.WriteLine();

Vehicle oldest = vehicles[0];
Vehicle newest = vehicles[0];

foreach (Vehicle v in vehicles)
{
    if (v.Year < oldest.Year)
    {
        oldest = v;
    }

    if (v.Year > newest.Year)
    {
        newest = v;
    }
}

Console.WriteLine("=== Самое старое и самое новое ===");
Console.WriteLine();
Console.WriteLine("Самое старое: " + oldest.Brand + " " + oldest.Model + ", " + oldest.Year + " год");
Console.WriteLine("Самое новое: " + newest.Brand + " " + newest.Model + ", " + newest.Year + " год");
Console.WriteLine();

double distance = 300;

Console.WriteLine("=== Расход топлива на " + distance + " км ===");
Console.WriteLine();

foreach (Vehicle v in vehicles)
{
    Console.WriteLine(v.GetType().Name + " " + v.Brand + " " + v.Model + ": "
        + v.CalculateFuelConsumption(distance) + " л");
}
