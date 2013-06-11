using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidTest
{
    public class Delegatebase
    {
        public delegate double CalculateMethod(double firstParam, double secondParam);
        public event CalculateMethod CalculateMethodHandler;
        /// <summary>
        /// Add Method
        /// </summary>
        /// <param name="first_param"></param>
        /// <param name="second_param"></param>
        /// <returns></returns>
        public static double Plus(double first_param, double second_param)
        {
            return first_param + second_param;
        }

        /// <summary>
        /// Minus Method
        /// </summary>
        /// <param name="first_param"></param>
        /// <param name="second_param"></param>
        /// <returns></returns>
        public static double Minus(double first_param, double second_param)
        {
            return first_param - second_param;
        }

        /// <summary>
        /// Mutiply Method
        /// </summary>
        /// <param name="first_param"></param>
        /// <param name="second_param"></param>
        /// <returns></returns>
        public static double Mutiply(double first_param, double second_param)
        {
            return first_param * second_param;
        }

        /// <summary>
        /// Divide Method
        /// </summary>
        /// <param name="first_param"></param>
        /// <param name="second_param"></param>
        /// <returns></returns>
        public static double Divide(double first_param, double second_param)
        {
            return second_param == 0 ? 0 : first_param / second_param;
        }
    }
}
