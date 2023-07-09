using System.Collections.Generic;
using System.Linq;
using System;

class B095 {

    static void Main() {
        
        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var a_i = GetIntArray(M);
        var h_i = GetIntArray(M * N);


        var participantData = ConvertParticipantData(h_i, N, M);
        var scores = new int[N];

        for(int i = 0; i < N; i++) {
            var data = Get1DArray(participantData, i);
            var errorScore = CalcErrorScore(a_i, data);
            scores[i] = 100 - errorScore;
        }

        var maxScore = scores.Max();
        if(maxScore < 0) {
            maxScore = 0;
        }
        Console.WriteLine(maxScore);

    }


    private static int[] GetIntArray(int size) {
        var array = new int[size];

        for(int i = 0; i < array.Length; i++) {
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }


    private static int[] Get1DArray(int[,] array, int index) {
        var size = array.GetLength(1);
        var result = new int[size];

        for(int i = 0; i < size; i++) {
            result[i] = array[index, i];
        }

        return result;
    }


    private static int CalcErrorScore(int[] songData, int[] participantData) {
        var errorScore = 0;
        if(songData.Length != participantData.Length) {
            throw new Exception("正解データと入力データの配列の長さが違います。");
        }
        for(int i = 0; i < songData.Length; i++) {
            errorScore += GetScore(songData[i], participantData[i]);
        }
        return errorScore;
    }


    private static int GetScore(int songData, int participantData) {
        var error = Math.Abs(songData - participantData);
        if(error <= 5) {
            return 0;
        } else if(error <= 10) {
            return 1;
        } else if(error <= 20) {
            return 2;
        } else if(error <= 30) {
            return 3;
        } else {
            return 5;
        }
    }


    //参加人ごとの小節情報を配列で返す。
     private static int[,] ConvertParticipantData(int[] allArray, int ParticipantCount, int songLength) {

        var data = new int[ParticipantCount, songLength];

        for(int i = 0; i < ParticipantCount; i++) {
            for(int j = 0; j < songLength; j++) {
                data[i, j] = allArray[j + (i * songLength)];
            }
        }

        return data;
    }

}