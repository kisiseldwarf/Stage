using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NotesEtudiant> res;
            res = Functions.ReadExcel(@"C:\Users\hadikk\TestStageLog1.xlsx");
            foreach (var item in res)
            {
                Console.Write(item.NomEtudiant+"\t");
                foreach (var item2 in item.ListeNotesLettre)
                {
                    Console.Write(item2 + "\t");
                }
                Console.WriteLine("");
            }
            Console.Read();
        }
    }
}
