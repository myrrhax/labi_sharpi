namespace Lab2
{

    class Computer
    {
        private readonly List<ComputerTechnique> connectedDevices = new List<ComputerTechnique>();
        private readonly Processor processor;
        private readonly Motherboard motherboard;

        public Computer(Processor processor, Motherboard motherboard)
        {
            this.processor = processor;
            this.motherboard = motherboard;
        }

        public void CheckConnectedDevices()
        {
            foreach (var device in connectedDevices)
            {
                Console.WriteLine(device.Name);
            }
        }

        public List<ComputerTechnique> ConnectedDevices => connectedDevices;
        
        public void AddDevice(ComputerTechnique technique)
        {
            connectedDevices.Add(technique);
        }

        public void RemoveDevice(ComputerTechnique tech)
        {
            if (connectedDevices.Contains(tech))
            {
                connectedDevices.Remove(tech);
            }
        }
    }

    abstract class ComputerTechnique
    {
        public abstract string Name { get; }
        public void Connect() {
            Console.WriteLine($"Device {Name} connected");
        }
        public void Disconnect()
        {
            Console.WriteLine($"Device {Name} disconnected");
        }
    }

    class Mouse : ComputerTechnique, IDisposable
    {
        private readonly Computer computer;
        public int Ping { get; set; }
        public Mouse(Computer computer, int ping)
        {
            this.computer = computer;
            Ping = ping;
            computer.AddDevice(this);
        }
        public override string Name => "Компьютерная мышь";

        public void Dispose()
        {
            Console.WriteLine("Мышь сломалась об стену");
            computer.RemoveDevice(this);
        }

        ~Mouse()
        {
            Dispose();
        }

        public void Throw()
        {
            Dispose();
        }
    }

    class Monitor : ComputerTechnique
    {
        public override string Name => "Монитор";
    }

    class Printer : ComputerTechnique
    {
        public override string Name => "Принтер";
    }

    class Keyboard : ComputerTechnique
    {
        public override string Name => "Клавиатура";
    }

    abstract class DataStorage : ComputerTechnique
    {
        public abstract void AddData();
        public abstract void RemoveData();
    }

    class Motherboard
    {
        public string Name { get; private set; }
        public string Chipset { get; private set; }

        public Motherboard(string name, string chipset)
        {
            Name = name;
            Chipset = chipset;
        }
    }

    class Processor
    {
        public string Name { get; private set; }
        public int CoresCount { get; private set; }
        public int ThreadsCount { get; private set; }

        public Processor(string name, int coresCount, int threadsCount)
        {
            Name = name;
            CoresCount = coresCount;
            ThreadsCount = threadsCount;
        }
    }

    class HDD : DataStorage
    {
        public override string Name => "Жесткий диск";

        public override void AddData()
        {
            Console.WriteLine("Данные добавлены в жесткий диск");
        }

        public override void RemoveData()
        {
            Console.WriteLine("Данные удалены с жесткого диска");
        }
    }

    class Disk : DataStorage
    {
        public override string Name => "Внешний диск";

        public override void AddData()
        {
            Console.WriteLine("Данные добавлены во внешний диск");
        }

        public override void RemoveData()
        {
            Console.WriteLine("Данные удалены с внешнего    диска");
        }
    }

    class AudioSpeakers : ComputerTechnique
    {
        public override string Name => "Колонки";
    }

    class Doter
    {
        private readonly Computer computer;
        public Doter(Computer computer)
        {
            this.computer = computer;
        }

        public void Play()
        {
            foreach (ComputerTechnique ct in computer.ConnectedDevices)
            {
                if (ct is Mouse mouse)
                {
                    if (mouse.Ping > 110)
                    {
                        Console.WriteLine("чет пингует ща перезагружу тут слегка");
                        mouse.Throw();
                        return;
                    }
                }
            }
            Console.WriteLine("Мышь не подключена");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Processor cpu = new Processor("Ryzen 7 5800X", 8, 16);
            Motherboard motherboard = new Motherboard("Материнская плата", "AM4");
            Computer computer = new Computer(cpu, motherboard);
            ComputerTechnique mouse = new Mouse(computer,120);
            DataStorage hdd = new HDD();
            hdd.AddData();
            
            DataStorage disk = new Disk();
            disk.AddData();

            computer.AddDevice(hdd);
            computer.AddDevice(disk);

            AudioSpeakers audio = new AudioSpeakers();
            Keyboard keyboard = new Keyboard();
            Printer printer = new Printer();
            Monitor monitor = new Monitor();

            computer.AddDevice(audio);
            computer.AddDevice(keyboard);
            computer.AddDevice(printer);
            computer.AddDevice(monitor);

            computer.CheckConnectedDevices();

            Doter doter = new Doter(computer);
            doter.Play();
        }
    }
}
