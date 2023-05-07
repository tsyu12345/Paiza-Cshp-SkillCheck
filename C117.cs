using System;

class C117 {

    static void Main() {
        var fst_input = Console.ReadLine().Split(' ');
        int N = int.Parse(fst_input[0]); //出店する店舗数
        int M = int.Parse(fst_input[1]); //営業月数

        var snd_input = Console.ReadLine().Split(' ');
        int A = int.Parse(snd_input[0]); //1店舗当たりの建設費用
        int B = int.Parse(snd_input[1]); //1店舗当たりの人件費/月
        int C = int.Parse(snd_input[2]); //1杯当たりの利益
        
        var ramenCups = getRamenCups(M, N); //各店舗の月間ラーメン杯数

        var mustCloseStoreCount = 0;

        foreach(var soldCupCount in ramenCups) {
            var profit = calcProfit(A, B, C, soldCupCount, M);
            if(mustCloseStore(profit)) {
                mustCloseStoreCount++;
            }
        }

        Console.WriteLine(mustCloseStoreCount);


    }

    /**
     * i 番目の店舗が M ヶ月間に販売したラーメンの杯数の入力を受け付け、その配列を返す
    */
    private static int[] getRamenCups(int month, int storeCount) {
        int[] ramenCups = new int[storeCount];
        for(int i = 0; i < storeCount; i++) {
            ramenCups[i] = int.Parse(Console.ReadLine());
        }
        return ramenCups;
    }

    /**
     * 純利益がマイナスな店舗を閉店判定する
     */
    private static bool mustCloseStore(int profit) {
        if(profit < 0) {
            return true;
        }
        return false;
    }

    /**
     * 純利益を計算する
     */
    private static int calcProfit(int buildCost, int menCost, int cupProfit, int soldCupCount,int month) {
        var salesValue = cupProfit * soldCupCount;
        var costs = menCost * month + buildCost;
        var profit = salesValue - costs;
        return profit;
    }
}