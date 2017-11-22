using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning
{
    public interface Card
    {
        int cost //cost to buy the card
        {
            get;
            set;
        }

        string name     //name of the card
        {
            get;
            set;
        }

        bool isAction   //true if the card is an action card
        {
            get;
            set;
        }

        bool isVictory  //true if the card is a victory card
        {
            get;
            set;
        }

        bool isTreasure //true if the card is a treasure card
        {
            get;
            set;
        }

        int bonusAction     //number of bonus actions the card gives when played
        {
            get;
            set;
        }

        int bonusTreasure   //number of bonus treasure the card gives when played
        {
            get;
            set;
        }

        int bonusDraw       //number of bonus draws the card gives when played
        {
            get;
            set;
        }

        int bonusBuy        //number of bonus buys the card gives when played
        {
            get;
            set;
        }

        int victoryPoint    //number of victory points this card is worth
        {
            get;
            set;
        }

        bool hasOwnAttribute    //true when the card has a specific action when played that
        {                       //  applies to this card
            get;
            set;
        }

    }
}
