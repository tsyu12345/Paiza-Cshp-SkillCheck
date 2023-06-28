using System.Collections.Generic;
using System.Linq;
using System;

class B131 {

    static void Main() {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var a_i = GetFareDatas(N, M);
        var X = int.Parse(Console.ReadLine());
        var R_S = GetViaStations(X);

        var sumFare = GetSumFare(R_S, a_i);
        Console.WriteLine(sumFare);



    }


    private static int GetSumFare(int[,] routes, int[,] fareData) {

        var sumfare = 0;
        var nowPos = 1; //現在の駅番号
        //var nowRouteNum = 1;
        for(int i = 0; i < routes.GetLength(0); i++) {
            var routeNum = routes[i, 0];
            var destination = routes[i, 1]; 
            int fare;

            if(nowPos == destination) {
                fare = 0;
            } else {
                fare = Math.Abs(fareData[routeNum-1, destination-1] - fareData[routeNum-1, nowPos-1]);
            }
            //Console.WriteLine(fare);
            sumfare += fare;
            nowPos = destination;
        }

        return sumfare;

    }


    private static int[,] GetFareDatas(int routeSize, int stationCount) {
        var datas = new int[routeSize, stationCount];

        for(int i = 0; i < routeSize; i++) {
            var data = Console.ReadLine().Split(' ');
            for(int j = 0; j < stationCount; j++) {
                datas[i, j] = int.Parse(data[j]);
            }
        }

        return datas;
    }


    private static int[,] GetViaStations(int viaCount) {
        var datas = new int[viaCount, 2];
        for(int i = 0; i < viaCount; i++) {
            var data = Console.ReadLine().Split(' ');
            datas[i, 0] = int.Parse(data[0]);
            datas[i, 1] = int.Parse(data[1]);
        }

        return datas;
    }

}