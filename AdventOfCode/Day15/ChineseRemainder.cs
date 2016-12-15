namespace AdventOfCode.Day15
{
    using System;

    public class ChineseRemainder
    {
        // this... just doesn't work?
        public static int[] Euclidian(int a, int b)
        {
            if (b > a)
            {
                int[] coeffs = Euclidian(b, a);
                return new [] { coeffs[1], coeffs[0] };
            }

            int q = a / b;
            int r = a - q * b;

            if (r == 0)
            {
                return new [] { 0, 1 };
            }

            int[] next = Euclidian(b, r);

            return new[] { next[1], next[0] - q * next[1] };
        }

        public static int LeastPosEquiv(int a, int m)
        {
            if (m < 0)
            {
                return LeastPosEquiv(a, -1 * m);
            }

            if (a >= 0 && a < m)
            {
                return a;
            }

            if (a < 0)
            {
                return -1 * LeastPosEquiv(-1 * a, m) + 1;
            }

            int q = a / m;

            return a - q * m;
        }

        public static void Execute()
        {
            int[] constraints = { 0, 1, 2, 3, 4, 5 };
            int[] mods = { 17, 19, 7, 13, 5, 3 };

            int M = 1;

            for (int i = 0; i < mods.Length; i++)
            {
                M *= mods[i];
            }

            int[] multInv = new int[constraints.Length];

            for (int i = 0; i < multInv.Length; i++)
            {
                multInv[i] = Euclidian(M / mods[i], mods[i])[0];
            }

            int x = 0;

            for (int i = 0; i < mods.Length; i++)
            {
                x += (M / mods[i]) * constraints[i] * multInv[i];
            }

            x = LeastPosEquiv(x, M);
            var mod = M % x;
            var res1 = x / M;
            var res2 = M / x;

            Console.WriteLine($"x is equiv to {x} mod {M}");
            Console.WriteLine($"x {x} M {M} q {constraints} mods {mods}");
            Console.WriteLine($"RES {mod}");
            Console.WriteLine($"RES {res1}");
            Console.WriteLine($"RES {res2}");
            for (var i = 0; i < mods.Length; i++)
            {
                Console.WriteLine($"MULTINV i={i} == {multInv[i]}");
                Console.WriteLine($"CONSTRAINT i={i} == {constraints[i]}");
                Console.WriteLine($"MODS i={i} == {mods[i]}");
            }
        }
    }
}