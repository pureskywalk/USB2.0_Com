using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

using DeviceProgramming.Memory;
using DeviceProgramming.FileFormat;

using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.Info;
using LibUsbDotNet.DeviceNotify;
using LibUsbDotNet.LibUsb;

using Mono.Options;

using HID;
using HIDTester;
using System.Threading;

namespace taihang_EVM
{

    public partial class taihang_EVM : Form
    {
        public taihang_EVM()
        {
            InitializeComponent();
        }

        public static UsbDevice MyUsbDevice;

        //ErrorCode ec = ErrorCode.None;
        public static IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
        public static UsbEndpointReader reader;
        public static UsbEndpointWriter writer;

        private Hid myHid = new Hid();
        private IntPtr myHidPtr = new IntPtr();

        delegate void SetTextCallback(string text);//安全线程访问txtReadInt的值

        bool EnbaleInt = true;//是否使用中断接收

        Byte[] RecDataBuffer = new byte[90];

        string folder;
        bool f_receiveEnroll = false;


        private static readonly Regex UsbIdRegex = new Regex
            (@"^(?<vid>[a-fA-F0-9]{1,4}):(?<pid>[a-fA-F0-9]{1,4})$", RegexOptions.Compiled);

        private static readonly Regex VersionRegex = new Regex
            (@"^(?<major>[0-9]{1,2})\.(?<minor>[0-9]{1,2})$", RegexOptions.Compiled);

        private void taihang_EVM_Load(object sender, EventArgs e)
        {
            SEND_BUTTON.Enabled = false;
            SelectFile_Button.Enabled = false;
            DownLoad_Button.Enabled = false;
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
            if (FindAndOpenUSB(0x1234, 0x1234) == true)
            {
                PID_TEXT.Text = Convert.ToString(1234);
                VID_TEXT.Text = Convert.ToString(1234);
                MyUsbDevice.Close();
            }
            else if ((int)(myHidPtr = myHid.OpenDevice(0x483, 0x5750)) != -1)
            {
                PID_TEXT.Text = Convert.ToString(5750);
                VID_TEXT.Text = Convert.ToString(483);
                myHid.CloseDevice(myHidPtr);

            }
            else
            {
                PID_TEXT.Text = Convert.ToString(0000);
                VID_TEXT.Text = Convert.ToString(0000);
            }
        }

