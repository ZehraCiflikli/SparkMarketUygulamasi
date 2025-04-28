using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.SOLID
{
    public class OpenClosedPrinciple
    {
        // Değişime Kapalı
        // Gelişime Açık


        //ÖZET: Bir sınıf ya da fonksiyon halihazırda var olan özellikleri korumalı ve değişikliğe izin vermemelidir.Yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabiliyor olmalıdır.

        // YANLIŞ 

        //public class Rectangle
        //{
        //    private double length;
        //    private double height;
        //    // getters/setters ... 
        //}


        //    public class AreaService
        //    {
        //       public double calculateArea(List<Rectangle>...shapes)
        //        {
        //            double area = 0;
        //            for (Rectangle rect : shapes)
        //            {
        //                area += (rect.getLength() * rect.getHeight());
        //            }
        //            return area;
        //        }
        //    }
        //    //---------------------------------------------------------

        //    public class Circle
        //    {
        //        private double radius;
        //        // getters/setters … 
        //    }
        //    public class AreaService
        //    {
        //        public double calculateArea(List<Object>...shapes)
        //        {
        //            double area = 0;
        //            for (Object shape : shapes)
        //            {
        //                if (shape instanceof Rectangle) {
        //                Rectangle rect = (Rectangle)shape;
        //                area += (rect.getLength() * rect.getHeight());
        //            } else if (shape instanceof Circle) {
        //                Circle circle = (Circle)shape;
        //                area += circle.getRadius() * cirlce.getRadius() * Math.PI;
        //            } else
        //            {
        //                throw new RuntimeException("Shape not supported");
        //            }
        //        } return area;
        //}

        //--------------------------------------------------------------------

        public interface Shape
        {
            double getArea();
        }

        //public class Rectangle : Shape
        //{
        //    private double length;
        //    private double height;
        //    public override double getArea()
        //    {
        //        return (length * height);
        //    }
        //}
        //public class Circle : Shape
        //{
        //    private double radius;

        //    // getters/setters … 

        //    public override double getArea()
        //    {
        //        return (radius * radius * Math.PI);
        //    }
        //}

        //public class AreaManager
        //{
        //    public double calculateArea(List<Shape> shapes)
        //    {
        //        double area = 0;
        //        for (Shape shape : shapes)
        //        {
        //            area += shape.getArea();
        //        }
        //        return area;
        //    }
        //}


    }

}
