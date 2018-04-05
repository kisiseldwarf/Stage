using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Profil
    {
        string name;
        List<Rules> rulesList;

        public Profil(string name, List<Rules> rulesList)
        {
            this.Name = name;
            this.RulesList = rulesList;
        }


        public override string ToString()
        {
            return name;
        }

        public string Name { get => name; set => name = value; }
        public List<Rules> RulesList { get => rulesList; set => rulesList = value; }
    }
}
