using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.SOLID
{
    public class DependencyInversionPrinciple
    {
        // ÖZET: Sınıflar arası bağımlılıklar olabildiğince az olmalıdır özellikle üst seviye sınıflar alt seviye sınıflara bağımlı olmamalıdır.
        // DOĞRU YÖNTEM
        public interface Message
        {
            void sendMessage();
        }

        public class Email : Message
        {
            public void sendMessage()
            {
                sendEmail();
            }

            private void sendEmail()
            {
                //Send email
            }
        }
        public class SMS : Message
        {
            public void sendMessage()
            {
                sendSMS();
            }

            private void sendSMS()
            {
                //Send email
            }
        }
        public class Notification
        {

            private List<Message> messages;

            public Notification(List<Message> messages)
            {
                this.messages = messages;
            }

            public void sender()
            {
                foreach (var item in messages)
                {
                    item.sendMessage();
                }

            }
        }

    }
}
