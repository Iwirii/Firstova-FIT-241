//Определить макс сумму подпоследовательности, состоящей из четных элементов
using System;
public class Test
{
	public static void Main()
	{
	    int a,sum=0;
	    int n = Convert.ToInt32(Console.ReadLine());
        int maxi=0;
        for (int i=0;i<n;i++)
        {
            a = Convert.ToInt32(Console.ReadLine());  
            if (a%2==0)
            {
                sum+=a;
            }
            else
            {
                if (sum>0) 
                {
                    maxi=Math.Max(sum,maxi);
                }
            sum=0;
            }
        }
        maxi=Math.Max(sum,maxi);
        Console.WriteLine(maxi);
    }
}
