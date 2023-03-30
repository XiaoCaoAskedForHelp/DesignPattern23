// using System.Linq.Expressions;
//
// Console.WriteLine("Hello, World!");
//
// // Expression<Func<People, bool>> expression = p => p.Id == 10;
// // Func<People, bool> func = expression.Compile();
// // bool bResult = func.Invoke(new People()
// // {
// //     Id = 10,
// //     Name = "张三"
// // });
// // Console.WriteLine(bResult);
//
// // public class People
// // {
// //     public int Id { get; set; }
// //     public string Name { get; set; }
// // }
// //-------------------------------------------------------------------
//
// // var a = Expression.Parameter(typeof(double), "a");
// // var b = Expression.Parameter(typeof(double), "b");
// // var r1 = Expression.Add(a, b);//a+b
// // var c = Expression.Parameter(typeof(double), "c");
// // var d = Expression.Parameter(typeof(double), "d");
// // var r2 = Expression.Subtract(c, d);//c-d
// // var r3 = Expression.Multiply(r1, r2);//(a+b)*(c-d)
// // var e = Expression.Parameter(typeof(double), "e");
// // var r4 = Expression.Modulo(r3, e);//(a+b)*(c-d)%e
// // var lambda = Expression.Lambda<Func<double, double, double, double, double, double>>(r4, a, b, c, d, e);
// // Console.WriteLine(lambda.ToString());
// // var dd = lambda.Compile()(2, 3, 4, 5, 6);
// // Console.WriteLine(dd);
//
// //-------------------------------------------------------------------------------------
//
// var newExpression = Expression.New(typeof(MyClass).GetConstructor(new[] { typeof(int) }), Expression.Constant(100)); // 有参构造函数方式
// //var newExpression = Expression.New(typeof(MyClass)); //无参构造函数方式
// var lambda = Expression.Lambda<Func<MyClass>>(newExpression);
// var myClass = lambda.Compile()();
// Console.WriteLine(myClass.SayHello("aaaa"));
//
// var e = Expression.Parameter(typeof(MyClass), "e");
// var property = Expression.Property(e, nameof(MyClass.MyProperty));
// var lambda1 = Expression.Lambda<Func<MyClass, String>>(property, e);
// var s = lambda1.Compile()(new MyClass(10) { MyProperty = "asdf" });
// Console.WriteLine(s);
//
// //赋值操作
// var assignString = Expression.Assign(property, Expression.Constant("ssss"));
// var assignList = Expression.Assign(Expression.Property(e, nameof(MyClass.List)),
//     Expression.Constant(new List<string>() { "sdf" }));
// Expression.Lambda<Action<MyClass>>(assignList, e).Compile()(myClass);
// Expression.Lambda<Action<MyClass>>(assignString, e).Compile()(myClass);
// Console.WriteLine(myClass.List.Count);
// Console.WriteLine(myClass.MyProperty);
//
// //调用方法
// var method = typeof(MyClass).GetMethod(nameof(GetHashCode));
// var call = Expression.Call(e, method);
// var lambda2 = Expression.Lambda<Func<MyClass, int>>(call, e).Compile()(myClass);
// Console.WriteLine(lambda2);
//
// //调用有参方法
// var method2 = typeof(MyClass).GetMethod(nameof(MyClass.SayHello), new[] { typeof(string) });
// var call2 = Expression.Call(e, method2, Expression.Constant("你好"));//调用SayHello方法并给方法传入"你好"参数
// var lambda3 = Expression.Lambda<Func<MyClass, string>>(call2, e).Compile();
// Console.WriteLine(lambda3(myClass));
//
// //调用Linq扩展方法e=>e.List.Contains("s")
// var list = Expression.Property(e, nameof(MyClass.List));//e.List
// var containsMethod = typeof(Enumerable).GetMethods().FirstOrDefault(info => info.GetParameters().Length == 2 && info.Name == "Contains").MakeGenericMethod(typeof(string));
// var contains = Expression.Call(null, containsMethod, list, Expression.Constant("s"));//e.List.Contains("s")
// var lambda4 = Expression.Lambda<Func<MyClass, bool>>(contains, e);
// Console.WriteLine(lambda4.Compile()(new MyClass(1){List = new List<string>(){"s"}}));
//
// //e=>e.List.Any(item=>item.Contains("s"))
// var s5 = Expression.Parameter(typeof(string), "s");
// var antContains = Expression.Call(
//     s5,
//     typeof(string).GetMethod("Contains",new[]{typeof(string)}),
//         Expression.Constant("a"));
// var containsLambda = Expression.Lambda<Func<string,bool>>(antContains, s5);
// var any = typeof(Enumerable).GetMethods().FirstOrDefault(info => info.GetParameters().Length == 2 && info.Name == "Any")
//     .MakeGenericMethod(typeof(string));
// var list5 = Expression.Property(e, nameof(MyClass.List));
// var whereLambda = Expression.Call(null, any, list, containsLambda);
// var lambda5 = Expression.Lambda<Func<MyClass, bool>>(whereLambda, e);
// Console.WriteLine(lambda5.Compile()(new MyClass(1){List = new List<string>(){"s"}}));
//
// //e => e.MyBool ? "真的" : "假的";
// var expression = Expression.Property(e, "MyBool");
// var condition = Expression.Condition(expression, Expression.Constant("true1"), Expression.Constant("false1"));
// var lambda6 = Expression.Lambda<Func<MyClass, string>>(condition, e);
// var dsa = lambda6.Compile()(new MyClass(1){ MyBool = true });
// Console.WriteLine(dsa);
//
// public class MyClass
// {
//     public MyClass(int num)
//     {
//         Number = num;
//     }
//     public bool MyBool { get; set; }
//     public int Number { get; set; }
//     public string MyProperty { get; set; }
//     public List<string> List { get; set; }
//     public string SayHello(string s)
//     {
//         return s + DateTime.Now.ToString("yyyy-MM-dd");
//     }
// }
//
//
