
namespace SchachspielUI
{
    public class Zug
    {
        private int _zugX;
        private int _zugY;
        public Zug(int _ZugX, int _ZugY)
        {
            ZugX = _ZugX;
            ZugY = _ZugY;
        }

        public int ZugX
        {
            get => _zugX;
            set => _zugX = value;
        }


        public int ZugY
        {
            get => _zugY;
            set => _zugY = value;
        }
    }
}
