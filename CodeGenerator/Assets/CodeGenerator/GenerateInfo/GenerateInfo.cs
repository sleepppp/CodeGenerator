using System.Collections.Generic;
namespace CodeGenerator
{
    public sealed class GenerateInfo
    {
        string _namespace;
        List<EnumInfo> _enumInfo = new List<EnumInfo>();
        List<string> _usingList = new List<string>();
        List<ClassInfo> _classList = new List<ClassInfo>();
        List<StructInfo> _structList = new List<StructInfo>();

        public Generator GenerateCode()
        {
            Generator generator = new Generator();

            return generator;
        }
    }
}