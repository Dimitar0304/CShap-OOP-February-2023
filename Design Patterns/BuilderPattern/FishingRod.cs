using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class FishingRod
    {
        private int size;
        private int rings;
        private int cord;
        private string stickers;
        public FishingRod(FishingRodBuilder fishingRodBuilder)
        {
            this.size = fishingRodBuilder.Size;
            this.rings = fishingRodBuilder.Rings;
            this.cord = fishingRodBuilder.Cord;
            this.stickers = fishingRodBuilder.Stickers;
        }
        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"This is {this.size} fishing rod ");
            return sb.ToString();
        }
    }
}
