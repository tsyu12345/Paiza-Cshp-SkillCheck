using System;
using System.Linq;

class C114 {

    static void Main(string[] args) {
        
        var N = int.Parse(Console.ReadLine()); //入力単語数N
        var phrases = GetPhrases(N); //入力単語リスト

        CheckPhrases(phrases);


    }


    private static void CheckPhrases(string[] phrases) {
        for(int i = 0; i < phrases.Length - 1; i++) {
            var first = phrases[i];
            var second = phrases[i + 1];
            if(!IsSatisfiedRule(first, second)) {
                //しりとりが成立しない単語に来た場合
                Console.WriteLine("{0} {1}", first.LastOrDefault(), second.FirstOrDefault());
                return;
            }
        }
        //全単語においてしりとり成立の場合
        Console.WriteLine("Yes");
        
    }

    /**
    2単語間のしりとりが成立しているかどうかを判定する。
    */
    private static bool IsSatisfiedRule(string fstPhrase, string scdPhrase) {
        if(fstPhrase[fstPhrase.Length - 1] == scdPhrase[0]) {
            return true;
        }
        return false;
    }


    /**
    * 単語を標準入力で取得する。
    */
    private static string[] GetPhrases(int N) {
        string[] phrases = new string[N];
        for(int i = 0; i < N; i++) {
            phrases[i] = Console.ReadLine();
        }
        return phrases;
    }
}