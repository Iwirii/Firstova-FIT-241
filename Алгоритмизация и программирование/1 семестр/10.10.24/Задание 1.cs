using System;
public class Test
{
	public static void Main()
	{
		int a,result=0;
		a=Convert.ToInt32(Console.ReadLine());
		while(a>=0)
		{
    		while(a>0)
    		{
    		    if ((a%10)%2!=0)
    		    {
        		    result=result*10+a%10;
        		    a/=10;
    		    }
    		    else
    		    {
    		        a/=10;
    		    }
    		}
    		if (result==0)
    		{
    		    Console.WriteLine("Нет нечётных цифр");
    		}
    		else
    		{
    		Console.WriteLine(result);
    		}
    		result=0;
    		a=Convert.ToInt32(Console.ReadLine());
		}
	}
}
