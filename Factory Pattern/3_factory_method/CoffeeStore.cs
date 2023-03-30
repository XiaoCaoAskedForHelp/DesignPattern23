using DesignPattern23.simple.factory;

namespace DesignPattern23.factory_method;

/// <summary>
/// 商店类，可能会有很多，所以将商店和Coffee的耦合解开，就不用因为咖啡的的种类变多而修改所有的咖啡店代码
/// </summary>
public class CoffeeStore
{
    private CoffeeFactory _factory;

    public CoffeeStore(CoffeeFactory factory)
    {
        _factory = factory;
    }

    public Coffee orderCoffee()
    {
        Coffee coffee = _factory.createCoffee();
        coffee.addMilk();
        coffee.addSugar();
        return coffee;
    }
}