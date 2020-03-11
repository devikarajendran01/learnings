using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace DependancyServiceDemo
{
    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}
