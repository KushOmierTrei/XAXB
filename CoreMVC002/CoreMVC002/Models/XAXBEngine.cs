using System;
using System.Collections.Generic;

namespace CoreMVC002.Models
{
    public class XAXBEngine
    {
        public string Secret { get; set; }
        public string Guess { get; set; }
        public string Result { get; set; }
        public List<string> GuessHistory { get; set; }
        public int GuessCount { get; set; }

        public XAXBEngine()
        {
            // 初始化时随机生成秘密数字
            Secret = GenerateSecretNumber();
            GuessHistory = new List<string>();
            GuessCount = 0;
        }

        // 随机生成4位数字
        private string GenerateSecretNumber()
        {
            Random random = new Random();
            HashSet<int> digits = new HashSet<int>();
            while (digits.Count < 4)
            {
                digits.Add(random.Next(0, 10));
            }
            return string.Join("", digits);
        }

        // 计算有多少个 'A'
        public int numOfA(string guessNumber)
        {
            int countA = 0;
            for (int i = 0; i < 4; i++)
            {
                if (guessNumber[i] == Secret[i])
                {
                    countA++;
                }
            }
            return countA;
        }

        // 计算有多少个 'B'
        public int numOfB(string guessNumber)
        {
            int countB = 0;
            var secretCopy = new List<char>(Secret.ToCharArray());
            var guessCopy = new List<char>(guessNumber.ToCharArray());

            // 先计算 'A'
            for (int i = 0; i < 4; i++)
            {
                if (guessCopy[i] == secretCopy[i])
                {
                    // 如果是 'A'，那么标记为已处理
                    secretCopy[i] = '\0'; // 将其标记为已处理
                    guessCopy[i] = '\0'; // 将其标记为已处理
                }
            }

            // 计算 'B'
            for (int i = 0; i < 4; i++)
            {
                if (guessCopy[i] != '\0' && secretCopy.Contains(guessCopy[i]))
                {
                    countB++;
                    secretCopy[secretCopy.IndexOf(guessCopy[i])] = '\0'; // 将其标记为已处理
                }
            }

            return countB;
        }

        // 获取当前猜测结果并保存记录
        public string GetResult(string guessNumber)
        {
            if (string.IsNullOrEmpty(guessNumber))
            {
                throw new ArgumentNullException(nameof(guessNumber), "猜測數字不能為空。");
            }

            int a = numOfA(guessNumber);
            int b = numOfB(guessNumber);
            GuessCount++;
            string result = $"{a}A{b}B";

            // 记录每次猜测的数字和结果
            GuessHistory.Add($"猜測：{guessNumber} -> 結果：{result}");

            return result;
        }

        // 判断游戏是否结束
        public bool IsGameOver()
        {
            return numOfA(Guess) == 4;
        }
    }
}
