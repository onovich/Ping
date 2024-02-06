using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ping.Business.Game;
using Ping.Business.Login;
using UnityEngine;

namespace Ping {

    public class ClientMain : MonoBehaviour {

        InputEntity inputEntity;

        AssetsInfraContext assetsInfraContext;
        TemplateInfraContext templateInfraContext;

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

            loginBusinessContext = new LoginBusinessContext();
            gameBusinessContext = new GameBusinessContext();

            uiAppContext = new UIAppContext();

            assetsInfraContext = new AssetsInfraContext();
            templateInfraContext = new TemplateInfraContext();

            // Inject
            uiAppContext.canvas = mainCanvas;
            uiAppContext.hudFakeCanvas = hudFakeCanvas;
            uiAppContext.templateInfraContext = templateInfraContext;

            loginBusinessContext.uiAppContext = uiAppContext;

            gameBusinessContext.inputEntity = inputEntity;
            gameBusinessContext.assetsInfraContext = assetsInfraContext;
            gameBusinessContext.templateInfraContext = templateInfraContext;
            gameBusinessContext.uiAppContext = uiAppContext;
            gameBusinessContext.mainCamera = mainCamera;

            Binding();

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

        void Binding() {
            var uiEventCenter = uiAppContext.eventCenter;
            // UI
            // - Login
            uiEventCenter.Login_OnStartGameClickHandle += () => {
                LoginBusiness.Exit(loginBusinessContext);
                GameBusiness.StartGame(gameBusinessContext);
            };

            uiEventCenter.Login_OnExitGameClickHandle += () => {
                LoginBusiness.ExitApplication(loginBusinessContext);
            };
        }

        async Task LoadAssets() {
            await UIApp.LoadAssets(uiAppContext);
            await AssetsInfra.LoadAssets(assetsInfraContext);
            await TemplateInfra.LoadAssets(templateInfraContext);
        }

        void OnApplicationQuit() {
            TearDown();
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
            AssetsInfra.ReleaseAssets(assetsInfraContext);
            TemplateInfra.Release(templateInfraContext);
            // TemplateInfra.ReleaseAssets(templateInfraContext);
            // UIApp.TearDown(uiAppContext);
        }

    }

}