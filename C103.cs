using System;
using System.Dynamic;
using System.Collections.Generic;

class C103 {

    static void Main() {
        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]); //作動時間N
        var M = int.Parse(inputs[1]); //動作規則数M
        var robotMovementDatas = GetRobotMovementDatas(M); //動作規則の入力値

        var inputedRules = new List<int>();
        for(int i = 1; i <= N; i++) {
            var output = new List<string>();
            foreach(var robotMovementData in robotMovementDatas) {
                var rule = robotMovementData.rule;
                var name = robotMovementData.name;
                if( i % rule == 0) {
                    output.Add(name);
                    inputedRules.Add(rule);
                }
            }
            if(output.Count == 0) {
                Console.WriteLine(i);
            } else {
                Console.WriteLine(string.Join(" ", output));
            }
        }
    }


    private static dynamic[] GetRobotMovementDatas(int size) {
        var robotMovementDatas = new dynamic[size];
        for(int i = 0; i < size; i++) {
            var inputs = Console.ReadLine().Split(' ');
            robotMovementDatas[i] = new ExpandoObject();
            robotMovementDatas[i].rule = int.Parse(inputs[0]); //動作規則の整数値
            robotMovementDatas[i].name = inputs[1]; //動作規則の名前
        }
        return robotMovementDatas;
    }
}