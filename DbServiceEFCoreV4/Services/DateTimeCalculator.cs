using System;
namespace detectVideoApp
{
    public class DateTimeCalculator
    {
        /// <summary>
        /// Returns a result of the substraction of two dates in seconds
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns>integer value</returns>
        public static int SubstactTwoDates(DateTime firstDate, DateTime secondDate)
        {

            return (int)secondDate.TimeOfDay.Subtract(firstDate.TimeOfDay).TotalSeconds;
        }

        // can call static method without creating an object of the class. Static methods are sometimes called class methods.
        /// <summary>
        /// Checks if a given date is between two given dates
        /// </summary>
        /// <param name="date"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>return true if the date is between dates</returns>
        public static bool IsBetweenTwoDates(DateTime date, DateTime fromDate, DateTime toDate)
        {
            return date.Date >= fromDate.Date && date.Date <= toDate.Date;
        }

        /// <summary>
        /// Checks  if two dates are equal or not
        /// </summary>
        /// <param name="date"></param>
        /// <param name="anotherDate"></param>
        /// <returns>true value if dates are equal</returns>
        public static bool isEqual(DateTime date, DateTime anotherDate)
        {
            if (date.Equals(anotherDate))
            {
                return true;
            }

            return false;
        }
    }
}
