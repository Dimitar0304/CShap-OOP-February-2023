using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern.Models
{
    public class RichCompound:Compound
    {
        private string chemical;
        private ChemicalDataBank bank;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
        }
        public override void Display()
        {
            bank = new ChemicalDataBank();
            boilingPoint = bank.GetCriticalPoint(chemical, "B");
            molecularFormula = bank.GetMulecularStructure(chemical);
            molecularWeight = bank.GetMolecularWeight(chemical);
            meltingPoint = bank.GetCriticalPoint(chemical, "M");

            Console.WriteLine($"Compound: {chemical}");
            Console.WriteLine($"Formula: {molecularFormula}");
            Console.WriteLine($"Weight: {molecularWeight}");
            Console.WriteLine($"Melting Pt: {meltingPoint}");
            Console.WriteLine($"Boiling Pt: {boilingPoint}");
        }
    }
}
