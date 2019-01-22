using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using blz;
using CTR;
using _3DS_Builder.Properties;

namespace _3DS_Builder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
        	if (args.Length!=4){
        		Console.WriteLine("3dsbuilder <exefs precompiled> <romfsdir> <exheader> <out file>");
        	}else{
        		//CTR_ROM.buildROM(true, "Nintendo", "/gooddrive/_temp/puyo/exefs.bin", "/gooddrive/_temp/puyo/romfs", "/gooddrive/_temp/puyo/exheader.bin", "CTR-P-XXXX", "/gooddrive/_temp/puyo/outrom");
        	    CTR_ROM.buildROM(true, "Nintendo", args[0], args[1], args[2], "CTR-P-XXXX", args[3]);
        	}
        }
    }
}
