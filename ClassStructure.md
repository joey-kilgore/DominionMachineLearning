# DominionMachineLearning
Machine learning algorithm to play dominion

Card Interface
  has list of attributes
  cost of card
  does the card have a card specific attribute
  name of card
  function for how card is played
  
  each card has an individual class (implements card interface)
    card classes assign specific values to all variables in the card interface


Attributes
  have an array of weights
  have a function to output the value of the attribute
  
Machine
  Has list of attributes
  has functions to input and output specific values for attributes
  has function that determines which card to play based on the play state
  has function that determines which card to buy based on the play state
  has functions that determine how to adjust the weights of each attribute
  
Game Manager
  keeps track to game state variables
  displays the game state and keeps track of where cards are located
  prompts user and machine on when to play
  

  
  
