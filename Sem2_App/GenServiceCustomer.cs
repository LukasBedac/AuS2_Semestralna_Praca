using GUIAuS2;
using Semestralna_Praca2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2_App
{
    public static class GenServiceCustomer
    {
        public static ServiceCustomer GetServiceCustomer()
        {
            ServiceCustomer customer = new();
            customer.ID = UniqueIDGenerator.GetUniqueID();
            customer.ECV = ECVGenerator.GetECV();
            customer.SureName = NameGenerator.GenerateSureName();
            customer.LastName = NameGenerator.GenerateLastName();
            customer.ServiceVisits = [];
            customer.SetLengths();
            return customer;
        }
    }
}
