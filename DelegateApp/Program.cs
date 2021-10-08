using System;

public class DivException:Exception
{
    public DivException() : base() { }
    public DivException(string message) : base(message) { }
}
namespace DelegateApp
{
    class Program
    {
        public delegate double Add(int x, int y);
        public delegate double Sub(int x, int y);
        public delegate double Mul(int x, int y);
        public delegate double Div(int x, int y);

        static void Main(string[] args)
        {
            int input1, input2; string[] read; string readOp;
            Add add = ((x, y) => x + y);
            Sub sub = (x, y) => x - y;
            Mul mul = (x, y) => x * y;
            Div div = (x, y) =>
            {
                if (y == 0)
                    throw new DivException("Деление на ноль!");
                else return (x / y);
            };

            while (true)
            {
                Console.WriteLine("Введите через пробел два числа, над которыми вы хотите совершать действия. Для выхода введите 'exit'");
                readOp= Console.ReadLine();
                if (readOp == "exit") break;
                try
                {
                    read = readOp.Split();
                    input1 = Convert.ToInt32(read[0]); input2 = Convert.ToInt32(read[1]);
                    Console.WriteLine("Введите операцию(+(сложение), -(вычитание), *(умножение), /(деление).");
                    readOp = Console.ReadLine();
                    switch (readOp)
                    {
                        case "/":
                            {
                                try
                                {
                                    Console.WriteLine("Результат: " + div(input1, input2));
                                }
                                catch (DivException d)
                                {
                                    Console.WriteLine(d.Message);
                                }
                                break;
                            }
                        case "*":
                            {
                                Console.WriteLine("Результат: " + mul(input1, input2));
                                break;
                            }
                        case "+":
                            {
                                Console.WriteLine("Результат: " + add(input1, input2));
                                break;
                            }
                        case "-":
                            {
                                Console.WriteLine("Результат: " + sub(input1, input2));
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Невверный ввод!");
                                break;
                            }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Ошибка ввода!");
                }
            }
        }
    }
}