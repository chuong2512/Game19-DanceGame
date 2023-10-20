using System;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace BabySound
{
    public class HomeScreen : AppScreen
    {
        [SerializeField] private TextMeshProUGUI _coinTMP;

        public override ScreenType GetID()
        {
            return ScreenType.HomeScreen;
        }

        protected override void Start()
        {
            base.Start();
            SetCoinText();
            GameManager.OnChangeCoin += OnChangeCoin;
        }

        private void OnChangeCoin(int i)
        {
            SetCoinText();
        }

        private void SetCoinText()
        {
            _coinTMP.SetText(GameDataManager.Instance.playerData.coin.ToString());
        }

        private void OnDestroy()
        {
            GameManager.OnChangeCoin -= OnChangeCoin;
        }

        public void PlayAnim(int i)
        {
            if (GameDataManager.Instance.playerData.coin >= 1)
            {
                Dancer.Instance.PlayAnim(i);
                GameDataManager.Instance.playerData.MinusCoin();
            }
            else
            {
                UIManager.Instance.OpenScreen<IDModel>(ScreenType.UnlockPopup, new IDModel()
                {
                });
            }
        }
    }
}