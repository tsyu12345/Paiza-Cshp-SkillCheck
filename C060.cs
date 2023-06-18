using System.Collections.Generic;
using System.Linq;
using System;


class C060 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //総単語数N
        var K = int.Parse(inputs[1]); //1Pあたりの単語数
        var P = int.Parse(inputs[2]); //調査対象のページ番号
        var words = Console.ReadLine().Split(' '); //辞書中のi番目の単語リスト


    }



    private static string[] GetDicPageWords(int pageNum, int wordsPerPage, string[,] words) {
        var result = new string[wordsPerPage]; //1ページあたりの単語リストの最大数で初期化
        
    }


    private static List<List<string>> SortDictionalOrder(string[] words, int pagePerWordCount) {
        var result = new List<List<string>>();
        for (int i = 1; i < words.Length; i++) {
            var word = words[i];
            var preWord = words[i - 1];
            var page = new List<string>();
            if(isSmallerByDic(word, preWord)) { //辞書順でwordがpreWordより小さい場合
                //preWordとwordの順番を入れ替えて格納
                page.Add(word);
                page.Add(preWord);
            } else {
                page.Add(preWord);
                page.Add(word);
            }
            result.Add(page);
        }
        return result;
    }


    private static bool isSmallerByDic(string s1, string s2) {
        var result = false;
        var s1Arr = s1.ToCharArray();
        var s2Arr = s2.ToCharArray();
        for (int i = 0; i < s1Arr.Length; i++) {
            if(s1Arr[i] == s2Arr[i] && s1Arr.Length < s2Arr.Length && s1Arr[i] < s2Arr[i]) {
                result = true;
                break;
            }
        }
        return result;
    }


}