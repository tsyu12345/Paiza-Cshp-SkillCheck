using System;
using System.Linq;
using System.Collections.Generic;

class C120 {

    static void Main() {

        var N = int.Parse(Console.ReadLine()); //花の数N
        var S_1 = Console.ReadLine(); //1つ目のリース状態S_1
        var S_2 = Console.ReadLine(); //2つ目のリース状態S_2

        var S_2_Patterns = GetCirclePermutation(S_2);
        //S_2_Patternsの中にS_1が含まれているかどうかを判定する
        foreach(var s in S_2_Patterns) {
            if(s.Contains(S_1)) {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");

    }

    /**
    * 与えられた文字列から考えられる、円順列の文字列の配列を返す。
    */
    private static List<string> GetCirclePermutation(string target) {

        List<string> result = new List<string>();

        
        for(int i = 0; i < target.Length; i++) {
            string firstChar = target[i].ToString();
            string remainingStr = target.Substring(0, i) + target.Substring(i + 1);
            List<string> remainingPermutations = GetPermutation(remainingStr);
            foreach(var s in remainingPermutations) {
                Console.WriteLine(firstChar + s);
                result.Add(firstChar + s);
            }
        }

        return result;
    }

    /**
    * 与えられた文字列から考えられる、文字列の並べ替えの組み合わせを返す。
    */
    private static List<string> GetPermutation(string str) {
        List<string> result = new List<string>();
        if (str.Length == 1) {
            result.Add(str);
        } else {
            for (int i = 0; i < str.Length; i++) {
                string firstChar = str[i].ToString();
                string remainingStr = str.Substring(0, i) + str.Substring(i + 1);
                List<string> remainingPermutations = GetPermutation(remainingStr);
                foreach (string s in remainingPermutations) {
                    result.Add(firstChar + s);
                }
            }
        }
        return result;
    }



}