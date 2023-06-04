using System;

class C108 {

    static void Main() {

        var N = int.Parse(Console.ReadLine()); //観光名所の数N
        var StayTimes = GetStayTimes(N); //i 番目の観光名所の滞在時間を表す整数
        var MovemrntTimes = GetMovementTimes(N);//i 番目の観光名所から j 番目の観光名所への移動時間
        var K = int.Parse(Console.ReadLine()); //行きたい観光名所の数を表す整数 K 
        var wantList = GetWantLocations(K);//i 番目に訪れたい観光名所を表す整数

        var totalTravelingTime = GetTotalTravelingTime(wantList, StayTimes, MovemrntTimes);
        Console.WriteLine(totalTravelingTime);


    }


    private static int GetTotalTravelingTime(int[] wantList, int[] StayTimes,int[,] MovemrntTimes) {
        var totalTravelingTime = 0;
        
        for(int i = 0; i < wantList.Length; i++) {
            //滞在時間の計算
            totalTravelingTime += StayTimes[wantList[i]-1];
            //移動時間の計算
            if(i < wantList.Length-1) {
                totalTravelingTime += MovemrntTimes[wantList[i]-1,wantList[i+1]-1];
            }
        }

        return totalTravelingTime;
    }



    private static int[] GetStayTimes(int days) {
        var stayTime = new int[days];
        for (int i = 0; i < days; i++) {
            stayTime[i] = int.Parse(Console.ReadLine());
        }
        return stayTime;
    }


    private static int[,] GetMovementTimes(int days) {
        var travelingTime = new int[days, days];
        for (int i = 0; i < days; i++) {
            var line = Console.ReadLine().Split(' ');
            for (int j = 0; j < days; j++) {
                travelingTime[i, j] = int.Parse(line[j]);
            }
        }
        return travelingTime;
    }

    private static int[] GetWantLocations(int Length) {
        var wantLocations = new int[Length];
        for (int i = 0; i < Length; i++) {
            wantLocations[i] = int.Parse(Console.ReadLine());
        }
        return wantLocations;
    }

}