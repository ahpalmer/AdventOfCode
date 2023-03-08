using System.Text;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        //Puzzle input: yzbqklnj
        var input = "yzbqklnj";
        int count = 0;
        do
        {

        }

    }
    //Day 4 Challenge 1, MD5 Hashes
    static string GenerateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public async Task<string> startAtZero(string input)
    {

    }


}

