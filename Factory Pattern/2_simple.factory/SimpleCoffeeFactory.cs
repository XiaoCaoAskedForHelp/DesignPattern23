namespace DesignPattern23.simple.factory;

/// <summary>
/// 简单咖啡工厂，用来生产咖啡。
/// </summary>
public class SimpleCoffeeFactory
{
    /// <summary>
    /// 静态工厂就是在方法上加static，不加也行。
    /// 不加的好处是不需要创建对象，直接通过类型获取对象
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Coffee CreateCoffee(String type)
    {
        Coffee coffee = null;
        if ("american".Equals(type))
        {
            coffee = new AmericanCoffee();
        }
        else if("latte".Equals(type))
        {
            coffee = new LatteCoffee();
        }
        else
        {
            throw new Exception("对不起，您所点的咖啡没有");
        }
        return coffee;
    }
}