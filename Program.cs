namespace Aoc2020day1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("AoC 2020 Day 2");

        String input = File.ReadAllText(@"input.txt");

        List<string> puzzleInput = input.Split('\n').ToList();

        // 8-14 k: xkkkwkkkkqkkkktz
        int valid = 0;
        for (int i = 0; i < puzzleInput.Count; i++)
        {
            if (validatePassword(puzzleInput[i]))
            {
                valid++;
            }
        }
        Console.WriteLine(valid);

        static Boolean validatePassword(string input)
        {
            // split the string into policy and password
            // validate password
            //Console.WriteLine(input);
            string[] strings = input.Split(": ");
            //Console.WriteLine(strings[0]);
            string[] policyString = strings[0].Split(' ');
            // policyString[0] "1-2"
            // policyString[1] "a"
            int[] minmax = policyString[0].Split('-').Select(i => Int32.Parse(i)).ToArray();
            //Console.WriteLine(minmax[0]);
            //Console.WriteLine(minmax[1]);
            //Console.WriteLine(policyString[1]); // the character to check
            //Console.WriteLine(strings[1]); // the passowrd to check
            int min = minmax[0];
            int max = minmax[1];
            char policyCharacter = policyString[1][0];
            string password = strings[1];
            //Console.WriteLine(strings[2]);
            

            int count = password.Count(f => f == policyCharacter);
            //Console.WriteLine($"Count is {count}");
            //Console.ReadLine();
            // 1-3 a means that the password must contain a at least 1 time and at most 3 times.
            //if (count >= min && count <= max)
            //{
            //    return true;
            //}
            //return false;

            return count >= min && count <= max ? true : false;
        }
    }


    static void Day1(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // givet ett papper med 6 siffror på
        // hur skulle jag göra för att hitta de två siffrorna
        // vars summa är 2020
        // vad är första steget

        // a. 1721
        // b.  979
        // c.  366
        // d.  299
        // e.  675
        // f.  1456

        // Steg 1. ta 2020 - a = 299 = x
        // Steg 2. finns x i listan?
        // Steg 3. Svar: ja. x = d
        // Steg 4. a + d, 1721 + 299 = 2020 (c) Danilo

        // Steg 1. Utgå ifrån a. Summera a och b. Är summan 2020?
        // Steg 2. Om ja, så har du din match
        // Steg 3. Om nej, summera a och c. Är summan 2020?
        // Steg 4. Rinse, repeat

        /*
        List<int> puzzleInput = new List<int>() {
            1721,
            979,
            366,
            299,
            675,
            1456
        };*/

        // a + b + c
        String input = File.ReadAllText(@"input.txt");

        List<int> puzzleInput = input.Split('\n').Select(s => Convert.ToInt32(s)).ToList();

        //Console.WriteLine(puzzleInput.Count);


        // Steg 1. Utgå ifrån a. Summera a och b. Är summan 2020?

        // puzzleInput[0] + puzzleInput[1] är lika med 2020 ?

        for (int i = 0; i < puzzleInput.Count; i++)
        {
            //Console.WriteLine(puzzleInput[i]);
            for (int j = i + 1; j < puzzleInput.Count; j++)
            {
                for (int k = j + 1; k < puzzleInput.Count; k++)
                {
                    //Console.WriteLine($"puzzleInput[i]: {puzzleInput[i]}, puzzleInput[j]: {puzzleInput[j]}");
                    int sum = puzzleInput[i] + puzzleInput[j] + puzzleInput[k];
                    //Console.WriteLine("sum: " + sum);
                    if (sum == 2020)
                    {
                        Console.WriteLine(puzzleInput[i] * puzzleInput[j] * puzzleInput[k]);
                    }
                }
            }

        }
        /*
        int sum = puzzleInput[0] + puzzleInput[1];
        if (sum == 2020)
        {
            // match
        }
        sum = puzzleInput[1] + puzzleInput[2];
        if (sum == 2020)
        {
            // match
        }
        */
    }
}

