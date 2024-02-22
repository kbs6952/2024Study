using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class10
{
    // Collections ArrayList, Stack, Queue, Hashtable 클래스로 선언하여 사용해보았는데,
    // C#에서 제공하는 Collections.Generic 사용해보는 예시입니다.
    internal class CollectionsGenericGroup
    {
        class ListData //
        {
            private string name;
            private int number;

            public string Name
            {
                get => name; 
                set => name = value;
            }
            public int Number
            {
                get=> number;
                set => number = value;
            }
        }
        public void ListExample()
        {

            List<int> list = new List<int>();

            for(int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            foreach( int element in list)
                Console.WriteLine($"List안의 요소 :{element}");

            List<ListData> listDatas = new List<ListData>();

        }

        // Queue : FIFO 방식으로 데이터를 저장하고 사용하는 자료구조입니다.
        // 저장할 데이터를 T로 선언해서, 모든 데이터 타입을 다룰 수 있게 됩니다.

        // 데이터를 순서대로 저장했다가 들어온 순서로 데이터를 내보낸다.
        // 게임에서 
        
        // Dictionary<Tkey,Tvalue>
        // HashTable의 일반화 버전입니다.
        // 형식 매개 변수를 두 개를 요구하는 자료 구조입니다.
        // Key는 Hash 알고리즘에 Key를 저장하고 Tvalue value를 저장합니다.
        
        public void DictionaryExample()
        {
            Dictionary<string,int> dict = new Dictionary<string,int>();

            // 실제 게임에서 사용되는 예시 
            
            
        }

    }
}
