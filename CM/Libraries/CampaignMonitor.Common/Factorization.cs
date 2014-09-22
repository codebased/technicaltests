//-----------------------------------------------------------------------
// <copyright file="Factorization.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Common
{
    using System;
    using System.Collections.Generic;
    using CampaignMonitor.Common.Extensions;

    /// <summary>
    /// Defines the Factorization object for factor.
    /// </summary>
    internal class Factorization
    {
        /// <summary>
        /// Initializes a new instance of the Factorization class.
        /// </summary>
        /// <param name="number">number for which the factor needs to be searched.</param>
        public Factorization(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number
        {
            get;
            set;
        }

        /// <summary>
        /// Validate the Factorization. Throws ArgumentException on invalid parameter.
        /// </summary>
        public void Validate()
        {
            if (this.Number.IsFactorable())
            {
            }
            else
            {
                throw new ArgumentException("Value should be great than 0.");
            }
        }

        /// <summary>
        /// Get a list of factor from the given number. 
        /// Throws ArgumentException if the number is less than 1.
        /// </summary>
        /// <returns>A list of factors (sorted) of a number.</returns>
        public List<int> Factor()
        {
            this.Validate();

            List<int> factors = new List<int>();

            // we do't have to loop through from 1 to number, instead do it half way!!!
            int factorLimit = (int)Math.Sqrt(this.Number);

            for (int factor = 1; factor <= factorLimit; ++factor)
            {
                //// test from 1 to the square root, or the int below it, inclusive.
                if (this.Number % factor == 0)
                {
                    factors.Add(factor);

                    //// just to check that it is not same as expected.
                    if (factor != (this.Number / factor))
                    {
                        factors.Add(this.Number / factor);
                    }
                }
            }

            // sort this out.
            factors.Sort();

            return factors;
        }
    }
}