using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CodeGenerator;
public static class Test
{
    [MenuItem("Test/CreateTestCode")]
    static void TestCreateFile()
    {
        string filePath = "Assets/TestCode/TestCode.cs";

        CsInfo csInfo = new CsInfo(filePath);

        csInfo.AddUsing("System.Collections");
        csInfo.AddUsing("System.Collections.Generic");
        csInfo.AddUsing("UnityEngine");

        csInfo.AddRemark("=======================================================================================");
        csInfo.AddRemark("코드 생성기를 통해 생성된 코드 입니다");
        csInfo.AddRemark("=======================================================================================");

        ClassInfo classInfo = new ClassInfo("TestCode", AccessorType.Public);
        classInfo.AddField(new FieldInfo("int", "TestInt", AccessorType.Public));
        classInfo.AddField(new FieldInfo("float", "TestFloat", AccessorType.Public));


        MethodInfo method = new MethodInfo("TestFunc", "void", AccessorType.Public);
        method.AddBody("Debug.Log(\"Test\");");

        classInfo.AddMethod(method);
        
        csInfo.AddClass(classInfo);

        using (CodeStream stream = new CodeStream())
        {
            stream.SaveFile(csInfo);
        }

        AssetDatabase.Refresh();
    }

}
