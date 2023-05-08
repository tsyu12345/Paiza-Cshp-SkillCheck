using System;

class C123 {
    
    static void Main() {
        var N = int.Parse(Console.ReadLine()); //参加人数N
        var attendersAgeList = getAgeOfAttenders(N); //参加者の年齢リスト
        var M = int.Parse(Console.ReadLine()); //命令数M
        var commands = getCommands(M); //命令リスト

        var obtainedBeans = getObtainedBeans(commands, attendersAgeList);
        foreach(var beans in obtainedBeans) {
            Console.WriteLine(beans);
        }


    }


    private static int[] getObtainedBeans(int[,] commands, int[] attendersAgeList) {
        int[] obtainedBeans = new int[attendersAgeList.Length];
        for(int i = 0; i < commands.GetLength(0); i++) {
            var start = commands[i,0]; //A_i
            var end = commands[i,1]; //B_i
            var grantedBeans = commands[i,2]; //C_i
            for(var j = start - 1; j <= end - 1; j++) {
                obtainedBeans[j] += grantedBeans;
                if(obtainedBeans[j] > attendersAgeList[j]) {
                    obtainedBeans[j] = attendersAgeList[j];
                }
            }

        }
        return obtainedBeans;
    }


    /**
     * 参加者の年齢を標準入力で取得する。
    */
    private static int[] getAgeOfAttenders(int N) {
        int[] ageOfAttenders = new int[N];
        for(int i = 0; i < N; i++) {
            ageOfAttenders[i] = int.Parse(Console.ReadLine());
        }
        return ageOfAttenders;
    }

    /**
     * 命令を示す整数のリストを標準入力で取得する。
     * */
    private static int[,] getCommands(int M) {
        int[,] commands = new int[M,3];
        for(int i = 0; i < M; i++) {
            var input = Console.ReadLine().Split(' ');
            for(int j = 0; j < 3; j++) {
                commands[i,j] = int.Parse(input[j]);
            }
        }
        return commands;
    }
}