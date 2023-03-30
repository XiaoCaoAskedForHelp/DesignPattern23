namespace DesignPattern23.factory_method;

public class LatteCoffeeFactory : CoffeeFactory
{
    public Coffee createCoffee()
    {
        return new LatteCoffee();
    }
}