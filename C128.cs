using System.Collections.Generic;
using System.Linq;
using System;

class C128 {

    static void Main() {

        var N = int.Parse(Console.ReadLine());
        var valiables = GetValiables(N);

        var sum = CalcFraction(valiables, N - 1);
        //分数に変換
        var result = ConvertFraction(sum);
        Console.WriteLine("{0} {1}",result[0] ,result[1]);


    }

    private static int[] GetValiables(int length) {
         var valiables = new int[length];

        for(int i = 0; i < length; i++) {
            valiables[i] = int.Parse(Console.ReadLine());
        }
        return valiables;
    }


    /**
    * 連分数を計算する
    */
    private static int[] CalcFraction(int[] nums, int index) {
        
        if(index == 0) {
            return [nums[0], 1];
        } else {
            return nums[index] + 1 / CalcFraction(nums, index - 1);
        }

    }

    /**
    *既約分数に変換する
    */
    private static int[] ConvertFraction(double num) {
        var result = new int[2];

        var numStr = num.ToString();
        var numStrs = numStr.Split('.');

        var numStrsLength = numStrs[1].Length;
        var denominator = Math.Pow(10, numStrsLength);
        var numerator = num * denominator;
        var gcd = Gcd(numerator, denominator);
        result[0] = (int)(numerator / gcd);
        result[1] = (int)(denominator / gcd);
        return result;
    }

    private static double Gcd(double a, double b) {
        //スワップ
        if(a < b) {
            var tmp = a;
            a = b;
            b = tmp;
        }
        //ユークリッドの互除法
        while(b != 0) {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
    

}