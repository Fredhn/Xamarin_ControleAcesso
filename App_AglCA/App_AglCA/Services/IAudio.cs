using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App_AglCA.Services
{
    public interface IAudio
    {
        void DTMFPlayTone(string t, float reproduceSpeed);
    }
}
