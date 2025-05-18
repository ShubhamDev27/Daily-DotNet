package Logic;

public class All_PrimeNum
{
	public static boolean check(int a) 
	{
		for(int i=2;i<a;i++) 
		{
			if(a%i==0) 
			{
				return false;
			}
		}
		return true;
	}
	public static void main(String[] args)
	{
		int n = 30;
		for(int i=2;i<n;i++) 
		{
			boolean b = check(i);
			if(b==true) 
			{
				System.out.println(i);
			}
		}
		
	}

}
