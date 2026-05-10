using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GymMS
{
    static class GymDataValidation
    {
       public static void CkechPhoneNo(string phone)
        {
            //check if phone number length is greater than 10
            if (phone.Length != 10)
                throw new Exception("Phone number must be greater than or equal to 10");
        }

        public static void CheckAge(DateTime birthDate)
        {
            //check if age is greater than 18
            int years = DateTime.Now.Year - birthDate.Year;
            if (years < 18)
                throw new Exception("Age must be more than 18 years");
        }

        public static void CkechStartAndEndDate(DateTime startDate, DateTime endDate)
        {
            //check if start date is less than end date
            if(startDate >= endDate)
                throw new Exception("Start date must be less then end date");

        }

        public static void CkechSubscrptionAmount(int amount, int paid_amount)
        {
            //check if paid amount is grater than amount
            if(amount < paid_amount)
                throw new Exception("Paid amount must be less than total amount");

        }

        public static void CkechAmount(int amount)
        {
            //check if amount is less than ZERO
            if(amount <= 0)
                throw new Exception("Amount should be more than ZERO");

        }

        public static void CkechCapacity(int capacity)
        {
            //check if capacity is less than ZERO
            if(capacity < 0)
                throw new Exception("Capacity should be more than ZERO");
        }
    }
}
