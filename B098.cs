using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System;

class B098 {


    static void Main() {
        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //検査対象数
        var M = int.Parse(inputs[1]); //監視時間
        var T = int.Parse(inputs[2]); //検査対象時間
        var K = int.Parse(inputs[3]); //バズの閾値
        var data = GetDataMatmatrix(M, N);

        var decomposedData = DataDecomposer(data);
        var result = new List<dynamic>();
        for(int i = 0; i < decomposedData.GetLength(0); i++) {
            var d = Get1dMatrix(decomposedData, i);
            var judgeResult = judgePopular(d, K, T);
            result.Add(judgeResult);
        }

        foreach(var r in result) {
            if(r.isPopular) {
                Console.WriteLine("yes {0}", r.popularIndex + 1);
            } else {
                Console.WriteLine("no {0}", 0);
            }
        }
    }

    /// <summary>
    /// バズの閾値を超えているかどうかを判定する
    /// Args:
    ///    GoodCountData: 検査対象発言のGood増分データ
    /// Return:
    ///   {    
    ///     isPopular: バズの閾値を超えているかどうか
    ///     popularIndex: バズの閾値を超えている発言の最初のインデックス
    ///   }
    /// </summary>
    private static dynamic judgePopular(int[] GoodCountData, int threshold, int timeLimit) {
        var sumGood = 0;
        dynamic result = new ExpandoObject();
        result.isPopular = false;
        result.popularIndex = -1;
        for(int i = 0; i < GoodCountData.Length; i++) {
            sumGood += GoodCountData[i];
            if (sumGood >= threshold && i <= timeLimit) {
                result.isPopular = true;
                result.popularIndex = i;
                //Console.WriteLine("{0}, {1} ,{2}", i, sumGood, sumGoodCount);
                return result;
            }
        }
        return result;
    }

    /// <summary>
    /// 検査対象発言のGood増分データを配列で返す
    /// </summary>
    private static int[,] DataDecomposer(int[,] data) {
        var result = new int[data.GetLength(1), data.GetLength(0)];
        for (int i = 0; i < data.GetLength(1); i++) {
            for (int j = 0; j < data.GetLength(0); j++) {
                result[i, j] = data[j, i];
                //Console.WriteLine("{0}, {1} ,{2}", i, j, result[i, j]);
            }
        }
        return result;
    }


    private static int[] Get1dMatrix(int[,] data, int getIndex) {
        var result = new int[data.GetLength(1)];
        for (int i = 0; i < data.GetLength(1); i++) {
            result[i] = data[getIndex, i];
            //Console.WriteLine("{0}, {1}", i, result[i]);
        }
        return result;
    }


    private static int[,] GetDataMatmatrix(int row, int column) {
        var data = new int[row, column];
        for (int i = 0; i < row; i++) {
            var inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < column; j++) {
                data[i, j] = int.Parse(inputs[j]);
            }
        }
        return data;
    }

}