using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sent_file_sever
{
    public static class Send_file
    {
        public static byte[] clientData (string fileName, string filePath)
        {
            byte[] fileNameByte = Encoding.UTF8.GetBytes(fileName);// chuyen ten file thanh byte

            byte[] fileData = File.ReadAllBytes(filePath + fileName);// doc du lieu trong file thanh byte

            byte[] clientData = new byte[1 + fileNameByte.Length + fileData.Length];// tao array byte chua du lieu can chuyen

            byte fileNameBit = (byte)fileNameByte.Length;// fileNameBit: byte chua do dai du lieu can chuyen

            //--------tao array clientData chua cac thong tin cua file---------- 
            clientData[0] = fileNameBit;
            fileNameByte.CopyTo(clientData, 1);
            fileData.CopyTo(clientData, 1 + fileNameByte.Length);
            return clientData;
        }
    }
}
