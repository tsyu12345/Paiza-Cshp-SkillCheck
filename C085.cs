using System.Collections.Generic;
using System.Linq;
using System;

class C085 {

    static void Main(string[] args) {

        var t_s = Console.ReadLine().Split(' '); //各キーの耐久度
        var keyEndurance = GetAlphabetEndurances(t_s);
        var S = Console.ReadLine(); //入力文字

        var result = GetDisplayString(keyEndurance, S);
        Console.WriteLine(result);
    }



    private static dynamic GetAlphabetEndurances(string[] strArr) {
        var result = new int[strArr.Length];
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var alphabetEndurance = new Dictionary<char, int>();
        for(int i = 0; i < strArr.Length; i++) {
            alphabetEndurance.Add(alphabet[i], int.Parse(strArr[i]));
        }
        return alphabetEndurance;
    }


    private static string GetDisplayString(dynamic keyEnduranceDatas, string inputStr) {
        var result = "";
        for(int i = 0; i < inputStr.Length; i++) {
            var key = inputStr[i];
            if(keyEnduranceDatas[key] > 0) {
                result += key;
                keyEnduranceDatas[key]--;
            }
        }
        return result;
    }
}