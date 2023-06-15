using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System;

class C106 {

    static void Main(string[] args) {

        var N = int.Parse(Console.ReadLine()); //競技者の人数N
        var scoreDatas = GetScoreDatas(N); //競技者の得点データ

        var playerScoreDatas = CreatePlayerScoreDatas(scoreDatas);
        GetResultData(playerScoreDatas);
    }

    private static int[] GetScoreDatas(int playerCount) {
        var inputs = Console.ReadLine().Split(' ');
        var scoreDatas = new int[playerCount];
        for (int i = 0; i < playerCount; i++) {
            scoreDatas[i] = int.Parse(inputs[i]);
        }
        
        return scoreDatas;
    }


    private static List<dynamic> CreatePlayerScoreDatas(int[] scoreDatas) {

        var playerScoreDatas = new List<dynamic>();
        for (int i = 0; i < scoreDatas.Length; i++) {
            dynamic playerScoreData = new ExpandoObject();
            playerScoreData.id = i + 1;
            playerScoreData.score = scoreDatas[i];
            playerScoreData.medal = "";
            playerScoreDatas.Add(playerScoreData);
        }

        return playerScoreDatas;

    }


    private static void GetResultData(List<dynamic> playerScoreDatas) {

        //メダル結果の格納
        //スコア順にソート
        var sortedPlayerScoreDatas = playerScoreDatas.OrderByDescending(data => data.score).ToList();
        //1位、２位、３位のスコアを取得
        var firstScore = sortedPlayerScoreDatas[0].score;
        var secondScore = sortedPlayerScoreDatas[1].score;
        var thirdScore = sortedPlayerScoreDatas[2].score;

        //メダル結果の格納
        foreach(var data in sortedPlayerScoreDatas) {
            if(data.score == firstScore) {
                data.medal = "G";
            } else if(data.score == secondScore) {
                data.medal = "S";
            } else if(data.score == thirdScore) {
                data.medal = "B";
            } else {
                data.medal = "N";
            }
        }

        //プレイヤー番号順にソート
        var resultPlayerScoreDatas = sortedPlayerScoreDatas.OrderBy(data => data.id).ToList();
        //順に表示
        foreach(var data in resultPlayerScoreDatas) {
            Console.WriteLine(data.medal);
        }
    }

}