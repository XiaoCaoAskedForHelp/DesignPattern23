namespace DesignPattern23._4_abstract_factory;

/// <summary>
/// 抽象工厂是解决生产同一个产品族的工资，而之前的工厂方法是同一产品的生产
/// </summary>
public class Client
{
    public static void Main(string[] args)
    {
        AmericanDessertFactory factory = new AmericanDessertFactory();
        Coffee coffee = factory.createCoffee();
        Dessert dessert = factory.createDessert();
        Console.WriteLine(coffee.getName());
        dessert.show();
    }
}