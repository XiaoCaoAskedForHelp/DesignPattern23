﻿namespace DesignPattern23._4_abstract_factory;

public interface DessertFactory
{
    //生产咖啡的功能
    Coffee createCoffee();
    //生产甜品的功能
    Dessert createDessert();
}