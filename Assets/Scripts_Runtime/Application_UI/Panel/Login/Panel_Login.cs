using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button newGameBtn;
        [SerializeField] Button exitGameBtn;
        [SerializeField] Transform waitingPanel;
        [SerializeField] Button cancleJoinRoomBtn;
        [SerializeField] Button startGameBtn;
        [SerializeField] Text roomInfoText;

        public Action OnClickNewGameHandle;
        public Action OnClickExitGameHandle;
        public Action OnClickCancleJoinRoomHandle;
        public Action OnClickStartGameHandle;

        public void Ctor() {
            newGameBtn.onClick.AddListener(() => {
                OnClickNewGameHandle?.Invoke();
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });

            cancleJoinRoomBtn.onClick.AddListener(() => {
                OnClickCancleJoinRoomHandle?.Invoke();
            });

            startGameBtn.onClick.AddListener(() => {
                OnClickStartGameHandle?.Invoke();
            });
        }

        public void SetRoomInfo(string info) {
            roomInfoText.text = info;
        }

        public void ShowWaitingPanel() {
            waitingPanel.gameObject.SetActive(true);
        }

        public void HideWaitingPanel() {
            waitingPanel.gameObject.SetActive(false);
        }

        public void ShowStartGameBtn() {
            startGameBtn.gameObject.SetActive(true);
        }

        public void HideStartGameBtn() {
            startGameBtn.gameObject.SetActive(false);
        }

        void OnDestroy() {
            newGameBtn.onClick.RemoveAllListeners();
            exitGameBtn.onClick.RemoveAllListeners();
            cancleJoinRoomBtn.onClick.RemoveAllListeners();
            startGameBtn.onClick.RemoveAllListeners();
            OnClickNewGameHandle = null;
            OnClickExitGameHandle = null;
            OnClickCancleJoinRoomHandle = null;
            OnClickStartGameHandle = null;
        }

    }

}