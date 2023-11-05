using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektor_Mathematik
{
    class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        

        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public void ShowVector()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"X : {X}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Y : {Y}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Z : {Z}");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static Vector operator +(Vector Vector1, Vector Vector2)
        {
            Vector resultVec = new Vector(0, 0, 0);
            resultVec.X = Vector1.X + Vector2.X;
            resultVec.Y = Vector1.Y + Vector2.Y;
            resultVec.Z = Vector1.Z + Vector2.Z;
            return resultVec;
        }

        public static Vector operator -(Vector Vector1, Vector Vector2)
        {
            Vector resultVec = new Vector(0, 0, 0);
            resultVec.X = Vector1.X - Vector2.X;
            resultVec.Y = Vector1.Y - Vector2.Y;
            resultVec.Z = Vector1.Z - Vector2.Z;
            return resultVec;
        }

        public static Vector operator *(Vector Vector1, int skalar)
        {
            Vector resultVec = new Vector(0, 0, 0);
            resultVec.X = Vector1.X * skalar;
            resultVec.Y = Vector1.Y * skalar;
            resultVec.Z = Vector1.Z * skalar;
            return resultVec;

        }

        //Distanz zwischen 2 Vektoren ausgeben
        public virtual float Distance(Vector Vector2)
        {
            float resultX = X - Vector2.X;
            double resultDoubleX = Math.Pow(resultX, 2);
            float resultY = Y - Vector2.Y;
            double resultDoubleY = Math.Pow(resultY, 2);
            float resultZ = Z - Vector2.Z;
            double resultDoubleZ = Math.Pow(resultZ, 2);

            double resultDouble = resultDoubleX + resultDoubleY + resultDoubleZ;
            double result = Math.Sqrt(resultDouble);
            return (float)result;


        }

        //Distanz zwischen 2 Vektoren ausgeben
        public static float DistanceStatic(Vector Vector1, Vector Vector2)
        {
            float resultX = Vector1.X - Vector2.X;
            double resultDoubleX = Math.Pow(resultX, 2);
            float resultY = Vector1.Y - Vector2.Y;
            double resultDoubleY = Math.Pow(resultY, 2);
            float resultZ = Vector1.Z - Vector2.Z;
            double resultDoubleZ = Math.Pow(resultZ, 2);

            double resultDouble = resultDoubleX + resultDoubleY + resultDoubleZ;
            double result = Math.Sqrt(resultDouble);
            return (float)result;
        }

        //Länge eines Vektors ausgeben
        public virtual float Length()
        {
            float resultX = X * X;
            float resultY = Y * Y;
            float resultZ = Z * Z;
            float resultAdd = resultX + resultY + resultZ;

            double resultDouble = Math.Sqrt(resultAdd);
            return (float)resultDouble;           
        }

        //Quadratlänge eines Vektors ausgeben
        public virtual float SquareLength()
        {
            float resultX = X * X;
            float resultY = Y * Y;
            float resultZ = Z * Z;
            float resultAdd = resultX + resultY + resultZ;

                    
            return (float)resultAdd;
        }
    }
}
