using System;
using MortiseFrame.LitIO;

namespace Ping.Protocol {

    public struct RoomStartGameReqMessage : IMessage<JoinRoomResMessage> {
        public string userToken;
        public void WriteTo(byte[] dst, ref int offset) {
            ByteWritter.WriteString(dst, userToken, ref offset);
        }

        public void FromBytes(byte[] src, ref int offset) {
            userToken = ByteReader.ReadString(src, ref offset);
        }

        public int GetEvaluatedSize(out bool isCertain) {
            int count = 2;
            isCertain = false;
            if (userToken != null) {
                count += userToken.Length * 4;
            }

            return count;
        }

        public byte GetID() {
            return 4;
        }

        public byte[] ToBytes() {
            int count = GetEvaluatedSize(out bool isCertain);
            int offset = 0;
            byte[] src = new byte[count];
            WriteTo(src, ref offset);
            if (isCertain) {
                return src;
            } else {
                byte[] dst = new byte[offset];
                Buffer.BlockCopy(src, 0, dst, 0, offset);
                return dst;
            }
        }

    }

}