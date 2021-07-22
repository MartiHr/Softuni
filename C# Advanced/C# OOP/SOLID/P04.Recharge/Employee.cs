namespace P04.Recharge
{
    using System;

    public class Employee : ISleeper
    {
        public Employee(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }
    }
}
