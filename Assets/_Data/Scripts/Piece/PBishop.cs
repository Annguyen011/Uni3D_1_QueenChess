using UnityEngine;


public class PBishop : BasePiece
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
        // Phai tren x++ y++
        Vector2 vec = new(pieceInfo.x, pieceInfo.y);

        while (true)
        {
            vec = new(vec.x + 1, vec.y + 1);

            if (Helper.CheckBound(vec))
            {
                Cell cell = ChessBoard.instance.Cells[(int)vec.x][(int)vec.y];

                if(cell.curPiece)
                {
                    if(cell.curPiece.player != GameManager.Instance.Player)
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

        base.BeSelected();
    }

    protected override void BeSlectedWhite()
    {
    }

    protected override void BeSlectedBlack()
    {
    }

    #endregion

}
