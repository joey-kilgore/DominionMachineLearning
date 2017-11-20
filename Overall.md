# DominionMachineLearning
Machine learning algorithm to play dominion

Preface:
Dominion is a popular board game, and is highly commended all across the gaming industry.
It is known for being the first deck building game. This means that each player starts with a deck of cards,
and overtime each player buys better cards to add to their deck.
The game is played pretty simply
  First, 10 actions cards are selected to play with, and are going to be the cards each player will buy to improve their deck
  Second, each player has a deck of 10 cards (7 coppers, each worth 1 treasure, and 2 estates, each worth 1 victory point)
  Each player then takes turns until either 3 of the piles of cards are gone or all of the province cards are gone
    In a turn:
    First draw 5 cards
    Each player starts with the ability to play all treasure, and one action card
    playing an action card allows you to do the instructions on the card
      if the action card gives bonus actions, then the player can continue playing more action cards
    when the player has no more actions or action cards then the player goes into a buy phase
      unless the player has extra buys, the player can only buy 1 card
      the player can only buy cards that cost equal or less than the treasure in their hand
      when the card is bought the card is put in the players discard pile
    the player then puts all cards played and all cards in hand in the discard pile
    then when the player tries to draw a hand and no longer has a deck, the discard pile is shuffled and is now the players deck
  Finally, when the ending conditions are met the game immediately stops
  The winner is the player with the most victory points
    if there is a tie the player with the fewest number of turns wins
      if there is still a tie, the players share the victor


Methodology For Algorithm:

Overview:
The algorithm is divided into two seperate networks, one for the action phase, one for the buy phase
The action phase network will determine what to do in the events that:
  there are action cards in the players hand, and the computer must determine the best way to play the hand given
The buy phase network will determine what to do when:
  the computer has to compare which card(s) to buy with the treasure in hand
  
Specifics of the networks:
Each network has 3 layers and a final comparison layer
  1: input layer, which includes:
    cards in hand
    cards in deck
    cards in discard pile
    victory points of each player
  2: attributes layer, which is used to decide what attributes are wanted based on the inputs. these include:
    bonus actions
    bonus cards
    bonus buys
    bonus treasure
    victory points (buy phase only)
    card specific attributes (ex. cellar)
  3: card layer, which determines values for all possible cards. these cards include:
    in action phase:
      each action in the player hand
    in buy phase:
      each combination of cards that the plyaer has the buys and treasure for
    nothing buy/action which is used for when the best option is to do nothing
  Comparison layer, which compares the values determined in the card layer.
    
How the layers interact:
  The input and attribute layer interaction:
    each input is connected to each attribute node
    the connection is weighted, and these weights will change as the algorithm learns
    the weight is multiplied onto each input value and the attribute node sums all the weighted inputs
  The attribute layer and card layer interaction:
    each card/combination of cards either has specific attributes or doesn't
    the card nodes sum the value of the attributes that the card/combination of cards has
  The card layer and comparison layer interaction:
    the comparison layer chooses which card/card combination had the highest value
    this card is then played or bought depending on the phase
    this will likely be done as the card layer is being calculated to conserve data space and time, because low values can be thrown
 
Overall learning:
  First the algorithm is set to random weights
  The algorithm begins with extremely supervised learning
    each turn the player will determine if the move was objectively bad, good or neutral
      examples
      bad: having only a smithy in hand, and not doing anything
      good: playing a village before playing a smithy
      neutral: choosing one action over another, when both are relatively equal    
  after learning to make moves that are not objectively bad it begins unsupervised learning,
    the computer can then begin basing weights on an analysis of the game as a whole
    
Final notes:
  This algorithm should allow for weights to be adjusted quickly in supervised learning,
  and finely tuned through unsupervised learning when looking at the game as a whole
  Number of nodes in each layer:
    input layer (50)
      each card in hand, deck, and discard adds to 48 (16 cards, each can have values in each of the 3 sets)
      victory points 2, (one for each player)
    attribute layer (4-14)
      4, one for each of the following: buys, bonus treasure, bonus actions, bonus draws
      one more for each actioncard with a card specific attribute (max 10)
    card layer (1-A LOT)
      1 for each card in hand during action phase
      1 for each card/card combination possible during buy phase, which can be a lot if the player has many buys
      
