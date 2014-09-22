//-----------------------------------------------------------------------
// <copyright file="Triangle.cs" company="CM Pty. Ltd.">
//     Copyright (c) CM. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CampaignMonitor.Common
{
    using System;

    /// <summary>
    /// Defines the Triangle objects that gives all functionalities related with Triangle Math.
    /// </summary>
    internal class Triangle
    {
        /// <summary>
        ///  Initializes a new instance of the Triangle class.
        /// </summary>
        /// <param name="sideA">Triangle side A</param>
        /// <param name="sideB">Triangle side B</param>
        /// <param name="sideC">Triangle side C</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;

            this.Validate();
        }

        /// <summary>
        /// Gets or sets the triangle side A
        /// </summary>
        public double SideA
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the triangle side B
        /// </summary>
        public double SideB
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the triangle side C
        /// </summary>
        public double SideC
        {
            get;
            set;
        }

        /// <summary>
        /// Validate the Triangle. Throws InvalidTriangleException on invalid parameter.
        /// </summary>
        public void Validate()
        {
            bool invalidTriangle = this.SideA < 0 | this.SideB < 0 | this.SideC < 0 |
                ((this.SideA + this.SideB) < this.SideC
                    | (this.SideB + this.SideC) < this.SideA
                    | (this.SideA + this.SideC) < this.SideB);

            if (invalidTriangle)
            {
                throw new InvalidTriangleException();
            }
        }

        /// <summary>
        /// Get the area of a triangle using 
        /// the Length of Each Side (Heron's Formula)
        /// </summary>
        /// <returns> The area of a triangle</returns>
        public double Area()
        {
            this.Validate();

            // Calculate the semi-perimeter of the triangle.
            double semiPeri = (this.SideA + this.SideB + this.SideC) / 2D;
            return Math.Sqrt(semiPeri * (semiPeri - this.SideA) * (semiPeri - this.SideB) * (semiPeri - this.SideC));
        }

        /// <summary>
        /// Get the perimeter of a triangle
        /// </summary>
        /// <returns>return perimeter of the triangle</returns>
        public double Perimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }
    }
}
