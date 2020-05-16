using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算器操作类
{
    public class operation
    {
        public static double Getresult(double numberA, double numberB, string operate)
        {
            double result = 0;
            switch (operate)
            {
                case "+":
                    result = numberA + numberB;
                    break;
                case "-":
                    result = numberA - numberB;
                    break;
                case "*":
                    result = numberA * numberB;
                    break;
                case "/":
                    result = numberA / numberB;
                    break;
                default: break;
            }
            return result;
        }
    }

    public class operation2
    {
        private double _number1;
        private double _number2;

        public double NumberA
        {
            get{ return _number1;}
            set { _number1 = value; }
        }

        public double NumberB
        {
            get { return _number2; }
            set { _number2 = value; }
        }

        public virtual double getResult()
        {
            double result = 0;
            return result;
        }
    }

    //加减乘除类
    public class addMethod:operation2
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }

    public class subMethod : operation2
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }

    public class mulMethod : operation2
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }


    public class divMethod : operation2
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA / NumberB;
            return result;
        }
    }

    //简单工厂模式
    public class OperationFactory
    {
        public static operation2 createOperation(string operate)
        {
            operation2 op = null;
            switch (operate)
            {
                case "+":
                    op = new addMethod();//多态
                    break;
                case "-":
                    op = new subMethod();//多态
                    break;
                case "*":
                    op = new mulMethod();//多态
                    break;
                case "/":
                    op = new divMethod();//多态
                    break;
                default: break;

            }
            return op;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.Write("请输入第一个数：");
            //    string strNumberA = Console.ReadLine();
            //    Console.Write("请输入运算符号（+-*/）：");
            //    string operate = Console.ReadLine();
            //    Console.Write("请输入第2个数：");
            //    string strNumberB = Console.ReadLine();
            //    string result = Convert.ToString(operation.Getresult(Convert.ToDouble(strNumberA), Convert.ToDouble(strNumberB), operate));
            //    Console.WriteLine();
            //    Console.Write("result = {0}", result);

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("您的输入有误：" + ex.Message);
            //}
            operation2 op;
            op = OperationFactory.createOperation("+");
            op.NumberA = 8;
            op.NumberB = 90.8;
            double result = op.getResult();
            Console.WriteLine("结果是：{0}", result);
        }
    }
}
