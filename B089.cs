using System;
using System.Collections.Generic;
using System.Linq;

class B089 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var N = int.Parse(inputs[0]);
        var M = int.Parse(inputs[1]);
        var s_i = GetStrings(N);
        var w_i = GetStrings(M);

        var dialData = Convert2DialData(s_i, N);

        //WriteLineChars(dialData);

        var results = new List<List<int>>();
        foreach (var word in w_i) {
            var r = new List<int>();
            r = SearchWordIndex(word, dialData);
            results.Add(r);
        }
        Console.WriteLine(string.Join(" ", results[0]));
        Console.WriteLine(string.Join(" ", results[1]));
    }


    
    private static void WriteLineChars(char[,] chars) {
        for (int i = 0; i < chars.GetLength(0); i++) {
            for (int j = 0; j < chars.GetLength(1); j++) {
                Console.Write(chars[i, j]);
            }
            Console.WriteLine();
        }    
    }


    private static List<int> SearchWordIndex(string targWord, char[,] dialData) {
        var result = new List<int>();
        for (int i = 0; i < dialData.GetLength(0); i++) {
            for (int j = 0; j < dialData.GetLength(1); j++) {
                if(targWord[0] == dialData[i, j]) { //頭文字が一致の場合、探索開始
                    var isWord = isEqualWord(targWord, dialData, i, j);
                    if(isWord) {
                        result.Add(j+1);
                        result.Add(i+1);
                        return result;
                    }
                }
            }
        }
        return result;
    }


    private static bool isEqualWord(string targWord, char[,] dialData, int stRow, int stCol) {
        var row = stRow;
        var col = stCol;

        for (int i = 0; i < targWord.Length; i++) {
            //Console.WriteLine(row + " " + col);
            //Console.WriteLine(targWord[i] + " " + dialData[row, col]);
            //indexの範囲チェック
            if(row > dialData.GetLength(0) - 1 || col > dialData.GetLength(1) -1) {
                return false;
            }

            if (targWord[i]!= dialData[row, col]) {
                return false;
            }
            row++;
            col++;
        }
        return true;
    }


    private static char[,] Convert2DialData(string[] originData, int size) {
        var data = new char[size, size];
        for (int i = 0; i < size; i++) {
            var str = originData[i];
            for (int j = 0; j < size; j++) {
                data[i, j] = str.ToCharArray()[j];
            }
        }

        return data;
    }


    private static string[] GetStrings(int size) {
        var data = new string[size];
        for(int i = 0; i < data.Length; i++) {
            data[i] = Console.ReadLine();
        }
        return data;
    }
}