using System.Collections;

namespace Class10
{
    // 10강
    // 학습 목표 : 일반화 프로그래밍 Generic에 대한 학습
    // 날짜 : 2024.02.22

    // 일반화 : 모든 데이터 타입을 사용하기 위해 고안된 프로그래밍 방법
    // 예시 1. 점수를 획득하는 시스템 있었습니다.
    // 획득한 점수를 더해서 모든 총합 점수를 랭킹으로 변환하는 시스템을 추가하고 싶다.
    // 

    class GenericExample
    {

       public void AddScore(params int[] index)
        {
            int total = 0;
            foreach(var item in index)
            {
                total += item;
            }
            Console.WriteLine($"모든 점수의 합은 : {total}입니다");
        }
        public void AddScore(params float[] values)
        {
            float total = 0;
            foreach (var item in values)
            {
                total += item;
            }
            Console.WriteLine($"모든 실수 타입 점수의 합은 : {total}입니다");
        }
        public void AddScore<T>(params T[] values)
        {
            T total;
            
            Console.WriteLine("점수의 합은 : {total}입니다");
        }
        
    }
    class Array_List
    {
        private int[] array;
        public int GetElement(int index) { return array[index]; }
    }

    class Array_Generic<T>
    {
        private T[] array;

        public T GetElement(int index) { return array[index]; }
    }

    // 더하는 기능을 잘 구현해서 랭킹 시스템의 일부분을 개발을 했습니다.
    // 소수점의 점수를 가산해주는 데이터가 있는데, 이 데이터도 랭킹 시스템에 반영하게 해달라.

    // 2가지 일반화 프로그래밍이 존재
    // 1. 메서드 일반화
    // 2. 클래스 일반화

    // 기본 문법 : 접근지정자 반환타입 메소드이름<T>(T 매개변수 이름){ }

    // 3. 형식 매개 변수 <T> : 모든 데이터 타입을 받아 올 수 있다고 하였습니다.




    // 기본 문법 : class Mylist<T> where T : "키워드"

    // where T : struct     -> T가 값 형식이여야 한다.
    // where T : class      -> T가 참조 형식이여야한다.
    // where T : new()      -> T는 반드시 매개 변수가 없는 생성자가 있어야 한다.
    // where T : 기반 클래스-> T는 명시한 기반 클래스의 파생 클래스여야한다.
    // where T : 인터페이스 -> T는 명시한 인터페이스를 반드시 구현하고 있어야한다.
    // where T : U(또 다른 형식 매개 변수) -> T는 또 다른 형식 매개 변수 U로부터 상속받은 클래스어야 한다.

    class GenericTest
    {
        // T 데이터 타입의 인스턴스를 반환하는 일반화 메서드
        // T 타입의 인스턴스는 반드시 매개변수가 없는 생성자를 가지고 있어야한다.
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }
    }
    class TestCalss
    {
        private string name;
        public void TestClass(string name)
        {
            this.name = name;
        }
    }


    internal class Program
    {
        public void Test()
        {
            // 가변 배열은 C#에서 클래스로 만든 ArrayList 예시
            // ArrayList뿐만 아니라 Collections 클래스에 내장된 자료 구조(컬렉션)들은 매개 변수를 object타입으로 받는다.
            ArrayList arrayList = new ArrayList();

            // ArrayList내부에서 요소를 추가해주는 Add 메소드는 object를 매개변수로 사용하고 있다.

            arrayList.Add(1);
            arrayList.Add("한글");
            arrayList.Add('c');
            arrayList.Add(0.5f);

            // 컬렉션 클래스를 통해서 자료구조를 사용할 수 있게 되었지만
            // 컬렉션 클래스가 매개변수로 object 타입을 사용하기 때문에 성능 상으로 문제가 있을 수 있다는 것을 파악하였습니다.
            // 이를 해결하기 위한 방법으로 일반화 프로그래밍 C# 지원해주는 Generic에 대해서 학습하도록 하겠습니다.
        }

            static void Main(string[] args)
        {
            GenericExample example = new GenericExample();
            int[] numbers = {1,2,3,4,5};
            example.AddScore<int>(numbers);


        }
    }
}
