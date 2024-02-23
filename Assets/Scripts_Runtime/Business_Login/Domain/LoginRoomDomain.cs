using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Ping.Requests;

namespace Ping.Business.Login {

    public static class LoginRoomDomain {

        public static void Net_StartConnect(LoginBusinessContext ctx) {

            Action connAction = null;
            if (connAction != null) {
                return;
            }

            const int DEFAULT_PORT = 5211;
            // const string LOCAL_IP = "localhost";
            const string REMOTE_IP = "localhost";

            InitToken(ctx);

            connAction = async () => {

                // - Room
                await Net_GetAndRecordPublicIP(ctx);

                // 连远程
                var client = ctx.reqContext.TCPClient;
                client.Connect(REMOTE_IP, DEFAULT_PORT);

                connAction = null;

            };
            connAction.Invoke();

        }

        public static void InitToken(LoginBusinessContext ctx) {

            const string TOKEN_PATH = "tk.txt";

            string dir = FileHelper.GetPersistentDir();

            // Create If Not Exists
            FileHelper.CreateDirIfNotExist(dir);
            string contactPath = Path.Combine(dir, TOKEN_PATH);
            if (!File.Exists(contactPath)) {
                using (File.CreateText(contactPath)) { }
            }

            // Get Or Gen Token
            byte[] data = FileHelper.ReadFileFromPersistent(TOKEN_PATH);
            string token = Encoding.UTF8.GetString(data);
            if (string.IsNullOrEmpty(token)) {
                token = Guid.NewGuid().ToString();
                data = Encoding.UTF8.GetBytes(token);
                FileHelper.WriteFileToPersistent(TOKEN_PATH, data);
            }

            // Add Different Suffix
            // For Different Processes Run In Same Device
            string[] cmd = Environment.CommandLine.Split(' ');
            token += cmd[2];

            PLog.Log("Token: " + token);
            var playerEntity = ctx.playerEntity;
            playerEntity.token = token;

        }

        public static async Task Net_GetAndRecordPublicIP(LoginBusinessContext ctx) {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.GetAsync("http://ip.utea.fun/");
            var ip = await res.Content.ReadAsStringAsync();
            var playerEntity = ctx.playerEntity;
            playerEntity.publicIP = ip;
            playerEntity.ethernetIP = IPHelper.GetLocalIpAddress();
        }

        // - Net Send: Join
        public static void Net_SendJoinRoom(LoginBusinessContext ctx) {
            var player = ctx.playerEntity;
            var client = ctx.reqContext.TCPClient;
            RequestInfra.JoinRoom_SendReq(ctx.reqContext, player.token);
        }

        // - Net Send: Start Game
        static void Net_SendRoomStart(LoginBusinessContext ctx) {
            var player = ctx.playerEntity;
            var client = ctx.reqContext.TCPClient;
            RequestInfra.RoomStartGame_SendReq(ctx.reqContext, player.token);
        }

    }

}