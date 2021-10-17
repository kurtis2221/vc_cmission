using System;
using System.Collections.Generic;
using System.Text;

namespace vc_cmission
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Injecting...");
            if (System.IO.File.Exists("gta-vc.exe"))
            {
                Inject();
                Console.WriteLine("Completed!");
                System.Threading.Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("Error, gta-vc.exe not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void Inject()
        {
            System.Diagnostics.Process.Start("gta-vc.exe");

        retry:
            if (!MemoryEdit.Memory.IsProcessOpen("gta-vc"))
            {
                System.Threading.Thread.Sleep(500);
                goto retry;
            }

            MemoryEdit.Memory mem = new MemoryEdit.Memory("gta-vc", 0x001F0FFF);

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            byte[] Buffer = encoding.GetBytes("cmission");
            mem.WriteString(0x00687C95, Buffer, 8);

            Buffer = BitConverter.GetBytes(0x00687C9568);
            mem.WriteByte(0x004506D1,Buffer,5);

            Buffer = encoding.GetBytes("cmission\\main.scm");
            mem.WriteString(0x00687FFE, Buffer, 17);

            Buffer = BitConverter.GetBytes(0x00687FFE68);
            mem.WriteByte(0x00608C81, Buffer, 5);

            encoding = null;
            Buffer = null;
            mem = null;
        }
    }
}
