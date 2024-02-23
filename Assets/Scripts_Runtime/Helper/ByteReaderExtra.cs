using System;
using MortiseFrame.LitIO;
using Ping.Protocol;

namespace Ping {

    public static class BufferReaderExtra {

        public static T ReadMessage<T>(byte[] src, Func<T> createHandle, ref int offset) where T : IMessage<T> {
            T msg = createHandle.Invoke();
            ushort count = ByteReader.Read<ushort>(src, ref offset);
            if (count > 0) {
                msg.FromBytes(src, ref offset);
            }
            return msg;
        }

        public static T[] ReadMessageArr<T>(byte[] src, Func<T> createHandle, ref int offset) where T : IMessage<T> {
            ushort totalCount = ByteReader.Read<ushort>(src, ref offset);
            T[] arr = new T[totalCount];
            for (int i = 0; i < arr.Length; i += 1) {
                arr[i] = (T)createHandle.Invoke();
                ushort count = ByteReader.Read<ushort>(src, ref offset);
                if (count > 0) {
                    arr[i].FromBytes(src, ref offset);
                }
            }
            return arr as T[];
        }

    }
}