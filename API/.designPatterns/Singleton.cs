namespace SingletonPattern
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }


        class Program
        {
            static void Main(string[] args)
            {
                Singleton fromTeachaer = Singleton.GetInstance;
                fromTeachaer.PrintDetails("From Teacher");
                Singleton fromStudent = Singleton.GetInstance;
                fromStudent.PrintDetails("From Student");
                Console.ReadLine();
            }
        }
    }
}