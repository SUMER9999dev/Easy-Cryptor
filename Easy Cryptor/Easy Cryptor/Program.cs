using System;
using System.IO;
using CryptoLib;

namespace Easy_Cryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            string IV = "FQW8imxAe2fba4WV"; //IV for encrypt 16 symbols
            string Key = "EconhIcGSJVCa8TP0VIbmpP2gYRLr7Su"; //Key for encrypt 32 symbols
            Console.Title = "Easy Cryptor"; //set title
            string[] files = Directory.GetFiles(@".\FolderForCrypt\", "*.*"); //Get files in folder
            foreach(string fil in files) 
            {
                string buftext; //buffer text
                using(StreamReader sr = new StreamReader(fil))  //using StreamReader for files
                {
                   buftext = sr.ReadToEnd(); //read all text in files and write to buffer
                   sr.Close(); //close stream
                }
                using(StreamWriter sw = new StreamWriter(fil)) //using StreamWriter for files
                {
                    sw.Write(Cryptor.Encrypt(Key, IV, buftext)); //write encrypted buffer text to file 
                    sw.Close(); //close stream
                }
            }
            Console.WriteLine("[Easy Cryptor]: Encrypted!");
            Console.WriteLine("[Easy Cryptor]: Type decrypt to decrypt!");
            Console.Write("[Input]: ");
            string message = Console.ReadLine(); //Read line
            if(message == "decrypt") //if line decrypt
            {
                foreach (string fil in files) 
                {
                    string buftext; //same buffer like in encrypt
                    using (StreamReader sr = new StreamReader(fil)) //Stream Reader
                    {
                        buftext = sr.ReadToEnd(); //read all text in files and write to buffer
                        sr.Close(); //close stream
                    }
                    using (StreamWriter sw = new StreamWriter(fil)) //using StreamWriter for files
                    {
                        sw.Write(Cryptor.Decrypt(Key, IV, buftext)); //Write decrypted text in buffer
                        sw.Close(); //close stream
                    }
                }
                Console.WriteLine("[Easy Cryptor]: Decrypted!");
            }
            Console.WriteLine("[Easy Cryptor]: Press any key to exit...");
            Console.ReadKey(); //Close after press button
        }
    }
}
