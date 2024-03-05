using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace JSON_Test
{
    [System.Serializable]
    class SomeJsonData
    {
        private string name;
        public SomeJsonData(string name)
        {
            this.name = name;
        }
    }
    public class JSON_Practice
    {
        // JSON : Java Script Object Notation


        // Nuget

        // C# .Net - 수많은 Library 클래스를 사용을 해서 API를 사용하여 여러가지 기능을 응용하여 만들 수 있다.
        // API사용 : 매개 변수에 해당 내용만 입력을 해주면 자동으로 그 기능이 사용이 되죠.

        // .Net 좋은 기능들을 많이 제공해주고 있지만, .Net 환경이 아닌 좋은 라이브러리도 우리가 받아서 사용하고 싶다.
        // 외부 라이브러리를 관리하는 저장소를 Nuget이라 하고,
        // Nuget은 개발자가 외부 패키지 파일을 쉽게 찾고, 설치하고, 업데이트할 수 있게 도와줍니다.
        public void Exampl()
        {
            SomeJsonData dataJson = new SomeJsonData("예시 제이슨");
            string jsonData = JsonConvert.SerializeObject(dataJson);

            File.WriteAllText(@"C:\Sample", jsonData);
        }
    }
    public class DatabaseJason
    {
        public static void SaveJson(string filePath)
        {
            int[] lottos = { 3, 24, 33 };
            DataJson dataJson = new DataJson();
            dataJson.Name = "고병석";
            dataJson.Age = 34;
            dataJson.Percentage = 0.5;
            dataJson.lottoNumber = lottos;

            ObjectID newobjectID = new ObjectID();
            newobjectID.index = 0;
            newobjectID.objectName = "마우스";
            dataJson.objectID = newobjectID;

            string saveJson = JsonConvert.SerializeObject(dataJson);
            File.WriteAllText(filePath,saveJson);

            // 
            
        }
        public static void LoadJson(string filePath)
        {
            string loadJson = File.ReadAllText(filePath);
            //JsonConvert.DeserializeObject<DataJson>(loadJson);
            DataJson json = new DataJson();
            JsonConvert.PopulateObject(loadJson, json);
            Console.WriteLine($"{json.Name},{json.Age}");

        }
    }
    public class DataJson
    {
        public string Name;
        public int Age;
        public double Percentage;
        public int[] lottoNumber;
        public ObjectID objectID;
    }
    public class ObjectID
    {
        public int index;
        public string objectName;
    }
}
