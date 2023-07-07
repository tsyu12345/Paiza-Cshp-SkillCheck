using System.Collections.Generic;
using System.Linq;
using System;

class B108 {

    static void Main() {
        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var A_i = GetDatas(N);
        var B_i = GetDatas(M);

        var result = GetPassengerCountsByGondra(B_i, A_i, N);
        foreach(var item in result) {
            Console.WriteLine(item);
        }
    }


    private static int[] GetPassengerCountsByGondra(int[] passengerGroups, int[] limits, int gondraCount) {
        var result = new int[gondraCount];
        var nowGondrasPassenger = new int[gondraCount];
        for(int i = 0; i < passengerGroups.Length; i++) {
            var leftPassenger = 0;
            while(true) {
                Array.Clear(nowGondrasPassenger, 0, nowGondrasPassenger.Length);
                var data = OnRideByGroup(leftPassenger, limits,result, passengerGroups[i], nowGondrasPassenger);
                leftPassenger = data[0].leftPassenger;
                result = data[0].result;
                if(leftPassenger == 0) {
                    break;
                }
            }
        }
        return result;
    }

    /// <summary>
    /// ゴンドラ１週分で、そのグループの残人数とゴンドラのresultを返す
    /// </summary>
    private static List<Data> OnRideByGroup(int leftPassenger, int[] limits,int[] result, int passengerGroup, int[] nowGondrasPassenger) {
        for(int j = 0; j < nowGondrasPassenger.Length; j++) {

            //残された人数がいる場合は、limit分まで乗せる
            if(leftPassenger <= limits[j]) {
                nowGondrasPassenger[j] = leftPassenger;
            }

            if(passengerGroup <= limits[j]) {
                nowGondrasPassenger[j] = passengerGroup;
            } else {
                leftPassenger = passengerGroup - limits[j];
                nowGondrasPassenger[j] = limits[j];
            }
            //resultにカウントを記録
            passengerGroup = passengerGroup - nowGondrasPassenger[j];
            result[j] += nowGondrasPassenger[j];

            //全員乗れた場合は、そのグループは終了なのでbreak
            if(leftPassenger == 0 && passengerGroup == 0) {
                break;
            }
        }
        var data = new List<Data>();
        Console.WriteLine("leftPassenger:" + leftPassenger);
        Console.WriteLine("result:" + string.Join(",", result));
        data.Add(new Data() { leftPassenger = leftPassenger, result = result });

        return data;
       

    }




    private static int[] GetDatas(int Count) {
        var data = new int[Count];
        for(int i = 0; i < Count; i++) {
            data[i] = int.Parse(Console.ReadLine());
        }
        return data;
    }

}


class Data {
    public int leftPassenger { get; set; }
    public int[] result { get; set; }
}