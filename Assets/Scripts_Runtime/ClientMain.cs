using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ping.Business.Game;
using Ping.Business.Login;
using Ping.Requests;
using UnityEngine;

namespace Ping {

    public class ClientMain : MonoBehaviour {

        InputEntity inputEntity;
        MainContext mainContext;

        AssetsInfraContext assetsInfraContext;
        TemplateInfraContext templateInfraContext;

        LoginBusinessContext loginBusinessContext;
        GameBusinessContext gameBusinessContext;
        RequestInfraContext requestInfraContext;

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
            requestInfraContext = new RequestInfraContext();

            // Inject
            uiAppContext.canvas = mainCanvas;
            uiAppContext.hudFakeCanvas = hudFakeCanvas;
            uiAppContext.templateInfraContext = templateInfraContext;

            loginBusinessContext.uiAppContext = uiAppContext;
            loginBusinessContext.reqContext = requestInfraContext;
            loginBusinessContext.mainContext = mainContext;

            gameBusinessContext.inputEntity = inputEntity;
            gameBusinessContext.assetsInfraContext = assetsInfraContext;
            gameBusinessContext.templateInfraContext = templateInfraContext;
            gameBusinessContext.uiAppContext = uiAppContext;
            gameBusinessContext.mainCamera = mainCamera;
            gameBusinessContext.mainContext = mainContext;
            gameBusinessContext.reqContext = requestInfraContext;

            Binding_Request_Login();
            Binding_Login();
            Binding_UI_Login();

            Binding_Request_Game();
            Binding_Game();
            Binding_UI_Game();

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

            RequestInfra.Tick_Net(requestInfraContext, dt);
            LoginBusiness.Tick(loginBusinessContext, dt);
            GameBusiness.Tick(gameBusinessContext, dt);
        }

        void Init() {

            Application.targetFrameRate = 120;

            var inputEntity = this.inputEntity;
            inputEntity.Ctor();
            inputEntity.Keybinding_Set(InputKeyEnum.MoveLeft, new KeyCode[] { KeyCode.A });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveRight, new KeyCode[] { KeyCode.D });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveUp, new KeyCode[] { KeyCode.W });
            inputEntity.Keybinding_Set(InputKeyEnum.MoveDown, new KeyCode[] { KeyCode.S });
            inputEntity.Keybinding_Set(InputKeyEnum.Cancel, new KeyCode[] { KeyCode.Escape, KeyCode.Mouse1 });
            inputEntity.Keybinding_Set(InputKeyEnum.UI_Setting, new KeyCode[] { KeyCode.Escape });

            GameBusiness.Init(gameBusinessContext);

            UIApp.Init(uiAppContext);

        }

        void Binding_Request_Login() {
            var evt = requestInfraContext.EventCenter;

            evt.OnConnect_ResHandle += (msg) => {
                LoginBusiness.OnNetResConnect(loginBusinessContext, msg);
            };

            evt.OnConnect_ResErrorHandle += (msg) => {
                LoginBusiness.OnNetResConnectError(loginBusinessContext, msg);
            };

            evt.OnLogin_JoinRoomBroadHandle += (msg) => {
                LoginBusiness.OnNetResJoinRoom(loginBusinessContext, msg);
            };

            evt.OnLogin_GameStartBroadHandle += (msg) => {
                LoginBusiness.OnNetResGameStart(loginBusinessContext, msg);
            };
        }

        void Binding_UI_Login() {
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

        void Binding_Login() {
            var evt = loginBusinessContext.evt;

            evt.OnLoginDoneHandle += (userName) => {
                LoginBusiness.Exit(loginBusinessContext);
                GameBusiness.StartGame(gameBusinessContext);
            };
        }

        void Binding_Request_Game() {
            var evt = requestInfraContext.EventCenter;

            evt.OnGame_EntitiesSyncBroadHandle += (msg) => {
                GameBusiness.OnNetResEntitiesSync(gameBusinessContext, msg);
            };

        }

        void Binding_UI_Game() {

        }

        void Binding_Game() {

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
        }

    }

}