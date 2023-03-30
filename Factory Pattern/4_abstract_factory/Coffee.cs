﻿namespace DesignPattern23._4_abstract_factory;
/// <summary>
///咖啡类
/// </summary>
public abstract class Coffee
{
    public abstract string getName();
    
    public void addSugar()
    {
        Console.WriteLine("Add sugar");
    }

    public void addMilk()
    {
        Console.WriteLine("Add milk");
    }
}