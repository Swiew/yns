using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 프로그램 시작시 말 다섯마리를 만들고
 * 각 다섯마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직인다.
 * 각각의 말이 거리 200에 도달하면 말의 이름과 등수를 출력해준다
 * 
 * 말은 이름, 달린거리를 멤버변수로
 * 달리기를 멤버 함수로 가짐
 * 달리기 멤버함수는 입력받은 거리를 달린거리에 더 해주어서 달린거리르 누적시키는 역할을 함
 * 
 * 매초 달릴 떄 마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
 * 경주가 끝나면 1,2,3,4,5 등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.
 * 
 * Syster.Threading namespace에 있는 Thread.Sleep(1000); 를 사용하면 현재 프로그램을 1초 지연시킬 수 있음
 * Whlie 반복문에서 Thread.Sleep(1000); 을 추가하면 1초에 한번씩 반복문을 실행함.
*/

namespace ConsoleApp3
{
    class Program
    {
        static bool isGameFinished = false;
        static int finishDistance = 200;
        static int currentGrade = 1;
        static Random random;
        static void Main(string[] args)
        {
            Horse[] arr_horse = new Horse[5];
            string[] arr_FinishedHorseName = new string[5];
            int length = arr_horse.Length;
            for (int i = 0; i < length; i++)
            {
                arr_horse[i] = new Horse();
                arr_horse[i].name = (i+1)+"번마";
            }

            Console.WriteLine("경주 시작!");

            while (!isGameFinished)
            {
                for (int i = 0; i < length; i++)
                {
                    random = new Random();
                    int tmpMoveDistance = random.Next(10, 21); // Next ( 미니멈 , 맥시멈-1)
                    arr_horse[i].Run(tmpMoveDistance);
                    Console.WriteLine($"{arr_horse[i].name}의 위치 : {arr_horse[i].distance}");

                    if (arr_horse[i].distance >= finishDistance)
                    {
                        arr_FinishedHorseName[currentGrade - 1] = arr_horse[i].name;
                        currentGrade++;
                    }

                    if (currentGrade>5)
                    {
                        isGameFinished = true;
                        Console.WriteLine("게임끝났당");
                        break;
                    }
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine($"1등 : {arr_FinishedHorseName[0]}");
            Console.WriteLine($"2등 : {arr_FinishedHorseName[1]}");
            Console.WriteLine($"3등 : {arr_FinishedHorseName[2]}");
            Console.WriteLine($"4등 : {arr_FinishedHorseName[3]}");
            Console.WriteLine($"5등 : {arr_FinishedHorseName[4]}");
        }
    }
    
    class Horse
    {
        public string name;
        public int distance;

        public void Run(int moveDistance)
        {
            distance += moveDistance;
        }
    }
}
