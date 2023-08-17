using FactoryPatternExample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample3
{
    public class NewspaperShop : WriterShop
    {
        protected override IWriter PublishingBook()
        {
           return new NewspapersWriter();
        }
    }
}
