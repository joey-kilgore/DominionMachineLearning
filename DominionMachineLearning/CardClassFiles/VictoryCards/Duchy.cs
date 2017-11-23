using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning.CardClassFiles
{
    class Duchy : Card
    {
        //All variables are set to the according values for the Duchy card
        //notable variable of the Duchy card:
        //  cost = 5
        //  name = "DUCHY"
        //  isVictory = true
        //  victoryPoint = 3


        public Duchy()
        {
            cost = 5;

            name = "DUCHY";

            isAction = false;
            isVictory = true;
            isTreasure = false;

            bonusAction = 0;
            bonusTreasure = 0;
            bonusDraw = 0;
            bonusBuy = 0;

            victoryPoint = 3;

            hasOwnAttribute = false;
        }

        public void playCard(IPlayers player)
        {

        }

        public int cost //cost to buy the card
        {
            get;
            set;
        }

        public string name     //name of the card
        {
            get;
            set;
        }

        public bool isAction   //true if the card is an action card
        {
            get;
            set;
        }

        public bool isVictory  //true if the card is a victory card
        {
            get;
            set;
        }

        public bool isTreasure //true if the card is a treasure card
        {
            get;
            set;
        }

        public int bonusAction     //number of bonus actions the card gives when played
        {
            get;
            set;
        }

        public int bonusTreasure   //number of bonus treasure the card gives when played
        {
            get;
            set;
        }

        public int bonusDraw       //number of bonus draws the card gives when played
        {
            get;
            set;
        }

        public int bonusBuy        //number of bonus buys the card gives when played
        {
            get;
            set;
        }

        public int victoryPoint    //number of victory points this card is worth
        {
            get;
            set;
        }

        public bool hasOwnAttribute    //true when the card has a specific action when played that
        {                       //  applies to this card
            get;
            set;
        }
    }
}
