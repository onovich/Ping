using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Login : MonoBehaviour {

        [SerializeField] Button newGameBtn;
        [SerializeField] Button exitGameBtn;
        [SerializeField] Transform waitingPanel;
        [SerializeField] Button cancleJoinRoomBtn;
        [SerializeField] Button gameStartBtn;
        [SerializeField] Text roomInfoText;
        [SerializeField] Text userNameText;

        public Action<string> OnClickNewGameHandle;
        public Action OnClickExitGameHandle;
        public Action OnClickCancleJoinRoomHandle;
        public Action OnClickGameStartHandle;

        public void Ctor() {
            newGameBtn.onClick.AddListener(() => {
                OnClickNewGameHandle?.Invoke(userNameText.text);
            });

            exitGameBtn.onClick.AddListener(() => {
                OnClickExitGameHandle?.Invoke();
            });

            cancleJoinRoomBtn.onClick.AddListener(() => {
                OnClickCancleJoinRoomHandle?.Invoke();
            });

            gameStartBtn.onClick.AddListener(() => {
                OnClickGameStartHandle?.Invoke();
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
            gameStartBtn.gameObject.SetActive(true);
        }

        public void HideStartGameBtn() {
            gameStartBtn.gameObject.SetActive(false);
        }

        void OnDestroy() {
            newGameBtn.onClick.RemoveAllListeners();
            exitGameBtn.onClick.RemoveAllListeners();
            cancleJoinRoomBtn.onClick.RemoveAllListeners();
            gameStartBtn.onClick.RemoveAllListeners();
            OnClickNewGameHandle = null;
            OnClickExitGameHandle = null;
            OnClickCancleJoinRoomHandle = null;
            OnClickGameStartHandle = null;
        }

    }

}