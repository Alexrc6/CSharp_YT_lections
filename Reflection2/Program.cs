/*Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.
Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.
[CustomName(“CustomFieldName”)]
public int I = 0.
Если использовать формат строки с данными использованной нами для предыдущего примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0
Подсказка:
Если GetProperty(propertyName) вернул null то очевидно свойства с таким именем нет и возможно имя является алиасом заданным 
с помощью CustomName. Возможно, если перебрать все поля с таким атрибутом то для одного из них propertyName = совпадает с таковым заданным атрибутом.*/

using System.Reflection;
using System.Text;

namespace Reflection2
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomNameAttribute : Attribute
    {
        public string Name { get; }

        public CustomNameAttribute(string name)
        {
            Name = name;
        }
    }

    internal class Program
    {
        public static TestClass? MakeTestClass()
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass) as TestClass;
        }

        public static TestClass? MakeTestClass(int i)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[] { i }) as TestClass;
        }

        public static TestClass? MakeTestClass(int i, string s, decimal d, char[] c)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[] { i, s, d, c }) as TestClass;
        }

        public static string ObjectToString(object o)
        {
            Type type = o.GetType();
            StringBuilder res = new StringBuilder();

            res.Append(type.AssemblyQualifiedName + ":");
            res.Append(type.Name + "|");

            var props = type.GetProperties();

            foreach (var item in props)
            {
                var customNameAttr = item.GetCustomAttribute<CustomNameAttribute>();
                string propName = customNameAttr != null ? customNameAttr.Name : item.Name;

                var temp = item.GetValue(o);
                res.Append(propName + ":");

                if (item.PropertyType == typeof(char[]))
                {
                    res.Append(new string(temp as char[]) + "|");
                }
                else
                {
                    res.Append(temp + "|");
                }
            }

            return res.ToString();
        }

       

            public static object? StringToObject(string s)
            {
                string[] arr = s.Split('|');
                string[] arr1 = arr[0].Split(':');

                object? some = Activator.CreateInstance(null, arr1[0].Split(",")[0])?.Unwrap();
                //object? some = Activator.CreateInstance(null, arr1[0].Split(",")[0]);

                if (arr1.Length > 1 && some != null)
                {
                    var type = some.GetType();
                    for (int i = 1; i < arr.Length; i++)
                    {
                        string[] nameAndValue = arr[i].Split(":");

                        var p = type.GetProperty(nameAndValue[0]);

                        if (p == null)
                        {
                            p = type.GetProperties()
        .FirstOrDefault(prop =>
            prop.GetCustomAttribute<CustomNameAttribute>()?.Name == nameAndValue[0]);
                        }

                        if (p != null)
                        {
                            if (p.PropertyType == typeof(int))
                            {
                                p.SetValue(some, int.Parse(nameAndValue[1]));
                            }
                            else if (p.PropertyType == typeof(string))
                            {
                                p.SetValue(some, nameAndValue[1]);
                            }
                            else if (p.PropertyType == typeof(decimal))
                            {
                                p.SetValue(some, decimal.Parse(nameAndValue[1]));
                            }
                            else if (p.PropertyType == typeof(char[]))
                            {
                                p.SetValue(some, nameAndValue[1].ToCharArray());
                            }
                        }
                    }
                }
            
                return some;
            }

            static void Main(string[] args)
        {
            char[] somearr = new char[] { 'a', 'g', 'f' };
            var n3 = MakeTestClass(6, "что-то", 1, somearr);

            string some = ObjectToString(n3);
            Console.WriteLine(some);

            var some1 = StringToObject(some);

            Console.WriteLine(ObjectToString(some1));
        }
    }
}