``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6650U CPU 2.20GHz, ProcessorCount=4
Frequency=2156248 Hz, Resolution=463.7685 ns, Timer=TSC
  [Host] : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2046.0
  Clr    : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2046.0
  Core   : .NET Core 4.6.25009.03, 64bit RyuJIT


```
 |                   Method |  Job | Runtime |       Mean |    StdErr |    StdDev |  Gen 0 | Allocated |
 |------------------------- |----- |-------- |----------- |---------- |---------- |------- |---------- |
 |          'return result' |  Clr |     Clr |  0.3436 ns | 0.0099 ns | 0.0382 ns |      - |       0 B |
 | 'Value task read result' |  Clr |     Clr |  7.9589 ns | 0.1040 ns | 0.3891 ns | 0.0296 |      64 B |
 |          Task.FromResult |  Clr |     Clr | 13.2926 ns | 0.1092 ns | 0.4228 ns | 0.0678 |     144 B |
 |    'async return result' |  Clr |     Clr | 88.7455 ns | 0.3748 ns | 1.4516 ns | 0.0655 |     144 B |
 |       'async value task' |  Clr |     Clr | 82.7492 ns | 0.4181 ns | 1.6194 ns | 0.0272 |      64 B |
 |          'return result' | Core |    Core |  0.3249 ns | 0.0103 ns | 0.0397 ns |      - |       0 B |
 | 'Value task read result' | Core |    Core |  2.5969 ns | 0.0971 ns | 0.3761 ns | 0.0296 |      64 B |
 |          Task.FromResult | Core |    Core |  5.5962 ns | 0.1353 ns | 0.5064 ns | 0.0639 |     136 B |
 |    'async return result' | Core |    Core | 35.5210 ns | 0.2930 ns | 1.0563 ns | 0.0615 |     136 B |
 |       'async value task' | Core |    Core | 40.6530 ns | 0.3030 ns | 1.1737 ns | 0.0272 |      64 B |
