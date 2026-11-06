class Truck : Vehicle
{
    private double loadCapacity;

    public double CurrentLoad { get; private set; }

    public double LoadCapacity
    {
        get { return loadCapacity; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Грузоподъёмность должна быть больше 0");
            }

            loadCapacity = value;
        }
    }

    public Truck(string brand, string model, int year, double speed,
                 double loadCapacity)
        : base(brand, model, year, speed)
    {
        LoadCapacity = loadCapacity;
        CurrentLoad = 0;
    }

    public void LoadCargo(double weight)
    {
        if (weight <= 0)
        {
            Console.WriteLine("Ошибка: вес груза должен быть больше 0");
            return;
        }

        if (CurrentLoad + weight > LoadCapacity)
        {
            double free = LoadCapacity - CurrentLoad;
            Console.WriteLine("Ошибка: нельзя загрузить " + weight + " кг. Свободно только " + free + " кг");
            return;
        }

        CurrentLoad += weight;
        Console.WriteLine("Загружено " + weight + " кг. Текущий груз: " + CurrentLoad + " из " + LoadCapacity + " кг");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Тип: грузовой автомобиль");
        Console.WriteLine("Грузоподъёмность: " + LoadCapacity + " кг");
        Console.WriteLine("Текущий груз: " + CurrentLoad + " кг");
    }

    public override double CalculateFuelConsumption(double distance)
    {
        if (distance < 0)
        {
            throw new ArgumentException("Расстояние не может быть отрицательным");
        }

        return distance * 25 / 100;
    }
}
