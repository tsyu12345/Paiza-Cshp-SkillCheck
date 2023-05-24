using System;

class C126 {

    static void Main() {

        var inputs = Console.ReadLine().Split(' ');
        var A = int.Parse(inputs[0]); //新幹線の片道料金
        var B = int.Parse(inputs[1]); //ホテル一泊の料金
        var N = int.Parse(inputs[2]); //インターン回数N
        var days = GetInternSchedules(N); //インターンのスケジュール

        var result = CalcSelfObligation(A, B, N, days);
        Console.WriteLine(result);


    }

    private static int [,] GetInternSchedules(int TotalTimes) {
        int [,] result = new int[TotalTimes, 2];
        for(int i = 0; i < TotalTimes; i++) {
            var inputs = Console.ReadLine().Split(' ');
            result[i, 0] = int.Parse(inputs[0]);
            result[i, 1] = int.Parse(inputs[1]);
        }
        return result;
    }



    private static int CalcSelfObligation(int transEx, int AccomEx, int InternTimes, int[,] days) {
        var result = 0;

        if(days.GetLength(0) == 0) {
            return 0;
        }
        result += transEx;
        for(int i = 0; i < days.GetLength(0); i++) {
            var internSt = days[i,0];
            var internEnd = days[i,1];
            
            if(i != days.GetLength(0) - 1) {
                var nextInternSt = days[i+1,0];

                //往復の交通費の計算
                var expectTransEx = transEx * 2;
                //次のインターンの開始日までの宿泊費の計算
                var expectAccomEx = AccomEx * (nextInternSt - internEnd);

                //どちらか安い方をresultに加算
                result += expectTransEx < expectAccomEx ? expectTransEx : expectAccomEx;
            }
        }
        //最後の帰宅分の交通費を加算
        result += transEx;

        return result;

    }   

}