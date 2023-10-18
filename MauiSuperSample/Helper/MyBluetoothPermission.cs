using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSuperSample.Helper
{
    internal class MyBluetoothPermission : Permissions.BasePlatformPermission
    {
#if ANDROID

    //("android.permission.BLUETOOTH_SCAN", true),
    //("android.permission.BLUETOOTH_CONNECT", true),
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string permission, bool isRuntime)>
        {
            (Android.Manifest.Permission.BluetoothScan, true),
            (Android.Manifest.Permission.BluetoothConnect, true),
        }.ToArray();
#endif

    }
}
