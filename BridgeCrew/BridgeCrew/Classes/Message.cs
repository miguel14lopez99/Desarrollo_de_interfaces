using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace BridgeCrew
{
    class Message
    {
        private String source;
        private String dest;
        private String text;
        private static List<Message> messages = new List<Message>();
        private static string path = @"../../data/Messages.txt";
        private static FileInfo fileinfo = new FileInfo(path);
        


        public Message(string src, string dst, string txt)
        {
            this.source = src;
            this.dest = dst;
            this.text = txt;
        }

        public String getSourceMsg { get => this.source; }
        public String getDestMsg { get => this.dest; }

        public String getTextMsg { get => this.text; }

        public static void add(Message msg)
        {
            messages.Add(msg);
        }

        public static void saveMsgs()
        {
            if (messages.Count != 0) { 
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (Message msg in messages)
                    {
                        sw.Write(msg.getSourceMsg + "#");
                        sw.Write(msg.getDestMsg + "#");
                        sw.Write(msg.getTextMsg + "##");
                        sw.WriteLine();
                    }
                    messages.Clear();
                }
            }
        }

        public static String ReadMsg()
        {
            string line = "";
            fileinfo.Refresh();
            if (fileinfo.Exists)
            {
                if (fileinfo.Length == 0)
                {
                    line = "File is Empty";
                }
                else
                {
                    line = File.ReadAllText(path);
                }
            }
            else {
                if (messages.Count == 0)
                {
                    line = "Please send a message first";
                }
                else {
                    line = "Wait Until the backup is done";
                }
                
            }
            
            
            return line;
        }

        public static void ClearFile() {

         File.WriteAllText(path, String.Empty);
           
            

        }
    }
}
