using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BackJackSystem.UI
{
    public class MatheRaisUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text raiseAmountText;

        [SerializeField] private GameObject mathUI;
        [SerializeField] private Player callAction;

        private byte raiseAmount;

        private void Awake()
        {
            ChipHandler.OnRaise += ChipHandler_OnRaise;
            mathUI.SetActive(false);
        }

        private void ChipHandler_OnRaise(Players player, byte chips)
        {
            if (player != callAction)
            {
                raiseAmountText.text = $"{chips}";
                mathUI.SetActive(true);
            }
        }

        public void MatheRais(bool math)
        {
            if (math)
                ChipHandler.AddChips(raiseAmount);

            callAction.ActionChosen(math);
            mathUI.SetActive(false);
        }
    }
}


