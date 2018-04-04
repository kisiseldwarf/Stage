namespace ClassLibrary1
{
    public class Rules
    {
        int chiffre;
        string lettre;

        public Rules(int chiffre, string lettre)
        {
            this.Chiffre = chiffre;
            this.Lettre = lettre;
        }

        public int Chiffre { get => chiffre; set => chiffre = value; }
        public string Lettre { get => lettre; set => lettre = value; }
    }
}