using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;

namespace AsyncTasks
{
    [ClrJob, CoreJob]
    [Config(typeof(Configs.Memory))]
    public class DictionaryBenchmarks
    {
        private static readonly string Paragraphs = @"Draconically psittacistic analyse unaccused barmy reexporter valerian king eurasian deodorizing renownedly dianthuses poppied hieracosphinxes. Ross lucubration louhi inurn adonis joe bellows bountiful yaw apologetically superattractive goosewing dignitary grand. Unpopularly deactivated undampened pseudobrotherly apperception formalizing overtalkative carpetbagging thermoelectric unlevelled prohibitive trierarch cation iniquity. Atrioventricular decahedron sahara grumpy robotized bedeswomen lamarck silurid anaglyphical belomancy bignoniaceous easygoing skywrite hallway. Pedological brodehurst kolkoz fulfil swatheable submicroscopically bagasse untraversable dharmashastra quill orbiculately unsoundly antibacchic divulgate. 
Thing talys tool undropsical unsufferable gjukung ungerminated thyroxin returnee petrovsk prediscriminator bragi anchovy peleus. Spirantism antiaggressive temesvï¾¡r superhumeral deescalation interequinoctial span northerliness ugly tellurize ahmadi zurv unceded kumamoto. Mover nondecalcification thomsen acervulus interdebating frugging austrian retailer nonministerial whip uncomplained woodworm fleury glottalization. Unshoved tentation leasing arbitral rottweiler acton unsonantal ashamedness feverishly misologist episcopizing austerlitz anchiale unaccompanied. Testosterone procity argenteous shopworn swan momence humbugging feuilletonistic laurens panguingue strode meteoritic unfrictioned adverb. 
Conglutinative haustellum fussiness stoichiometric renullification jalisco paleface foolishness mho subtrihedral anergic verger shawllike corner. Semiprivate unidealistic brig prefabbing suomi uneffectible hosannaed tarde metaphrastical beauvais orbicularity orontes variform quebecker. Sublimed nonusurping untapestried ginnungagap satyrid susurrant unround rosily primp lignifying epitomised vitellus acetometry also. Tsarevna vicennial neocolonialism hackly nonlarcenous fiddlerfishes artfully haugh sloughiness antipopularization sapsucker landau westpreussen menshevik. Craniology preanesthetic rembrandtesque unfoxed nonreceipt esterase bemean untakable walrus bankbook pamperer indonesia gastrula stickit.";

        private static readonly string[] Words = Paragraphs.Split(' ', '\n', '\r').Take(20).ToArray();

        private static Random CreateRandom() => new Random(1111111);


        [Params(0, 1, 10, 50)]
        public int Loops { get; set; }

        [Benchmark(Description = "Ordinary dictionary")]
        public void DictionaryOnly()
        {
            var random = CreateRandom();
            var dictionary = new Dictionary<string, int>();
            for (var i = 0; i < Loops; i++)
            {
                var word = Words[random.Next(Words.Length)];
                dictionary.TryGetValue(word, out var value);
                dictionary[word] = value + 1;
            }
        }

        private class IntRefProperty
        {
            public int Counter { get; set; }
        }

        [Benchmark(Description = "Int ref property dictionary")]
        public void IntRefPropertyDictionary()
        {
            var random = CreateRandom();
            var dictionary = new Dictionary<string, IntRefProperty>();
            for (var i = 0; i < Loops; i++)
            {
                var word = Words[random.Next(Words.Length)];
                if (!dictionary.TryGetValue(word, out var value))
                {
                    value = new IntRefProperty();
                    dictionary[word] = value;
                }
                value.Counter += 1;
            }
        }

        private class IntRefField
        {
            public int _counter = 0;
        }

        [Benchmark(Description = "Int ref field dictionary")]
        public void IntRefFieldDictionary()
        {
            var random = CreateRandom();
            var dictionary = new Dictionary<string, IntRefField>();
            for (var i = 0; i < Loops; i++)
            {
                var word = Words[random.Next(Words.Length)];
                if (!dictionary.TryGetValue(word, out var value))
                {
                    value = new IntRefField();
                    dictionary[word] = value;
                }
                value._counter += 1;
            }
        }

    }
}
