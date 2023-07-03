using System.Collections.Generic;
using System.Linq;
using System;


class B099 {

    static void Main() {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var p_i = GetPrecipitationDatas(N);


        var routeDatas = GetRouteArrays(p_i);
        var canCommuteRoutes = new bool[N];

        for(int i = 0; i < routeDatas.GetLength(0); i++) {
            var route = GetArrayFromArrays(routeDatas, i);
            canCommuteRoutes[i] = CanCommuteAllowed(route, M);
            //Console.WriteLine("route {0} is {1}", i + 1, canCommuteRoutes[i]);
        }

        if(!canCommuteRoutes.Contains(true)) {
            Console.WriteLine("wait");
        } else {
            var routeNumStr = "";
            for(int i = 0; i < canCommuteRoutes.Length; i++) {
                if(canCommuteRoutes[i]) {
                    routeNumStr += i + 1;
                    if(i != canCommuteRoutes.Length - 1) {
                        routeNumStr += " ";
                    }
                }
            }
            Console.WriteLine(routeNumStr);
        }
    }


    private static int[] GetArrayFromArrays(int[,] arrays, int index) {
        var array = new int[arrays.GetLength(1)];
        for(int i = 0; i < arrays.GetLength(1); i++) {
            array[i] = arrays[index, i];
        }
        return array;
    }


    private static int[,] GetRouteArrays(int[,] arrays) {
        var datas = new int[arrays.GetLength(0), arrays.GetLength(1)];

        for(int i = 0; i < arrays.GetLength(0); i++) {
            for(int j = 0; j < arrays.GetLength(1); j++) {
                datas[i, j] = arrays[j, i];
            }
        }

        return datas;
    }


    private static bool CanCommuteAllowed(int[] routeData, int limitAmount) {

        for(int i = 0; i < routeData.Length; i++) {
            if(routeData[i] >= limitAmount) {
                return false;
            }
        }
        return true;
    }


    private static int[,] GetPrecipitationDatas(int dataSize) {
        
        var data = new int[dataSize, dataSize];

        for(int i = 0; i < dataSize; i++) {
            var inputs = Console.ReadLine().Split(' ');
            for(int j = 0; j < dataSize; j++) {
                data[i, j] = int.Parse(inputs[j]);
            }
        }

        return data;
    }

}