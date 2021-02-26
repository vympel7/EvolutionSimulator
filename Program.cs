using System;
using System.Collections.Generic;

namespace Evolution
{
    class Program
    {
        static void Main()
        {
            List<Creature> cs = new List<Creature>();

            for (int i = 0; i < 100; i++) cs.Add(new Creature());
        }
    }
}
