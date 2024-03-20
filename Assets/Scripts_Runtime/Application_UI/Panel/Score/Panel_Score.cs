using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Score : MonoBehaviour {

        [SerializeField] Text player1ScoreText;
        [SerializeField] Text player2ScoreText;
        [SerializeField] Text player1NameText;
        [SerializeField] Text player2NameText;
        [SerializeField] Text gameTimeText;

        public void Ctor() {
            player1ScoreText.text = "0";
            player2ScoreText.text = "0";
            gameTimeText.text = "0.0";

            player1NameText.color = Color.white;
            player1ScoreText.color = Color.white;
            player2NameText.color = Color.white;
            player2ScoreText.color = Color.white;
        }

        public void SetPlayer1Name(string name) {
            player1NameText.text = "PLAYER1 " + name;
        }

        public void SetPlayer2Name(string name) {
            player2NameText.text = "PLAYER2 " + name;
        }

        public void SetOwnerIndex(int ownerIndex) {
            if (ownerIndex == 1) {
                player1NameText.color = Color.yellow;
                player1ScoreText.color = Color.yellow;
            }
            if (ownerIndex == 2) {
                player2ScoreText.color = Color.yellow;
                player2NameText.color = Color.yellow;
            }
        }

        public void SetPlayer1Score(int score) {
            player1ScoreText.text = score.ToString();
        }

        public void SetPlayer2Score(int score) {
            player2ScoreText.text = score.ToString();
        }

        public void SetGameTime(float time) {
            gameTimeText.text = time.ToString("0.0");
        }

        void OnDestroy() {
        }

    }

}