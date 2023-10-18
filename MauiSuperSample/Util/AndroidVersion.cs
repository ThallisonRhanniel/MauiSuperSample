using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSuperSample.Util
{
    internal class AndroidVersion
    {
        public int GetAndroidVersion => DeviceInfo.Version.Major;
    }
}
