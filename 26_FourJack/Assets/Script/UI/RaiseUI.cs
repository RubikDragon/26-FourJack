using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BackJackSystem.UI
{   
    public class RaiseUI : MonoBehaviour
    { 
        [SerializeField] private GameObject setUIOnOrOff;
        [SerializeField] private Players player;

        [SerializeField] private TMP_Text raiseCount;
        private byte raiseAmount;

        private void OnEnable()
        {
            ChangeRaise(0);
        }

        public void SendRaise()
        {
            ChipHandler.Raise(player, raiseAmount);

        }

        public void ChangeRaise(int raiseChange)
        {
            raiseAmount += (byte)raiseChange;

            // indsures we dont go above or onder 
            if (raiseAmount > ChipHandler.GetRemaningRaise())
                raiseAmount = 1;
            else if (raiseAmount == 0)
                raiseAmount = (byte)ChipHandler.GetRemaningRaise();

            raiseCount.text = $"{raiseAmount}";
        }

    }

}
