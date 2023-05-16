using System;
using System.Collections.Generic;
using System.Linq;


class C105 {

    static void Main() {
        var N = int.Parse(Console.ReadLine()); //カードの枚数N
        var cards = GetCards(N); //カードの数字

        var cardGroup = SplitCardGroup(cards);
        var result = CalcMaxScore(cardGroup);
        Console.WriteLine(result);
    }

    private static int[] GetCards(int cardLength) {
        var cards = new int[cardLength];
        var input = Console.ReadLine().Split(' ');
        //カードの数字を配列に昇順ソートして格納
        var data = input.OrderBy(x => int.Parse(x)).ToArray();
        for(int i = 0; i < cardLength; i++) {
            cards[i] = int.Parse(data[i]);
        }
        return cards;
    }

    /**
     * 各グループの代表値として、そのグループの最大値をとり、全グループの代表値の合計を計算する
    */
    private static int CalcMaxScore(List<List<int>> data) {
        var result = 0;
        foreach(var group in data) {
            result += group.Max();
        }
        return result;
    }


    /**
     * 要素間の差が1であるようなグループに分ける
     * */
    private static List<List<int>> SplitCardGroup(int[] array) {
        var result = new List<List<int>>();
        var tmp = new List<int>();
        for(int i = 0; i < array.Length-1; i++) {
            if(array[i+1] - array[i] == 1) {
                tmp.Add(array[i]);
            } else {
                tmp.Add(array[i]);
                result.Add(tmp);
                tmp = new List<int>();
            }
        }
        tmp.Add(array[array.Length-1]);
        result.Add(tmp);
        return result;
    }

}