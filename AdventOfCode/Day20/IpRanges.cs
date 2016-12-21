namespace AdventOfCode.Day20
{
    using System;
    using System.CodeDom;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class IpRanges
    {
        private BigArray<ulong> _allIps;

        private BigArray<uint> _removedIps;

        public IpRanges()
        {
            _allIps = new BigArray<ulong>(uint.MaxValue);

            for (uint i = 0; i < _allIps.Length; i++)
            {
                _allIps[i] = i;
            }
        }

        public void RemoveInvalidRanges(string input)
        {
            var lines = input.Replace("\r", "").Split('\n');

            foreach (var line in lines)
            {
                var split = line.Split('-');
                var start = uint.Parse(split[0]);
                var end = uint.Parse(split[1]);

                for (var j = start; j < (long)end + 1; j++)
                {
                    _allIps[j] = 0;
                }

                Console.WriteLine($"Removed entries. Left: {_allIps.Count(i => i != 0)}");
            }
        }

        public ulong GetMin()
        {
            return _allIps.Min();
        }
    }

    class BigArray<T> : IEnumerable<T>
    {
        // These need to be const so that the getter/setter get inlined by the JIT into 
        // calling methods just like with a real array to have any chance of meeting our 
        // performance goals.
        //
        // BLOCK_SIZE must be a power of 2, and we want it to be big enough that we allocate
        // blocks in the large object heap so that they don’t move.
        internal const int BLOCK_SIZE = 524288;
        internal const int BLOCK_SIZE_LOG2 = 19;


        // Don’t use a multi-dimensional array here because then we can’t right size the last
        // block and we have to do range checking on our own and since there will then be 
        // exception throwing in our code there is a good chance that the JIT won’t inline.
        T[][] _elements;
        ulong _length;


        // maximum BigArray size = BLOCK_SIZE * Int.MaxValue
        public BigArray(ulong size)
        {
            int numBlocks = (int)(size / BLOCK_SIZE);
            if ((ulong)(numBlocks * BLOCK_SIZE) < size)
            {
                numBlocks += 1;
            }


            _length = size;
            _elements = new T[numBlocks][];
            for (int i = 0; i < (numBlocks - 1); i++)
            {
                _elements[i] = new T[BLOCK_SIZE];
            }
            // by making sure to make the last block right sized then we get the range checks 
            // for free with the normal array range checks and don’t have to add our own
            _elements[numBlocks - 1] = new T[BLOCK_SIZE];
        }


        public ulong Length
        {
            get
            {
                return _length;
            }
        }


        public T this[ulong elementNumber]
        {
            // these must be _very_ simple in order to ensure that they get inlined into
            // their caller 
            get
            {
                ulong blockSizeMinus = BLOCK_SIZE - 1;
                int blockNum = (int)(elementNumber >> BLOCK_SIZE_LOG2);
                int elementNumberInBlock = (int)(elementNumber & blockSizeMinus);
                return _elements[blockNum][elementNumberInBlock];
            }
            set
            {
                ulong blockSizeMinus = BLOCK_SIZE - 1;
                int blockNum = (int)(elementNumber >> BLOCK_SIZE_LOG2);
                int elementNumberInBlock = (int)(elementNumber & blockSizeMinus);
                _elements[blockNum][elementNumberInBlock] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this._elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}