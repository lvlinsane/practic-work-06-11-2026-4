class Bus : Vehicle
{
    private int seatsCount;

    public int PassengersCount { get; private set; }

    public int SeatsCount
    {
        get { return seatsCount; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Количество мест должно быть больше 0");
            }

            seatsCount = value;
        }
    }

    public Bus(string brand, string model, int year, double speed,
               int seatsCount)
        : base(brand, model, year, speed)
    {
        SeatsCount = seatsCount;
        PassengersCount = 0;
    }

    public void BoardPassengers(int count)
    {
        if (count <= 0)
        {
            Console.WriteLine("Ошибка: количество пассажиров должно быть больше 0");
            return;
        }

        if (PassengersCount + count > SeatsCount)
        {
            int free = SeatsCount - PassengersCount;
            Console.WriteLine("Ошибка: нельзя посадить " + count + " пассажиров. Свободных мест: " + free);
            return;
        }

        PassengersCount += count;
        Console.WriteLine("Село " + count + " пассажиров. Сейчас в автобусе: " + PassengersCount + " из " + SeatsCount);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Тип: автобус");
        Console.WriteLine("Количество мест: " + SeatsCount);
        Console.WriteLine("Пассажиров сейчас: " + PassengersCount);
    }

    public override double CalculateFuelConsumption(double distance)
    {
        if (distance < 0)
        {
            throw new ArgumentException("Расстояние не может быть отрицательным");
        }

        return distance * 18 / 100;
    }
}
