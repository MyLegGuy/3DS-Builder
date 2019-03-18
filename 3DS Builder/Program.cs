using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using blz;
using CTR;
using _3DS_Builder.Properties;

namespace _3DS_Builder
{
    static class Program
    {

        static string makePathAbsolute(string _passedFilename){
            if (!Path.IsPathRooted(_passedFilename)){
                return Path.GetFullPath(_passedFilename);
            }else{
                return _passedFilename;
            }
        }
        static string removeEndSlash(string _passedDirectory){
            if (_passedDirectory[_passedDirectory.Length-1]==Path.DirectorySeparatorChar || _passedDirectory[_passedDirectory.Length-1]==Path.AltDirectorySeparatorChar){
                return _passedDirectory.Substring(0,_passedDirectory.Length-1);
            }else{
                return _passedDirectory;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
        	if (args.Length!=5){
        		Console.WriteLine("3dsbuilder <exefs precompiled> <romfsdir> <romfs patch or 'NULL'> <exheader> <out file>");
        	}else{
        		//CTR_ROM.buildROM(true, "Nintendo", "/gooddrive/_temp/puyo/exefs.bin", "/gooddrive/_temp/puyo/romfs", "/gooddrive/_temp/puyo/exheader.bin", "CTR-P-XXXX", "/gooddrive/_temp/puyo/outrom");
                string _possiblePatchDir = args[2];
                if (_possiblePatchDir=="NULL"){
                    _possiblePatchDir=null;
                }else{
                    _possiblePatchDir = removeEndSlash(makePathAbsolute(_possiblePatchDir));
                }
        	    CTR_ROM.buildROM(true, "Nintendo", makePathAbsolute(args[0]), removeEndSlash(makePathAbsolute(args[1])), makePathAbsolute(args[3]), "CTR-P-XXXX", makePathAbsolute(args[4]), _possiblePatchDir);
        	}
        }
    }
}
