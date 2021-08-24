using System;

namespace Matrix
{
    class Program
    {
        static dynamic[,] MatrixCreate(int rows, int cols)
        {
            dynamic[,] result = new dynamic[rows, cols];
            return result;
        }
        static dynamic[,] MatrixForm(dynamic[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            return matrix;
        }
        static dynamic[,] RanMatrxGen()
        {
            int n = default, m = default;
            Console.Write("Enter A Number Of Rows : ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter A Number Of Colums: ");
            m = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            dynamic[,] MyMatrix = MatrixCreate(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    MyMatrix[i, j] = random.Next(1, 100);
                    //Console.Write(MyMatrix[i, j] + "\t");
                }
                //Console.WriteLine();
            }
            return MyMatrix;
        }
        static dynamic[,] add(dynamic[,] Matrix1, dynamic[,] Matrix2)
        {
            dynamic[,] result = MatrixCreate(Matrix1.GetLength(0), Matrix1.GetLength(1));
            try
            {
                if (Matrix1.GetLength(0) == Matrix2.GetLength(0) && Matrix1.GetLength(1) == Matrix2.GetLength(1))
                {
                    for (int i = 0; i < Matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < Matrix1.GetLength(1); j++)
                        {
                            result[i, j] = Matrix1[i, j] + Matrix2[i, j];
                        }
                    }
                }
                else
                {
                    throw new Exception("For addition Matrices size needs to be the same");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
        static dynamic[,] ScMulty(dynamic[,] Matrix, double x)
        {
            dynamic[,] result = MatrixCreate(Matrix.GetLength(0), Matrix.GetLength(1));
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    result[i, j] = Matrix[i, j] * x;
                }
            }
            return result;
        }
        static dynamic[,] Multy(dynamic[,] Matrix1, dynamic[,] Matrix2)
        {
            dynamic[,] result = new dynamic[Matrix1.GetLength(0), Matrix2.GetLength(1)];

            try
            {
                if (Matrix1.GetLength(1) == Matrix2.GetLength(0))
                {
                    for (int i = 0; i < Matrix1.GetLength(0); ++i)
                    {
                        for (int j = 0; j < Matrix2.GetLength(1); ++j)
                        {
                            for (int k = 0; k < Matrix1.GetLength(1); ++k)
                            {
                                if (result[i, j] == null)
                                {
                                    result[i, j] = 0;
                                }

                                result[i, j] += Matrix1[i, k] * Matrix2[k, j];
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Colums of the first matrix needs to be equal to the rows of the second one: ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
        static dynamic[,] Inverse(dynamic[,] matrix)
        {
            dynamic[,] result = new dynamic[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result = Math.Pow(matrix[i, j], -1);
                }
            }
            return result;
        }
        static string Orth(dynamic[,] m)
        {
            string answer = default;
            if (m.GetLength(0) != m.GetLength(1))
            {
                answer = "Is Not Orthogonal";
            }
            else
            {
                answer = "Is Orthogonal";
            }
            return answer;
        }
        static dynamic Max(dynamic[,] matrix)
        {
            dynamic max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
        static dynamic Min(dynamic[,] matrix)
        {
            dynamic min = 100;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }
        static dynamic[,] Transpose(dynamic[,] matrix)
        {
            dynamic[,] resultMatix = new dynamic[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    resultMatix[i, j] = matrix[j, i];
                }
            }

            return resultMatix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("****************************Operations With Matrices****************************\n");
            Console.WriteLine("*Matrices Will Be Generated Randomly\n");
            Console.WriteLine("Enter Parameters For The First Matrix");
            dynamic[,] m1 = MatrixForm(RanMatrxGen());
            Console.WriteLine();
            Console.WriteLine("Enter Parameters For The Second Matrix");
            dynamic[,] m2 = MatrixForm(RanMatrxGen());
            Console.WriteLine();
            Console.WriteLine($"The Largest Value In The First Matrix Is: {Max(m1)}\n");
            Console.WriteLine($"The Smallest Value In The First Matrix Is: {Min(m1)}\n");
            Console.WriteLine($"The Largest Value In The Second Matrix Is: {Max(m2)}\n");
            Console.WriteLine($"The Smallest Value In The Second Matrix Is: {Min(m2)}\n");
            Console.WriteLine("Checking Whether Entered Matrices Are Orthogonal...\n");
            Console.WriteLine("The First Matrix " + Orth(m1) + "\n");
            Console.WriteLine("The Second Matrix " + Orth(m2) + "\n");
            Console.WriteLine("**************Transpose For The Fist Matrix Is**************\n");
            MatrixForm(Transpose(m1));
            Console.WriteLine("**************Transpose For The Second Matrix Is**************\n");
            MatrixForm(Transpose(m2));
            Console.WriteLine();
            Console.WriteLine("**************Addition Of Those Two Matrices**************\n");
            MatrixForm(add(m1, m2));
            Console.WriteLine();
            Console.WriteLine("\n**************Multiplication Of Those Two Matrices**************\n");
            MatrixForm(Multy(m1, m2));
            Console.WriteLine("**************Scalar Multiplication**************\n");
            Console.Write("Enter A number For A Matrices To be Multiplied: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n Multiplied With First Matrix");
            MatrixForm(ScMulty(m1, x));
            Console.WriteLine("\n Multiplied With Second Matrix");
            MatrixForm(ScMulty(m2, x));
        }
    }
}
