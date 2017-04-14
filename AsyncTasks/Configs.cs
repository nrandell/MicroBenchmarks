using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncTasks
{
    public static class Configs
    {
        public class Full : ManualConfig
        {
            public Full()
            {
                Add(new MemoryDiagnoser());
            }
        }

        public class Memory : ManualConfig
        {
            public Memory() => Add(new MemoryDiagnoser());
        }
    }
}
