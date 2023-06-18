using System.Collections.Generic;
using System.Linq;
using System;

class C121 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //注文品数N
        var C  = int.Parse(inputs[1]); //摂取カロリーC
        var famousMenuDatas = GetFamousMenuDatas(N);

        var results = isEatTopMenu(famousMenuDatas, 10, C);
        if(results == 10) {
            Console.WriteLine("Yes");
        } else {
            Console.WriteLine(results);
        }


    }


    private static int isEatTopMenu(int[,] menuData, int rankRange,int calorieLimit) {

        var gotCalories = 0;
        var gotRankMenu = 0;

        for(int i = 0; i < menuData.Length; i++) {

            var rank = menuData[i,0];
            var menuCalorie = menuData[i,1];

            if(gotCalories + menuCalorie > calorieLimit) { //終了条件
                break;
            }

            if(rank <= rankRange) {
                gotRankMenu += 1;
            }
            gotCalories += menuCalorie;
        }

        return gotRankMenu;


    }

    private static int[,] GetFamousMenuDatas(int count) {
        var famousMenuDatas = new int[count, 2];
        for(int i = 0; i < count; i++) {
            var inputs = Console.ReadLine().Split(' ');
            var rank = int.Parse(inputs[0]);
            var calorie = int.Parse(inputs[1]);
            famousMenuDatas[i, 0] = rank;
            famousMenuDatas[i, 1] = calorie;
        }
        return famousMenuDatas;
    }

}