using System.Data;

namespace Class11
{
    // 11강
    // 학습목표 : delegate(대리자)와 이벤트를 학습하고 c#의 winform을 활용하여 계산기를 만들어 봅시다.
    // 2024.02.23

    // delegate
    // delegate 사전적 의미는 대리인, 사절이라는 의미를 가졌습니다.
    // 대리인 또는 대리자란 누군가를 대신해서 일을 해주는 사람을 의미합니다.
    // C#에서 대리자 메소드를 참조해서 대신 불러주는 기능을 합니다.
    
    // 기본 문법
    // 접근 지정자 delegate 데이터 타입 델리게이트 이름(매개 변수);

    delegate int MyDelegate(int a,int b);

    // delegate의 선언 위치
    // namespace 공간에 자유롭게 위치할 수 있고, 클래스 내부에서도 선언할 수 있습니다.
    // delegate는 선언 후 메소드의 주소를 가져오는 객체를 생성하는 설계도라고 볼 수 있습니다.

    class DelegateExample
    {

        int Plus(int a,int b)
        {
            return a + b;
        }
        int Minus(int a,int b)
        {
            return a - b;
        }

        public void DeleageTest(MyDelegate callback)
        {
            MyDelegate Callback;
            Callback = callback;

            Console.WriteLine(callback);
        }
        public void Execute()
        {
            MyDelegate CalculateCallback;
            CalculateCallback = new MyDelegate(Plus);
            Console.WriteLine(CalculateCallback(3,4));

            CalculateCallback = new MyDelegate(Minus);
            Console.WriteLine(CalculateCallback(7, 5));
        }
    }

    // delegate를 사용하면 메소드를 매개변수로 사용할수있는것을 눈으로 확인하였습니다.
    // 콜백(Call back) : 어떤 메소드를 실행 할 때 다른 메소드를 불러와서 실행하는 것을 콜백이라고 합니다.
    internal class Program
    {
        static void Main(string[] args)
        {
           DelegateExample delegateExample = new DelegateExample();
            delegateExample.Execute();

            Event_Class event_Class = new Event_Class();
            event_Class.Main2();
        }
    }
}
