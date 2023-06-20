using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern.Models
{
    public class ChemicalDataBank
    {
        public float GetCriticalPoint(string compound, string point)
        {
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol":
                        return -114.5f;
                        break;
                    default: return 0f;
                }
            }
            else
            {
                switch (compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }

        }
        public string GetMulecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case"water": return "H20";
                    case"benzene": return "c6h6";
                case "ethanol": return "c2h5oh";
                    break;
                default: return " ";
            }
        }
        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":return 18.05;
                case "benzene": return 78.123;
                case "ethanol": return 46.0688;
                default: return 0d;
                    break;
            }
        }
    }
}
