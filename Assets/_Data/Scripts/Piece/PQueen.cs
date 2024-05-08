using System;
using UnityEngine;


public class PQueen : BasePiece
{

    #region [Elements]



    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]



    #endregion

    #region [Override]

    

    public override void BeSelected()
    {
        WayLikeRook();
        WayLikeBishop();

        base.BeSelected();
    }

    private void WayLikeRook()
    {
        // Di chuyen ngang
        for (int i = pieceInfo.x + 1; i < 8; i++)
        {
            Cell c = ChessBoard.instance.Cells[i][pieceInfo.y];
            if (!c.curPiece)
            {
                targetCell.Add(c);
            }
            else
            {
                if (c.curPiece.player != GameManager.Instance.Player)
                {
                    targetCell.Add(c);
                }

                break;
            }
        }

        for (int i = pieceInfo.x - 1; i >= 0; i--)
        {
            Cell c = ChessBoard.instance.Cells[i][pieceInfo.y];

            if (!c.curPiece)
            {
                targetCell.Add(c);
            }
            else
            {
                if (c.curPiece.player != GameManager.Instance.Player)
                {
                    targetCell.Add(c);
                }

                break;
            }
        }

        // Di chuyen doc
        for (int i = pieceInfo.y + 1; i < 8; i++)
        {
            Cell c = ChessBoard.instance.Cells[pieceInfo.x][i];
            if (!c.curPiece)
            {
                targetCell.Add(c);
            }
            else
            {
                if (c.curPiece.player != GameManager.Instance.Player)
                {
                    targetCell.Add(c);
                }

                break;
            }
        }
        for (int i = pieceInfo.y - 1; i >= 0; i--)
        {
            Cell c = ChessBoard.instance.Cells[pieceInfo.x][i];

            if (!c.curPiece)
            {
                targetCell.Add(c);
            }
            else
            {
                if (c.curPiece.player != GameManager.Instance.Player)
                {
                    targetCell.Add(c);
                }

                break;
            }
        }
    }

    private void WayLikeBishop()
    {
        // Phai tren x++ y++
        Vector2 vec = new(pieceInfo.x, pieceInfo.y);

        while (true)
        {
            vec = new(vec.x + 1, vec.y + 1);

            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                if (cell.curPiece)
                {
                    if (cell.curPiece.player != GameManager.Instance.Player)
                    {
                        targetCell.Add(cell);
                    }
                    break;
                }
                targetCell.Add(cell);
            }
            else
            {
                break;
            }
        }
        // Phai duoi x++ y--
        vec = new(pieceInfo.x, pieceInfo.y);
        while (true)
        {
            vec = new(vec.x + 1, vec.y - 1);

            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                if (cell.curPiece)
                {
                    if (cell.curPiece.player != GameManager.Instance.Player)
                    {
                        targetCell.Add(cell);
                    }
                    break;
                }
                targetCell.Add(cell);
            }
            else
            {
                break;
            }
        }

        // Trai tren x-- y++
        vec = new(pieceInfo.x, pieceInfo.y);
        while (true)
        {
            vec = new(vec.x - 1, vec.y + 1);

            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                if (cell.curPiece)
                {
                    if (cell.curPiece.player != GameManager.Instance.Player)
                    {
                        targetCell.Add(cell);
                    }
                    break;
                }
                targetCell.Add(cell);
            }
            else
            {
                break;
            }
        }

        // Trai duoi x-- y--
        vec = new(pieceInfo.x, pieceInfo.y);
        while (true)
        {
            vec = new(vec.x - 1, vec.y - 1);

            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                if (cell.curPiece)
                {
                    if (cell.curPiece.player != GameManager.Instance.Player)
                    {
                        targetCell.Add(cell);
                    }
                    break;
                }
                targetCell.Add(cell);
            }
            else
            {
                break;
            }
        }
    }

    protected override void BeSlectedWhite()
    {
    }

    protected override void BeSlectedBlack()
    {
    }

    #endregion

}
