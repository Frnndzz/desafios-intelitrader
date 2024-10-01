using System;

public class MenorDistanciaArrays
{

    public static void Main(string[] args)
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int[] array1 = { 12, -8, 25, 7, -13, 14, 9, 32, -21, 5, 18, -4, 26, 11, -16 };
        int[] array2 = { 20, 3, -11, 17, 100, -15, 28, -6, 31, -19, 8, 4, 22, -10, 6 };
        int menorDistancia = int.MaxValue;
        int distancia;
        int posicao1 = 0;
        int posicao2 = 0;


        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                distancia = modulo(array1[i] - array2[j]);


                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    posicao1 = i;
                    posicao2 = j;
                }

            }
        }

        Console.WriteLine("A menor distância é entre os números " + array1[posicao1] + " e " + array2[posicao2] + ".");
        Console.WriteLine("\nMenor Distância: " + menorDistancia);

    }

    static int modulo(int n)
    {
        if (n < 0)
        {
            return n * -1;
        }
        return n;
    }

}