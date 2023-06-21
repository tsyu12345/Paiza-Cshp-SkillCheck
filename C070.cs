using System.Collections.Generic;
using System.Linq;
using System;

class C070 {

    static void Main(string[] args) {

        var N = int.Parse(Console.ReadLine()); //N
        var cardDatas = GetCardDatas(N);

        for(int i = 0; i < N; i++) {
            var cardData = cardDatas[i];
            var cardArray = StringDecomposer(cardData);
            var cardPair = JudgeCardPair(cardArray);
            Console.WriteLine(cardPair);
        }

    }


    private static string[] GetCardDatas(int cardCount) {
        var cardDatas = new string[cardCount];
        for(int i = 0; i < cardCount; i++) {
            cardDatas[i] = Console.ReadLine();
        }
        return cardDatas;
    }


    private static string JudgeCardPair(string[] cards) {

        HashSet<string> set = new HashSet<string>(cards);
        
        //FourCardのチェック
        if(set.Count == 1) {
            return "Four Card";
        }

        //ThreeCardのチェック
        //同一要素が3つある場合はThreeCard
        var count = 0;
        for(int i = 0; i < cards.Length - 1; i++) {
            if(cards[i] == cards[i + 1]) {
                count++;
            }
            if(count == 2 || (count > 0 && cards[i] != cards[i + 1])) {
                break;
            }
        }
        if(set.Count == 2 && count == 2) {
            return "Three Card";
        }

        //TwoPairのチェック
        var onePair = 0;
        for(int i = 0; i < cards.Length - 1; i++) {
            if(cards[i] == cards[i + 1]) {
                onePair++;
            }
        }
        if(set.Count == 2 && onePair == 2) {
            return "Two Pair";
        }

        //OnePairのチェック
        if(set.Count == 3 && onePair == 1) {
            return "One Pair";
        }

        return "No Pair";
    }


    private static string[] StringDecomposer(string str) {
        var strArray = new string[str.Length];
        for(int i = 0; i < str.Length; i++) {
            strArray[i] = str.Substring(i, 1);
        }
        return strArray;
    }

}