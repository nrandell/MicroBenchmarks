using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTasks
{
    [ClrJob, CoreJob]
    [Config(typeof(Configs.Memory))]
    public class AsyncTaskBenchmarks
    {
        public bool Flag { get; set; }
        private readonly int _result = 1234;

        [Benchmark(Description = "return result")]
        public int SyncReadResult()
        {
            if (Flag)
            {
                Task.Delay(1).GetAwaiter().GetResult();
            }
            return _result;
        }

        [Benchmark(Description = "Value task read result")]
        public ValueTask<int> ValueTaskReadResult()
        {
            if (Flag)
            {
                return new ValueTask<int>(Task.Delay(1).ContinueWith(_ => _result));
            }
            else
            {
                return new ValueTask<int>(_result);
            }

        }

        [Benchmark(Description = "Task.FromResult")]
        public Task<int> TaskReadResult()
        {
            if (Flag)
            {
                return Task.Delay(1).ContinueWith(_ => _result);
            }
            else
            {
                return Task.FromResult(_result);
            }
        }

        [Benchmark(Description = "async return result")]
        public async Task<int> AsyncReadResult()
        {
            if (Flag)
            {
                await Task.Delay(1);
            }
            return _result;
        }

        [Benchmark(Description = "async value task")]
        public async ValueTask<int> AsyncValueTaskReadResult()
        {
            if (Flag)
            {
                await Task.Delay(1);
            }
            return _result;
        }

    }
}
