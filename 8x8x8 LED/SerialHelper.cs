using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED
{
    static class SerialHelper
    {
        const byte HEADER = 0xF2;
        public static void SendPacket(SerialPort serialPort, byte[] payload, bool prependHeader = true)
        {
            if (serialPort.IsOpen)
            {

                if (!prependHeader)
                {
                    serialPort.Write(payload, 0, payload.Length);
                    return;
                }

                // Import payload with room for header:
                var dataPacket = new byte[payload.Length + 1];

                // Copy header:
                dataPacket[0] = HEADER;

                // Copy payload:
                for (int i = 1; i < dataPacket.Length; i++)
                {
                    dataPacket[i] = payload[i - 1];
                }

                // Send bytes:
                serialPort.Write(dataPacket, 0, dataPacket.Length);
            }
        }
    }
}
