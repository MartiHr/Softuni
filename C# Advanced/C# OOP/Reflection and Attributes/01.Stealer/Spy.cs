using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameToInvestigate, params string[] fieldsToInvestigate)
        {
            Type hackerMetadata = Type.GetType(nameToInvestigate);
            FieldInfo[] fieldsOfHacker = hackerMetadata
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            var instance = Activator.CreateInstance(hackerMetadata, new object[] { });

            sb.AppendLine($"Class under investigation: {hackerMetadata.FullName}");

            foreach (var field in fieldsOfHacker.Where(x => fieldsToInvestigate.Contains(x.Name)))
            {

                sb.AppendLine($"{field.Name} - {field.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
