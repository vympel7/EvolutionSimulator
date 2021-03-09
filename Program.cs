namespace Evolution
{
    class Program
    {
        static void Main()
        {
            Simulation sim = new Simulation(15);
            sim.Simulate(3, 50, true);
        }
    }
}
