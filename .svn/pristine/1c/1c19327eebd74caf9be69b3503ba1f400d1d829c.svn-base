using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CurrencyStore.Business;
using CurrencyStore.Communication;
using System.Threading;

namespace CurrencyStore.Unpack
{
    static class Program
    {
        const string data = "AABB012E3158325900BC614EA00A000C0A1E120815000101010101010101010103120816000100003207D5110045473133363230363334000000020000000000000000000000003F001FFE07FC3F800FF001FE3FFE00000000000000001FFC3FFE300E30073007380E3FFE07F000000000000030003000300030FF37FF3F003C003800000000000000200060006000601F61FF67E07E0078007000000000000000400060006000601F61FF67F87F007800780000000000000000003FFC3FFF7807600360036003780F3FFF0FF80000000000000008380E380F6183618363833FC73EFE007C0000000000000800180038003FFF3FFF000000000000000000000000000000F801F807B83E383FFF3FFF00380000000000000000007801F807981E183FFF3FFF001800000000003B05";
        static byte[] buff = new byte[data.Length / 2];
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            V1();

            while (true)
            {
                Console.WriteLine("请输入测试次数.");
                var val = Console.ReadLine();
                try
                {
                    var count = Convert.ToInt32(val);
                    //Tester.Time("缓存测试", count, () => { ConnectionCounter.Current.Increase("_aa", 1); });

                    //Tester.Time("解码测试", count, () => { CurrencyStore.Communication.Message.ConvertFrom(buff); });

                    Tester.Time("并发测试", count, Push);

                    Tester.Time("技术测试", count, V2);

                }
                catch { }
                Console.WriteLine("测试结束，继续请按C，退出请按X");
                var k = Console.ReadKey();
                if (k.Key == ConsoleKey.X)
                    break;
            }
        }

        static void Push()
        {
            Entity.CurrencyInfo item = CurrencyStore.Communication.Message.ConvertFrom(buff).Currency;
            for (int i = 0; i < 100; i++)
            {
                DataPool.Push(item);
            }
        }
 

        static long index;
        static void V2()
        {
            for (int i = 0; i < 1000; i++)
            {
                var j = Interlocked.Increment(ref index);
                var val = Convert.ToInt32(j / 3);
            }
           
        }


 
        static void V1()
        {
            buff = new byte[data.Length / 2];
            for (int i = 0; i < buff.Length; i++)
            {
                var val = "0x" + data[i * 2] + data[i * 2 + 1];
                buff[i] = (byte)Convert.ToInt16(val, 16);
            }
        }
    }
}
