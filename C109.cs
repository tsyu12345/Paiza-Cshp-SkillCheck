using System;
using System.Text.RegularExpressions;

class C109 {

    static void Main() {
        var N = int.Parse(Console.ReadLine());//ユーザー ID の個数を表す整数 N 
        var userIDs = GetUserIDs(N);//ユーザー ID を表す文字列を表す配列

        var userObjects = GetUserObjects(userIDs);//ユーザー ID と通し番号を分割したオブジェクトの配列
        var result = SortUsrObjs(userObjects);//通し番号の昇順にソートした配列
        for(int i = 0; i < result.Length; i++) {
            var user = (dynamic)result[i];
            Console.WriteLine("{0}{1}", user.UserId, user.SerialNumber);
        }

    }

    private static string[] GetUserIDs(int size) {
        var userIDs = new string[size];
        for (int i = 0; i < size; i++) {
            userIDs[i] = Console.ReadLine();
        }
        return userIDs;
    }


    private static object[] GetUserObjects(string[] userIDs) {
        var userObjects = new object[userIDs.Length];
        for (int i = 0; i < userIDs.Length; i++) {
            userObjects[i] = SplitSerialNumber(userIDs[i]);
        }
        return userObjects;
    }

    /**
    * ユーザーIDの末尾にある通し番号とユーザーIDを分割する。
    */
    private static object SplitSerialNumber(string userId) {
        var regex = new Regex(@"\d+$"); //数字部分を表す正規表現
        var match = regex.Match(userId);
        var serialNumber = match.Value;
        var id = userId.Replace(serialNumber, "");
        return new { SerialNumber = int.Parse(serialNumber), UserId = id };
    }

    /**通し番号の昇順にソートする*/
    private static object[] SortUsrObjs(object[] userObjects) {
        for (int i = 0; i < userObjects.Length - 1; i++) {
            for (int j = userObjects.Length - 1; j > i; j--) {
                var fst = (dynamic)userObjects[j - 1];
                var scd = (dynamic)userObjects[j];
                if (fst.SerialNumber > scd.SerialNumber) {
                    var tmp = userObjects[j - 1];
                    userObjects[j - 1] = userObjects[j];
                    userObjects[j] = tmp;
                }
            }
        }
        return userObjects;
    }


}