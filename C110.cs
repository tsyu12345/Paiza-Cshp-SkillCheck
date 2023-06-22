using System.Collections.Generic;
using System.Linq;
using System;

class C110 {

    static void Main() {

        var N = int.Parse(Console.ReadLine());
        var schedule = GetScheduleDatas(N);

        var result = GetMaxSchedule(schedule);
        Console.WriteLine(result[0] + " " + result[1]);

            
    }


    private static int[] GetMaxSchedule(int[] scheduleDatas) {

        var dayGroups = new List<List<int>>();
        var days = new List<int>();
        var continuousCount = 0;
        var startIndex = 0;

        for(int i = 0; i < scheduleDatas.Length - 1; i++) {
            if(continuousCount == 0) {
                startIndex = i;
                days = new List<int>();
            }

            if(scheduleDatas[i] + 1 == scheduleDatas[i+1])  {
                continuousCount++;
                days.Add(scheduleDatas[i]);
            } else { //グループの区切れ
                continuousCount = 0;
                days.Add(scheduleDatas[i]); //そのグループの最後の日を追加
                dayGroups.Add(days);
            }
        }

        //dayGroupsの中で最も長いグループを探す
        var maxGroup = new List<int>();
        foreach(var group in dayGroups) {
            if(maxGroup.Count < group.Count) {
                maxGroup = group;
            }
        }

        var result = new int[] {maxGroup[0], maxGroup[maxGroup.Count - 1]};
        return result;

    }


    private static int[] GetScheduleDatas(int times) {
        var data = new int[times];

        for(int i = 0; i < times; i++) {
            data[i] = int.Parse(Console.ReadLine());
        }

        return data;
    }

}