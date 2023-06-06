using System;
using System.Collections.Generic;
using System.Linq;

class C130 {

    static void Main() {
        var N = int.Parse(Console.ReadLine());
        var correctnessDatas = GetCorrectnessDatas(N);
        
        var result = new List<int>();
        for(int i = 0; i < correctnessDatas.GetLength(0); i++) {
            if(IsHaveToSolve(correctnessDatas[i,0], correctnessDatas[i,1])) {
                result.Add(i+1);
            }
        }
        Console.WriteLine(result.Count);
        foreach(var r in result) {
            Console.WriteLine(r);
        }

    
    }

    private static string[,] GetCorrectnessDatas(int questionLength) {
        var correctnessDatas = new string[questionLength,2];
        for (int i = 0; i < questionLength; i++) {
            var correctnessData = Console.ReadLine().Split(' ');
            correctnessDatas[i,0] = correctnessData[0];
            correctnessDatas[i,1] = correctnessData[1];
        }
        return correctnessDatas;
    }

    /**
    * 3周目でその問題を解きべきか否か判定する
    * @param firstResult 1周目の結果
    * @param secondResult 2周目の結果
    * @return 3周目でその問題を解きべきか否か(bool)
    */
    private static bool IsHaveToSolve(string firstResult, string secondResult) {
        if(firstResult == "y" && secondResult == "y") {
            return false;
        }
        return true;
    }

}