using System.Collections.Generic;
using System.Linq;
using System;

class B117 {

    static void Main(string[] args) {
        
        var N = int.Parse(Console.ReadLine());
        var A_i = GetCarNumsNearExit(N);

        var result = CalcRoundCountOfLastCar(A_i);
        Console.WriteLine(result);


    }


    private static List<int> GetCarNumsNearExit(int CarAmount) {
        var data = new List<int>();

        for (int i = 0; i < CarAmount; i++) {
            var d = int.Parse(Console.ReadLine());
            data.Add(d);
        }
        return data;
    }


    private static int CalcRoundCountOfLastCar(List<int> posData) {
        var targetCarNum = posData.Max();
        var length = posData.Count;
        var rountCOunt = 0;
        for(int i = 0; i < length; i++) {
            if(i > posData.Count - 1) {
                i = 0;
            }
            //Console.WriteLine(i);
            //Console.WriteLine("now chek is {0}", posData[i]);
            var exitTargetNum = posData.Min();
            //Console.WriteLine("now car is {0}",exitTargetNum);
            if(posData[i] == exitTargetNum) {
                posData.Remove(exitTargetNum);
                i--;
                if(exitTargetNum == targetCarNum) {
                    break;
                }
            } else {
                if(posData[i] == targetCarNum) {
                    rountCOunt++;
                }
            }
        }

        return rountCOunt;
    }

}