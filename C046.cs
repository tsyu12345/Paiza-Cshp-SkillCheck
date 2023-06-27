using System.Collections.Generic;
using System.Linq;
using System;

class C046 {

    static void Main() {

        var N = int.Parse(Console.ReadLine());
        var enginners = Console.ReadLine().Split(' ');
        var M = int.Parse(Console.ReadLine());
        var purchaseDatas = GetPurchaseDatas(M);

        var rankedDatas = SortPurchaseDatas(purchaseDatas);
        DisplayRank(rankedDatas);




    }


    private static void DisplayRank(List<Tuple<string, int>> datas) {
        foreach(var data in datas) {
            Console.WriteLine(data.Item1);
        }
    }

    private static List<Tuple<string, int>> SortPurchaseDatas(List<Tuple<string, int>> datas) {
        var sortedDatas = datas.OrderByDescending(x => x.Item2).ToList();
        return sortedDatas;
    }   

    private static List<Tuple<string, int>> GetPurchaseDatas(int purchasedCount) {
        var datas = new List<Tuple<string, int>>();

        for(int i = 0; i < purchasedCount; i++) {
            var data = Console.ReadLine().Split(' ');
            datas.Add(new Tuple<string, int>(data[0], int.Parse(data[1])));
        }

        //重複している人物を合算
        for (int i = 0; i < datas.Count; i++) {
            for (int j = i + 1; j < datas.Count; j++) {
                if (datas[i].Item1 == datas[j].Item1) {
                    datas[i] = new Tuple<string, int>(datas[i].Item1, datas[i].Item2 + datas[j].Item2);
                    datas.RemoveAt(j);
                    j--;
                }
            }
        }
        

        return datas;
    }




}