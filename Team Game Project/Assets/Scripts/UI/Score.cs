using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
    {
        private string playerName;
        private int playerScore;
        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayerScore { get => playerScore; set => playerScore = value; }
    }
