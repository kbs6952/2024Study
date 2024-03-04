using System.Data;
using static JSON_Test.AttributeTest;

namespace JSON_Test
{
    [System.Serializable]
    public class Database
    {
        string tableName;
        DataTable dt;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(AttributeTest);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            foreach(var attr in attributes)
            {
                History history = attr as History;
            }

            AttributeTest at = new AttributeTest();
            
        }
    }
}
