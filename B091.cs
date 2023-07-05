using System.Collections.Generic;
using System.Linq;
using System;

class B091 {
    
    static void Main() {

        var N = int.Parse(Console.ReadLine());
        var h_i = GetAltitudeDatas(N);

        var peaks = SearchMountainPeaks(h_i);
        peaks.Sort();
        peaks.Reverse();

        foreach (var peakAlt in peaks) {
            Console.WriteLine(peakAlt);
        }
    }


    private static List<int> SearchMountainPeaks(int[,] mapData) {
        var peaks = new List<int>();

        for(int i = 0; i < mapData.GetLength(0); i++) {
            for(int j = 0; j < mapData.GetLength(1); j++) {
                var centerCell = new int[] { i, j };
                var adjacentCells = GetAdjacentCells(centerCell, mapData);
                
                //現在のセルが山頂かの判定
                var currentAlt = mapData[i, j];
                bool isPeak;
                if(currentAlt > adjacentCells.Max()) {
                    isPeak = true;
                } else {
                    isPeak = false;
                }

                //山頂の場合はリストに追加
                if(isPeak) {
                    peaks.Add(currentAlt);
                }
            }
        }

        return peaks;
    }


    private static List<int> GetAdjacentCells(int[] centerCell, int[,] mapData) {
        var centerRow = centerCell[0];
        var centerCol = centerCell[1];
        var adjacentCells = new List<int>();

        //上下左右の隣接セルを取得
        //上
        if(centerRow != 0) {
            adjacentCells.Add(mapData[centerRow - 1, centerCol]);
        } else {
            adjacentCells.Add(0);
        }
        //下
        if(centerRow != mapData.GetLength(0) - 1) {
            adjacentCells.Add(mapData[centerRow + 1, centerCol]);
        } else {
            adjacentCells.Add(0);
        }
        //左
        if(centerCol != 0) {
            adjacentCells.Add(mapData[centerRow, centerCol - 1]);
        } else {
            adjacentCells.Add(0);
        }
        //右
        if(centerCol != mapData.GetLength(1) - 1) {
            adjacentCells.Add(mapData[centerRow, centerCol + 1]);
        } else {
            adjacentCells.Add(0);
        }
        return adjacentCells;
    }


    private static int[,] GetAltitudeDatas(int mapSize) {

        var datas = new int[mapSize, mapSize];

        for(int i = 0; i < mapSize; i++) {
            var inputs = Console.ReadLine().Split(' ');
            for(int j = 0; j < mapSize; j++) {
                datas[i, j] = int.Parse(inputs[j]);
            }
        }

        return datas;
        
    }

}