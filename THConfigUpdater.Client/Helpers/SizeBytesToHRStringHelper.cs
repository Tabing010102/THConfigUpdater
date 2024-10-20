using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THConfigUpdater.Client.Helpers
{
    public static class SizeBytesToHRStringHelper
    {
        public static string SizeBytesToHRString(long sizeBytes)
        {
            // https://stackoverflow.com/a/4975942
            string[] suf = { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" }; //Longs run out around EB
            if (sizeBytes == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(sizeBytes);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 2);
            return (Math.Sign(sizeBytes) * num).ToString() + " " + suf[place];
        }
    }
}
