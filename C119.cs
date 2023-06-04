using System;
using System.Linq;

class C119 {

    static void Main(string[] args) {

        var input = Console.ReadLine();
        var inputs = input.Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var K = int.Parse(inputs[2]);

        var houseNumbers = GetHideHouseNums(M);

        var result = GetRewardCount(N, houseNumbers, K);
        Console.WriteLine(result);

    }


    private static int[] GetHideHouseNums(int houseCount) {

        var result = new int[houseCount];

        for(int i = 0; i < houseCount; i++) {
            var input = Console.ReadLine();
            result[i] = int.Parse(input);
        }

        return result;

    }


    private static int GetRewardCount(int houseCount, int[] menHideHouseNumbers, int wentBackTimes) {
        var result = 0;
        var trapCount = 0;

        for(int i = 0; i < houseCount; i++) {

            if(menHideHouseNumbers.Contains(i+1)) {
                trapCount++;
            } else {
                result++;
                trapCount = 0;
            }
            if(trapCount == wentBackTimes) {
                break;
            }
        }

        return result;
    }

}