        private void USB_Conntect_Button_Click(object sender, EventArgs e)
        {
            if (USB_Conntect_Button.Text == "Connect")
            {
                if (FindAndOpenUSB(Convert.ToInt32(PID_TEXT.Text, 16), Convert.ToInt32(VID_TEXT.Text, 16)) == true)
                {
                    Status_TEXT.Text += string.Format("PID = 0x{0:X}, VID = 0x{2:X}，设备已连接,该设备用于DFU\r\n", PID_TEXT.Text, 16, VID_TEXT.Text, 16);
                    // open read endpoint 1.
                    reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);

                    // open write endpoint 1.
                    writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);

                    //if (EnbaleInt == true)
                    //{
                    //    reader.DataReceived += (OnRxEndPointData);
                    //    reader.DataReceivedEnabled = true;
                    //}
                    USB_Conntect_Button.Text = "Disconnect";
                    SEND_BUTTON.Enabled = false;
                    SelectFile_Button.Enabled = true;
                    DownLoad_Button.Enabled = true;
                }
                else if ((int)(myHidPtr = myHid.OpenDevice(Convert.ToInt32(VID_TEXT.Text, 16), Convert.ToInt32(PID_TEXT.Text, 16))) != -1)
                {
                    Status_TEXT.Text += string.Format("PID = 0x{0:X}, VID = 0x{2:X}，设备已连接，该设备用于通信\r\n", PID_TEXT.Text, 16, VID_TEXT.Text, 16);
                    myHid.DataReceived += MyHid_DataReceived;
                    f_receiveEnroll = true;
                    USB_Conntect_Button.Text = "Disconnect";
                    SEND_BUTTON.Enabled = true;
                    SelectFile_Button.Enabled = false;
                    DownLoad_Button.Enabled = false;
                }
                else
                    Status_TEXT.Text += "设备未连接" + "\r\n";
            }
            else
            {
                CloseUSB();
            }
        }
        private void MyHid_DataReceived(object sender, Report e)
        {
            RecDataBuffer = e.reportBuff;

            //Int16 dissipate_H = (short)(RecDataBuffer[13] & 0x0F);
            //Int16 dissipate_L = RecDataBuffer[14];
            //Int16 dissipate = (short)((dissipate_H << 8) + dissipate_L);
            //double showtext = ((3.429 / 4096) * dissipate - 1.2);
            //this.Invoke((EventHandler)delegate
            //{
            //    DissipateText.Text = showtext.ToString();
            //});

            //string receive_str = "";
            //for (int i = 0; i < RecDataBuffer.Length; i++)
            //{
            //    string mid_str = Convert.ToString(RecDataBuffer[i], 16);
            //    if (mid_str.Length == 1)
            //    {
            //        mid_str = "0" + mid_str;
            //    }
            //    receive_str += mid_str + " ";
            //}
            //receive_str += "\r\n";
            //this.Invoke((EventHandler)delegate
            //{
            //    RECEIVE_TEXT.Text += receive_str;
            //});
        }

        private void StatusDate_Clear_Click(object sender, EventArgs e)
        {
            Status_TEXT.Text = "";
        }

        private void SEND_BUTTON_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SEND_TEXT.Text))
            {
                byte[] send_buf = new byte[SEND_TEXT.Text.Length / 3];
                for (int i = 0; i < send_buf.Count(); i++)
                {
                    send_buf[i] = Convert.ToByte(SEND_TEXT.Text.Substring(i * 3, 2), 16);
                }

                //int bytesWritten;
                //ec = writer.Write(send_buf, 2000, out bytesWritten);
                //if (ec != ErrorCode.None) 
                Report r = new Report(0, send_buf);
                myHid.Write(r);
                //myHid.BeginAsyncRead();
                //Status_TEXT.Text += UsbDevice.LastErrorString;
            }
        }

        private void ReceiveDate_Clear_Click(object sender, EventArgs e)
        {
            RECEIVE_TEXT.Text = "";
        }

        private void SelectFile_Button_Click(object sender, EventArgs e)
        {
            if (My_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                folder = My_openFileDialog.FileName;
                string fileName = Path.GetFileName(folder);
                SelectedFile_TEXT.Text = fileName;
            }
        }

        private void DownLoad_Button_Click(object sender, EventArgs e)
        {
            string filePath = folder;
            string fileExt = null;
            bool help = false;
            bool isDfuFile = false;
            // Vendor and Product IDs are required, set them to invalid
            int vid = Convert.ToInt32(VID_TEXT.Text, 16), pid = Convert.ToInt32(PID_TEXT.Text, 16);
            // version is optional, FF means forced update
            int vmajor = 0xFF, vminor = 0xFF;

            // parameter parsing
            OptionSet optionSet = new OptionSet()
                .Add("?|help|h",
                    "Prints out the options.", option => help = option != null)
                .Add("i|image=",
                   "Path of the image file to download. Supported formats are DFU, Intel HEX and Motorola SREC.",
                   option => filePath = option)
                .Add("d|device=",
                   "USB Device Vendor and Product ID in XXXX:XXXX format. Ignored if the file format is DFU.",
                   option =>
                   {
                       var result = UsbIdRegex.Match(option);
                       if (!result.Success)
                       {
                           help = true;
                       }
                       else
                       {
                           vid = UInt16.Parse(result.Groups["vid"].Value, NumberStyles.HexNumber);
                           pid = UInt16.Parse(result.Groups["pid"].Value, NumberStyles.HexNumber);
                       }
                   })
                .Add("v|version=",
                   "Firmware version in D.D format. Ignored if the file format is DFU.",
                   option =>
                   {
                       var result = VersionRegex.Match(option);
                       if (!result.Success)
                       {
                           help = true;
                       }
                       else
                       {
                           vmajor = Byte.Parse(result.Groups["major"].Value);
                           vminor = Byte.Parse(result.Groups["minor"].Value);
                       }
                   });
            try
            {
                // try to get required arguments
                //optionSet.Parse((IEnumerable<string>)e);
                fileExt = Path.GetExtension(filePath);
                isDfuFile = Dfu.IsExtensionSupported(fileExt);
                if (!isDfuFile && ((vid > 0xFFFF) || (pid > 0xFFFF)))
                {
                    help = true;
                }
            }
            catch
            {
                help = true;
            }

            if (help == true)
            {
                // print help text and exit
                //Console.Error.WriteLine("Usage:");
                //optionSet.WriteOptionDescriptions(Console.Error);
                Environment.Exit(-1);
            }

            // DFU device event printers
            //int prevCursor = -1;
            EventHandler<ProgressChangedEventArgs> printDownloadProgress = (obj, A) =>
            {
                //if (prevCursor == Console.CursorTop)
                //{
                //    Console.SetCursorPosition(0, Console.CursorTop - 1);
                //}
                //Status_TEXT.Text += ("Download progress:" + A.ProgressPercentage.ToString() + "\r\n");
                //prevCursor = Console.CursorTop;
                DownLoad_progressBar.Value = A.ProgressPercentage;
            };
            EventHandler<ErrorEventArgs> printDevError = (obj, A) =>
            {
                Status_TEXT.Text += "The DFU device reported the following error: " + A.GetException().Message + "\r\n";
            };

            Device device = null;
            try
            {
                Version fileVer = new Version(vmajor, vminor);
                Dfu.FileContent dfuFileData = null;
                RawMemory memory = null;

                // find the matching file parser by extension
                if (isDfuFile)
                {
                    dfuFileData = Dfu.ParseFile(filePath);
                    Status_TEXT.Text += ("DFU image parsed successfully." + "\r\n");

                    // DFU file specifies VID, PID and version, so override any arguments
                    vid = dfuFileData.DeviceInfo.VendorId;
                    pid = dfuFileData.DeviceInfo.ProductId;
                    fileVer = dfuFileData.DeviceInfo.ProductVersion;
                }
                else if (IntelHex.IsExtensionSupported(fileExt))
                {
                    memory = IntelHex.ParseFile(filePath);
                    Status_TEXT.Text += ("Intel HEX image parsed successfully." + "\r\n");
                }
                else if (SRecord.IsExtensionSupported(fileExt))
                {
                    memory = SRecord.ParseFile(filePath);
                    Status_TEXT.Text += ("SRecord image parsed successfully." + "\r\n");
                }
                else
                {
                    Status_TEXT.Text += ("Image file format not recognized." + "\r\n");
                }

                // find the DFU device
                device = Device.OpenFirst(UsbDevice.AllDevices, vid, pid);
                device.DeviceError += printDevError;

                if (isDfuFile)
                {
                    // verify protocol version
                    if (dfuFileData.DeviceInfo.DfuVersion != device.DfuDescriptor.DfuVersion)
                    {
                        Status_TEXT.Text += ("DFU file version" + dfuFileData.DeviceInfo.DfuVersion.ToString() + "doesn't match device DFU version" +
                            device.DfuDescriptor.DfuVersion.ToString() + "\r\n");//String.Format??
                    }
                }

                // if the device is in normal application mode, reconfigure it
                if (device.InAppMode())
                {
                    bool skipUpdate = fileVer <= device.Info.ProductVersion;

                    // skip update when it's deemed unnecessary
                    if (skipUpdate)
                    {
                        Status_TEXT.Text += ("The device is already up-to-date (version " + device.Info.ProductVersion.ToString() + "), skipping update (version " + fileVer.ToString() + ")." + "\r\n");
                        return;
                    }

                    Status_TEXT.Text += ("Device found in application mode, reconfiguring device to DFU mode..." + "\r\n");
                    device.Reconfigure();

                    // in case the device detached, we must find the DFU mode device
                    if (!device.IsOpen())
                    {
                        // clean up old device first
                        device.DeviceError -= printDevError;
                        device.Dispose();
                        device = null;

                        device = Device.OpenFirst(UsbDevice.AllDevices, vid, pid);
                        device.DeviceError += printDevError;
                    }
                }
                else
                {
                    Status_TEXT.Text += ("Device found in DFU mode." + "\r\n");
                }


                // perform upgrade
                //th = new Thread(new ThreadStart(delegate()
                //{
                    device.DownloadProgressChanged += printDownloadProgress;
                    if (isDfuFile)
                    {
                        device.DownloadFirmware(dfuFileData);
                    }
                    else
                    {
                        device.DownloadFirmware(memory);
                    }
                    device.DownloadProgressChanged -= printDownloadProgress;
                //}));
                //th.IsBackground = true;
                //th.Start();


                Status_TEXT.Text += ("Download successful, manifesting update..." + "\r\n");
                device.Manifest();

                // if the device detached, clean up
                if (!device.IsOpen())
                {
                    //device.DeviceError -= printDevError;
                    device.Dispose();
                    device = null;
                }

                // TODO find device again to verify new version
                Status_TEXT.Text += ("The device has been successfully upgraded." + "\r\n");

            }
            catch (Exception A)
            {
                Status_TEXT.Text += "Device Firmware Upgrade failed with exception: " + A.Message + "\r\n";
                CloseUSB();
            }
            finally
            {
                if (device != null)
                {
                    device.Dispose();
                }
            }
        }

        private void Status_TEXT_TextChanged(object sender, EventArgs e)
        {
            Status_TEXT.SelectionStart = Status_TEXT.TextLength;
            Status_TEXT.ScrollToCaret();
        }

        private void SEND_TEXT_TextChanged(object sender, EventArgs e)
        {
            //if (((SEND_TEXT.Text.Length + 1) % 3) == 0)
            //{
            //    SEND_TEXT.Text += " ";
            //MoveSendTextCurorLast();
            ////}
            ////SEND_TEXT.SelectionStart = SEND_TEXT.TextLength;
            //SEND_TEXT.ScrollToCaret();
        }

        private void RECEIVE_TEXT_TextChanged(object sender, EventArgs e)
        {
            RECEIVE_TEXT.SelectionStart = RECEIVE_TEXT.TextLength;
            RECEIVE_TEXT.ScrollToCaret();
        }

        //原USB中断接收事件
        //private void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        //{
        //    //LastDataEventDate = DateTime.Now;
        //    //MessageBox.Show(Encoding.Default.GetString(e.Buffer, 0, e.Count));

        //    string receive_str = "";
        //    for (int i = 0; i < e.Count; i++)
        //    {
        //        string mid_str = Convert.ToString(e.Buffer[i], 16);
        //        if (mid_str.Length == 1)
        //        {
        //            mid_str = "0" + mid_str;
        //        }
        //        receive_str += mid_str + " ";
        //    }
        //    SetText(receive_str);
        //}

        //设备变化消息相应函数
        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (e.EventType == EventType.DeviceArrival)
            {
                try
                {
                    //Status_TEXT.Text += string.Format("发现有新USB设备连接，PID = 0x{0:X},VID = 0x{1:X}.\r\n设备的详细信息{2}\r\n", e.Device.IdProduct, e.Device.IdVendor, e.Device.ToString());
                    Status_TEXT.Text += string.Format("发现有USB设备接入，PID = 0x{0:X}, VID = 0x{1:X}\r\n", e.Device.IdProduct, e.Device.IdVendor);
                    PID_TEXT.Text = Convert.ToString(e.Device.IdProduct, 16);
                    VID_TEXT.Text = Convert.ToString(e.Device.IdVendor, 16);
                    FindAndOpenUSB(Convert.ToInt32(PID_TEXT.Text, 16), Convert.ToInt32(VID_TEXT.Text, 16));
                }
                catch /*(Exception A)*/
                {
                    //MessageBox.Show(A.Message);
                }
            }
            else if (e.EventType == EventType.DeviceRemoveComplete)
            {
                try
                {
                    //Status_TEXT.Text += string.Format("发现有USB设备移除，PID = 0x{0:X}, VID = 0x{1:X}\r\n设备的详细信息{2}\r\n", e.Device.IdProduct, e.Device.IdVendor, e.Device.ToString());
                    Status_TEXT.Text += string.Format("发现有USB设备移除，PID = 0x{0:X}, VID = 0x{1:X}\r\n", e.Device.IdProduct, e.Device.IdVendor);
                    //看看目前移除的USB设备是不是目标设备
                    if (e.Device.IdProduct == Convert.ToInt32(PID_TEXT.Text, 16) && e.Device.IdVendor == Convert.ToInt32(VID_TEXT.Text, 16))
                    {
                        //MessageBox.Show(string.Format("移除的USB设备是目标设备\r\n"));
                        CloseUSB();
                    }
                }
                catch /*(Exception A)*/
                {
                    //MessageBox.Show(A.Message);
                }
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.RECEIVE_TEXT.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.RECEIVE_TEXT.Text += (text + "\r\n");
            }
        }

        private bool FindAndOpenUSB(int PID, int VID)
        {
            UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(PID, VID);
            UsbRegistry myUsbRegistry = UsbDevice.AllDevices.Find(MyUsbFinder);

            if (ReferenceEquals(myUsbRegistry, null))
            {
                return false;
            }
            // Open this usb device.
            if (!myUsbRegistry.Open(out MyUsbDevice))
            {
                return false;
            }

            ((LibUsbDevice)MyUsbDevice).SetConfiguration(1);

            ((LibUsbDevice)MyUsbDevice).ClaimInterface(0);

            //Status_TEXT.Text += string.Format("Device Name:{0}\r\n", myUsbRegistry[SPDRP.DeviceDesc]);
            return true;
        }

        public void CloseUSB()
        {
            if(f_receiveEnroll == true)
            { 
                myHid.CloseDevice(myHidPtr);
                //必须把注册的事件释放，不然连续开上位机的情况下，重新连接下位机，连接多少次就会有多少个中断接收函数被注册，导致重复接受问题
                myHid.DataReceived -= MyHid_DataReceived;
                f_receiveEnroll = false;
            }
            if (!ReferenceEquals(reader, null))
                reader.Dispose();
            if (!ReferenceEquals(writer, null))
                writer.Dispose();
            if (!ReferenceEquals(MyUsbDevice, null))
                MyUsbDevice.Close();
            SEND_BUTTON.Enabled = false;
            SelectFile_Button.Enabled = false;
            DownLoad_Button.Enabled = false;
            
            if (USB_Conntect_Button.Text == "Disconnect")
            {
                Status_TEXT.Text += "设备已断开" + "\r\n";
            }
            USB_Conntect_Button.Text = "Connect";
        }

        //将send_text光标移至最后
        private void MoveSendTextCurorLast()
        {
            //让文本框获取焦点 
            this.SEND_TEXT.Focus();
            //设置光标的位置到文本尾 
            this.SEND_TEXT.Select(this.SEND_TEXT.TextLength, 0);
            //滚动到控件光标处 
            this.SEND_TEXT.ScrollToCaret();
        }

        //将receive_text光标移至最后
        private void MoveReceiveTextCurorLast()
        {
            //让文本框获取焦点 
            this.RECEIVE_TEXT.Focus();
            //设置光标的位置到文本尾 
            this.RECEIVE_TEXT.Select(this.RECEIVE_TEXT.TextLength, 0);
            //滚动到控件光标处 
            this.RECEIVE_TEXT.ScrollToCaret();
        }

        private void ReceiveDate_Click(object sender, EventArgs e)
        {
            string receive_str = "";
            for (int i = 0; i < RecDataBuffer.Length; i++)
            {
                string mid_str = Convert.ToString(RecDataBuffer[i], 16);
                if (mid_str.Length == 1)
                {
                    mid_str = "0" + mid_str;
                }
                receive_str += mid_str + " ";
            }
            receive_str += "\r\n";
            this.Invoke((EventHandler)delegate
            {
                RECEIVE_TEXT.Text += receive_str;

            });
        }
    }
}
