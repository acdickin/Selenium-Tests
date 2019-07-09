using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_CSM_Web
{
    class BrowserOptions
    {
        public enum browserOptions { Chrome, Phantom };
        public Enum getChromeEnum()
        {
            return browserOptions.Chrome;
        }
        public Enum getPhantomEnum()
        {
            return browserOptions.Phantom;
        }
    }
}
