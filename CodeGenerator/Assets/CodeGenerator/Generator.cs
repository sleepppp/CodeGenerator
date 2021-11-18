using System;
namespace CodeGenerator
{
    public sealed class Generator
    {
        Worker _worker;
        int _codeBlockCount = 0;

        public string GetResult() { return _worker.GetString(); }
        public void AddCodeBlockCount() { _codeBlockCount++; }
        public void RemoveCodeBlockCount() { _codeBlockCount--; }

        public Generator() { _worker = new Worker(); }

        public void Remark(string text)
        {
            CheckTab().Append(Token.Remark).Append(text).EndLine();
        }

        public void Using(string name)
        {
            CheckTab().Append(Keyword.Using).Space().Append(name).EndLine();
        }

        public CodeBlock Namespace(string name)
        {
            CheckTab().Append(Keyword.Namespace).Space().Append(name).EndLine();
            return new CodeBlock(this);
        }

        public void Attribute(string name)
        {
            CheckTab().Append(Token.StartBigBracket).Append(name).Append(Token.EndBigBracket).EndLine();
        }

        public void Attribute(string name ,object[] param)
        {
            CheckTab().Append(Token.StartBigBracket).Append(name).Append(Token.StartSmallBracket);
            for(int i =0; i < param.Length; ++i)
            {
                _worker.Append(param.ToString());
                if (i != param.Length - 1)
                {
                    _worker.Append(Token.Comma);
                }
            }
            _worker.Append(Token.EndSmallBracket).Append(Token.EndBigBracket).EndLine();
        }

        public CodeBlock DeclarationClass(string name, AccessorType accessorType = AccessorType.Private,bool isStatic = false, string inheritanceName = null)
        {
            CheckTab().Append(GetAccessorStr(accessorType)).Space();
            if (isStatic)
                _worker.Append(Keyword.Static).Space();
            _worker.Append(Keyword.Class).Space().Append(name).Space();

            if(string.IsNullOrEmpty(inheritanceName) == false)
            {
                _worker.Append(Token.Colon).Space().Append(inheritanceName);
            }

            _worker.EndLine();

            return new CodeBlock(this);
        }

        public void DeclarationField(Type type,string fieldName,AccessorType accessorType = AccessorType.Private)
        {
            CheckTab().Append(GetAccessorStr(accessorType)).Space().Append(type.Name).Space().Append(fieldName).Semicolon().EndLine();
        }

        public void DelclarationField(Type type, string fieldName, string initializeValue, AccessorType accessorType = AccessorType.Private)
        {
            CheckTab().Append(GetAccessorStr(accessorType)).Space().Append(type.Name).Space().Append(fieldName).Space().
                Append(Token.Substitute).Space().Append(initializeValue).Semicolon().EndLine();
        }

        public void StartCodeBlock()
        {
            CheckTab().Append(Token.StartBlock).EndLine();
            AddCodeBlockCount();
        }

        public void EndCodeBlock()
        {
            CheckTab().Append(Token.EndBlock).EndLine();
            RemoveCodeBlockCount();
        }

        Worker Tab()
        {
            return _worker.Append(Token.Tab);
        }

        Worker CheckTab()
        {
            if (_codeBlockCount != 0)
            {
                _worker.Append(Token.Tab,_codeBlockCount);
            }
            return _worker;
        }

        string GetAccessorStr(AccessorType type)
        {
            switch(type)
            {
                case AccessorType.Internal:
                    return Keyword.Internal;
                case AccessorType.Public:
                    return Keyword.Public;
                case AccessorType.Private:
                    return Keyword.Private;
                case AccessorType.Protected:
                    return Keyword.Protected;
                default:
                    return Keyword.Private;
            }
        }
    }
}