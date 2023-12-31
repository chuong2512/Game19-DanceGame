﻿using TMPro;
using UnityEngine;

namespace ABCBoard.Scripts.UI
{
    public class CoinText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tmp;

        private void OnValidate()
        {
            _tmp = GetComponentInChildren<TextMeshProUGUI>();
        }

        void Start()
        {
            GameManager.OnChangeCoin += OnChangeCoin;
            ShowCurrentCoin();
        }

        private void OnChangeCoin(int obj)
        {
            ShowCurrentCoin();
        }

        private void ShowCurrentCoin()
        {
            _tmp.SetText($"{GameDataManager.Instance.playerData.coin} <sprite=0>");
        }
    }
}