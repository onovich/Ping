using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ping.Business.Game;
using Ping.Business.Login;
using UnityEngine;
using MortiseFrame.Rill;
using Ping.Protocol;
using Ping.Requests;

namespace Ping {

    public class ClientMain : MonoBehaviour {

        [SerializeField] bool isTest;

        InputEntity inputEntity;
        MainContext mainContext;

        AssetsInfraContext assetsInfraContext;
        TemplateInfraContext templateInfraContext;
        RequestInfraContext reqInfraContext;

        LoginBusinessContext loginBusinessContext;
        GameBusinessContext gameBusinessContext;


        UIAppContext uiAppContext;

        bool isLoadedAssets;
        bool isTearDown;

        void Start() {

            isLoadedAssets = false;
            isTearDown = false;

            Canvas mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
            Transform hudFakeCanvas = GameObject.Find("HUDFakeCanvas").transform;
            Camera mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

            inputEntity = new InputEntity();
            mainContext = new MainContext();

            loginBusinessContext = new LoginBusinessContext();
            gameBusinessContext = new GameBusinessContext();

            uiAppContext = new UIAppContext();

            assetsInfraContext = new AssetsInfraContext();
            templateInfraContext = new TemplateInfraContext();
            reqInfraContext = new RequestInfraContext();
            reqInfraContext.isTest = isTest;

            var player1 = new PlayerEntity(1);
            var player2 = new PlayerEntity(2);
            mainContext.Player_Add(player1);
            mainContext.Player_Add(player2);

            // Inject
            uiAppContext.canvas = mainCanvas;
            uiAppContext.hudFakeCanvas = hudFakeCanvas;
            uiAppContext.templateInfraContext = templateInfraContext;

            loginBusinessContext.uiAppContext = uiAppContext;
            loginBusinessContext.mainContext = mainContext;
            loginBusinessContext.reqInfraContext = reqInfraContext;

            gameBusinessContext.inputEntity = inputEntity;
            gameBusinessContext.assetsInfraContext = assetsInfraContext;
            gameBusinessContext.templateInfraContext = templateInfraContext;
            gameBusinessContext.uiAppContext = uiAppContext;
            gameBusinessContext.mainCamera = mainCamera;
            gameBusinessContext.mainContext = mainContext;
            gameBusinessContext.reqInfraContext = reqInfraContext;

            reqInfraContext.templateInfraContext = templateInfraContext;

            RegisterProtocols();
            BindingEvents();

            Action action = async () => {
                try {
                    await LoadAssets();
                    Init();
                    Enter();
                    isLoadedAssets = true;
                } catch (Exception e) {
                    PLog.LogError(e.ToString());
                }
            };
            action.Invoke();

        }

        void Enter() {
            LoginBusiness.Enter(loginBusinessContext);
        }

        void Update() {
            if (!isLoadedAssets || isTearDown) {
                return;
            }
            var dt = Time.deltaTime;
            TickNet(dt);
            LoginBusiness.Tick(loginBusinessContext, dt);
            GameBusiness.Tick(gameBusinessContext, dt);
        }

        public void TickNet(float dt) {
            if (!isLoadedAssets || isTearDown) {
                return;
            }
            RequestInfra.Tick(reqInfraContext, dt);
        }

        void Init() {

            Application.targetFrameRate = 120;

            var inputEntity = this.inputEntity;
            inputEntity.Ctor();
            inputEntity.Keybinding_Set(InputKeyEnum.MoveLeft, new KeyCode[] { KeyCode.A, KeyCode.LeftArrow });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveRight, new KeyCode[] { KeyCode.D, KeyCode.RightArrow });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveUp, new KeyCode[] { KeyCode.W, KeyCode.UpArrow });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveDown, new KeyCode[] { KeyCode.S, KeyCode.DownArrow });
            inputEntity.Keybinding_Set(InputKeyEnum.Cancel, new KeyCode[] { KeyCode.Escape, KeyCode.Mouse1 });
            inputEntity.Keybinding_Set(InputKeyEnum.UI_Setting, new KeyCode[] { KeyCode.Escape });

            GameBusiness.Init(gameBusinessContext);

            UIApp.Init(uiAppContext);

        }

        void RegisterProtocols() {
            RequestInfra.RegisterAllProtocol(reqInfraContext);
        }

        void BindingEvents() {

            // Request_Login
            {
                RequestInfra.On<ConnectResMessage>(reqInfraContext, (msg) => LoginBusiness.OnNetResConnect(loginBusinessContext, (ConnectResMessage)msg));
                RequestInfra.On<JoinRoomBroadMessage>(reqInfraContext, (msg) => LoginBusiness.OnNetResJoinRoom(loginBusinessContext, (JoinRoomBroadMessage)msg));
                RequestInfra.On<GameStartBroadMessage>(reqInfraContext, (msg) => LoginBusiness.OnNetResGameStart(loginBusinessContext, (GameStartBroadMessage)msg));
                RequestInfra.OnError(reqInfraContext, (msg) => LoginBusiness.OnNetResConnectError(loginBusinessContext, msg));
            }

            // Request_Game
            {
                RequestInfra.On<EntitiesSyncBroadMessage>(reqInfraContext, (msg) => GameBusiness.OnNetResEntitiesSync(gameBusinessContext, (EntitiesSyncBroadMessage)msg));
                RequestInfra.On<GameResultBroadMessage>(reqInfraContext, (msg) => GameBusiness.OnNetResGameResult(gameBusinessContext, (GameResultBroadMessage)msg));
                RequestInfra.On<KeepAliveResMessage>(reqInfraContext, (msg) => GameBusiness.OnNetResKeepAlive(gameBusinessContext, (KeepAliveResMessage)msg));
            }

            // UI_Login
            {
                var evt = uiAppContext.eventCenter;
                evt.Login_OnNewGameClickHandle += (userName) => {
                    LoginBusiness.OnUILoginClick(loginBusinessContext, userName);
                };
                evt.Login_OnExitGameClickHandle += () => {
                    LoginBusiness.OnUIExitGameClick(loginBusinessContext);
                };
                evt.Login_OnCancleJoinRoomClickHandle += () => {
                    LoginBusiness.OnUICancleWaitingClick(loginBusinessContext);
                };
                evt.Login_OnGameStartClickHandle += () => {
                    LoginBusiness.OnUIGameStartClick(loginBusinessContext);
                };
            }

            // Login
            {
                var evt = loginBusinessContext.evt;

                evt.OnLoginDoneHandle += (userName) => {
                    LoginBusiness.Exit(loginBusinessContext);
                    GameBusiness.StartGame(gameBusinessContext);
                };
            }

        }

        async Task LoadAssets() {
            await UIApp.LoadAssets(uiAppContext);
            await AssetsInfra.LoadAssets(assetsInfraContext);
            await TemplateInfra.LoadAssets(templateInfraContext);
        }

        void OnApplicationQuit() {
            TearDown();
            Application.Quit();
        }

        void OnDestroy() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;

            loginBusinessContext.evt.Clear();
            uiAppContext.eventCenter.Clear();

            GameBusiness.TearDown(gameBusinessContext);
            LoginBusiness.TearDown(loginBusinessContext);
            AssetsInfra.ReleaseAssets(assetsInfraContext);
            TemplateInfra.Release(templateInfraContext);
            // TemplateInfra.ReleaseAssets(templateInfraContext);
            // UIApp.TearDown(uiAppContext);
            RequestInfra.Stop(reqInfraContext);
        }

    }

}