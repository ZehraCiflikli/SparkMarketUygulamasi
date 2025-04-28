using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.SOLID
{
    public class InterfaceSegregationPrinciple
    {
        //ÖZET: Sorumlulukların hepsini tek bir arayüze toplamak yerine daha özelleştirilmiş birden fazla arayüz oluşturmalıyız.
        //public interface Animal
        //{
        //    void fly();
        //    void run();
        //    void bark();
        //}


        //public class Bird implements Animal
        //{
        //public void bark()
        //{
        //    /* do nothing */
        //}
        //public void run()
        //{
        //    System.out.println("Koşan kuş");
        //}
        //public void fly()
        //{
        //    System.out.println("Uçan kuş");
        //}

        //public class Cat implements Animal
        //{
        //public void fly()
        //{
        //    /* do nothing */
        //}
        //public void bark()
        //{
        //    /* do nothing */
        //}
        //public void run()
        //{
        //    System.out.println("Koşan kedi");
        //    // logic        
        //}

        public interface Flyable
        {
            void fly();
        }
        public interface Runnable
        {
            void run();
        }
        public interface Barkable
        {
            void bark();
        }

        //    public class Bird: Flyable, Runnable {
        //public void run()
        //    {
        //        System.out.println("Kuş,Koşuyorum");
        //        //logic
        //    }
        //    public void fly()
        //    {
        //        System.out.println("Kuş, Uçuyorum.");
        //        //logic
        //    }

        //    public class Cat implements Runnable
        //    {
        //public void run()
        //    {
        //        System.out.println("Kedi,Koşuyorum");
        //        //logic
        //    }

    //}


}
}
