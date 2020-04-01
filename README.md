# SudokuWebApp
Creating a ASP.Net web application to generate a solution to the Sudoku puzzle.

### What is Sudoku?
Sudoku consists of 81 cells, distributed in a 9x9 matrix. This matrix is composed of 9 rows and 9 columns, each with 9 cells. Additionally, there are 9 groups of 3x3-matrixes, that we call "squares" in this article. The idea is to write a digit between 1 and 9 in each cell, but the game has some rules:

* You cannot write the same digit in two or more cells of the same row.
* You cannot write the same digit in two or more cells of the same column.
* You cannot write the same digit in two or more cells of the same "square"

### The Goal
Given a partially filled 9x9 2D array, the goal is to assign digits (from 1 to 9) to the empty cells so that every row, column, and subgrid of size 3×3 contains exactly one instance of the digits from 1 to 9.

### Algorithm
**Backtracking** - We can solve Sudoku by assigning numbers to empty cells, one at a time. Before assigning a number, we check whether it is safe to assign. We basically check that the same number is not present in the current row, current column and current 3x3 subgrid. After checking for safety, we assign the number, and recursively check whether this assignment leads to a solution or not. If the assignment doesn’t lead to a solution, then we try the next number for the current empty cell. And if none of the number (1 to 9) leads to a solution, we return false.

### Using the web application

![SudokuWebApplication.png](https://github.com/msthakkar121/SudokuWebApp/blob/master/Images/SudokuWebApplication.png)

* In the input box on the top of the page, enter a string with 91 digits which will make up the puzzle. Use '0' for blank cells.
* Click on the 'Populate' button to generate the puzzle. If you mis-entered the type or length of the input, it should display an error message asking you to re-enter the input.
* Once the puzzle is generated (the grid on the left side of the page), you can click on 'Solve It' button to generate the solution for the puzzle. If the solutio does not exist, an error message might ask you to change your input, else the grid on the right side of the page will be populated with the solved puzzle. 
* At the bottom-right corner of the screen, you shall also see the time taken by the algorithm to solve the puzzle. 

### Unit Tests

Unit tests are written using Microsoft's built-in framework for testing. The sudoku grid is populated with both valid and invalid inputs before testing it for the corresponding behaviour. 
