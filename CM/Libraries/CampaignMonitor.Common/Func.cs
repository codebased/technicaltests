//-----------------------------------------------------------------------
// <copyright file="Func.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CampaignMonitor.Common.Extensions;

    /// <summary>
    /// Defines a list of class functions that can be used throughout any application.
    /// </summary>
    public class Func
    {
        /// <summary>
        /// Get a list of factor from the given number. 
        /// Throws ArgumentException if the number is less than 1.
        /// </summary>
        /// <param name="number">A positive number to factor.</param>
        /// <returns>A list of factors (sorted) of a number.</returns>
        public static List<int> Factor(int number)
        {
            Factorization fac = new Factorization(number);
            return fac.Factor();
        }

        /// <summary>
        /// Get the triangle of a area that has been sent through.
        /// </summary>
        /// <param name="sideA">Side A of a triangle</param>
        /// <param name="sideB">Side B of a triangle</param>
        /// <param name="sideC">Side C of a triangle</param>
        /// <returns>Calculated triangle area</returns>
        public static double TriangleArea(int sideA, int sideB, int sideC)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            triangle.Validate();

            return triangle.Area();
        }

        /// <summary>
        /// Get a list of integer that are matching with the final list.
        /// </summary>
        /// <param name="intgrColtion">An array of integers</param>
        /// <returns>An array of the most common integers</returns>
        public static List<int> MostCommonIntegers(List<int> intgrColtion)
        {
            if (intgrColtion != null && intgrColtion.Count() > 0)
            {
                // Get an object with two properties Item and Count
                var groupedItems = from item in intgrColtion
                                   group item by item into g
                                   orderby g.Count() descending
                                   select new { Item = g.Key, Count = g.Count() };

                if (groupedItems != null && groupedItems.Count() > 0)
                {
                    // get the first instance of query.
                    var firstItem = groupedItems.FirstOrDefault();

                    // get all items that has same count.
                    var returnValue = (from a in groupedItems
                                       where a.Count == firstItem.Count
                                       select a.Item).ToList<int>();

                    return returnValue;
                }
            }

            return null;
        }

        public static List<int> MaxNumbers(List<int> intList, int count)
        {
             
            var index = 0 ;
            var top = (from item in intList
                       select new { Index = index++, Value = item } );

            var finalResult = (from t in top
                               orderby t.Value descending
                               select t.Index).Take(count);

            return finalResult.ToList<int>();
        }
    }
}
