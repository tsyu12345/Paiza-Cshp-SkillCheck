using System.Collections.Generic;
using System.Linq;
using System;

class C116 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //棒アイスの個数N
        var M = int.Parse(inputs[1]); //検査区間の大きさM
        var stickCharacters = Console.ReadLine().Split(' '); //0:はずれ 1:当たり
        var isSafe = false;
        for(int i = 0; i < N; i++) {
            isSafe = JudgeSafe(stickCharacters, i, M, M);
            if(!isSafe  || i + M >= N) {
                break;
            }
        }
        Console.WriteLine(isSafe ? "OK" : "NG");




    }


    private static bool JudgeSafe(string[] stickDatas, int startIndex, int checkRange, int outCount) {
        
        var loseTimes = 0;
        for(int i = 0; i < checkRange; i++) {
            if(stickDatas[startIndex + i] == "0") {
                loseTimes++;
            } else {
                loseTimes = 0;
            }
            if(loseTimes == outCount) {
                return false;
            }
        }
        return true;
    }


}
