using System;

public class Class1
{
	public Class1()
	{
        StreamReader sr = new StreamReader("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\bludisko.xlsx");

        while (true)
        {
            string obsah = nahrada.ReadLine();

            if (obsah == null)
                break;

            Console.WriteLine(obsah);
        }
    }
}
