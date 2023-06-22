using System.Collections.Generic;
using System.Linq;
using System;


class C101 {

    static void Main(string[] args) {

        var X = int.Parse(Console.ReadLine()); //X

        var fortuneDayCount = GetfortuneDayCount(X);
        Console.WriteLine(fortuneDayCount);

    }


    private static int GetfortuneDayCount(int day) {
        var fortuneDay = day.ToString();
        var count = 0;
        for(int i = 0; i < 365; i++) {
            var elapsedDays = i.ToString();
            if(elapsedDays.Contains(fortuneDay)) {
                count++;
            }
        }
        return count;
    }


}