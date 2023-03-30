namespace DesignPattern23.factory_method;

public class AmericaCoffeeFactory : CoffeeFactory
{
    public Coffee createCoffee()
    {
        return new AmericanCoffee();
    }
}