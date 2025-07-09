using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionLibrary
{
    public class ConcessionCalculator
    {
        public string CalculateConcession(int age)
        {
            const decimal totalFare = 500M;

            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal concessionAmount = totalFare * 0.30M;
                decimal discountedFare = totalFare - concessionAmount;
                return $"Senior Citizen - Fare: {discountedFare:F2}";
            }
            else
            {
                return $"Ticket Booked - Fare: {totalFare:F2}";
            }
        }
    }
}
