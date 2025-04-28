using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.SOLID
{
    public class SingleResponsibilityPrinciple
    {
        // Bir sınıf, veya bir metodun tek bir işi olmalı. Yani senin metodun hem Mail Gönderip hemde sms göndermemeli.
        // yani bir sınıfın(fonksiyona da indirgenebilir) yapması gereken yalnızca bir işi olması gerekir.


        // YANLIŞ OLAN
        public class User
        {
            private long id;
            private String name;
            private String street;
            private String city;
            private String username;

            //Getters, setters

            public void changeAddress(String street, String city)
            {
                //logic
            }

            public void login(String username)
            {
                //logic
            }

            public void logout(String username)
            {
                //logic
            }
        }


        // DOĞRU OLAN
        //public class Address
        //{

        //    private String street;
        //    private String city;
        //    private String country;
        //    //Getter,setter
        //}

        //public class AddressService
        //{
        //    public void changeAddress(Address address)
        //    {
        //        // Sadece addressle ilgileniyorum ve ondan sorumluyum userdaki değişiklikler beni etkilemez.
        //        //logic
        //    }
        //}
        //public class User
        //{

        //    private Long id;
        //    private Address name;

        //    //Getter,setter
        //}

    }
}
