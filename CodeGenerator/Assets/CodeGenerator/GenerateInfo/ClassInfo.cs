using System.Collections.Generic;

namespace CodeGenerator
{
    public sealed class ClassInfo
    {
        public string Name;
        public AccessorType AccessorType;
        public bool IsStatic;
        public string HaritanceName;
        public List<EnumInfo> Enums = new List<EnumInfo>();
        //public List<ClassInfo> Classes = new List<ClassInfo>();
        public List<FieldInfo> Fields = new List<FieldInfo>();
        public List<MethodInfo> Methods = new List<MethodInfo>();

        public void Init(string name,AccessorType accessorType = AccessorType.Private,string haritance = null, bool isStatic = false)
        {
            Name = name;
            AccessorType = accessorType;
            HaritanceName = haritance;
            IsStatic = isStatic;
        }
    }
}