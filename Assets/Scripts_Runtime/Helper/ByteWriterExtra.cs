using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping {

    public static class BufferWriterExtra {

        public static void WriteMessage<T>(byte[] dst, T data, ref int offset) where T : IMessage<T> {
            if (data != null) {
                byte[] b = data.ToBytes();
                ushort count = (ushort)b.Length;
                ByteWritter.Write<ushort>(dst, count, ref offset);
                Buffer.BlockCopy(b, 0, dst, offset, count);
                offset += count;
            } else {
                ByteWritter.Write<ushort>(dst, 0, ref offset);
            }
        }

        public static void WriteMessageArr<T>(byte[] dst, T[] data, ref int offset) where T : IMessage<T> {
            if (data != null) {
                ushort count = (ushort)data.Length;
                ByteWritter.Write<ushort>(dst, count, ref offset);
                for (int i = 0; i < data.Length; i += 1) {
                    WriteMessage(dst, data[i], ref offset);
                }
            } else {
                ByteWritter.Write<ushort>(dst, 0, ref offset);
            }
        }

    }
}