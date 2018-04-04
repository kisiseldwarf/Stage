using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;

namespace ClassLibrary1
{
    static public class Functions
    {
        static public List<NotesEtudiant> ReadCSV(string path)
        {
            List<NotesEtudiant> res = new List<NotesEtudiant>();
            try
            {
                StreamReader tr = new StreamReader(path);
                while (!tr.EndOfStream)
                {
                    string line = tr.ReadLine();
                    string[] values = line.Split(';');
                    NotesEtudiant ne = new NotesEtudiant();
                    int index = 0;
                    foreach (var item in values)
                    {
                        if (index == 0)
                            ne.NomEtudiant = item;
                        else
                        {
                            ne.ListeNotesLettre.Add(item);
                        }
                        index++;
                    }
                    res.Add(ne);
                }
                tr.Close();
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Chemin incorrect");
            }
        } //Lire XLMS

        static public List<NotesEtudiant> ReadExcel(string path)
        {
            try
            {
                var stream = File.Open(path, FileMode.Open, FileAccess.Read);
                var excelReader = ExcelReaderFactory.CreateReader(stream);
                List<NotesEtudiant> res = new List<NotesEtudiant>();
                while (excelReader.Read())
                {
                    NotesEtudiant ne = new NotesEtudiant();
                    for (int i = 0; i < excelReader.FieldCount; i++)
                    {
                        if (i == 0)
                            ne.NomEtudiant = excelReader.GetString(i);
                        else
                        {
                            ne.ListeNotesLettre.Add(excelReader.GetString(i));
                        }
                    }
                    res.Add(ne);
                }
                excelReader.Close();
                return res;
            }
            catch(Exception)
            {
                throw new Exception("Chemin incorrect");
            }
        } //Lire CSV

        static public void setTheNumbers(NotesEtudiant ne)
        {
            foreach (var item in ne.ListeNotesLettre)
            {
                switch (item)
                {
                    case "A":
                        ne.ListeNotesChiffre.Add(18);
                        break;
                    case "B":
                        ne.ListeNotesChiffre.Add(16);
                        break;
                    case "C":
                        ne.ListeNotesChiffre.Add(12);
                        break;
                    case "D":
                        ne.ListeNotesChiffre.Add(7);
                        break;
                    case "E":
                        ne.ListeNotesChiffre.Add(2);
                        break;
                    default:
                        break;
                }
            }
        } //Lettre -> Notes

        static public void exportCSV(List<NotesEtudiant> lne,string path)
        {
            string[] res = new string[lne.Count()];
            for (int i = 0; i < lne.Count(); i++)
            {
                res[i] += lne[i].NomEtudiant+";";
                foreach (var item in lne[i].ListeNotesChiffre)
                {
                    res[i] += item + ";";
                }
                res[i] += lne[i].Moyenne;
            }
            File.WriteAllLines(path, res);
        } //Enregistrer dans un fichier .csv
        
    }
}
