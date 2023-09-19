namespace XZero.Shared
{
    public class GameState
    {
        
        static GameState()
        {
        }

        /// <summary>
        /// Indicate whether a player has won, the game is a tie, or game in ongoing
        /// </summary>
       

        /// <summary>
        /// The player whose turn it is.  By default, player 1 starts first
        /// </summary>
        public int PlayerTurn => TheBoard.Count(x => x != 0) % 2 + 1;

        /// <summary>
        /// Number of turns completed and pieces played so far in the game
        /// </summary>
        public int CurrentTurn { get { return TheBoard.Count(x => x != 0); } }


        
        /// <summary>
        /// Check the state of the board for a winning scenario
        /// </summary>
        /// <returns>0 - no winner, 1 - player 1 wins, 2 - player 2 wins, 3 - draw</returns>
        public int  CheckForWin()
        {

            // Exit immediately if less than 7 pieces are played
           
           //Horizontal
            if (TheBoard[0]!=0&&TheBoard[0] == TheBoard[1] && TheBoard[0] == TheBoard[2])
                return TheBoard[0];
            if (TheBoard[3] != 0 && TheBoard[3] == TheBoard[4] && TheBoard[3] == TheBoard[5])
                return TheBoard[3];
            if (TheBoard[6] != 0 && TheBoard[6] == TheBoard[7] && TheBoard[6] == TheBoard[8])
                return TheBoard[6];
            //Vertical
            if (TheBoard[0] != 0 && TheBoard[0] == TheBoard[3] && TheBoard[0] == TheBoard[6])
                return TheBoard[0];
            if (TheBoard[1] != 0 && TheBoard[1] == TheBoard[4] && TheBoard[1] == TheBoard[7])
                return TheBoard[1];
            if (TheBoard[2] != 0 && TheBoard[2] == TheBoard[5] && TheBoard[2] == TheBoard[8])
                return TheBoard[2];
            //Diagonal1
            if (TheBoard[0] != 0 && TheBoard[0] == TheBoard[4] && TheBoard[0] == TheBoard[8])
                    return TheBoard[0];
            //Diagonal2
            if (TheBoard[2] != 0 && TheBoard[2] == TheBoard[4] && TheBoard[2] == TheBoard[6])
                return TheBoard[2];

            for(int i = 0; i < TheBoard.Count; i++)
            {
                if (TheBoard[i] == 0)
                {
                    return -1;
                }
            }
            return 0;

        }
        

            /// <summary>
            /// Takes the current turn and places a piece in the 0-indexed column requested
            /// </summary>
           
            /// <returns>The final array index where the piece resides</returns>
            public int PlayPiece(int column)
        {


            // Check the column
            if (TheBoard[column] != 0) return -1;

        

            TheBoard[column] = PlayerTurn;
            return 0;

           

        }

        public List<int> TheBoard { get; private set; } = new List<int>(new int[9]);

        public void ResetBoard()
        {
            TheBoard = new List<int>(new int[9]);
            for (var i = 0; i < 9; i++)
            {
                TheBoard[i] = 0;
               
            }
        }

      

    
}
}
