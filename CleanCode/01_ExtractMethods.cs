using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string s, byte[] d)
		{
		    OpenAndWrite(s, d);
            OpenAndWrite(Path.ChangeExtension(s, "bkp"), d);
			var tf = s + ".time";
			var t = BitConverter.GetBytes(DateTime.Now.Ticks);
		    OpenAndWrite(tf, t);
		}

	    private static void OpenAndWrite(string s, byte[] d)
	    {
	        var fs = new FileStream(s, FileMode.OpenOrCreate);
	        fs.Write(d, 0, d.Length);
	        fs.Close();
	    }
	}
}