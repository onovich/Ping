using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button startGameBtn;
        [SerializeField] Button exitGameBtn;
        [SerializeField] Text userNameText;
        [SerializeField] Transform waitingPanel;
        [SerializeField] Button cancleWaitingBtn;
        [SerializeField] Button roomStartGameBtn;
        [SerializeField] Text roomInfoText;

        public Action<string> OnClickStartGameHandle;
        public Action OnClickExitGameHandle;
        public Action OnClickCancleWaitingHandle;
        public Action OnClickRoomStartGameHandle;

        public void Ctor() {
            startGameBtn.onClick.AddListener(() => {
                OnClickStartGameHandle?.Invoke(userNameText.text);
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });

            cancleWaitingBtn.onClick.AddListener(() => {
                OnClickCancleWaitingHandle?.Invoke();
            });

            roomStartGameBtn.onClick.AddListener(() => {
                OnClickRoomStartGameHandle?.Invoke();
            });
        }

        public void ShowWaitingPanel(bool isShow) {
            waitingPanel.gameObject.SetActive(isShow);
        }

        public void SetRoomInfo(string info) {
            roomInfoText.text = info;
        }

        void OnDestroy() {
            startGameBtn.onClick.RemoveAllListeners();
            exitGameBtn.onClick.RemoveAllListeners();
            cancleWaitingBtn.onClick.RemoveAllListeners();
            roomStartGameBtn.onClick.RemoveAllListeners();
            OnClickStartGameHandle = null;
            OnClickExitGameHandle = null;
            OnClickCancleWaitingHandle = null;
            OnClickRoomStartGameHandle = null;
        }

    }

}