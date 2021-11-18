using System.Text;
namespace CodeGenerator
{
    public class ExecuteCodeInfo
    {
        StringBuilder _stringBuilder = new StringBuilder();
        public string Get() { return _stringBuilder.ToString(); }
    }
}
