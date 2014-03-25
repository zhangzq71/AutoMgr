using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMgrWP.Helpers
{
    public class CustomProcessor : OpticalReaderLib.BasicProcessor
    {
        public CustomProcessor()
            : base(new OpticalReaderLib.ZxingDecoder())
        {
            Normalizer = new OpticalReaderLib.BasicNormalizer();
            Enhancer = new CustomEnhancer();
        }
    }
}
