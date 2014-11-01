using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string fileName, byte[] data)
		{
		    OpenAndWriteData(fileName, data);
            OpenAndWriteData(Path.ChangeExtension(fileName, "bkp"), data);
			var timeFile = fileName + ".time";
			var timeStamp = BitConverter.GetBytes(DateTime.Now.Ticks);
		    OpenAndWriteData(timeFile, timeStamp);
		}

	    private static void OpenAndWriteData(string fileName, byte[] data)
	    {
	        var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
	        fileStream.Write(data, 0, data.Length);
	        fileStream.Close();
	    }
	}
}