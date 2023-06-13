using System.Collections.Generic;
using System.Linq;
using System;

class C100 {

    static void Main() {
        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //流したい曲の数
        var M = int.Parse(inputs[1]); //持ち時間（分）
        var S = int.Parse(inputs[2]); //持ち時間（秒）
        var songTimes = GetWantSongTimeDatas(N);

        //とりあえず全部秒に直す
        var timeLimit = ConvertMin2Second(M, S);
        var songDatasSec = new int[N];
        for (var i = 0; i < N; i++) {
            songDatasSec[i] = ConvertMin2Second(songTimes[i, 0], songTimes[i, 1]);
        }

        var result = GetMaximumSongCount(timeLimit, songDatasSec);  
        Console.WriteLine(result);
    }


    private static int GetMaximumSongCount(int secLimit, int[] songDatas) {

        var result = 0;
        //昇順ソート
        Array.Sort(songDatas);
        for(int i = 0; i < songDatas.Length; i++) {
            if(secLimit - songDatas[i] > 0) {
                secLimit -= songDatas[i];
                result++;
            }
        }
        return result;
    }   


    private static int[,] GetWantSongTimeDatas(int songCount) {
        var datas = new int[songCount, 2];
        for(int i = 0; i < songCount; i++) {
            var inputs = Console.ReadLine().Split(' ');
            datas[i, 0] = int.Parse(inputs[0]);
            datas[i, 1] = int.Parse(inputs[1]);
        }
        return datas;
    }


    private static int ConvertMin2Second(int min, int seconds) {
        return min * 60 + seconds;
    }


}