namespace ClassLibrary1
{
    public class Rules
    {
        float chiffre;
        string lettre;
        float borneMax;
        float borneMin;

        public Rules(int chiffre, string lettre)
        {
            this.Chiffre = chiffre;
            this.Lettre = lettre;
        }

        public float Chiffre { get => chiffre; set => chiffre = value; }
        public string Lettre { get => lettre; set => lettre = value; }
    }
}