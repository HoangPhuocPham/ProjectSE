using System;
/*
    https://www.oodesign.com/abstract-factory-pattern.html
*/

namespace pj.DesignPatterm.Factory
{   
    public interface Food
    {
        void show();
    }

    public class ImportedHamburger : Food
    {
        public void show()
        {
            Console.WriteLine("Show info imported hamburger");
        }
    }

    public class HomemadeHamburger : Food
    {
        public void show()
        {
            Console.WriteLine("Show info homemade hamburger");
        }
    }

    public interface Drink
    {
        void show();
    }

    public class ImportedBeer : Drink
    {
        public void show()
        {
            Console.WriteLine("Show info imported beer");
        }
    }

    public class HomemadeBeer : Drink
    {
        public void show()
        {
            Console.WriteLine("Show info homemade beer");
        }
    }

    public abstract class GoodAbstractFactory 
    {
        public abstract Food getFood();
 
        public abstract Drink getDrink();
    }

    public class ImportedFactory : GoodAbstractFactory
    {
        public override Drink getDrink()
        {
            return new ImportedBeer();
        }

        public override Food getFood()
        {
            return new ImportedHamburger();
        }
    }

    public class HomemadeFactory : GoodAbstractFactory
    {
        public override Drink getDrink()
        {
            return new HomemadeBeer();
        }

        public override Food getFood()
        {
            return new HomemadeHamburger();
        }
    }

    public enum TypeofGood
    {
        Imported, Homemade
    }

    public class GoodFactory
    {
        public static GoodAbstractFactory GetFactory(TypeofGood type)
        {
            switch (type)
            {
                case TypeofGood.Homemade:
                    return new HomemadeFactory();
                case TypeofGood.Imported:
                    return new ImportedFactory();
                default:
                    return null;
            }
        }
        
    }

    public class AbstractFactoryPattern
    {
        public static void Run()
        {
            var imported = TypeofGood.Imported;
            GoodAbstractFactory factory = GoodFactory.GetFactory(imported);
            Food food = factory.getFood();
            food.show();
            Drink drink = factory.getDrink();
            drink.show();

        }
    }
}