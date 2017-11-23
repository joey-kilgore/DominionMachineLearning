using DominionMachineLearning.CardClassFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning.Players.Human
{
    class HumanPlayer : IPlayers
    {
        public HumanPlayer()
        {
            deck = new List<Card>();    //Declare deck

            for (int i = 0; i < 7; i++)
            {
                deck.Add(new Copper()); //Fill deck with 7 coppers
            }

            for (int i = 0; i < 3; i++)
            {
                deck.Add(new Estate()); //Fill deck with 3 estates
            }

            discard = new List<Card>(); //Declare discard
            hand = new List<Card>();    //Declare hand
            inPlay = new List<Card>();  //Declare inPlay

            currentTreasure = 0;    //set all basic turn variables to 0
            currentAction = 0;
            currentBuy = 0;
        }

        /// <summary>
        /// called when the player must take their turn
        /// </summary>
        public void playTurn()
        {
            GameManager.drawHand(this); //Draw hand

            currentAction = 1;  //Set all current turn variables to starting amounts
            currentBuy = 1;
            currentTreasure = 0;

            bool stillActionPhase = true;   //keeps track of whether the player is still in the action phase

            do  //ACTION PHASE LOOP
            {
                bool haveActionCard = false;    //keeps track of if the player has an action card in hand

                foreach (Card card in hand) //check hand to see if the player has an action card
                {
                    if (card.isAction)
                    {
                        haveActionCard = true;
                    }
                }

                if (haveActionCard)
                {
                    if (currentAction > 0)
                    {   //PLAYER HAS ACTIONS AND ACTION CARDS

                        foreach (Card card in hand)  //Display cards in hand
                        {
                            Console.WriteLine(card.name);
                        }

                        bool stillChoosingCard = true;  //keeps track of when the player has successfully chosen a card
                        Card chosenCard = new BlankCard();  //declare and instantiate chosenCard so that we can use it.
                                                            //it is declared as a blankCard to because objects can't be declared as interfaces
                        string cardToPlay = "";

                        do
                        {
                            Console.WriteLine("WHICH CARD TO PLAY (OR ENTER 'NONE')");    //ask the user for what action card to play
                            cardToPlay = Console.ReadLine();     //store the name of the card wanted to play

                            foreach(Card card in hand)  //loop through hand and check if the card entered is actually in the players hand
                            {
                                if(String.Compare(card.name,cardToPlay,true) == 0)  //compare card name entered to the name of each card in hand
                                {
                                    stillChoosingCard = false;  //the card entered is actually in hand and the player has chosen a card
                                    chosenCard = card;
                                }
                            }

                            if (String.Compare(cardToPlay, "NONE", true) == 0)   //check if player entered none
                            {
                                stillChoosingCard = false;
                            }

                        } while (stillChoosingCard);    //repeats until player enters a card that is actually in the player's hand

                        if (String.Compare(cardToPlay, "NONE", true) != 0)
                        {
                            hand.Remove(chosenCard);    //remove chosen card from hand. this is like the player laying the card down
                            inPlay.Add(chosenCard);     //add chosen card to inPlay

                            chosenCard.playCard(this);  //resolve the action card
                        }
                        else
                        {
                            stillActionPhase = false;
                        }
                    }
                    else
                    {
                        stillActionPhase = false;   //action phase is over if the player has no more actions to be able to play more action cards
                    }
                }
                else
                {
                    stillActionPhase = false;   //action phase is over if there are no actions in the players hand
                }
            } while (stillActionPhase);

            foreach(Card card in hand)  //loop through all cards in hand and play all treasure cards
            {
                if (card.isTreasure)
                {
                    card.playCard(this);
                }
            }

            //BUY PHASE
            bool stillBuyPhase = true;
            do
            {
                GameManager.outputSupplyPiles();

                if (currentBuy > 0)
                {
                    bool stillChoosingCard = true;  //keeps track of when the player has successfully chosen a card
                    Card chosenCard = new BlankCard();  //declare and instantiate chosenCard so that we can use it.
                                                        //it is declared as a blankCard to because objects can't be declared as interfaces
                    string cardToBuy = "";
                    do
                    {
                        Console.WriteLine("CURRENT TREASURE: " + currentTreasure);
                        Console.WriteLine("WHICH CARD TO BUY (OR ENTER 'NONE')");    //ask the user for what card to buy
                        cardToBuy = Console.ReadLine();     //store the name of the card wanted to buy

                        foreach (Card card in GameManager.supplyPile)  //loop through supply pile and check if the card entered is actually in the supply pile
                        {
                            if (String.Compare(card.name, cardToBuy, true) == 0)  //compare card name entered to the name of each card in supply pile
                            {
                                if (card.cost <= currentTreasure)   //check that the player can afford the card they chose
                                {
                                    stillChoosingCard = false;  //the card entered is actually in pile and the player has chosen a card
                                    chosenCard = card;
                                }
                            }
                        }

                        if (String.Compare(cardToBuy, "NONE", true) == 0)   //check if player entered none
                        {
                            stillChoosingCard = false;
                        }

                    } while (stillChoosingCard);    //repeats until player enters a card that is actually in the supply pile

                    if (String.Compare(cardToBuy, "NONE", true) != 0)
                    {
                        GameManager.supplyPile.Remove(chosenCard);  //actions are done as if the player bought thecard put it in the discard 
                        this.discard.Add(chosenCard);               //and now has fewer buys and treasure
                        currentBuy--;
                        currentTreasure -= chosenCard.cost;
                    }
                    else
                    {
                        stillBuyPhase = false;
                    }
                }
                else
                {
                    stillBuyPhase = false;
                }
            } while (stillBuyPhase);

            //CLEANUP PHASE
            List<Card> copyOfHand = new List<Card>();
            foreach(Card card in hand)
            {
                copyOfHand.Add(card);
            }

            foreach(Card card in copyOfHand)    //remove all cards from hand and put them in the discard
            {
                hand.Remove(card);
                discard.Add(card);
            }

            List<Card> copyOfInPlay = new List<Card>();
            foreach (Card card in inPlay)
            {
                copyOfInPlay.Add(card);
            }
            foreach (Card card in copyOfInPlay)  //remove all cards from in play and put them in the discard
            {
                inPlay.Remove(card);
                discard.Add(card);
            }
        }

        /// <summary>
        /// deck is a list of all cards in the player's deck
        /// this does not have a specific order because the cards are randomly drawn
        /// </summary>
        public List<Card> deck
        {
            get;
            set;
        }

        /// <summary>
        /// discard is a list of all cards in the player's discard pile
        /// this does not have a specific order
        /// </summary>
        public List<Card> discard
        {
            get;
            set;
        }

        /// <summary>
        /// hand is a list of all cards in the player's hand
        /// this does not have a specific order
        /// </summary>
        public List<Card> hand
        {
            get;
            set;
        }

        /// <summary>
        /// inPlay is a list of all cards the player currently has in play
        /// this does not have a specific order
        /// </summary>
        public List<Card> inPlay
        {
            get;
            set;
        }

        /// <summary>
        /// keeps track of the treasure the player has in play
        /// </summary>
        public int currentTreasure
        {
            get;
            set;
        }

        /// <summary>
        /// keeps track of the number of actions the player has left
        /// </summary>
        public int currentAction
        {
            get;
            set;
        }

        /// <summary>
        /// keeps track of the number of buys the player has
        /// </summary>
        public int currentBuy
        {
            get;
            set;
        }

        /// <summary>
        /// called when a specific card action needs to be resolved
        /// the name of the card tells what to do
        /// </summary>
        /// <param name="nameOfCard"></param>
        public void playSpecificAction(string nameOfCard)
        {

        }
    }
}
