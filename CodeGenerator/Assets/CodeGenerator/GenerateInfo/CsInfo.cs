using System.Collections.Generic;
namespace CodeGenerator
{
    public sealed class CsInfo
    {
        public string FileName;
        public string NameSpace;
        public List<string> UsingList = new List<string>();
        public List<EnumInfo> EnumList = new List<EnumInfo>();
        public List<ClassInfo> ClassList = new List<ClassInfo>();
        public List<string> RemarkList = new List<string>();

        public CsInfo(string fileName)
        {
            FileName = fileName;
        }
    }
}