using System;
using System.Collections.Generic;

class C102 {
    
    static void Main() {
        var M = int.Parse(Console.ReadLine()); //バンドA日数M
        var daysA = getLiveDays(M); //バンドAの日
        var N = int.Parse(Console.ReadLine()); //バンドB日数N
        var daysB = getLiveDays(N); //バンドBの日

        var liveDayData = new Dictionary<int, List<string>>();
        liveDayData = getLiveData(daysA, "A", liveDayData);
        liveDayData = getLiveData(daysB, "B", liveDayData);

        var result = getGoLiveData(liveDayData);
        foreach(var day in result) {
            Console.WriteLine(day);
        }


    }


    private static string[] getGoLiveData(Dictionary<int, List<string>> liveDayData) {
        var result = new string[31];
        //前回競合した時にどちらのバンドへ行ったか記録する変数
        string ConfLastBand = "";
        List<string> bands;
        for(int i = 0; i < result.Length; i++) {
            try {
                bands = liveDayData[i+1];
            } catch (KeyNotFoundException) {
                //ライブがない時
                result[i] = "x";
                continue;
            }
            if(bands.Count > 1) {
                //競合した時
                if(ConfLastBand == "A") {
                    //前回はAに行ったので、今回はBに行く
                    result[i] = "B";
                    ConfLastBand = "B";
                } else {
                    //前回はBに行ったので、今回はAに行く
                    result[i] = "A";
                    ConfLastBand = "A";
                }
            } else {
                //競合しなかった時
                result[i] = bands[0];
            }
        }
        return result;
    }

    /**
     * 日にちをキーとして、その日ライブのあるバンド名のリストを取得する
    */
    private static Dictionary<int, List<string>> getLiveData(int[] bandDayArray, string bandName, Dictionary<int, List<string>> liveDayData) {
    
        foreach(var day in bandDayArray) {
            try {
                liveDayData[day].Add(bandName);
            } catch (KeyNotFoundException) {
                liveDayData[day] = new List<string>{bandName};
            }
        }
        return liveDayData;
    }


    

    /**
     * バンドのi番目のライブの日を取得する
    */
    private static int[] getLiveDays(int days) {
        var liveDays = new int[days];
        for(int i = 0; i < days; i++) {
            liveDays[i] = int.Parse(Console.ReadLine());
        }
        return liveDays;
    }
}