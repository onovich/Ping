using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button startGameBtn;
        [SerializeField] Button exitGameBtn;
        [SerializeField] Transform waitingPanel;
        [SerializeField] Button cancleJoinRoomBtn;
        [SerializeField] Text roomInfoText;

        public Action OnClickStartGameHandle;
        public Action OnClickExitGameHandle;
        public Action OnClickCancleJoinRoomHandle;

        public void Ctor() {
            startGameBtn.onClick.AddListener(() => {
                OnClickStartGameHandle?.Invoke();
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });

            cancleJoinRoomBtn.onClick.AddListener(() => {
                OnClickCancleJoinRoomHandle?.Invoke();
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
            cancleJoinRoomBtn.onClick.RemoveAllListeners();
            OnClickStartGameHandle = null;
            OnClickExitGameHandle = null;
            OnClickCancleJoinRoomHandle = null;
        }

    }

}