using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors {
    class Program {
        static void Main(string[] args) {
            string answer = "y";
            List<int> factors = new List<int>();

            do {
                long num = 0;
                bool result = false;
                do {
                    Console.Write("Please enter a natural number: ");
                    result = (Int64.TryParse(Console.ReadLine(), out num));
                } while (!result);                
               
                long displaynum = num;
                do {
                    if (num == 0) {
                        factors.Add(0);
                        break;
                    }
                    int f = (PrimeFactor(num));
                    factors.Add(f);
                    num /= f;

                } while (num != 1);

                Console.Write("The prime factors of " + displaynum + " are: ");
                factors.Sort(); // Only for negative numbers


                for (int i = 0; i < factors.Count; i++) {
                    switch (factors.Count) {
                        case 1:
                            Console.WriteLine(factors[i] + Environment.NewLine);
                            break;
                        default:
                            if (i != factors.Count - 1) {
                                Console.Write(factors[i] + ", ");
                            } else {
                                Console.WriteLine("and " + factors[i] + Environment.NewLine);
                            }
                            break;
                    }
                }

                factors.Clear();
                Console.Write("Do you want to continue y/n: "); 
                answer = Console.ReadLine();

            } while (answer.StartsWith("y"));            
        }

        static int PrimeFactor(long x) {
            if (x % 2 == 0) {
                return 2;
            }

            for (int i = 3; i <= x; i += 2) {
                if (x % i == 0) {
                    for (int j = 3; j <= i; j += 2) {
                        if (i == j) {
                            return i;
                        }

                        if (i % j == 0) {
                            break;
                        }
                    }
                }
            }
            return -1;
        }
    }
}
