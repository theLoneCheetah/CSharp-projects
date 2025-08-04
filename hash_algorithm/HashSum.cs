using System;

class HashSum
{
    private static int p = 31;
    private static int limit = 20;
    private static int[] p_pow;

    static HashSum()
    {
        p_pow = new int[limit];
        p_pow[0] = 1;

        for (int i = 1; i < limit; ++i)
            p_pow[i] = p_pow[i - 1] * p;
    }

    public static int Calculate_Hash(string str)
    {
        int hash = 0;

        for (int i = 0; i < str.Length; ++i)
            hash += (str[i] - 'a' + 1) * p_pow[i];

        return hash;
    }
}
