using System.Collections.Generic;
using System.Linq;
using System;

class C064 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var M = int.Parse(inputs[0]);
        var N = int.Parse(inputs[1]);
        var calolieDatas = GetCalorieDatas(M);
        var atedCalorieDatas = GetAtedCalorieDatas(N, M);

        for(int i = 0; i < N; i++) {
            var row = GetSpecifiedRow(i, atedCalorieDatas);
            var sumCalorie = CalcSumCalorie(row, calolieDatas);
            Console.WriteLine(sumCalorie);
        }
        

    }


    private static int[] GetSpecifiedRow(int index, int[,] datas) {
        var row = new int[datas.GetLength(1)];
        for(int i = 0; i < datas.GetLength(1); i++) {
            row[i] = datas[index, i];
        }
        return row;
    }


    private static int CalcSumCalorie(int[] ateData, int[] calorieDatas) {
        var sum = 0;
        
        for(int i = 0; i < calorieDatas.Length; i++) {
            var ateGram = ateData[i];
            var calorie = calorieDatas[i];
            double sumCalorie = ((double)ateGram / 100) * calorie;
            sum += (int)Math.Floor(sumCalorie); 
        }
        return sum;
    }


    private static int[] GetCalorieDatas(int dataLen) {
        var datas = new int[dataLen];
        for(int i = 0; i < dataLen; i++) {
            datas[i] = int.Parse(Console.ReadLine());
        }
        return datas;
    }

    private static int[,] GetAtedCalorieDatas(int dataLen, int columnLen) {
        var datas = new int[dataLen, columnLen];
        for(int i = 0; i < dataLen; i++) {
            var inputs = Console.ReadLine().Split(' ');
            for(int j = 0; j < columnLen; j++) {
                datas[i, j] = int.Parse(inputs[j]);
            }
        }
        return datas;
    }

}