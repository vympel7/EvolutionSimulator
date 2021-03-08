namespace Evolution
{
    class Program
    {
        static void Main()
        {
            Simulation sim = new Simulation(150);
            sim.Simulate(3, 20, true);
        }
    }
}
