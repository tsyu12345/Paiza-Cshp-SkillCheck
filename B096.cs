using System.Collections.Generic;
using System.Linq;
using System;

class B096 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var H = int.Parse(inputs[0]);
        var N = int.Parse(inputs[1]);
        var s_h = GetStrs(H);

        var mapData = ConvertStrsToMapData(s_h, H, N);
        var blastCount = GetBlastCount(mapData, "#");

        Console.WriteLine(blastCount);
    }


    private static int GetBlastCount(string[,] mapData, string bomMark) {
        var blastCount = 0;
        var blastedMark = "%";
        var blastedMap = new string[mapData.GetLength(0), mapData.GetLength(1)];
        for(int i = 0; i < mapData.GetLength(0); i++) {
            for(int j = 0; j < mapData.GetLength(1); j++) {
                if(mapData[i, j] == bomMark) {
                    var bomPoint = new int[] { i, j };
                    blastedMap = GetBlastedMap(bomPoint, blastedMap, blastedMark);
                }
            }
        }

        //balstedMarkの個数をカウントし返却
        for(int i = 0; i < blastedMap.GetLength(0); i++) {
            for(int j = 0; j < blastedMap.GetLength(1); j++) {
                if(blastedMap[i, j] == blastedMark) {
                    blastCount++;
                }
            }
        }

        return blastCount;
    }


    private static string[,] GetBlastedMap(int[] bomPoint, string[,] blastedMap, string blastMark) {
        var rowSize = blastedMap.GetLength(0);
        var colSize = blastedMap.GetLength(1);

        //その行全体と、１列全体が爆風の範囲
        for(int i = 0; i < rowSize; i++) {
            blastedMap[i, bomPoint[1]] = blastMark;
        }
        for(int j = 0; j < colSize; j++) {
            blastedMap[bomPoint[0], j] = blastMark;
        }

        return blastedMap;
    }


    private static string[] GetStrs(int rowSize) {
        var strs = new string[rowSize];
        for(int i = 0; i < rowSize; i++) {
            strs[i] = Console.ReadLine();
        }
        return strs;
    }


    private static string[,] ConvertStrsToMapData(string[] strs, int rowSize, int colSize) {
        var mapData = new string[rowSize, colSize];

        for(int i = 0; i < rowSize; i++) {
            var rowStr = strs[i];
            var cells = rowStr.Select(c => c.ToString()).ToArray();
            for(int j = 0; j < colSize; j++) {
                mapData[i, j] = cells[j];
            }
        }

        return mapData;
    }
}