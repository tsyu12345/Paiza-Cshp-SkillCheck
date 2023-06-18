using System.Collections.Generic;
using System.Linq;
using System;

class C068 {


    static void Main() {

        var N = int.Parse(Console.ReadLine());//ずらした文字数を表す整数 N 
        var S = Console.ReadLine(); //暗号文字列を表す文字列 S

        var result = decrypt(S, N);
        Console.WriteLine(result);
    }



    private static string decrypt(string encryptionString, int decodingKey) {

        var result = "";
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        for(int i = 0; i < encryptionString.Length; i++) {
            var encryptStrPos = alphabet.IndexOf(encryptionString[i]);
            var decryptStrPos = 0;
            if((i+1) % 2 != 0) { //奇数番目の文字に関して,復号化文字はN数分だけ逆順にしたもの
                decryptStrPos = encryptStrPos - (decodingKey);
                if(decryptStrPos < 0) { //先頭を超えた場合は末尾から数える
                    decryptStrPos = (alphabet.Length) - (decodingKey - encryptStrPos);
                }
            } else { //偶数番目の文字は、N数分だけ後ろの文字にしたもの
                decryptStrPos = encryptStrPos + (decodingKey);
                if(decryptStrPos > alphabet.Length - 1) { //末尾を超えた場合は先頭から数える
                    decryptStrPos = 0 + (decodingKey - (alphabet.Length  - encryptStrPos));
                }
            }
            result += alphabet[decryptStrPos];
        }

        return result;
    }

}