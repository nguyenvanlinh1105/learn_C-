namespace bai_31_utils
{
    static class ConvertNumberToText {
        // Chuyển đổi số thành từ
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);

            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }

            int ones, tens, hundreds;
            int positionDigit = sNumber.Length; // last -> first
            string result = "";

            // Process each digit from last to first
            for (int i = 0; i < sNumber.Length; i++)
            {
                positionDigit--;
                int currentDigit = int.Parse(sNumber.Substring(i, 1));

                // Process unit digit
                if (positionDigit % 3 == 2)
                {
                    if (currentDigit == 0)
                    {
                        if (sNumber.Substring(i + 1, 1) != "0" && sNumber.Substring(i + 2, 1) != "0")
                            result += "không trăm ";
                    }
                    else
                    {
                        result += unitNumbers[currentDigit] + " trăm ";
                    }
                }

                // Process tens digit
                else if (positionDigit % 3 == 1)
                {
                    if (currentDigit == 0)
                    {
                        if (sNumber.Substring(i + 1, 1) != "0")
                            result += "lẻ ";
                    }
                    else if (currentDigit == 1)
                    {
                        result += "mười ";
                    }
                    else
                    {
                        result += unitNumbers[currentDigit] + " mươi ";
                    }
                }

                // Process ones digit
                else
                {
                    if (currentDigit == 5 && i > 0 && sNumber.Substring(i - 1, 1) != "0")
                    {
                        result += "lăm ";
                    }
                    else if (currentDigit > 0)
                    {
                        result += unitNumbers[currentDigit] + " ";
                    }

                    // Add place value
                    if (positionDigit / 3 > 0 && i < sNumber.Length - 1)
                    {
                        if (positionDigit % 3 == 0)
                        {
                            result += placeValues[positionDigit / 3] + " ";
                        }
                    }
                }
            }

            // Add suffix if required
            if (suffix)
            {
                result += "đồng";
            }

            // Add negative sign if necessary
            if (isNegative)
            {
                result = "Âm " + result;
            }

            // Capitalize the first letter
            result = result.Substring(0, 1).ToUpper() + result.Substring(1);

            return result.Trim();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
