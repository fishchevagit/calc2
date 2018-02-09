using CalcLibrary;
using System;
using System.Linq;
using System.Collections.Generic;
using CalcLibrary.Operations;
using System.Reflection;
using System.IO;

namespace CalcConsole
{
    public class Calc
    {

        public Calc()
        {
            Operations = new List<IOperation>();

            var curAssemly = Assembly.GetExecutingAssembly();
            // операции из текущей сборки
            LoadOperations(curAssemly);


            // операции сторонних разработчиков
            var pathExtenions = Path.Combine(Environment.CurrentDirectory, "extensions");

            if (Directory.Exists(pathExtenions))
            {
                var assemlies = Directory.GetFiles(pathExtenions, "*.dll");

                foreach (var fileName in assemlies)
                {
                    LoadOperations(Assembly.LoadFile(fileName));
                }
            }

        }

        private void LoadOperations(Assembly assemly)
        {
            var types = assemly.GetTypes();
            var typeOperation = typeof(IOperation);
            foreach (var type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;

                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeOperation))
                {

                    var obj = Activator.CreateInstance(type) as IOperation;
                    if (obj != null)
                    {
                        Operations.Add(obj);
                    }
                }
            }
        }

        private IList<IOperation> Operations;

        public string[] GetOperationNames()
        {
            return Operations.Select(o => o.Name).ToArray();
        }

        public double Exec(string operationName, string[] args)
        {
            IOperation oper;

            // найти операцию в списке операций
            oper = Operations.FirstOrDefault(it => it.Name == operationName);

            // если не удалось найти - возвращаем NaN
            if (oper == null)
            {
                return double.NaN;
            }

            // иначе 
            // вычисляем результат операции
            var result = oper.Exec(args);
            // если в результате ошибка заполнена
            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                // выводим ее на экран
            }
            else
            {
                // иначе выводим результат
                return result.Result;
            }
            // дефолтное значение
            return double.NaN;
        }

        #region int

        [Obsolete("НЕ ИСПОЛЬЗОВАТЬ!")]
        public int Sum(int x, int y)
        {
            return (int)Sum((double)x, (double)y);
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }

        #endregion

        #region double

        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }

        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        #endregion

    }
}
