using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entitites.Notifications
{
    public class Notification
    {


      


        public Notification()
        {
            Notifications = new List<Notification>();
        }




        [NotMapped]
        public string NameProperty { get; set; }

        [NotMapped]
        public string Mensage { get; set; }

        [NotMapped]
        public List<Notification> Notifications;



        public bool ValidateProperties(string value, string nameProperty)
        {

            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperty))
            {


                Notifications.Add(new Notification
                {
                    Mensage = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }


            return true;
        }


        public bool validateDecimal(decimal value, string nameProperty)
        {
            if (value < 0.5m || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notification
                {
                    Mensage = "O Valor deve ser maior que 0",
                    NameProperty = nameProperty
                    
                });

                return false;
            }
            return true;
        }


    }
}
