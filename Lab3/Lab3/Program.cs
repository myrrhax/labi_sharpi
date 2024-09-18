namespace Lab3
{
    interface IElectricSource
    {
        int Voltage { get; }
        int MaxPower { get; }
        List<IElectricAppliance> Appliances { get; }
        void AddAppliance(IElectricAppliance appliance);
        void RemoveAppliance(IElectricAppliance appliance);
    }

    interface IElectricAppliance
    {
        int Voltage { get; }
        int MaxPower { get; }
        string Name { get; }
        int Power { get; }
    }

    interface IElectricWire
    {
        int Voltage { get; }
        int MaxPower { get; }
        bool Isolation { get; set; }
        List<IElectricAppliance> Appliances { get; }
        void AddAppliance(IElectricAppliance appliance);
        void RemoveAppliance(IElectricAppliance appliance);
    }

    interface IEntity
    {
        public bool IsAlive { get; set; }
    }

    interface IElectric : IEntity, IDisposable
    {
        public void WorkWithWire(IElectricWire wire);
    }

    class RealElectric : IElectric
    {
        public bool IsAlive { get; set; } = true;

        public void Dispose()
        {
            Console.WriteLine("Электрик умер");
        }

        ~RealElectric()
        {
            Dispose();
        }

        public void WorkWithWire(IElectricWire wire)
        {
            if (!wire.Isolation)
            {
                Console.WriteLine("Электрика убило током");
                IsAlive = false;
                Dispose();
                return;
            }
            Console.WriteLine("Электрик поработал с проводом");
        }
    }

    class SolarBattery : IElectricSource
    {
        private int _voltage = 220;
        private int _maxPower = 220;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();
        public int Voltage => _voltage;
        public int MaxPower => _maxPower;
        public List<IElectricAppliance> Appliances => _appliances;

        public SolarBattery() { }

        public SolarBattery(int voltage, int maxPower)
        {
            _voltage = voltage;
            _maxPower = maxPower;
        }

        public void AddAppliance(IElectricAppliance appliance)
        {

            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к солнечной батарее");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от солнечной батареи");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }

    class DieselGenerator : IElectricSource
    {
        private int _voltage = 220;
        private int _maxPower = 220;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();
        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public List<IElectricAppliance> Appliances => _appliances;

        public void AddAppliance(IElectricAppliance appliance)
        {

            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к дизельному генератору");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от дизельного генератора");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }

    class NuclearPowerPlant : IElectricSource
    {
        private int _voltage = 220;
        private int _maxPower = 220;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();
        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public List<IElectricAppliance> Appliances => _appliances;

        public void AddAppliance(IElectricAppliance appliance)
        {

            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к АЭС");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от АЭС");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }

    class Kettle : IElectricAppliance
    {
        private int _voltage;
        private int _maxPower;
        private int _power;
        
        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public string Name { get; } = "Чайник";

        public int Power => _power;

        public Kettle(int voltage, int maxPower, int power)
        {
            _voltage = voltage;
            _maxPower = maxPower;
            _power = power;
            Console.WriteLine("Электрочайник создан");
        }
    }

    class Lathe : IElectricAppliance
    {
        private int _voltage;
        private int _maxPower;
        private int _power;

        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public string Name => "Токарный станок";

        public int Power => _power;

        public Lathe(int voltage, int maxPower, int power)
        {
            _voltage = voltage;
            _maxPower = maxPower;
            _power = power;
            Console.WriteLine("Токарный станок создан");
        }
    }

    class Refrigerator : IElectricAppliance
    {
        private int _voltage;
        private int _maxPower;
        private int _power;

        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public string Name => "Холодильник";

        public int Power => _power;

        public Refrigerator(int voltage, int maxPower, int power)
        {
            _voltage = voltage;
            _maxPower = maxPower;
            _power = power;
            Console.WriteLine("Холодильник создан");
        }
    }

    class ElectricPowerStrip : IElectricWire
    {
        private int _voltage;
        private int _maxPower;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();

        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public List<IElectricAppliance> Appliances => _appliances;

        public bool Isolation { get; set; }

        public ElectricPowerStrip(int voltage, int maxPower)
        {
            _voltage = voltage;
            _maxPower = maxPower;
        }

        public void AddAppliance(IElectricAppliance appliance)
        {

            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к Удлинителю");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от удлинителя");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }

    class HighLine : IElectricWire
    {
        private int _voltage;
        private int _maxPower;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();

        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public List<IElectricAppliance> Appliances => _appliances;

        public bool Isolation { get; set; } = false;

        public HighLine(int voltage, int maxPower)
        {
            _voltage = voltage;
            _maxPower = maxPower;
        }

        public void AddAppliance(IElectricAppliance appliance)
        {

            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к Высковольтной линии");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от Высоковольтной линии");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }

    class StepDownTransformer : IElectricAppliance, IElectricSource
    {
        private int _voltage;
        private int _maxPower;
        private List<IElectricAppliance> _appliances = new List<IElectricAppliance>();
        private int _power;
        public int Voltage => _voltage;

        public int MaxPower => _maxPower;

        public string Name => "Трансформатор";

        public int Power => _power;

        public List<IElectricAppliance> Appliances => _appliances;

        public void AddAppliance(IElectricAppliance appliance)
        {
            if (appliance.Voltage < Voltage)
            {
                Console.WriteLine("Элемент может перегореть");
                return;
            }
            Console.WriteLine("Элемент добавлен к Высковольтному трансформатору");
            _appliances.Add(appliance);
        }

        public void RemoveAppliance(IElectricAppliance appliance)
        {
            Console.WriteLine("Элемент отсоединен от Высоковольтного трансформатора");
            if (_appliances.Contains(appliance)) _appliances.Remove(appliance);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            IElectric oleg = new RealElectric();

            IElectricWire wire = new HighLine(220, 500)
            {
                Isolation = true,
            };
            oleg.WorkWithWire(wire);

            IElectricWire wire2 = new HighLine(220, 500);
            oleg.WorkWithWire(wire2);
        }
    }
}
