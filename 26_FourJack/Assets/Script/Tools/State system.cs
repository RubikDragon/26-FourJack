using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Unity
{
    // gernal and common states. add as neede
    public enum StateNames
    {
        Idel,
        Running,
        Walking,
        Attacking,
        Defending,
        Awaiting,
        Shoting
    }


    public class Statesystem : MonoBehaviour
    {
        [System.Serializable]
        private struct States
        {
            [SerializeField] private StateNames stateName;
            [SerializeField] private bool loop;
            //private <T> make it take a scripts methode

            public StateNames StateNames { get => stateName; }
            public bool Loop { get => loop; }
        }

        [SerializeField] private States[] allStates;

        private States lastState;

        public void SwitchState(StateNames stateName, float? switchBackTimer = null)
        {
            foreach (States state in allStates)
            {
                if (state.StateNames == stateName)
                {
                    //state. call the method
                }
            }

            if (switchBackTimer != null)
            {
                // wait time and then swith to the previas
            }
        }
    }

}

