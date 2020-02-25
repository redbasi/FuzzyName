using System.ComponentModel;
using System.Text;

namespace CsvDemo
{
    public abstract class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            var propertiesString = new StringBuilder();

            propertiesString.Append($"Name: \"{Name}\"");

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string pName = descriptor.Name;
                object pValue = descriptor.GetValue(this);

                if (pName != nameof(Name))
                { 
                    propertiesString.Append($", {pName}: \"{pValue}\"");
                }
            }

            return propertiesString.ToString();
        }
    }

    public class DirtyPerson : Person
    {
        public string NewData { get; set; }
    }

    public class CleanPerson : Person
    {
        public string ExistingData { get; set; }
    }

    public class OutputPerson : Person
    {
        public string ExistingData { get; set; }

        public string NewData { get; set; }
    }
}
