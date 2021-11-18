using System.IO;
using System;
namespace CodeGenerator
{
    public sealed class CodeStream : IDisposable
    {
        Generator _generator;

        public void SaveFile(string filePath, CsInfo csInfo)
        {
            GenerateCode(csInfo);

            //todo stream save
        }

        void GenerateCode(CsInfo csInfo)
        {
            _generator = new Generator();

            // {{ using ~
            for(int i = 0; i < csInfo.UsingList.Count; ++i)
            {
                _generator.Using(csInfo.UsingList[i]);
            }
            // }} 
            
            // {{ Remark ~
            for (int i =0; i < csInfo.RemarkList.Count; ++i)
            {
                _generator.Remark(csInfo.RemarkList[i]);
            }
            // }} 

            // {{ namespace ~
            using(_generator.Namespace(csInfo.NameSpace))
            {
                // {{ enum ~
                for(int i =0; i < csInfo.EnumList.Count; ++i)
                {
                    _generator.DeclarationEnum(csInfo.EnumList[i].EnumName, csInfo.EnumList[i].ElementNames, csInfo.EnumList[i].ElementValues,csInfo.EnumList[i].AccessorType);
                }
                // }} 

                for(int i =0; i < csInfo.ClassList.Count; ++i)
                {
                    ClassInfo classInfo = csInfo.ClassList[i];
                    using (_generator.DeclarationClass(classInfo.Name, classInfo.AccessorType, classInfo.IsStatic, classInfo.HaritanceName))
                    {
                        for(int j = 0; j < classInfo.Enums.Count; ++j)
                        {
                            EnumInfo enumInfo = classInfo.Enums[j];
                            _generator.DeclarationEnum(enumInfo.EnumName, enumInfo.ElementNames, enumInfo.ElementValues, enumInfo.AccessorType);
                        }

                        for(int j = 0; j < classInfo.Fields.Count; ++j)
                        {
                            FieldInfo fieldInfo = classInfo.Fields[j];
                            if (string.IsNullOrEmpty(fieldInfo.StartValue))
                                _generator.DeclarationField(fieldInfo.TypeName, fieldInfo.FieldName, fieldInfo.AccessorType);
                            else
                                _generator.DeclarationField(fieldInfo.TypeName, fieldInfo.FieldName, fieldInfo.StartValue, fieldInfo.AccessorType);
                        }                    

                        //todo Methods ~ 
                    }
                }
            }
            // }} 
        }

        public void Dispose()
        {
            _generator = null;
        }
    }
}