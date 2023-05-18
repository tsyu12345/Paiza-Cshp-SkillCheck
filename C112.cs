using System;

class C112 {

    static void Main() {
        
        var N = int.Parse(Console.ReadLine()); //旅行日程の日数N
        var flightInfo = GetFlightInfo(N); //フライト情報

        var maxDayTime = calcMaxDayTime(flightInfo);
        var minDayTime = calcMinDayTime(flightInfo);

        Console.WriteLine(minDayTime);
        Console.WriteLine(maxDayTime);


    }


    private static int[,] GetFlightInfo(int days) {
        var flightInfo = new int[days, 3];
        for (int i = 0; i < days; i++) {
            var input = Console.ReadLine().Split(' '); //s_i f_i t_i
            for (int j = 0; j < 3; j++) {
                flightInfo[i, j] = int.Parse(input[j]);
            }
        }
        return flightInfo;
    }


    private static int calcMaxDayTime(int[,] flightInfo) {
        const int dayHour = 24;
        var maxDayTime = 0;
        for(int i = 0; i < flightInfo.GetLength(0); i++) {
            var firstCountryTime = flightInfo[i, 0]; //s_i
            var secondCountryTime = dayHour - flightInfo[i, 2]; //t_i
            var travelingTime = flightInfo[i,1]; //f_i
            var dayTime = firstCountryTime + travelingTime + secondCountryTime;
            if (dayTime > maxDayTime) {
                maxDayTime = dayTime;
            }
        }
        return maxDayTime;
    }


    private static int calcMinDayTime(int[,] flightInfo) {
        const int dayHour = 24;
        var minDayTime = 0;
        for(int i = 0; i < flightInfo.GetLength(0); i++) {
            var firstCountryTime = flightInfo[i, 0]; //s_i
            var secondCountryTime = dayHour - flightInfo[i, 2]; //t_i
            var travelingTime = flightInfo[i,1]; //f_i
            var dayTime = firstCountryTime + travelingTime + secondCountryTime;
            if(i == 0) {
                minDayTime = dayTime;
            }
            if (dayTime < minDayTime) {
                minDayTime = dayTime;
            }
        }
        return minDayTime;
    }



}