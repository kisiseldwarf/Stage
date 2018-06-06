namespace ClassLibrary1
{
    public class Rules
    {
        float borneH;
        float borneB;
        string lettre;

        public Rules(float borneH,float borneB, string lettre)
        {
            this.BorneB = borneB;
            this.BorneH = borneH;
            this.Lettre = lettre;
        }

        public string Lettre { get => lettre; set => lettre = value; }
        public float BorneH { get => borneH; set => borneH = value; }
        public float BorneB { get => borneB; set => borneB = value; }
    }
}