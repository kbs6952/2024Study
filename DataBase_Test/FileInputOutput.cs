using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Test
{
    internal class FileInputOutput
    {
        // File, Directory(Folder), Stream 개념을 학습하도록 하겠습니다.

        // Stream 스트림
        // 시간의 흐름에 따라 연속적으로 발생하는 데이터의 흐름을 뜻합니다.
        // IO. 저장하고 불러올 때 사용을 하는 클래스이름. 스트림이 연결되있어야 합니다.

        // 파일 읽기

        void ReadStream()
        {
            string data;
            StreamReader reader = new StreamReader(@"C:\새 폴더.Test.txt");

            data = reader.ReadLine();

            while(data != null)
            {
                data = reader.ReadLine();
            }
            reader.Close();
            
        }
        void WriteStream()
        {
            StreamWriter writer = new StreamWriter(@"C:\새 폴더.Test.txt");
            writer.WriteLine("여기에는 테스트 데이터가 들어갈겁니다");
            writer.Close();
        }
    }
}
