using System;
using System.Collections.Generic;

namespace Evolution
{
    class Program
    {
        static void Main()
        {
            Simulation sim = new Simulation();
            sim.Simulate(3, 50, true);
        }
    }
}
