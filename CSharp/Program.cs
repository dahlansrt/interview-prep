namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array2D = new string[,] {
                { "abc", "abc" },
                { "abbc", "abc" },
                { "cba", "abc" },
                { "abcd", "abc" },
                { "abc", "aabbcc" }
                };

            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                Console.Write($"{array2D[i, 0]} : {array2D[i, 1]} => ");
                Console.WriteLine(ransomNoteWithDict(array2D[i, 0], array2D[i, 1]));
            }
            return;

            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[]? TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> inside = new Dictionary<int, int>();
            int[] indices = new int[2];

            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };

                }

            return null;
        }

        /// <summary>
        /// Function that encodes “aaaabcccaaa” to “4ab3c3a”
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string DecodeMsg(string _input)
        {
            char _current = _input[0];
            string _output = "";
            int _counter = 0;

            for (int i = 0; i < _input.Length - 1; i++)
            {
                // Console.WriteLine(_input[i]);
                if (_input[i] == _input[i + 1])
                {
                    _counter++;
                }
                else
                {
                    if (_counter > 0)
                    {
                        _counter++;
                        _output += _counter.ToString() + _input[i];
                    }
                    else
                    {
                        _output += _input[i];
                    }

                    _counter = 0;
                }
            }

            return _output;
        }

        /// <summary>
        /// ransomNote(“abc”, “abc”); //true
        /// ransomNote(“abbc”, “abc”); //false
        /// ransomNote(“cba”, “abc”); //true
        /// ransomNote(“abcd”, “abc”); //false
        /// ransomNote(“abc”, “aabbcc); //true
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        public static bool ransomNoteWithDict(string string1, string string2)
        {
            Dictionary<char, int> inputDict = new Dictionary<char, int>();
            foreach (char item in string1)
            {
                try
                {
                    inputDict.Add(item, 1);
                }
                catch (ArgumentException)
                {
                    inputDict[item] += 1;
                }
            }

            foreach (KeyValuePair<char, int> kvp in inputDict)
            {
                if (!string2.Any(x => x == kvp.Key) && string2.Count(x => x == kvp.Key) < kvp.Value)
                {
                    return false;
                }
            }

            return true;
        }


        public static bool ransomNote(string string1, string string2)
        {
            bool result = false;
            foreach (var item in string1)
            {
                if (string2.Length == 0)
                {
                    result = true;
                    break;
                }
                else if (string2.Contains(item))
                {
                    string2 = string2.Remove(string2.IndexOf(item));
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}