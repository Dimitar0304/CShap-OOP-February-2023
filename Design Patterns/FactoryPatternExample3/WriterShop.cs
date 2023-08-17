using FactoryPatternExample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample3
{
    public abstract class WriterShop
    {
        abstract protected IWriter PublishingBook();

        public void PublishedBook()
        {
            var writer = this.PublishingBook();
            writer.WriteBook();
        }
    }
}
