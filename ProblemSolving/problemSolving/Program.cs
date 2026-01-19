using System.Text;

public class Reverse{
    static void Main(){
        string text="hi hello                                hh";
        StringBuilder sb=new StringBuilder();
        for(int i = text.Length-1; i >=0; i--)
        {
            sb.Append(text[i]);
        }

        Console.WriteLine(sb.ToString());
    }
}