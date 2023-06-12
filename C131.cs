using System.Collections.Generic;
using System.Linq;
using System;


class C131 {

    //[元の数字, 対応する回転数]
    private static readonly int[,] reverseNumbers;

    static C131() {
        reverseNumbers = new int[5, 2] {
            {0, 0},
            {1, 1},
            {6, 9},
            {8, 8},
            {9, 6}
        };
    }

    static void Main() {

        var inputs = Console.ReadLine().Split(' ');
        var A = int.Parse(inputs[0]);
        var B = int.Parse(inputs[1]);

        var result = GetReversNumRoomCount(A, B);
        Console.WriteLine(result);
    }


    private static int GetReversNumRoomCount(int start, int end) {
        var count = 0;
        for(int i = start; i <= end; i++) {
            if(isEqReversNum(i)) {
                count++;
            }
        }
        return count;
    }


    private static bool isEqReversNum(int roomNum) {
        var str = roomNum.ToString();
        var reverseStr = string.Empty;
        
        for(int i = str.Length - 1; i >= 0; i--) { //180度回転した数字を作成
            var num = int.Parse(str[i].ToString());
            var reverseNum = GetReverseNum(num);
            if(reverseNum == -1) { //回転できない数字があったらその時点でfalse
                return false;
            }
            reverseStr += reverseNum.ToString();
        }
        return str == reverseStr;
    }


    private static int GetReverseNum(int num) {
        for(int i = 0; i < reverseNumbers.GetLength(0); i++) {
            if(reverseNumbers[i, 0] == num) {
                return reverseNumbers[i, 1];
            }
        }
        return -1;
    }







}