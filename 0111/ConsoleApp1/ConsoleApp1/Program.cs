// See https://aka.ms/new-console-template for more information
using System;

//delegate : 대리자
//함수의 인자로 함수를 받고 싶을 때,

// delegate 반환형 델리게이트이름(인자);
namespace ConsoleApp
{
    class program
    {
        delegate int CalcDelegate(int a , int b);
        int dd;
        static void Main(string[] args)
        {
            int a = 4;
            int b = 7;

            CalcDelegate CD_Sum = Sum;
            CalcDelegate CD_Sub = Sub;

            // 람다식 : 함수를 정의하지 않고, 연산에 필요한 내용만 표현하는 방법으로 객체지향이 아닌 함수지향 프로그램
            CalcDelegate CD_Div = delegate (int a, int b)
            {
                return a / b;
            };

            PrintCalc(a,b, CD_Sum,CD_Sub,CD_Div);
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sub(int a, int b)
        {
            return a - b;
        }

        static int Div(int a, int b)
        {
            return (a / b);
        }

        static void PrintCalc(int a, int b, CalcDelegate sum,CalcDelegate sub,CalcDelegate div)
        {
            Console.WriteLine($"Sum : {sum(a,b)}");
            Console.WriteLine($"Sub : {sub(a,b)}");
            Console.WriteLine($"Sub : {div(a,b)}");
        }
    }
}