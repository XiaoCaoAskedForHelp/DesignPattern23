namespace DesignPattern23.factory.before;

public class CoffeeStore
{
    public Coffee orderCoffee(String type)
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
        //加配料
        coffee.addMilk();
        coffee.addSugar();
        return coffee;
    }
}