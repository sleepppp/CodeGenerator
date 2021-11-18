using System;

namespace CodeGenerator
{
    public class CodeBlock : IDisposable
    {
        Generator _generator;
        public CodeBlock(Generator generator)
        {
            _generator = generator;
            _generator.StartCodeBlock();
        }

        public void Dispose()
        {
            _generator.EndCodeBlock();
        }
    }
}