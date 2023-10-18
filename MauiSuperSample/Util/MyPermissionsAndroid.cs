using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using MauiSuperSample.Helper;

namespace MauiSuperSample.Util
{

    public  class MyPermissionsAndroid
    {
        async Task RequestBluetooth()
        {
            var status = PermissionStatus.Unknown;

            if (DeviceInfo.Version.Major >= 12)
            {
                status = await Permissions.CheckStatusAsync<MyBluetoothPermission>();

                if (status == PermissionStatus.Granted)
                    return;

                if (Permissions.ShouldShowRationale<MyBluetoothPermission>())
                {
                    await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
                }

                status = await Permissions.RequestAsync<MyBluetoothPermission>();


            }
            else
            {
                status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status == PermissionStatus.Granted)
                    return;

                if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
                {
                    //await Shell.Current.DisplayAlert("Needs permissions", "BECAUSE!!!", "OK");
                }

                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();


            }
        }
    }
}
