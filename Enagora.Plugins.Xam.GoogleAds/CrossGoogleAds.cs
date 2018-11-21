
using Enagora.Plugins.Xam.GoogleAds.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enagora.Plugins.Xam.GoogleAds
{
    public class CrossGoogleAds
    {
        static Lazy<IGoogleAds> TTS = new Lazy<IGoogleAds>(() => CreateGoogleAds(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IGoogleAds Current
        {
            get
            {
                var ret = TTS.Value;
                if(ret== null)
                {
                    throw NotImplementedInAssemblyReference();
                }

                return ret;
            }
        }

        static IGoogleAds CreateGoogleAds()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new GoogleAds();
#endif
        }
        
        internal static Exception NotImplementedInAssemblyReference()
        {
            return new NotImplementedException("This functionality  is not implemented in the portable version of this assembly.  You should reference the Xam.Plugins.Vibrate NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
