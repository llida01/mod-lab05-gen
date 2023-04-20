using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace generator
{
    public class Bigramm
    {
        Dictionary<char, Dictionary<char, int>> stat = new Dictionary<char, Dictionary<char, int>>();
        private string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public string text = "";
        public Bigramm()
        {
            size = syms.Length;
            data = syms.ToCharArray();
            ReadFile();
        }
        public void ReadFile()
        {
            StreamReader f = new StreamReader("bigramm.txt");
            char str = 'а';
            while (!f.EndOfStream)
            {
                if (str != 'ъ')
                {
                    Dictionary<char, int> tmp_s = new Dictionary<char, int>();
                    string[] temp = f.ReadLine().Split();
                    char tmp_str = 'а';
                    for (int i = 0; i < 31; ++i)
                    {
                        tmp_s.Add(tmp_str, int.Parse(temp[i]));
                        tmp_str++;
                        if (tmp_str == 'ъ')
                        {
                            tmp_str++;
                        }
                    }
                    stat.Add(str, tmp_s);
                    str++;
                }
                else
                {
                    str++;
                }
            }
        }
        public void ToFile(string name)
        {
            StreamWriter file = new StreamWriter(name);
            file.WriteLine(text);
            file.Close();
        }
        public int Count(char c)
        {
            int count = 0;
            foreach (var tmp in stat[c])
            {
                count += tmp.Value;
            }
            return count;
        }
        public char GetSym(char c)
        {
            Dictionary<char, int> tmp_s = stat[c];
            int sum = Count(c);
            int next = random.Next(0, sum);
            int curr = 0;
            char next_ch = ' ';
            foreach (var cur_s in tmp_s)
            {
                curr += cur_s.Value;
                if (next < curr)
                {
                    next_ch = cur_s.Key;
                    break;
                }
            }
            return next_ch;
        }
        public (string, int) Generate(int len)
        {
            SortedDictionary<char, int> result = new SortedDictionary<char, int>();
            double sum = 0;
            char next_ch = data[random.Next(0, size)];
            if (result.ContainsKey(next_ch))
                result[next_ch]++;
            else
                result.Add(next_ch, 1); Console.Write(next_ch);
            text += next_ch;
            for (int i = 0; i < (len - 1); i++)
            {
                next_ch = GetSym(next_ch);
                if (result.ContainsKey(next_ch))
                    result[next_ch]++;
                else
                    result.Add(next_ch, 1);
                Console.Write(next_ch);
                text += next_ch;
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in result)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / (double)len);
                sum += (entry.Value / (double)len);
            }
            (string, int) answ = (text, (int)sum);
            return answ;
        }
    }
    public class FrequencyWords
    {
        Dictionary<string, int> stat = new Dictionary<string, int>();
        private Random random = new Random();
        public string text = "";
        public FrequencyWords()
        {
            ReadFile();
        }
        public void ReadFile()
        {
            StreamReader f = new StreamReader("frequency_words.txt");
            while (!f.EndOfStream)
            {
                string[] tmp = f.ReadLine().Split();
                stat.Add(tmp[0], int.Parse(tmp[1]));
            }
        }
        public void ToFile(string name)
        {
            StreamWriter file = new StreamWriter(name);
            file.WriteLine(text);
            file.Close();
        }
        public int Count()
        {
            int count = 0;
            foreach (KeyValuePair<string, int> cur_w in stat)
            {
                count += cur_w.Value;
            }
            return count;
        }
        public string GetSym()
        {
            int sum = Count();
            int next = random.Next(0, sum);
            int curr = 0;
            string next_w = "";
            foreach (KeyValuePair<string, int> cur_w in stat)
            {
                curr += cur_w.Value;
                if (next < curr)
                {
                    next_w = cur_w.Key;
                    break;
                }
            }
            return next_w;
        }
        public (string, int) Generate(int len)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();
            double sum = 0;
            for (int i = 0; i < len; ++i)
            {
                string next_ch = GetSym();
                if (result.ContainsKey(next_ch))
                    result[next_ch]++;
                else
                    result.Add(next_ch, 1);
                Console.Write(next_ch + " ");
                text += (next_ch + " ");
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, int> entry in result)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / (double)len);
                sum += (entry.Value / (double)len);

            }
            (string, int) answ = (text, (int)sum);
            return answ;
        }
    }
    public class PairsWords
    {
        Dictionary<string, int> stat = new Dictionary<string, int>();
        private Random random = new Random();
        public string text = "";
        public PairsWords()
        {
            ReadFile();
        }
        public void ReadFile()
        {
            StreamReader f = new StreamReader("pairs_words.txt");
            while (!f.EndOfStream)
            {
                string[] tmp = f.ReadLine().Split('|');
                stat.Add(tmp[0], int.Parse(tmp[1]));
            }
        }
        public void ToFile(string name)
        {
            StreamWriter file = new StreamWriter(name);
            file.WriteLine(text);
            file.Close();
        }
        public int Count()
        {
            int count = 0;
            foreach (KeyValuePair<string, int> cur_w in stat)
            {
                count += cur_w.Value;
            }
            return count;
        }
        public string GetSym()
        {
            int sum = Count();
            int next = random.Next(0, sum);
            int curr = 0;
            string next_w = "";
            foreach (KeyValuePair<string, int> cur_w in stat)
            {
                curr += cur_w.Value;
                if (next < curr)
                {
                    next_w = cur_w.Key;
                    break;
                }
            }
            return next_w;
        }
        public (string, int) Generate(int len)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();
            double sum = 0;
            for (int i = 0; i < len; ++i)
            {
                string next_w = GetSym();
                if (result.ContainsKey(next_w))
                    result[next_w]++;
                else
                    result.Add(next_w, 1);
                Console.Write(next_w + " ");
                text += (next_w + " ");
            }
            Console.Write('\n');
            foreach (KeyValuePair<string, int> entry in result)
            {
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value / (double)len);
                sum += (entry.Value / (double)len);
            }
            (string, int) answ = (text, (int)sum);
            return answ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bigramm g1 = new Bigramm();
            g1.Generate(1000);
            g1.ToFile("Bigramma.txt");
            FrequencyWords g2 = new FrequencyWords();
            g2.Generate(1000);
            g2.ToFile("FrequencyWords.txt");
            PairsWords g3 = new PairsWords();
            g3.Generate(1000);
            g3.ToFile("PairsWords.txt");
        }
    }
}