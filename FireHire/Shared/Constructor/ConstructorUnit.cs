

namespace FireHire.Shared.Constructor
{
    public class ConstructorUnit
    {
        public ConstructorUnit(int id, string title, int xS = 6, int sM = 4, int mD = 3, int lG = 2)
        {
            Id = id;
            Title = title;
            XS = xS;
            SM = sM;
            MD = mD;
            LG = lG;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int XS { get; set; }
        public int SM { get; set; }
        public int MD { get; set; }
        public int LG { get; set; }
    }
}
