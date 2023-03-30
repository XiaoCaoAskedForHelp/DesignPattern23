namespace DesignPattern23._4_abstract_factory;

/// <summary>
/// 意大利分为甜品工厂，生产拿铁咖啡和提拉米苏
/// </summary>
public class LatteDessertFactory : DessertFactory
{
    public Coffee createCoffee()
    {
        return new LatteCoffee();
    }

    public Dessert createDessert()
    {
        return new Trimisu();
    }
}