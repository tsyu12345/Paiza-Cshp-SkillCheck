using System;

class C115
{
    static void Main()
    {
        //標準入力　N M を取得
        string[] input = Console.ReadLine().Split(' ');

        int N = int.Parse(input[0]);; //クルマの数
        int M = int.Parse(input[1]);; //渋滞を定義する車間距離
        float[] jamDistDatas = new float[N-1]; //車間ごとの距離データ
        float jamTotalDistance = 0.0f; //渋滞の総距離

        //標準入力　車間距離データを取得
        for(int i = 0;  i< N-1; i++)
        {
            jamDistDatas[i] = float.Parse(Console.ReadLine());
        }

        //渋滞の総距離を計算
        foreach (var distance in jamDistDatas)
        {
            if(isJam(distance, M)) {
                jamTotalDistance += distance;
            }
        }

        //渋滞の総距離を出力
        Console.WriteLine(jamTotalDistance);
    }

    private static bool isJam(float jamTotalDistance, int M) {
        if(jamTotalDistance <= M) {
            return true;
        } else {
            return false;
        }
    }
}