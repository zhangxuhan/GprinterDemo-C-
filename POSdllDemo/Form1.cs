using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using GprinterTest;
using System.Threading;

namespace POSdllDemo
{
    public partial class Form1 : Form
    {
        private IntPtr Gp_IntPtr;                   //驱动打印句柄
        private libUsbContorl.UsbOperation NewUsb=new libUsbContorl.UsbOperation();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPOSDll PosPrint = new LoadPOSDll();
            
						//POS_COM_DTR_DSR 0x00 流控制为DTR/DST  
						//POS_COM_RTS_CTS 0x01 流控制为RTS/CTS 
						//POS_COM_XON_XOFF 0x02 流控制为XON/OFF 
						//POS_COM_NO_HANDSHAKE 0x03 无握手 
						//POS_OPEN_PARALLEL_PORT 0x12 打开并口通讯端口 
						//POS_OPEN_BYUSB_PORT 0x13 打开USB通讯端口 
						//POS_OPEN_PRINTNAME 0X14 打开打印机驱动程序 
						//POS_OPEN_NETPORT 0x15 打开网络接口 

            if (PosPrint.OpenNetPort("192.168.0.123"))//当参数nParam的值为POS_OPEN_NETPORT时，表示打开指定的网络接口，如“192.168.10.251”表示网络接口IP地址，打印时参考
            {
                Gp_IntPtr = PosPrint.POS_IntPtr;
            }
            if (LoadPOSDll.POS_StartDoc())
            {
                byte[] by_SendData = System.Text.Encoding.Default.GetBytes("test print\r\n");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, by_SendData, (uint)by_SendData.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_EndDoc();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
        	NewUsb.FindUSBPrinter();
        	for(int k=0; k < NewUsb.USBPortCount; k++)
        	{
                int i = 0;
        		if(NewUsb.LinkUSB(k))
        		{
        			byte[] shiftsize={0x1d,0x57,0xd0,0x01};//偏移量
        			byte[] KanjiMode={0x1c,0x26};//汉字模式
        			
        			SendData2USB(shiftsize);
        			SendData2USB(KanjiMode);
        			
        			#region 打印信息测试
        			string strPrintwidth="48毫米";
        			string strPrintDensity="384点/行";
        			string strPrintSpeed="90毫米/秒";
        			string strPrintLiftTime="50公里";
        			string strPowerSupply="DC 12V/4A";
        			string strSerialInfo="有";
        			string strParInfo="无";
        			string strUSBInfo="USB2.0协议";
        			string strWirelessInfo="无";
        			string strNetInfo="无";
        			
        			string strSend;
        			byte[] SendData={0x1b,0x61,0x01,0x1b,0x21,0x30,0x1c,0x57,0x01};
        			byte[] enddata={0x0a};//换行
        			
        			SendData2USB(SendData);
        			
        			string strSendData="联机测试";
        			SendData2USB(strSendData);
        			
        			SendData2USB(new byte[]{0x0a,0x0a});
        			SendData2USB(new byte[]{0x1b,0x61,0x00,0x1b,0x21,0x00,0x1c,0x57,0x00});
        			
        			SendData2USB("技术指标：");
        			SendData2USB(enddata);
        			SendData2USB("*打印宽度"+strPrintwidth);
        			SendData2USB(enddata);
        			SendData2USB("*打印速度"+strPrintSpeed);
        			SendData2USB(enddata);
        			SendData2USB("*打印浓度"+strPrintDensity);
        			SendData2USB(enddata);
        			SendData2USB("*使用寿命"+strPrintLiftTime);
        			SendData2USB(enddata);
        			SendData2USB("*电源要求"+strPowerSupply);
        			SendData2USB(enddata);
        			SendData2USB("*打印宽度"+strPrintwidth);
        			SendData2USB(enddata);
        			SendData2USB("*串行接口"+strSerialInfo);
        			SendData2USB(enddata);
        			SendData2USB("*并行接口"+strParInfo);
        			SendData2USB(enddata);
        			SendData2USB("*USB接口"+strUSBInfo);
        			SendData2USB(enddata);
        			SendData2USB("*无线接口"+strWirelessInfo);
        			SendData2USB(enddata);
        			SendData2USB("*网络接口"+strWirelessInfo);
        			SendData2USB(enddata);
        			SendData2USB(enddata);
        			#endregion
        			
        			#region 字体打印测试
        			SendData2USB(KanjiMode);
					SendData=new byte[16];
					int linecount=3;
					byte bit=0xa1,Zone=0xa1;
					for(i=0;i<16;i+=2)
					{
						SendData[i]	=Zone;
						SendData[i+1]=bit;
						bit++;
					}
        			SendData2USB(enddata);
        			SendData2USB(SendData);
        			
        			Zone=0xb0;
        			bit=0xa1;
        			for(i=0;i<linecount;i++)
        			{
        				for(int j=0;j<16;j+=2)
        				{
        					SendData[j]=Zone;
        					SendData[j+1]=bit;
        					Zone++;
        				}
        				bit++;
	        			SendData2USB(enddata);
	        			SendData2USB(SendData);
        			}
        			SendData2USB(enddata);
        			SendData2USB(enddata);
        			#endregion
        			
        			SendData2USB(new byte[]{0x10,0x04,0x01});//查询状态
	        		byte[] readData=new byte[]{};
	        		NewUsb.ReadDataFmUSB(ref readData);
        			NewUsb.CloseUSBPort();
        		}
        	}
        }
        private void button3_Click(object sender, EventArgs e)
        {
        	NewUsb.FindUSBPrinter();
        	for(int i=0;i<NewUsb.USBPortCount;i++)
        	{
        		if(NewUsb.LinkUSB(i))
        		{
        			SendData2USB("SIZE 58 mm,60 mm\r\n");//标签尺寸
        			SendData2USB("GAP 0 mm,0 mm\r\n");//间距为0
        			SendData2USB("DENSITY 7\r\n");//打印浓度
        			SendData2USB("REFERENCE 0,0\r\n");
        			SendData2USB("TEXT 15,10,\"1\",0,1,1,\"asdfggDDD\"\r\n");
        			SendData2USB("TEXT 15,60,\"TSS24.BF2\",0,1,1,\"简体字\"\r\n");
        			
        			StreamReader strReadFile=new StreamReader(@"./10.bmp");
        			byte[] byteReadData=new byte[strReadFile.BaseStream.Length];
        			strReadFile.BaseStream.Read(byteReadData,0,byteReadData.Length);
        			strReadFile.Close();
        			SendData2USB("DOWNLOAD\"10.bmp\",4096,");
        			SendData2USB(byteReadData);//bmp数据
        			SendData2USB("PUTBMP 14,110,\"10.bmp\"\r\n");
        			SendData2USB("PRINT 1\r\n");
        			
        			NewUsb.CloseUSBPort();
        		}
        	}
        }
        private void SendData2USB(byte[] str)
        {
        	NewUsb.SendData2USB(str,str.Length);
        }
        private void SendData2USB(string str)
        {
        	byte[] by_SendData=System.Text.Encoding.GetEncoding(54936).GetBytes(str);
        	SendData2USB(by_SendData);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|ALL files(*.*)|*.*";
            //             fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true;
            fd.Multiselect = true;//单选
            Thread showPicsThread = new Thread(new ParameterizedThreadStart(delegate
            {
                DialogResult r1 = fd.ShowDialog();
                fd.Dispose();

                if (r1 == DialogResult.OK)
                {
                    string[] strReadFilePaths = fd.FileNames;
                    uint sendDatabuf = 0;

                    foreach (string strReadFilePath in strReadFilePaths)
                    {
                        StreamReader srReadFile = new StreamReader(strReadFilePath);
                        byte[] byteReaddata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                        srReadFile.Close();
                        byte bmpBitCount = byteReaddata[0x1c]; //获取位图 位深度
                        if (byteReaddata[0] != 'B' || byteReaddata[1] != 'M')
                        {
                            MessageBox.Show("文件不支持");
                            this.Invoke(new MethodInvoker(delegate
                            {
                                button4.Enabled = true;
                            }));
                            return;
                        }

                        uint byteLeght = (uint)byteReaddata.Length;
                        if (byteLeght > 1024000)
                        {
                            MessageBox.Show("所选文件过大");
                            this.Invoke(new MethodInvoker(delegate
                            {
                                button4.Enabled = true;
                            }));
                            return;
                        }
                        uint BMPWidth = (uint)(byteReaddata[0x15] * 0x1000000 + byteReaddata[0x14] * 0x10000 + byteReaddata[0x13] * 0x100 + byteReaddata[0x12]);
                        uint BMPHeight = (uint)(byteReaddata[0x19] * 0x1000000 + byteReaddata[0x18] * 0x10000 + byteReaddata[0x17] * 0x100 + byteReaddata[0x16]);

                        uint sendWidth = BMPWidth;      //实际发送的宽
                        uint sendHeight = BMPHeight;    //实际发送的高
                        if (BMPHeight % 8 != 0)
                            sendHeight = BMPHeight + 8 - BMPHeight % 8;
                        if (BMPWidth % 8 != 0)
                            sendWidth = BMPWidth + 8 - BMPWidth % 8;

                        sendDatabuf += 4 + sendWidth * sendHeight / 8;
                        #region lbBMPSize.Text = "已选择" + strReadFilePath.Length.ToString() + "张图片\r\n";
                        //                 if (sendDatabuf > 8096)
                        //                 {
                        //                     lbBMPSize.Text = "要发送的数据超过8096字节,请重新选择\r\n";
                        //                     lbBMPSize.Text += "已选择" + strReadFilePath.Length.ToString() + "张图片\r\n";
                        //                     disShowPic();
                        //                     strReadFilePath = new string[] { "" };
                        //                 }
                        //                 else
                        #endregion

                        byte printMod;
                        button4.Invoke(new MethodInvoker(delegate
                        {
                            button4.Enabled = true;
                            printMod = (byte)cb_1D_76_30.SelectedIndex;
                            sendGSBmpStream(strReadFilePath, printMod);
                        }));
                    }
                }
                else
                {
                    button4.Invoke(new MethodInvoker(delegate
                    {
                        button4.Enabled = true;
                    }));
                }
            }));//Thread showPicsThread
            showPicsThread.SetApartmentState(ApartmentState.STA);
            showPicsThread.Start();
        }
        private void button5_Click(object sender, EventArgs e)
        {
			if(serialPort1==null)
			{
			serialPort1=new SerialPort();
			serialPort1.RtsEnable=true;
			}
			if(serialPort1.IsOpen)
			{
			serialPort1.Close();
			}
			serialPort1.PortName="COM1";
			serialPort1.BaudRate=19200;
			serialPort1.Parity=(Parity)Enum.Parse(typeof(Parity),"None");
			serialPort1.DataBits=8;
			serialPort1.StopBits=(StopBits)Enum.Parse(typeof(StopBits),"One");
			serialPort1.ReadBufferSize=100;
			serialPort1.WriteBufferSize=2048;
			serialPort1.ReadTimeout=100;
			serialPort1.WriteTimeout=10000;
          LoadPOSDll PosPrint = new LoadPOSDll();
          if(PosPrint.OpenComPort(ref serialPort1))
          {
          	LoadPOSDll.POS_Reset();
          	PosPrint.PrintBmpInFlash(1,0,0x00);
          	PosPrint.PrintBmpInFlash(2,0,0x00);
          	PosPrint.PrintBmpInFlash(3,0,0x00);
          	PosPrint.PrintBmpInFlash(4,0,0x00);
          	PosPrint.ClosePrinterPort();
          }
        }

