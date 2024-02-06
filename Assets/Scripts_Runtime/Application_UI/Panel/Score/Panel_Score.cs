using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ping.UI {

    public class Panel_Score : MonoBehaviour {

        [SerializeField] Text player1ScoreText;
        [SerializeField] Text player2ScoreText;
        [SerializeField] Text gameTimeText;

        public void Ctor() {
            player1ScoreText.text = "0";
            player2ScoreText.text = "0";
            gameTimeText.text = "0.0";
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