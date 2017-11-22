using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning
{
    public interface IPlayers
    {
        List<Card> deck
        {
            get;
            set;
        }

        List<Card> discard
        {
            get;
            set;
        }

        List<Card> hand
        {
            get;
            set;
        }

        List<Card> inPlay
        {
            get;
            set;
        }

        void playTurn();
    }
}
