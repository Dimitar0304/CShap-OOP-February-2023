using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string type, params string[] nameOfFieldsToHack)
        {
            StringBuilder result = new StringBuilder();
            Type obj = Type.GetType(type);

            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (var item in nameOfFieldsToHack)
            {
                FieldInfo currentField = obj.GetField(item,BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
                fields.Add(currentField);
            }

            Object classInstance = Activator.CreateInstance(obj,new object[] { });


            foreach (FieldInfo field in fields)
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return result.ToString().Trim();
        }
    }
}
