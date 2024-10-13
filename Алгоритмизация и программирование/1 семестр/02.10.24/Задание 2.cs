//Определить минимальный размер подпоследовательности, состоящий из четных элементов
using System;
public class Test
{
	public static void Main()
	{
	    int a,cnt=0;
	    int n = Convert.ToInt32(Console.ReadLine());
        int mini=n+1;
        for (int i=0;i<n;i++)
        {
            a = Convert.ToInt32(Console.ReadLine());  
            if (a%2==0)
            {
                cnt++;
            }
            else
            {
                if (cnt>0) 
                {
                    mini=Math.Min(cnt,mini);
                }
            cnt=0;
            }
        }
        if (cnt>0) 
        {
            mini=Math.Min(cnt,mini);
        }
        if (mini == n+1)
        {
            Console.WriteLine("Чётных элементов нет");
        }
        else
        {
            Console.WriteLine(mini);
        }
    }
}
