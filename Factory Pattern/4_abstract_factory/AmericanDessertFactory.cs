namespace DesignPattern23._4_abstract_factory;

/// <summary>
/// 美式风味的甜品工厂，可以生产美式咖啡和抹茶慕斯
/// </summary>
public class AmericanDessertFactory : DessertFactory
{
    public Coffee createCoffee()
    {
        return new AmericanCoffee();
    }

    public Dessert createDessert()
    {
        return new MatchaMousse();
    }
}