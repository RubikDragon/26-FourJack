using UnityEngine;
using TMPro;

namespace BackJackSystem.Look
{
    public class HealtBox : MonoBehaviour
    {
        
        [SerializeField] private TMP_Text healtText;
        [SerializeField] private Players onHealtChange;

        private void Awake()
        {
            onHealtChange.OnDamge += OnHealtChange_OnDamge;
        }

        private void OnHealtChange_OnDamge(byte healt)
        {
            ChangeHealtText(healt);
        }

        // updates the healt shown
        private void ChangeHealtText(byte healt)
        {
            Debug.Log($"{onHealtChange.name} healt is {healt}");

            if (healt >= 0)
            {
                healtText.text = $"{healt}";
            }
            else
            {
                healtText.text = $"{0}";
            }
        }
    }
}