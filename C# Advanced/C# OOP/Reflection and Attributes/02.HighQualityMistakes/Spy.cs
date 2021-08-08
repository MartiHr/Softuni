using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type metadata = Type.GetType($"{className}");
            
            FieldInfo[] wrongFields = 
                metadata.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] wrongGetters =
                metadata.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] wrongSetters =
                metadata.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            
            StringBuilder sb = new StringBuilder();

            foreach (var field in wrongFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var getter in wrongGetters.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }
            foreach (var getter in wrongSetters.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{getter.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

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