        private void btCheckMarkGo_Click(object sender, EventArgs e)
        {
            bool printpoint = true; //打印起始位置
            bool front = true;      //前进
            int resultLength = int.Parse(tbCheckMarkGo.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCheckMarkBack_Click(object sender, EventArgs e)
        {
            bool printpoint = true; //打印起始位置
            bool front = false;
            int resultLength = int.Parse(tbCheckMarkBack.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCutMarkGo_Click(object sender, EventArgs e)
        {
            bool printpoint = false; // 切/撕纸位置
            bool front = true;
            int resultLength = int.Parse(tbCutMarkGo.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btCutMarkBack_Click(object sender, EventArgs e)
        {
            bool printpoint = false; // 切/撕纸位置
            bool front = false;
            int resultLength = int.Parse(tbCutMarkBack.Text);

            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                byte[] cmddata1 = { 0X1D, 0X54 };
                byte[] cmddata2 = { 0X1D, 0X28, 0x46, 0x04, 0x00, 0x01, 0x00, 0x00, 0x00 };

                if (printpoint == true)
                    cmddata2[5] = 0x01;
                else
                    cmddata2[5] = 0x02;

                if (front == true)
                    cmddata2[6] = 0x00;
                else
                    cmddata2[6] = 0x01;

                cmddata2[7] = (byte)Math.Round((resultLength / 0.176) % 256);
                cmddata2[8] = (byte)((resultLength / 0.176) / 256);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, cmddata2, (uint)cmddata2.Length);

                PosPrint.ClosePrinterPort();
            }
        }

        private void btPrintGoNext_Click(object sender, EventArgs e)
        {
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                LoadPOSDll.POS_Reset();

                byte[] data1 = System.Text.Encoding.Default.GetBytes("开始打印");
                byte[] data2 = System.Text.Encoding.Default.GetBytes("然后走纸到下一个起始打印位置");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data1, (uint)data1.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[]{0x0a}, 1);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data2, (uint)data2.Length);

                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1B, 0x64, 0x05, 0x0A }, 4);//打印并进纸 n 行(0x05行)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1D, 0x54, 0x1D, 0x0C }, 4);//进黑标纸至打印起始位置(1D 0C)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0D }, 1);//把打印起始位置设置为该行的开始

                PosPrint.ClosePrinterPort();
            }
        }

