using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ShopNum1.Common
{
    public class FTP
    {
        public string server;

        public string user;

        public string pass;

        public int port;

        public int timeout;

        public string errormessage;

        private string string_0;

        private string string_1;

        private bool bool_0;

        private long long_0;

        private long long_1;

        private Socket socket_0;

        private IPEndPoint ipendPoint_0;

        private Socket socket_1;

        private Socket socket_2;

        private IPEndPoint ipendPoint_1;

        private FileStream fileStream_0;

        private int int_0;

        private string string_2;

        private int int_1 = 512;

        public long BytesTotal
        {
            get
            {
                return this.long_0;
            }
        }

        public long FileSize
        {
            get
            {
                return this.long_1;
            }
        }

        public bool IsConnected
        {
            get
            {
                bool flag;
                flag = (this.socket_0 == null ? false : this.socket_0.Connected);
                return flag;
            }
        }

        public string Messages
        {
            get
            {
                string string0 = this.string_0;
                this.string_0 = "";
                return string0;
            }
        }

        public bool MessagesAvailable
        {
            get
            {
                bool flag;
                flag = (this.string_0.Length <= 0 ? false : true);
                return flag;
            }
        }

        public bool PassiveMode
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public string ResponseString
        {
            get
            {
                return this.string_1;
            }
        }

        public FTP()
        {
            this.server = null;
            this.user = null;
            this.pass = null;
            this.port = 21;
            this.bool_0 = true;
            this.socket_0 = null;
            this.ipendPoint_0 = null;
            this.socket_1 = null;
            this.socket_2 = null;
            this.ipendPoint_1 = null;
            this.fileStream_0 = null;
            this.string_2 = "";
            this.long_0 = 0L;
            this.timeout = 10000;
            this.string_0 = "";
            this.errormessage = "";
        }

        public FTP(string server, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = 21;
            this.bool_0 = true;
            this.socket_0 = null;
            this.ipendPoint_0 = null;
            this.socket_1 = null;
            this.socket_2 = null;
            this.ipendPoint_1 = null;
            this.fileStream_0 = null;
            this.string_2 = "";
            this.long_0 = 0L;
            this.timeout = 10000;
            this.string_0 = "";
            this.errormessage = "";
        }

        public FTP(string server, int port, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.bool_0 = true;
            this.socket_0 = null;
            this.ipendPoint_0 = null;
            this.socket_1 = null;
            this.socket_2 = null;
            this.ipendPoint_1 = null;
            this.fileStream_0 = null;
            this.string_2 = "";
            this.long_0 = 0L;
            this.timeout = 10000;
            this.string_0 = "";
            this.errormessage = "";
        }

        public FTP(string server, int port, string user, string pass, int mode)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.bool_0 = (mode <= 1 ? true : false);
            this.socket_0 = null;
            this.ipendPoint_0 = null;
            this.socket_1 = null;
            this.socket_2 = null;
            this.ipendPoint_1 = null;
            this.fileStream_0 = null;
            this.string_2 = "";
            this.long_0 = 0L;
            this.timeout = 10000;
            this.string_0 = "";
            this.errormessage = "";
        }

        public FTP(string server, int port, string user, string pass, int mode, int timeout_sec)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.bool_0 = (mode <= 1 ? true : false);
            this.socket_0 = null;
            this.ipendPoint_0 = null;
            this.socket_1 = null;
            this.socket_2 = null;
            this.ipendPoint_1 = null;
            this.fileStream_0 = null;
            this.string_2 = "";
            this.long_0 = 0L;
            this.timeout = (timeout_sec <= 0 ? 2147483647 : timeout_sec * 1000);
            this.string_0 = "";
            this.errormessage = "";
        }

        public bool ChangeDir(string path)
        {
            bool flag;
            this.Connect();
            this.method_2(string.Concat("CWD ", path));
            this.method_5();
            if (this.int_0 == 250)
            {
                flag = true;
            }
            else
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
                flag = false;
            }
            return flag;
        }

        public void Connect(string server, int port, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.Connect();
        }

        public void Connect(string server, string user, string pass)
        {
            this.server = server;
            this.user = user;
            this.pass = pass;
            this.Connect();
        }

        public bool Connect()
        {
            bool flag;
            if (this.server == null)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, "No server has been set.\r\n");
            }
            if (this.user == null)
            {
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, "No server has been set.\r\n");
            }
            if (this.socket_0 == null || !this.socket_0.Connected)
            {
                try
                {
                    this.socket_0 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.socket_0.Connect(this.server, this.port);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    FTP fTP2 = this;
                    fTP2.errormessage = string.Concat(fTP2.errormessage, exception.Message);
                    flag = false;
                    return flag;
                }
                this.method_5();
                if (this.int_0 != 220)
                {
                    this.method_0();
                }
                this.method_2(string.Concat("USER ", this.user));
                this.method_5();
                int int0 = this.int_0;
                if (int0 != 230)
                {
                    if (int0 == 331)
                    {
                        if (this.pass != null)
                        {
                            this.method_2(string.Concat("PASS ", this.pass));
                            this.method_5();
                            if (this.int_0 == 230)
                            {
                                goto Label1;
                            }
                            this.method_0();
                            flag = false;
                            return flag;
                        }
                        else
                        {
                            this.Disconnect();
                            FTP fTP3 = this;
                            fTP3.errormessage = string.Concat(fTP3.errormessage, "No password has been set.");
                            flag = false;
                            return flag;
                        }
                    }
                }
            Label1:
                flag = true;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public void Disconnect()
        {
            this.method_8();
            if (this.socket_0 != null)
            {
                if (this.socket_0.Connected)
                {
                    this.method_2("QUIT");
                    this.socket_0.Close();
                }
                this.socket_0 = null;
            }
            if (this.fileStream_0 != null)
            {
                this.fileStream_0.Close();
            }
            this.ipendPoint_0 = null;
            this.fileStream_0 = null;
        }

        public long DoDownload()
        {
            long num;
            byte[] numArray = new byte[this.int_1];
            try
            {
                long num1 = (long)this.socket_2.Receive(numArray, (int)numArray.Length, SocketFlags.None);
                if (num1 > 0L)
                {
                    this.fileStream_0.Write(numArray, 0, (int)num1);
                    FTP long0 = this;
                    long0.long_0 = long0.long_0 + num1;
                    num = num1;
                    return num;
                }
                else
                {
                    this.method_8();
                    this.fileStream_0.Close();
                    this.fileStream_0 = null;
                    this.method_5();
                    int int0 = this.int_0;
                    if (int0 == 226 || int0 == 250)
                    {
                        this.method_1(false);
                        num = num1;
                    }
                    else
                    {
                        FTP fTP = this;
                        fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
                        num = -1L;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.method_8();
                this.fileStream_0.Close();
                this.fileStream_0 = null;
                this.method_5();
                this.method_1(false);
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, exception.Message);
                num = -1L;
            }
            return num;
        }

        public long DoUpload()
        {
            long num;
            long num1;
            byte[] numArray = new byte[this.int_1];
            try
            {
                num = (long)this.fileStream_0.Read(numArray, 0, (int)numArray.Length);
                FTP long0 = this;
                long0.long_0 = long0.long_0 + num;
                this.socket_2.Send(numArray, (int)num, SocketFlags.None);
                if (num <= 0L)
                {
                    this.fileStream_0.Close();
                    this.fileStream_0 = null;
                    this.method_8();
                    this.method_5();
                    int int0 = this.int_0;
                    if (int0 == 226 || int0 == 250)
                    {
                        this.method_1(false);
                    }
                    else
                    {
                        FTP fTP = this;
                        fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
                        num1 = -1L;
                        return num1;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.fileStream_0.Close();
                this.fileStream_0 = null;
                this.method_8();
                this.method_5();
                this.method_1(false);
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, exception.Message);
                num1 = -1L;
                return num1;
            }
            num1 = num;
            return num1;
        }

        public DateTime GetFileDate(string fileName)
        {
            return this.method_9(this.GetFileDateRaw(fileName));
        }

        public string GetFileDateRaw(string fileName)
        {
            string str;
            this.Connect();
            this.method_2(string.Concat("MDTM ", fileName));
            this.method_5();
            if (this.int_0 == 213)
            {
                str = this.string_1.Substring(4);
            }
            else
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
                str = "";
            }
            return str;
        }

        public long GetFileSize(string filename)
        {
            this.Connect();
            this.method_2(string.Concat("SIZE ", filename));
            this.method_5();
            if (this.int_0 != 213)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
            return long.Parse(this.string_1.Substring(4));
        }

        public string GetWorkingDirectory()
        {
            string str;
            string str1;
            this.Connect();
            this.method_2("PWD");
            this.method_5();
            if (this.int_0 != 257)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
            try
            {
                str = this.string_1.Substring(this.string_1.IndexOf("\"", 0) + 1);
                str = str.Substring(0, str.LastIndexOf("\""));
                str = str.Replace("\"\"", "\"");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, exception.Message);
                str1 = null;
                return str1;
            }
            str1 = str;
            return str1;
        }

        public ArrayList List()
        {
            byte[] numArray = new byte[this.int_1];
            string str = "";
            long num = 0L;
            int num1 = 0;
            ArrayList arrayLists = new ArrayList();
            this.Connect();
            this.method_6();
            this.method_2("LIST");
            this.method_5();
            int int0 = this.int_0;
            if (int0 != 125 && int0 != 150)
            {
                this.method_8();
                throw new Exception(this.string_1);
            }
            this.method_7();
            do
            {
                if (this.socket_2.Available < 1)
                {
                    Thread.Sleep(50);
                    num1 = num1 + 50;
                }
                else
                {
                    break;
                }
            }
            while (num1 <= this.timeout / 10);
            while (this.socket_2.Available > 0)
            {
                num = (long)this.socket_2.Receive(numArray, (int)numArray.Length, SocketFlags.None);
                str = string.Concat(str, Encoding.ASCII.GetString(numArray, 0, (int)num));
                Thread.Sleep(50);
            }
            this.method_8();
            this.method_5();
            if (this.int_0 != 226)
            {
                throw new Exception(this.string_1);
            }
            string[] strArrays = str.Split(new char[] { '\n' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                if ((str1.Length <= 0 ? false : !Regex.Match(str1, "^total").Success))
                {
                    arrayLists.Add(str1.Substring(0, str1.Length - 1));
                }
            }
            return arrayLists;
        }

        public ArrayList ListDirectories()
        {
            ArrayList arrayLists = new ArrayList();
            foreach (string str in this.List())
            {
                if (str.Length <= 0)
                {
                    continue;
                }
                if ((str[0] == 'd' ? false : str.ToUpper().IndexOf("<DIR>") < 0))
                {
                    continue;
                }
                arrayLists.Add(str);
            }
            return arrayLists;
        }

        public ArrayList ListFiles()
        {
            ArrayList arrayLists = new ArrayList();
            foreach (string str in this.List())
            {
                if (str.Length <= 0)
                {
                    continue;
                }
                if ((str[0] == 'd' ? true : str.ToUpper().IndexOf("<DIR>") >= 0))
                {
                    continue;
                }
                arrayLists.Add(str);
            }
            return arrayLists;
        }

        public void MakeDir(string string_3)
        {
            this.Connect();
            this.method_2(string.Concat("MKD ", string_3));
            this.method_5();
            int int0 = this.int_0;
            if (int0 != 250 && int0 != 257)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
        }

        private void method_0()
        {
            this.Disconnect();
            FTP fTP = this;
            fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
        }

        private void method_1(bool bool_1)
        {
            if (!bool_1)
            {
                this.method_2("TYPE A");
            }
            else
            {
                this.method_2("TYPE I");
            }
            this.method_5();
            if (this.int_0 != 200)
            {
                this.method_0();
            }
        }

        private void method_2(string string_3)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string.Concat(string_3, "\r\n").ToCharArray());
            if ((string_3.Length <= 3 ? true : !(string_3.Substring(0, 4) == "PASS")))
            {
                this.string_0 = string.Concat("\r", string_3);
            }
            else
            {
                this.string_0 = "\rPASS xxx";
            }
            try
            {
                this.socket_0.Send(bytes, (int)bytes.Length, SocketFlags.None);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                try
                {
                    this.Disconnect();
                    FTP fTP = this;
                    fTP.errormessage = string.Concat(fTP.errormessage, exception.Message);
                    return;
                }
                catch
                {
                    this.socket_0.Close();
                    this.fileStream_0.Close();
                    this.socket_0 = null;
                    this.ipendPoint_0 = null;
                    this.fileStream_0 = null;
                }
            }
        }

        private void method_3()
        {
            byte[] numArray = new byte[this.int_1];
            int num = 0;
            while (true)
            {
                if ((this.socket_0 == null ? true : this.socket_0.Available >= 1))
                {
                    while (true)
                    {
                        if ((this.socket_0 == null ? true : this.socket_0.Available <= 0))
                        {
                            return;
                        }
                        long num1 = (long)this.socket_0.Receive(numArray, this.int_1, SocketFlags.None);
                        FTP fTP = this;
                        fTP.string_2 = string.Concat(fTP.string_2, Encoding.ASCII.GetString(numArray, 0, (int)num1));
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    Thread.Sleep(50);
                    num = num + 50;
                    if (num > this.timeout)
                    {
                        this.Disconnect();
                        FTP fTP1 = this;
                        fTP1.errormessage = string.Concat(fTP1.errormessage, "Timed out waiting on server to respond.");
                        break;
                    }
                }
            }
        }

        private string method_4()
        {
            string str = "";
            int num = this.string_2.IndexOf('\n');
            int num1 = num;
            if (num < 0)
            {
                while (num1 < 0)
                {
                    this.method_3();
                    num1 = this.string_2.IndexOf('\n');
                }
            }
            str = this.string_2.Substring(0, num1);
            this.string_2 = this.string_2.Substring(num1 + 1);
            return str;
        }

        private void method_5()
        {
            string str;
            this.string_0 = "";
            while (true)
            {
                str = this.method_4();
                if (Regex.Match(str, "^[0-9]+ ").Success)
                {
                    break;
                }
                FTP fTP = this;
                fTP.string_0 = string.Concat(fTP.string_0, Regex.Replace(str, "^[0-9]+-", ""), "\n");
            }
            this.string_1 = str;
            this.int_0 = int.Parse(str.Substring(0, 3));
        }

        private void method_6()
        {
            Exception exception;
            string[] strArrays;
            if (!this.bool_0)
            {
                this.Connect();
                try
                {
                    this.method_8();
                    this.socket_1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    string str = this.socket_0.LocalEndPoint.ToString();
                    int num = str.IndexOf(':');
                    if (num >= 0)
                    {
                        string str1 = str.Substring(0, num);
                        IPEndPoint pEndPoint = new IPEndPoint(IPAddress.Parse(str1), 0);
                        this.socket_1.Bind(pEndPoint);
                        str = this.socket_1.LocalEndPoint.ToString();
                        num = str.IndexOf(':');
                        if (num < 0)
                        {
                            FTP fTP = this;
                            fTP.errormessage = string.Concat(fTP.errormessage, "Failed to parse the local address: ", str);
                        }
                        int num1 = int.Parse(str.Substring(num + 1));
                        this.socket_1.Listen(1);
                        string str2 = string.Format("PORT {0},{1},{2}", str1.Replace('.', ','), num1 / 256, num1 % 256);
                        this.method_2(str2);
                        this.method_5();
                        if (this.int_0 != 200)
                        {
                            this.method_0();
                        }
                    }
                    else
                    {
                        FTP fTP1 = this;
                        fTP1.errormessage = string.Concat(fTP1.errormessage, "Failed to parse the local address: ", str);
                    }
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    FTP fTP2 = this;
                    fTP2.errormessage = string.Concat(fTP2.errormessage, "Failed to connect for data transfer: ", exception.Message);
                }
            }
            else
            {
                this.Connect();
                this.method_2("PASV");
                this.method_5();
                if (this.int_0 != 227)
                {
                    this.method_0();
                }
                try
                {
                    int num2 = this.string_1.IndexOf('(') + 1;
                    int num3 = this.string_1.IndexOf(')') - num2;
                    strArrays = this.string_1.Substring(num2, num3).Split(new char[] { ',' });
                }
                catch (Exception exception2)
                {
                    this.Disconnect();
                    FTP fTP3 = this;
                    fTP3.errormessage = string.Concat(fTP3.errormessage, "Malformed PASV response: ", this.string_1);
                    return;
                }
                if ((int)strArrays.Length >= 6)
                {
                    object[] objArray = new object[] { strArrays[0], strArrays[1], strArrays[2], strArrays[3] };
                    string str3 = string.Format("{0}.{1}.{2}.{3}", objArray);
                    int num4 = (int.Parse(strArrays[4]) << 8) + int.Parse(strArrays[5]);
                    try
                    {
                        this.method_8();
                        this.socket_2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        this.socket_2.Connect(str3, num4);
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                        FTP fTP4 = this;
                        fTP4.errormessage = string.Concat(fTP4.errormessage, "Failed to connect for data transfer: ", exception.Message);
                    }
                }
                else
                {
                    this.Disconnect();
                    FTP fTP5 = this;
                    fTP5.errormessage = string.Concat(fTP5.errormessage, "Malformed PASV response: ", this.string_1);
                }
            }
        }

        private void method_7()
        {
            if (this.socket_2 == null)
            {
                try
                {
                    this.socket_2 = this.socket_1.Accept();
                    this.socket_1.Close();
                    this.socket_1 = null;
                    if (this.socket_2 == null)
                    {
                        throw new Exception(string.Concat("Winsock error: ", Convert.ToString(Marshal.GetLastWin32Error())));
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    FTP fTP = this;
                    fTP.errormessage = string.Concat(fTP.errormessage, "Failed to connect for data transfer: ", exception.Message);
                }
            }
        }

        private void method_8()
        {
            if (this.socket_2 != null)
            {
                if (this.socket_2.Connected)
                {
                    this.socket_2.Close();
                }
                this.socket_2 = null;
            }
            this.ipendPoint_1 = null;
        }

        private DateTime method_9(string string_3)
        {
            if (string_3.Length < 14)
            {
                throw new ArgumentException("Input Value for ConvertFTPDateToDateTime method was too short.");
            }
            int num = Convert.ToInt16(string_3.Substring(0, 4));
            int num1 = Convert.ToInt16(string_3.Substring(4, 2));
            int num2 = Convert.ToInt16(string_3.Substring(6, 2));
            int num3 = Convert.ToInt16(string_3.Substring(8, 2));
            int num4 = Convert.ToInt16(string_3.Substring(10, 2));
            int num5 = Convert.ToInt16(string_3.Substring(12, 2));
            return new DateTime(num, num1, num2, num3, num4, num5);
        }

        public void OpenDownload(string filename)
        {
            this.OpenDownload(filename, filename, false);
        }

        public void OpenDownload(string filename, bool resume)
        {
            this.OpenDownload(filename, filename, resume);
        }

        public void OpenDownload(string remote_filename, string localfilename)
        {
            this.OpenDownload(remote_filename, localfilename, false);
        }

        public void OpenDownload(string remote_filename, string local_filename, bool resume)
        {
            Exception exception;
            this.Connect();
            this.method_1(true);
            this.long_0 = 0L;
            try
            {
                this.long_1 = this.GetFileSize(remote_filename);
            }
            catch
            {
                this.long_1 = 0L;
            }
            if ((!resume ? true : !File.Exists(local_filename)))
            {
                try
                {
                    this.fileStream_0 = new FileStream(local_filename, FileMode.Create);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    this.fileStream_0 = null;
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                try
                {
                    this.fileStream_0 = new FileStream(local_filename, FileMode.Open);
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    this.fileStream_0 = null;
                    throw new Exception(exception.Message);
                }
                this.method_2(string.Concat("REST ", this.fileStream_0.Length));
                this.method_5();
                if (this.int_0 != 350)
                {
                    throw new Exception(this.string_1);
                }
                this.fileStream_0.Seek(this.fileStream_0.Length, SeekOrigin.Begin);
                this.long_0 = this.fileStream_0.Length;
            }
            this.method_6();
            this.method_2(string.Concat("RETR ", remote_filename));
            this.method_5();
            int int0 = this.int_0;
            if (int0 == 125 || int0 == 150)
            {
                this.method_7();
            }
            else
            {
                this.fileStream_0.Close();
                this.fileStream_0 = null;
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
        }

        public bool OpenUpload(string filename)
        {
            return this.OpenUpload(filename, filename, false);
        }

        public bool OpenUpload(string filename, string remotefilename)
        {
            return this.OpenUpload(filename, remotefilename, false);
        }

        public bool OpenUpload(string filename, bool resume)
        {
            return this.OpenUpload(filename, filename, resume);
        }

        public bool OpenUpload(string filename, string remote_filename, bool resume)
        {
            bool flag;
            this.Connect();
            this.method_1(true);
            this.method_6();
            this.long_0 = 0L;
            try
            {
                this.fileStream_0 = new FileStream(filename, FileMode.Open);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.fileStream_0 = null;
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, exception.Message);
                flag = false;
                return flag;
            }
            this.long_1 = this.fileStream_0.Length;
            if (resume)
            {
                long fileSize = this.GetFileSize(remote_filename);
                this.method_2(string.Concat("REST ", fileSize));
                this.method_5();
                if (this.int_0 == 350)
                {
                    this.fileStream_0.Seek(fileSize, SeekOrigin.Begin);
                }
            }
            this.method_2(string.Concat("STOR ", remote_filename));
            this.method_5();
            int int0 = this.int_0;
            if (int0 == 125 || int0 == 150)
            {
                this.method_7();
                flag = true;
            }
            else
            {
                this.fileStream_0.Close();
                this.fileStream_0 = null;
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, this.string_1);
                flag = false;
            }
            return flag;
        }

        public void RemoveDir(string string_3)
        {
            this.Connect();
            this.method_2(string.Concat("RMD ", string_3));
            this.method_5();
            if (this.int_0 != 250)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
        }

        public void RemoveFile(string filename)
        {
            this.Connect();
            this.method_2(string.Concat("DELE ", filename));
            this.method_5();
            if (this.int_0 != 250)
            {
                FTP fTP = this;
                fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
            }
        }

        public void RenameFile(string oldfilename, string newfilename)
        {
            this.Connect();
            this.method_2(string.Concat("RNFR ", oldfilename));
            this.method_5();
            if (this.int_0 == 350)
            {
                this.method_2(string.Concat("RNTO ", newfilename));
                this.method_5();
                if (this.int_0 != 250)
                {
                    FTP fTP = this;
                    fTP.errormessage = string.Concat(fTP.errormessage, this.string_1);
                }
            }
            else
            {
                FTP fTP1 = this;
                fTP1.errormessage = string.Concat(fTP1.errormessage, this.string_1);
            }
        }
    }
}