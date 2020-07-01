using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public enum State
    { 
        PROCESSING,
        ONLINE,
        OFFLINE
    }

    public class Server : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        [Display(Name = "Root Password")]
        public string RootPassword { get; set; }

        [Required]
        [Display(Name = "Max Clients")]
        public int MaxClients { get; set; } = 1;

        [Display(Name = "HTTP Port")]
        public int HttpPort { get; set; } = 80;

        [Display(Name = "HTTPS Port")]
        public int HttpsPort { get; set; } = 443;

        [Display(Name = "SSH Port")]
        public int SshPort { get; set; } = 22;

        [Display(Name = "RTMP Port")]
        public int RtmpPort { get; set; } = 1935;

        [Display(Name = "Is RTMP?")]
        public bool IsRTMP { get; set; } = false;

        public State State { get; set; } = State.PROCESSING;

    }
}
