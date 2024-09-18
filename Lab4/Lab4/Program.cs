namespace Lab4
{
    class Program
    {
        delegate int ElectricSorce(string name, int maxPower, int currentPower);
        delegate int ElectricAppliance(string name, int maxPower, int currentPower);
        delegate int Wire(int maxPower, int currentPower);

        public static int SolarBattery(string name, int maxPower, int currentPower)
        {
            Console.WriteLine("солярка");
            if (currentPower >= maxPower) return 0;
            
            return maxPower - currentPower;
        }

        public static int DieselGenerator(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower) return 0;
            Console.WriteLine("дизелька");
            return maxPower - currentPower;
        }

        public static int NuclearPowerPlant(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower) return 0;
            Console.WriteLine("ядерка");
            return maxPower - currentPower;
        }

        public static int Kettle(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower)
            {
                Console.WriteLine("чайник сгорел");
                return -1;
            }
            Console.WriteLine("ура чайник");
            return currentPower;
        }

        public static int Lathe(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower)
            {
                Console.WriteLine("станок сгорел");
                return -1;
            }
            Console.WriteLine("ура станок там гаечки");
            return currentPower;
        }

        public static int Refridgerator(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower)
            {
                Console.WriteLine("холодос сгорел(((");
                return -1;
            }
            Console.WriteLine("холодильнички)");
            return currentPower;
        }

        public static int ElectricPowerStrip(int maxPower, int currentPower)
        {
            Console.WriteLine("проводок");
            if (currentPower >= maxPower) return currentPower;
            
            return maxPower - currentPower;
        }

        public static int HighLine(int maxPower, int currentPower)
        {
            Console.WriteLine("высоковольтная");
            if (currentPower >= maxPower) return currentPower;
            
            return maxPower - currentPower;
        }

        public static int StepDownTransformer(string name, int maxPower, int currentPower)
        {
            if (currentPower >= maxPower)
            {
                Console.WriteLine("трансформер сгорел:(");
                return 0;
            }
            return currentPower;
        }

        static event ElectricSorce Notify;

        static void Main(string[] args)
        {
            ElectricSorce es = SolarBattery;
            ElectricAppliance app = Refridgerator;
            Wire w = ElectricPowerStrip;

            es("соларка", 500, 29);
            app("холодрс", 29, 500);
            w(500, 29);

            Notify += es;
            Notify.Invoke("соларка", 29, 500);
        }
    }
}
