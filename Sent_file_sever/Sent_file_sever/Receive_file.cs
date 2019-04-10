using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sent_file_sever
{
    public static class Receive_file
    {
        public static void clientData(byte[] clientData, string receivedPath)
        {
            int receivedBytesLen = clientData.Count();

            int fileNameLen = clientData[0];
            string fileName = Encoding.ASCII.GetString(clientData, 1, fileNameLen);
            BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append)); ;
            bWrite.Write(clientData, 1 + fileNameLen, receivedBytesLen - 1 - fileNameLen);
            Console.WriteLine("File: {0} received & saved at path: {1}", fileName, receivedPath);
            bWrite.Close();
        }
    }
}
