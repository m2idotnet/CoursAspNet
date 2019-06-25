using System;
using System.Collections.Generic;
using System.Text;

namespace MesExtension
{
    public static class Extension
    {
        public static void Melanger<T>(this T[] objet)
        {
            Random r = new Random();
            for (int i = 0; i < objet.Length; i++)
            {
                int alea = r.Next(0, objet.Length - 1);
                T tmp = objet[i];
                objet[i] = objet[alea];
                objet[alea] = tmp;
            }
        }

        public static void Add(this int a, int b)
        {
            a += b;
        }
    }
}
