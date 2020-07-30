using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models.Enums
{
    public enum TuneOptions
    {
        //intended for high-bitrate/high-quality movie content. Lower deblocking is used here
        film,
        // intended for cartoons, etc., where deblocking is boosted to compensate for larger, flat areas. More reference frames are used.
        animation,
        // this should be used for material that is already grainy. Here, the grain won't be filtered out as much.
        grain,
        //like the name says, it optimizes for still image encoding by lowering the deblocking filter.
        stillimage,
        //for psnr and ssim  these are debugging modes to optimize for good PSNR and SSIM values only.
        //Better metrics don't necessarily mean better quality though.
        psnr,
        ssim,
        //optimization for fast encoding and low latency streaming
        zerolatency,
        // disables CABAC and the in-loop deblocking filter to allow for faster decoding on devices with lower computational power
        fastdecode,
    }
}
