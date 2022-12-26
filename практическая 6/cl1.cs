using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace практическая6
{
    internal class cl1
    {
        public void Crlz(List<h2> fgr)
        {

            string fl = Console.ReadLine();
            string flT;
            flT = "json";
            if (fl.Contains(flT))
            {
                string json = JsonConvert.SerializeObject(fgr);
                File.WriteAllText(fl, json);
            }
            flT = "txt";
            if (fl.Contains(flT))
            {
                File.Delete(fl);
                foreach (var item in fgr)
                {
                    File.AppendAllText(fl, item.Name + "\n");
                    File.AppendAllText(fl, item.Form + "\n");
                    File.AppendAllText(fl, item.Desc + "\n");
                    File.AppendAllText(fl, item.Cost);
                }
            }
            flT = "xml";
            if (fl.Contains(flT))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<h2>));
                using (FileStream fs = new FileStream(fl, FileMode.Create))
                {
                    xml.Serialize(fs, fgr);
                }
            }
            Console.Clear();



        }
        public int Dcrlz(List<h2> figur, h2 text)
        {
            List<h2> texts = new List<h2>();
            string fali = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Данные файла: \n========================================");
            string faliT;
            int h = 5;
            if (File.Exists(fali))
            {
                faliT = "json";
                if (fali.Contains(faliT))
                {
                    string json = File.ReadAllText(fali);
                    texts = JsonConvert.DeserializeObject < List < h2 > > (json);
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Desc);
                        Console.WriteLine(item.Cost);
                    }
                }
                faliT = "txt";
                if (fali.Contains(faliT))
                {

                    string[] lines = File.ReadAllLines(fali);
                    for (int i = 0; i < lines.Length; i += 4)
                    {
                        h2 hp = new h2();
                        hp.Name = lines[i];
                        hp.Form = lines[i + 1];
                        hp.Desc = lines[i + 2];
                        hp.Cost = lines[i + 3];

                        texts.Add(hp);
                    }
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Desc);
                        Console.WriteLine(item.Cost);
                    }

                }
                faliT = "xml";
                if (fali.Contains(faliT))
                {

                    XmlSerializer xml = new XmlSerializer(typeof(List<h2>));
                    using (FileStream fs = new FileStream(fali, FileMode.Open))
                    {
                        texts = (List<h2>)xml.Deserialize(fs);
                    }
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Desc);
                        Console.WriteLine(item.Cost);
                    }
                }
                Console.WriteLine("========================================\n Хотите изменить файл? \n  Да\n  Нет");
                int p = 8;
                int pr = 3;
                ConsoleKeyInfo d = Console.ReadKey();
                if (d.Key == ConsoleKey.F1)
                {
                    foreach (var item in texts)
                    {
                        Console.WriteLine("  " + item.Name);
                        text.Name = item.Name;
                        Console.WriteLine("  " + item.Form);
                        text.Form = item.Form;
                        Console.WriteLine("  " + item.Desc);
                        text.Desc = item.Desc;
                        Console.WriteLine("  " + item.Cost);
                        text.Cost = item.Cost;
                    }
                    h = 3;
                }
                else
                {
                    h = Str(p, pr);
                    if (h == 9)
                    {
                        foreach (var item in texts)
                        {
                            Console.WriteLine("  " + item.Name);
                            text.Name = item.Name;
                            Console.WriteLine("  " + item.Form);
                            text.Form = item.Form;
                            Console.WriteLine("  " + item.Desc);
                            text.Desc = item.Desc;
                            Console.WriteLine("  " + item.Cost);
                            text.Cost = item.Cost;
                        }
                        h = 3;
                    }
                    if (h == 8)
                    {
                        Menalka(texts, text);
                        h = 3;
                    }
                }

            }
            else
            {
                Console.WriteLine("Такого файла не существует.");
            }

            return h;

        }
        public int Str(int p, int pr)
        {
            int b = 9;
            while (b != 0)
            {
                ConsoleKeyInfo k = Console.ReadKey();

                if (k.Key == ConsoleKey.Enter)
                {
                    b = 0;
                }
                if (k.Key == ConsoleKey.Escape)
                {
                    p = 0;
                    b = 0;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    p = p + 1;
                    b = p - 1;
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    p = p - 1;
                    b = p + 1;
                }
                if (pr == 3)
                {
                    if (p == 10)
                    {
                        p = 9; b = 8;
                    }
                    if (p == 7)
                    {
                        p = 8; b = 9;
                    }
                }
                if (pr == 2)
                {
                    if (p == 1)
                    { p = 2; b = 3; }
                    if (p == 6)
                    { p = 5; b = 4; }

                }
                Console.SetCursorPosition(0, p);
                Console.WriteLine("->");
                Console.SetCursorPosition(0, b);
                Console.WriteLine("  ");
            }
            return
            p;
        }
        public void Menalka(List<h2> texts, h2 text)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Выберите строчку и измените её. \n ================================");
            foreach (var item in texts)
            {
                Console.WriteLine("  " + item.Name);
                text.Name = item.Name;
                Console.WriteLine("  " + item.Form);
                text.Form = item.Form;
                Console.WriteLine("  " + item.Desc);
                text.Desc = item.Desc;
                Console.WriteLine("  " + item.Cost);
                text.Cost = item.Cost;
            }
            int p = 2;
            int pr = 2;
            int d = Str(p, pr);
            Console.SetCursorPosition(0, d);
            Console.Write(" ");
            if (d == 2)
            {
                Console.SetCursorPosition(2, d);
                text.Name = Console.ReadLine();
            }
            if (d == 3)
            {
                Console.SetCursorPosition(2, d);
                text.Form = Console.ReadLine();
            }
            if (d == 4)
            {
                Console.SetCursorPosition(2, d);
                text.Desc = Console.ReadLine();
            }
            if (d == 5)
            {
                Console.SetCursorPosition(2, d);
                text.Cost = Console.ReadLine();
            }

        }
    }
}