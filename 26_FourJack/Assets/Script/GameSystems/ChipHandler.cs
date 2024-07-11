using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BackJackSystem
{
    public static class ChipHandler
    {
        // what i want the system to do
        // (1) four a player to rais the amount of chips
        // (2) if somone has raised then other players have to mach the chip amount         
        // (3) if somone does not math the amount of chips then the round ends and there are the loser
        // (4) the loser then takes damge = to chip amount before rais + the amount the fist person raisd ONLY THE FISTS

        // (extra) mabye alow players to pay extra untop of the bid. making the others need to math the amount

        private static byte maxChipsPerPlayer;
        private static byte currentChipsPerPlayer;
        private static byte totalChips;

        public static byte MaxChipsPerPlayer { get => maxChipsPerPlayer;}
        public static byte TotalChips { get => totalChips; }

        public static event Action<Players, byte> OnRaise;
        public static event Action<byte> OnChipAdded;

        public static void SetMaxChips(byte maxPerPlayer)
        {
            maxChipsPerPlayer = maxPerPlayer;
            Debug.Log($"ithe player can have a max of {maxChipsPerPlayer} chips");
        }

        public static void Raise(Players raiser, byte raiseAmount)
        {
            byte chipAmountAdded = 0;

            // indcase we somhow get sendt a number that is above limit
            if (currentChipsPerPlayer + raiseAmount >= maxChipsPerPlayer)
            {
                chipAmountAdded = (byte)(maxChipsPerPlayer - currentChipsPerPlayer);
                currentChipsPerPlayer = maxChipsPerPlayer;
            }
            else
            {
                currentChipsPerPlayer += raiseAmount;
                chipAmountAdded = raiseAmount;
            }

            if (chipAmountAdded > 0)
            {
                AddChips(chipAmountAdded);
                OnRaise?.Invoke(raiser, chipAmountAdded);
            }

            Debug.Log($"{raiser.name} has raised by {chipAmountAdded} chips. and the raisebol amount is now {maxChipsPerPlayer - currentChipsPerPlayer} total chips:[{totalChips}]");
        }

        public static void AddChips(byte addAmount)
        {
            totalChips += addAmount;
            OnChipAdded?.Invoke(addAmount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> returns how muthe more you can raise per player</returns>
        public static int GetRemaningRaise()
        {
            return maxChipsPerPlayer - currentChipsPerPlayer;
        }
    }
}


