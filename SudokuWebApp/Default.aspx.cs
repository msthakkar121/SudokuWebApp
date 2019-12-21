using System;

namespace SudokuWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public static int[,] Grid { get; set; }
        public string InputString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid = new int[9, 9];
        }

        protected void SudoFormSubmit_Click(object sender, EventArgs e)
        {
            //Flush the OutputData from the hidden field
            //It will be refilled once we compute the result
            OutputData.Value = "";

            //GetDataItem input data from the hidden field
            InputString = InputData.Value;

            //Fill the Grid array for processing from input data string
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Grid[i, j] = Int32.Parse(InputString[j].ToString());
                }
                InputString = InputString.Substring(9, InputString.Length - 9);
            }
            //The Grid array now contains the input data

            if (SolveGrid())
            {
                // success, set the error flag to false
                IsError.Value = "false";

                //Fill the OutputData hidden field to pass the data to the front end
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        OutputData.Value += Grid[i, j];
                    }
                }
            }
            else
            {
                // no solution, set the error flag for front-end to handle the error
                IsError.Value = "true";
            }
        }
        
        //Recursive Function
        public static bool SolveGrid()
        {
            //Initialize row & column to default values
            int row = -1;
            int col = -1;
            bool isEmpty = true;

            //find the first missing value in the grid
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Grid[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        // we still have some missing values 
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            // no empty space left -> Success
            if (isEmpty)
            {
                return true;
            }

            // you got row & column for an empty cell, now try the first possible number and fill it
            for (int num = 1; num <= 9; num++)
            {
                if (IsNumberValid(row, col, num))
                {
                    Grid[row, col] = num;
                    //after substituting the number, call the recursie function to solve the rest of the grid
                    if (SolveGrid())
                    {
                        //if the grid is solved with this substuitution, good.
                        return true;
                    }
                    else
                    {
                        //If the grid is not solved with this substuitution, set it back to zero and try the next number.
                        Grid[row, col] = 0; // replace it 
                    }
                }
            }
            //If any number does not solve the grid, the solution does not exist
            return false;
        }

        public static bool IsNumberValid(int row, int col, int num)
        {
            // check if number already present in row
            for (int c = 0; c < 9; c++)
            {
                if (Grid[row, c] == num)
                {
                    return false;
                }
            }

            // check if number already present in column
            for (int r = 0; r < 9; r++)
            { 
                if (Grid[r, col] == num)
                {
                    return false;
                }
            }

            // check if number already present in box
            int RowStartIndex = row - row % 3;
            int ColStartIndex = col - col % 3;

            for (int r = RowStartIndex; r < RowStartIndex + 3; r++)
            {
                for (int c = ColStartIndex; c < ColStartIndex + 3; c++)
                {
                    if (Grid[r, c] == num)
                    {
                        return false;
                    }
                }
            }

            // if the number does not conflict anything, it is valid
            return true;
        }
    }
}