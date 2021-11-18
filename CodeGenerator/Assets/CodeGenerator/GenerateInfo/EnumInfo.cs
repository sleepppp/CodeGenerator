using System.Collections.Generic;

namespace CodeGenerator
{
    public sealed class EnumInfo
    {
        public string EnumName;
        public AccessorType AccessorType;
        public List<string> ElementNames = new List<string>();
        public List<string> ElementValues = new List<string>();

        public void AddElement(string name)
        {
            ElementNames.Add(name);
        }

        public void AddElement(string name, string value)
        {
            ElementNames.Add(name);
            ElementValues.Add(value);
        }
    }
}