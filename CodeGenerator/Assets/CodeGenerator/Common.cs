using UnityEditor;
using UnityEngine;

namespace CodeGenerator
{
    internal static class Token
    {
        public const char Space = ' ';
        public const char Slash = '/';
        public const char EndLine = '\n';
        public const char Colon = ':';
        public const char Semicolon = ';';
        public const char Comma = ',';
        public const string Remark = @"//";
        public const string StartRemark = @"/*";
        public const string EndRemark = @"*/";
        public const char StartBlock = '{';
        public const char EndBlock = '}';
        public const char Tab = '\t';
        public const char Substitute = '=';
        public const string Equal = "==";
        public const string NotEqual = "!=";
        public const char Plus = '+';
        public const char Minus = '-';
        public const char Mul = '*';
        public const char Division = '/';
        public const string And = "&&";
        public const string Or = "||";
        public const char StartBigBracket = '[';
        public const char EndBigBracket = ']';
        public const char StartSmallBracket = '(';
        public const char EndSmallBracket = ')';
    }

    internal static class Keyword
    {
        public const string Using = "using";
        public const string Namespace = "namespace";
        public const string Class = "class";
        public const string Static = "static";
        public const string Public = "public";
        public const string Internal = "internal";
        public const string Private = "private";
        public const string Protected = "Protected";
        public const string Void = "void";
        public const string For = "for";
        public const string Foreach = "foreach";
        public const string If = "if";
        public const string ElseIf = "else if";
        public const string Else = "else";
        public const string Const = "const";
        public const string Readonly = "readonly";
        public const string Enum = "enum";
    }

    public enum AccessorType
    {
        Public,
        Protected,
        Private,
        Internal
    }
}