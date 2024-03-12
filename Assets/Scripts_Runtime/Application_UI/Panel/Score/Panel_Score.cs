using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Score : MonoBehaviour {

        [SerializeField] Text player0ScoreText;
        [SerializeField] Text player1ScoreText;
        [SerializeField] Text player0NameText;
        [SerializeField] Text player1NameText;
        [SerializeField] Text gameTimeText;

        public void Ctor() {
            player0ScoreText.text = "0";
            player1ScoreText.text = "0";
            gameTimeText.text = "0.0";

            player0NameText.color = Color.white;
            player0ScoreText.color = Color.white;
            player1NameText.color = Color.white;
            player1ScoreText.color = Color.white;
        }

        public void SetPlayer0Name(string name) {
            player0NameText.text = "PLAYER1 " + name;
        }

        public void SetPlayer1Name(string name) {
            player1NameText.text = "PLAYER2 " + name;
        }

        public void SetOwnerIndex(int ownerIndex) {
            if (ownerIndex == 0) {
                player0NameText.color = Color.yellow;
                player0ScoreText.color = Color.yellow;
            }
            if (ownerIndex == 1) {
                player1ScoreText.color = Color.yellow;
                player1NameText.color = Color.yellow;
            }
        }

        public void SetPlayer0Score(int score) {
            player0ScoreText.text = score.ToString();
        }

        public void SetPlayer1Score(int score) {
            player1ScoreText.text = score.ToString();
        }

        public void SetGameTime(float time) {
            gameTimeText.text = time.ToString("0.0");
        }

        void OnDestroy() {
        }

    }

}