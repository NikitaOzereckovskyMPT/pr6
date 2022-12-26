using Newtonsoft.Json;
using System.Xml.Serialization;

namespace практическая6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            h2 text = new h2();
            text.Name = "Предмет - коробка";
            text.Form = "Квадрат - куб";
            text.Desc = "Больших размеров, картонная из переработанной древесины";
            text.Cost = "За небольшую цену";
            List<h2> fgr = new List<h2>();
            fgr.Add(text);

            cl1 vgr = new cl1();

            while (true)
            {
                int v = 10;
                while (v != 0)
                {
                    Console.WriteLine(" Введите путь до файла который необходимо открыть\n =============================================");
                    v = vgr.Dcrlz(fgr, text);
                    if (v == 3)
                    {
                        fgr.Remove(text);
                        fgr.Add(text);
                        v = 0;
                    }
                    Console.Clear();
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(" Введите путь для сохранения: \n =============================================");
                vgr.Crlz(fgr);

                Console.WriteLine(" Сохранено. Нажмите любую кнопку. \n =============================================");
                Console.ReadKey(true);
                Console.Clear();
            }

        }
    }
}