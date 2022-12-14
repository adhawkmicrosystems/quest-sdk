using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AdhawkApi
{
    public struct TrackerStatusStruct : PacketDataStruct
    {
        //status,
        public TrackerStatusStruct(byte[] data)
        {
            int i = 0;
            data.ReadNextInt8(ref i, out TrackerStatus);
        }
        public byte TrackerStatus;
    }
    public class TrackerStatusStream : AHTrackingStream<TrackerStatusStruct>
    {
        public TrackerStatusStream(UDPBehaviour udpClient) : base(udpClient) { }
        public override byte StreamPacketByte { get { return 0x16; } }

        public override udpInfo.StreamControl StreamControlBit { get { return 0; } }

        public override void Start(StreamRate rate = StreamRate.Default)
        {
            Debug.Log("Starting stream: " + StreamPacketByte);
            udpClient?.RegisterStreamHandler(StreamPacketByte, ProcessPacketData);
        }
    }
}
