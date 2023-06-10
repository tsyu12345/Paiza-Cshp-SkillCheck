using System.Collections.Generic;
using System.Linq;
using System;

class C104 {

    static void Main(string[] args) {

        var inputs = Console.ReadLine().Split(' ');
        var a = int.Parse(inputs[0]);
        var b = int.Parse(inputs[1]);

        var result = GetVermiculationNumber(a, b);

        if(result.Length == 0) {
            Console.WriteLine("No");
        } else {
            Console.WriteLine(result[0] + " " + result[1]);
        }

    }


    
    private static int[] GetVermiculationNumber(int a, int b) {
        int v1, v2;

        for(int i = 1; i <= 9; i++) {
            v1 = i;
            for(int j = 0; j <= 9; j++) {
                v2 = j;
                if(Formula(v1, v2) == FormulaAns(a, b, v1)) {
                    return new int[] { v1, v2 };
                }
            }
        }
        return new int[] {};
    }


    private static int Formula(int v1, int v2) {
        return ((10 * v1) + v2) * v2;
    }

    private static int FormulaAns(int a, int b, int v1) {
        return (100 * a) + (10 * v1) + b;
    }

}