        private void btPrintGoNextCut_Click(object sender, EventArgs e)
        {
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
                serialPort1.RtsEnable = true;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;
            LoadPOSDll PosPrint = new LoadPOSDll();
            if (PosPrint.OpenComPort(ref serialPort1))
            {
                LoadPOSDll.POS_Reset();

                byte[] data1 = System.Text.Encoding.Default.GetBytes("开始打印");
                byte[] data2 = System.Text.Encoding.Default.GetBytes("然后走纸到下一个/撕纸位置");
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data1, (uint)data1.Length);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0a }, 1);
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, data2, (uint)data2.Length);

                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1B, 0x64, 0x05, 0x0A }, 4);//打印并进纸 n 行(0x05行)
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x1D, 0x54, 0x1D, 0x56, 0x30 }, 5);//一种切纸模式并切纸(1D 56)30 31
                LoadPOSDll.POS_WriteFile(PosPrint.POS_IntPtr, new byte[] { 0x0D }, 1); //把打印起始位置设置为该行的开始

                PosPrint.ClosePrinterPort();
            }
        }
        /// <summary>
        /// 重写metset
        /// </summary>
        /// <param name="buf">设置的数组</param>
        /// <param name="val">设置的数据</param>
        /// <param name="size">数据长度</param>
        /// <returns>void</returns>     
        public void memset(byte[] buf, byte val, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                buf[i] = val;
        }

        /// <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "位图文件(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|ALL files(*.*)|*.*";
            //             fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true;
            fd.Multiselect = false;//单选
            DialogResult r1 = fd.ShowDialog();
            fd.Dispose();

            if (r1 == DialogResult.OK)
            {
                string strReadFilePath = fd.FileName;
                string filename = Path.GetFileName(strReadFilePath);
                StreamReader srReadFile = new StreamReader(strReadFilePath);

                byte[] b_bmpdata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                srReadFile.Close();

                byte bmpBitCount = b_bmpdata[0x1c]; //获取位图 位深度
                if (b_bmpdata[0] != 'B' || b_bmpdata[1] != 'M')
                {
                    MessageBox.Show("文件不支持");
                    return;
                }

                uint byteLeght = (uint)b_bmpdata.Length;
                if (byteLeght > 1024000)
                {
                    MessageBox.Show("所选文件过大");
                    return;
                }

                byte[] SendBmpData;
                uint sendWidth = 0;     //实际发送的宽
                uint sendHeight = 0;    //实际发送的高
                byte[] setHBit = { 0x80, 0x40, 0x30, 0x10, 0x08, 0x04, 0x02, 0x01 };    //算法辅助 置1
                byte[] clsLBit = { 0x7F, 0xBF, 0xDF, 0xEF, 0xF7, 0xFB, 0xFD, 0xFE };    //算法辅助 置0

                {
                    Stream str1 = new MemoryStream();
                    Image getimage = Image.FromFile(strReadFilePath);

                    sendWidth = (uint)getimage.Width;      //实际发送的宽
                    sendHeight = (uint)getimage.Height;    //实际发送的高

                    if (getimage.Height % 8 != 0)
                        sendHeight = sendHeight + 8 - sendHeight % 8;
                    if (getimage.Width % 8 != 0)
                        sendWidth = sendWidth + 8 - sendWidth % 8;

                    Bitmap getbmp = new Bitmap(getimage);
                    //                     Bitmap BmpCopy = new Bitmap(getimage.Width, getimage.Height, PixelFormat.Format32bppArgb);

                    SendBmpData = new byte[sendWidth * sendHeight / 8];
                    memset(SendBmpData, 0xff, (int)(sendWidth * sendHeight / 8));//0XFF为全白

                    #region 求灰度平均值
                    Double redSum = 0, geedSum = 0, blueSum = 0;
                    Double total = sendWidth * sendHeight;
                    byte[] huiduData = new byte[sendWidth * sendHeight / 8];
                    for (int i = 0; i < getimage.Width; i++)
                    {
                        int ta = 0, tr = 0, tg = 0, tb = 0;
                        for (int j = 0; j < getimage.Height; j++)
                        {
                            Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                            ta = getcolor.A;
                            tr = getcolor.R;
                            tg = getcolor.G;
                            tb = getcolor.B;
                            redSum += ta;
                            geedSum += tg;
                            blueSum += tb;
                        }
                    }
                    int meanr = (int)(redSum / total);
                    int meang = (int)(geedSum / total);
                    int meanb = (int)(blueSum / total);
                    #endregion 求灰度平均值

                    #region 抖动效果

                    #endregion 抖动效果

                    for (int j = 0; j < getimage.Height; j++)
                    {
                        for (int i = 0; i < getimage.Width; i++)
                        {
                            Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                            if ((getcolor.R * 0.299) + (getcolor.G * 0.587) + (getcolor.B * 0.114) < ((meanr * 0.299) + (meang * 0.587) + (meanb * 0.114)))//颜色转灰度(可调 0-255)
                                SendBmpData[j * sendWidth / 8 + i / 8] &= clsLBit[i % 8];
                        }
                    }
                }
                NewUsb.FindUSBPrinter();
                for (int i = 0; i < NewUsb.USBPortCount; i++)
                {
                    if (NewUsb.LinkUSB(i))
                    {
                        SendData2USB("CLS\n");
                SendData2USB("SIZE " + (sendWidth / 8 + 4).ToString() + " mm," + (sendHeight / 8 + 3).ToString() + " mm\n");
                SendData2USB("BITMAP 24,20," + (sendWidth / 8).ToString() + "," + sendHeight.ToString() + ",0,");
                SendData2USB(SendBmpData);
                SendData2USB("PRINT 1\n");

                NewUsb.CloseUSBPort();

                    }
                }
            }
        }

        public void sendGSBmpStream(string filename, byte printMod)
        {
            byte[] setHBit = { 0x80, 0x40, 0x30, 0x10, 0x08, 0x04, 0x02, 0x01 };    //算法辅助
            byte[] clsLBit = { 0x7F, 0xBF, 0xDF, 0xEF, 0xF7, 0xFB, 0xFD, 0xFE };    //算法辅助

            uint sendWidth = 0;      //实际发送的宽
            uint sendHeight = 0;    //实际发送的高
            byte[] SendBmpData = new byte[] { };

            if (filename != "")
            {//支持4，8位 位图
                StreamReader srReadFile = new StreamReader(filename);

                byte[] byteReaddata = StreamToBytes(srReadFile.BaseStream);//获取读取文件的byte[]数据
                srReadFile.Close();

                byte bmpBitCount = byteReaddata[0x1c]; //获取位图 位深度

                Stream str1 = new MemoryStream();
                Image getimage = Image.FromFile(filename);

                sendWidth = (uint)getimage.Width;      //实际发送的宽
                sendHeight = (uint)getimage.Height;    //实际发送的高

                if (getimage.Height % 8 != 0)
                    sendHeight = sendHeight + 8 - sendHeight % 8;
                if (getimage.Width % 8 != 0)
                    sendWidth = sendWidth + 8 - sendWidth % 8;

                Bitmap getbmp = new Bitmap(getimage);
                //                     Bitmap BmpCopy = new Bitmap(getimage.Width, getimage.Height, PixelFormat.Format32bppArgb);

                SendBmpData = new byte[sendWidth * sendHeight / 8];

                #region 求灰度平均值
                Double redSum = 0, geedSum = 0, blueSum = 0;
                Double total = sendWidth * sendHeight;
                byte[] huiduData = new byte[sendWidth * sendHeight / 8];
                for (int i = 0; i < getimage.Width; i++)
                {
                    int ta = 0, tr = 0, tg = 0, tb = 0;
                    for (int j = 0; j < getimage.Height; j++)
                    {
                        Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                        ta = getcolor.A;
                        tr = getcolor.R;
                        tg = getcolor.G;
                        tb = getcolor.B;
                        redSum += tr;
                        geedSum += tg;
                        blueSum += tb;
                    }
                }
                int meanr = (int)(redSum / total);
                int meang = (int)(geedSum / total);
                int meanb = (int)(blueSum / total);
                #endregion 求灰度平均值

                #region 抖动效果

                #endregion 抖动效果

                for (int j = 0; j < getimage.Height; j++)
                {
                    for (int i = 0; i < getimage.Width; i++)
                    {
                        Color getcolor = getbmp.GetPixel(i, j);//取每个点颜色
                        if ((getcolor.R * 0.299) + (getcolor.G * 0.587) + (getcolor.B * 0.114) < ((meanr * 0.299) + (meang * 0.587) + (meanb * 0.114)))//颜色转灰度(可调 0-255)
                            SendBmpData[j * sendWidth / 8 + i / 8] |= setHBit[i % 8];
                        //                         if (getcolor.R < meanr)//颜色转灰度(可调 0-255)
                        //                             SendBmpData[i * sendHeight / 8 + j / 8] |= setHBit[j % 8];
                    }
                }
                getimage.Dispose();
                getbmp.Dispose();
            }
            byte[] cmd1 = new byte[] { 0X1B, 0X40, 0X1D, 0X76, 0X30 };//1B 40--初始化
            byte[] cmd2 = new byte[5];
            cmd2[0] = printMod;
            cmd2[1] = (byte)(sendWidth / 8 % 256);
            cmd2[2] = (byte)(sendWidth / 8 / 256);
            cmd2[3] = (byte)(sendHeight % 256);
            cmd2[4] = (byte)(sendHeight / 256);
            NewUsb.FindUSBPrinter();

            for (int k = 0; k < NewUsb.USBPortCount; k++)
            {
                int i = 0;
                if (NewUsb.LinkUSB(k))
                {
                    SendData2USB(cmd1);//初始化指令                                   
                    SendData2USB(cmd2);//参数设置
                    SendData2USB(SendBmpData);//位图数据

                }
            }
            


            uint showwide = sendWidth / 8;
            if (showwide > 48)
                showwide = 48;
            if (cb_SaveFile.Checked == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "文本文件(*.txt)|*.txt";
                sfd.Title = "保存的点阵文件";

                DialogResult r1 = sfd.ShowDialog();
                sfd.Dispose();
                if (r1 == DialogResult.OK)
                {
                    string savepath = sfd.FileName;

                    FileStream temp = File.Create(savepath);//TEST
                    string textstr = "";
                    int index = 0;
                   
                    textstr += "命令:0x1B 0x40 0x1D 0x76 0x30 0x" + cmd2[0].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[1].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[2].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[3].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "0x" + cmd2[4].ToString("X").PadLeft(2, '0') + " ";
                    textstr += "\r\n位图数据:\r\n";
                    foreach (byte currbyte in SendBmpData)
                    {
                        textstr += "0x" + currbyte.ToString("X").PadLeft(2, '0') + ",";
                        index++;
                        if (index == showwide)
                        {
                            textstr += "\r\n";
                            index = 0;
                        }
                    }
                    byte[] sendata = System.Text.Encoding.Default.GetBytes(textstr);
                    temp.Write(sendata, 0, sendata.Length);
                    temp.Close();
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            byte[] buf1 = Encoding.GetEncoding("gb18030").GetBytes("TEXT 15,60,\"TSS24.BF2\",0,2,2,\"简体中文\"\r\n");
            byte[] buf2 = Encoding.GetEncoding("big5").GetBytes("TEXT 15,120,\"TST24.BF2\",0,2,2,\"繁體中文\"\r\n");

            //  byte[] by_SendData = System.Text.Encoding.GetEncoding("ksc5601").GetBytes(str); 韓文
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
            }
            serialPort1.Close();


            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            serialPort1.DataBits = 8;
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            serialPort1.ReadBufferSize = 100;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 10000;



            serialPort1.Open();
      

            serialPort1.Write("SIZE 58 mm,60 mm\r\n");//标签尺寸
            serialPort1.Write("GAP 0 mm,0 mm\r\n");//间距为0
            serialPort1.Write("CLS\r\n");
            serialPort1.Write("DENSITY 7\r\n");
            serialPort1.Write("REFERENCE 0,0\r\n");
            serialPort1.Write("TEXT 15,10,\"1\",0,2,2,\"ABCDEFGABCDEFG\"\r\n");
            serialPort1.Write(buf1, 0, buf1.Length);
            serialPort1.Write(buf2, 0, buf2.Length);
            serialPort1.Write("PRINT 1\r\n");
        }

        private void cb_1D_76_30_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
