﻿using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace TennisMatch
{
    /// <summary>
    /// ARD
    /// </summary>
    public class UndoRedo_Visual : MonoBehaviour
    {
        [Header("GameEvent")]
        private MatchEvents matchEvents;

        [Header("Component")]
        [SerializeField] private ExchangeManager action;
        [Space(10)]
        [SerializeField] private Button UndoButton;
        [SerializeField] private TextMeshProUGUI UndoText;
        [SerializeField] private Image UndoImg;
        [Space(5)]
        [SerializeField] private Button RedoButton;
        [SerializeField] private TextMeshProUGUI RedoText;
        [SerializeField] private Image RedoImg;
        
        [Header("Variable")]
        [SerializeField] private float colorFadeDuration = 0.5f;
        [SerializeField] private Ease fadeMode = Ease.InOutCubic;

        private void Awake() => matchEvents = MatchEvents.Instance;

        private void OnEnable()
        {
            matchEvents.onMatchStart += UpdateVisual;
            matchEvents.onVisualUpdate += UpdateVisual;
        }
        private void OnDisable()
        {
            matchEvents.onMatchStart += UpdateVisual;
            matchEvents.onVisualUpdate += UpdateVisual;
        }

        void UpdateVisual()
        {
            Invoke("ButtonColor", 0.1f);
        }

        private void ButtonColor()
        {
            if (action.canUndo)
            {
                UndoButton.interactable = true;
                UndoText.DOColor(Color.white, colorFadeDuration).SetEase(fadeMode);
                UndoImg.DOColor(Color.white, colorFadeDuration).SetEase(fadeMode);
            }
            else
            {
                UndoButton.interactable = false;
                UndoText.DOColor(Color.black, colorFadeDuration).SetEase(fadeMode);
                UndoImg.DOColor(Color.black, colorFadeDuration).SetEase(fadeMode);
            }

            if (action.canRedo)
            {
                RedoButton.interactable = true;
                RedoText.DOColor(Color.white, colorFadeDuration).SetEase(fadeMode);
                RedoImg.DOColor(Color.white, colorFadeDuration).SetEase(fadeMode);
            }
            else
            {
                RedoButton.interactable = false;
                RedoText.DOColor(Color.black, colorFadeDuration).SetEase(fadeMode);
                RedoImg.DOColor(Color.black, colorFadeDuration).SetEase(fadeMode);

            }
        }
    }
}
