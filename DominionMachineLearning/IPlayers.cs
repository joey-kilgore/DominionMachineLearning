using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning
{
    /// <summary>
    /// IPlayers allows for the GameManager to tell what the all players know
    /// IPlayers is used to create a Human class and a Machine class
    /// </summary>
    public interface IPlayers
    {
        /// <summary>
        /// deck is a list of all cards in the player's deck
        /// this does not have a specific order because the cards are randomly drawn
        /// </summary>
        List<Card> deck
        {
            get;
            set;
        }

        /// <summary>
        /// discard is a list of all cards in the player's discard pile
        /// this does not have a specific order
        /// </summary>
        List<Card> discard
        {
            get;
            set;
        }

        /// <summary>
        /// hand is a list of all cards in the player's hand
        /// this does not have a specific order
        /// </summary>
        List<Card> hand
        {
            get;
            set;
        }

        /// <summary>
        /// inPlay is a list of all cards the player currently has in play
        /// this does not have a specific order
        /// </summary>
        List<Card> inPlay
        {
            get;
            set;
        }

        void playTurn();
    }
}
