namespace DesignPattern23.simple.factory;

/// <summary>
/// 商店类，可能会有很多，所以将商店和Coffee的耦合解开，就不用因为咖啡的的种类变多而修改所有的咖啡店代码
/// </summary>
public class CoffeeStore
{
    public Coffee orderCoffee(String type)
    {
        Coffee coffee = SimpleCoffeeFactory.CreateCoffee(type);
        //加配料
        coffee.addMilk();
        coffee.addSugar();
        return coffee;
    }
}