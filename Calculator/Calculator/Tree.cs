using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class GFG
    {
        public class nptr
        {
            public string data;
            public nptr left, right;
        };

        static nptr newNode(string c)
        {
            nptr n = new nptr();
            n.data = c;
            n.left = n.right = null;
            return n;
        }

        public static nptr build(String s)
        {

            Stack<nptr> stN = new Stack<nptr>();

            Stack<string> stC = new Stack<string>();
            nptr t, t1, t2;

            int[] p = new int[123];
            p['+'] = p['-'] = 1;
            p['/'] = p['*'] = 2;
            p['^'] = 3;
            p[')'] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stC.Push("(");
                }
                else if (char.IsDigit(s[i]))
                {
                    string holnum = "";
                    while (char.IsDigit(s[i]) || s[i] == '.')
                    {
                        holnum += s[i++];
                    }
                    t = newNode(holnum);
                    stN.Push(t);
                    i--;

                }
                else if (p[s[i]] > 0)
                {

                    while (stC.Count != 0 && stC.Peek() != "("
                        && ((s[i] != '^' && p[Convert.ToChar(stC.Peek())] >= p[s[i]])
                            || (s[i] == '^' && p[Convert.ToChar(stC.Peek())] > p[s[i]])))
                    {

                        t = newNode(stC.Peek());
                        stC.Pop();

                        t1 = stN.Peek();
                        stN.Pop();

                        t2 = stN.Peek();
                        stN.Pop();

                        t.left = t2;
                        t.right = t1;

                        stN.Push(t);
                    }

                    stC.Push(s[i].ToString());
                }
                else if (s[i] == ')')
                {
                    while (stC.Count != 0 && stC.Peek() != "(")
                    {
                        t = newNode(stC.Peek());
                        stC.Pop();
                        t1 = stN.Peek();
                        stN.Pop();
                        t2 = stN.Peek();
                        stN.Pop();
                        t.left = t2;
                        t.right = t1;
                        stN.Push(t);
                    }
                    stC.Pop();
                }
            }
            t = stN.Peek();
            return t;
        }
    }
}
