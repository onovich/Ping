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

            loginBusinessContext = new LoginBusinessContext();
            gameBusinessContext = new GameBusinessContext();

            uiAppContext = new UIAppContext();

            assetsInfraContext = new AssetsInfraContext();
            templateInfraContext = new TemplateInfraContext();
            requestInfraContext = new RequestInfraContext();

            // Player
            var playerEntity = new PlayerEntity();
            loginBusinessContext.Player_Set(playerEntity);
            gameBusinessContext.Player_Set(playerEntity);

            // Inject
            uiAppContext.canvas = mainCanvas;
            uiAppContext.hudFakeCanvas = hudFakeCanvas;
            uiAppContext.templateInfraContext = templateInfraContext;

            loginBusinessContext.uiAppContext = uiAppContext;
            loginBusinessContext.reqContext = requestInfraContext;

            gameBusinessContext.inputEntity = inputEntity;
            gameBusinessContext.assetsInfraContext = assetsInfraContext;
            gameBusinessContext.templateInfraContext = templateInfraContext;
            gameBusinessContext.uiAppContext = uiAppContext;
            gameBusinessContext.mainCamera = mainCamera;

            BindingRemoteEvent();
            BindingLocalEvent();

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

        void BindingRemoteEvent() {
            var requestEvt = requestInfraContext.EventCenter;
            // Login
            requestEvt.ConnectRes_OnHandle += (msg) => {
                LoginBusiness.OnNetResConnect(loginBusinessContext, msg);
            };

            requestEvt.ConnectRes_OnErrorHandle += (msg) => {
                LoginBusiness.OnNetResConnectError(loginBusinessContext, msg);
            };

            requestEvt.JoinRoom_OnHandle += (msg) => {
                LoginBusiness.OnNetResJoinRoom(loginBusinessContext, msg);
            };
        }

        void BindingLocalEvent() {
            var uiEventCenter = uiAppContext.eventCenter;
            // UI
            // - Login
            uiEventCenter.Login_OnStartGameClickHandle += () => {
                LoginBusiness.OnUILoginClick(loginBusinessContext);
            };

            uiEventCenter.Login_OnExitGameClickHandle += () => {
                LoginBusiness.ExitLogin(loginBusinessContext);
            };

            uiEventCenter.Login_OnCancleJoinRoomClickHandle += () => {
                LoginBusiness.OnUICancleWaitingClick(loginBusinessContext);
            };

            // Login
            var loginEvt = loginBusinessContext.evt;
            loginEvt.OnLoginHandle += (userName) => {
                // 监听网络请求
                LoginBusiness.Exit(loginBusinessContext);
                GameBusiness.StartGame(gameBusinessContext);
            };
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