
Using System;

Namespace GameOfLife
{

    Public Class LifeSimulation
    {
        Private int Heigth;
        Private int Width;
        Private bool[,] cells;

        Public LifeSimulation(int Heigth, int Width)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = New bool[Heigth, Width];
            GenerateField();
        }

        Public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }


        Private void Grow()
        {
            For(int i = 0; i < Heigth; i++) {
            For(int j = 0; j < Width; j++) {
                int numOfAliveNeighbors = GetNeighbors(i, j);

                If(cells[i, j]) {
                    If(numOfAliveNeighbors < 2) {
                        cells[i, j] = false;
                    }

                    If(numOfAliveNeighbors > 3) {
                        cells[i, j] = false;
                    }
                }
                Else {
                    If(numOfAliveNeighbors == 3) {
                        cells[i, j] = true;
                    }
                }
            }
        }
    }

    Private int GetNeighbors(int x, int y) {
        int NumOfAliveNeighbors = 0;

        For(int i = x - 1; i < x + 2; i++) {
            For(int j = y - 1; j < y + 2; j++) {
                If(!((i < 0 || j < 0) || (i >= Heigth || j >= Width))) {
                    If(cells[i, j] == true) NumOfAliveNeighbors++;
                }
            }
        }
        Return NumOfAliveNeighbors;
    }


    Private void DrawGame() {
        For(int i = 0; i < Heigth; i++) {
            For(int j = 0; j < Width; j++) {
                Console.Write(cells[i, j] ? "x" : " ");
                If(j == Width - 1) Console.WriteLine("\r");
            }
        }
        Console.SetCursorPosition(0, Console.WindowTop);
    }

    Private void GenerateField() {
        Random generator = New Random();
        int number;
        For(int i = 0; i < Heigth; i++) {
            For(int j = 0; j < Width; j++) {
                number = generator.Next(2);
                cells[i, j] = ((number == 0) ? false : true);
            }
        }
    }
}

internal Class Program
{

    Private Const int Heigth = 10;
    Private Const int Width = 30;
    Private Const uint MaxRuns = 100;

    Private Static void Main(String []
    args) {
        int runs = 0;
        LifeSimulation sim = New LifeSimulation(Heigth, Width);

        While(runs + +< MaxRuns) {
            sim.DrawAndGrow();

            System.Threading.Thread.Sleep(100);
        }
    }
}
}