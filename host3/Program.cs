using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace host3 {
    static class Program {
        [STAThread]
        static void Main(string[] args) {
            if (args.Length != 0) {
                string pac = "D:\\ss\\pac.txt";
                string chromeMessage = OpenStandardStreamIn();
                bool remove=false;
                string host = "";
                if (chromeMessage.StartsWith("\"_REMOVE_$")) {
                    remove = true;
                    string[] data = chromeMessage.Split('$');
                    host = "\"" + data[1];
                }
                else {
                    host = chromeMessage;
                }
                FileStream fs = new FileStream(pac, FileMode.OpenOrCreate,FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                string fullText="";
                //全都读进来，在读的同时弄好
                while (sr.Peek() >= 0) {
                    string content = sr.ReadLine();
                    if (content.Contains(host) && remove) {
                        //Do nothing
                    }
                    else
                        fullText+=content+Environment.NewLine;
                    if (content.StartsWith("var domains")) {
                        if(!remove)
                            fullText += host + ": 1," + Environment.NewLine;
                    }
                    
                }
                sr.Close();
                fs.Close();
                //备份已有文件
                for (int i = 0; i < 100; i++)
                    if (!File.Exists(pac + ".bak" + i.ToString())) {
                        File.Move(pac, pac + ".bak" + i.ToString());
                        break;
                    }
                //再写回去
                FileStream fsNew = new FileStream(pac, FileMode.Create);
                StreamWriter sw = new StreamWriter(fsNew, Encoding.UTF8);
                sw.WriteLine(fullText);
                sw.Close();
                fsNew.Close();
            }
        }

        private static string OpenStandardStreamIn() {
            //// We need to read first 4 bytes for length information
            Stream stdin = Console.OpenStandardInput();
            int length = 0;
            byte[] bytes = new byte[4];
            stdin.Read(bytes, 0, 4);
            length = System.BitConverter.ToInt32(bytes, 0);
            byte[] msg = new byte[length];
            string input = "";
            for (int i = 0; i < length; i++) {
                msg[i] = (byte)stdin.ReadByte();
            }
            input = System.Text.Encoding.UTF8.GetString(msg);
            return input;
        }
    }
}