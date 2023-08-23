using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class FishingRodBuilder
    {
        public int Size;
        public int Rings;
        public int Cord;
        public string Stickers;

        public FishingRodBuilder(int size)
        {
            Size = size;    
        }
        public void GetRings(int rings)
        {
            Rings = rings;
        }
        public void GetCord(int cord)
        {
            Cord = cord;
        }
        public FishingRod Build()
        {
            return new FishingRod(this);
        }

    }
}
