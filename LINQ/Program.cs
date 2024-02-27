using System.Runtime.CompilerServices;

namespace LINQ
{
    internal class Program
    {
        // 데이터베이스 다루는 언어. SQL
        // LINQ : 통합 질의 언어 Language Integrated Query
        // 사람이 묻는 것 처럼 언어를 사용하게 만드는 문법 Query문


        
        // 사용해야 되는 이유 : 우리가 실제로 프로그래밍을 작성하면 논리적인 로직을 작성하는 일보다 데이터를 분류하고 관리하는 일을 하는 빈도 수가 더 많습니다.
        // 데이터를 분류하고 정렬한 후 검색하는 코드를 작성하는 것에 시간이 소모되는 경우가 많습니다.

        // 사용법 : frim, where, orderby, select, group
        // 실습 : 

        static void Main(string[] args)
        {
            List<Database>databases = new List<Database> (0);

            Database[] myDatabase =
            {
                new Database("이순신",100),
                new Database("기기",200),
                new Database("나나",300),
                new Database("다다",400),
                new Database("라라",500),
            };
            // database 클래스 내부에서 money 300이상인 객체만 필요하다.
            
            foreach(Database database in myDatabase)
            {
                if(database.Money >=300)
                {
                    databases.Add(database);
                }
            }

            // LINQ : 어떤 데이터베이스에서 특정 정보만 빼올때 사용
            
        }
    }
    class Database
    {
        private string name;
        private int money;

        public string Name => name;
        public int Money => money;
        public Database(string name, int money)
        {
            this.name = name;
            this.money = money;
        }
    }
}
