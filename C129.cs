using System;
using System.Linq;

class C129 {

    static void Main() {
        
        var line = Console.ReadLine().Split(' ');
        var N = int.Parse(line[0]); //寿司の種類数N
        var M = int.Parse(line[1]); //パックされる個数M
        var A_M = GetSortSushiData(M); //A_M
        var B_M = GetSortSushiData(M); //B_M


        var isAnableSort = IsAnableSort(A_M, B_M);
        Console.WriteLine(isAnableSort ? "Yes" : "No");

    }

    /**A_M, B_Mの共同入力値ゲッター*/
    private static int[] GetSortSushiData(int size) {
        var sushiNums = new int[size];
        for (int i = 0; i < size; i++) {
            sushiNums[i] = int.Parse(Console.ReadLine());
        }
        return sushiNums;
    }


    /**
    * 指定された順番に配列の要素を並び変えられる = 入力の配列が指定配列の要素を過不足なく満たせばよい。
    */
    private static bool IsAnableSort(int[] order, int[] inputOrder) {
        
        if(order.Length != inputOrder.Length) { //早期終了用
            return false;
        }

        for(int i = 0; i < order.Length; i++) {
            if(!inputOrder.Contains(order[i])) {
                return false;
            }
        }

        return true;
    }


}