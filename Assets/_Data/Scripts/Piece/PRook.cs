using UnityEngine;


public class PRook : BasePiece
{

    #region [Elements]



    #endregion



    #region [Override]


    public override void BeSelected()
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
        base.BeSelected();
    }

    protected override void BeSlectedWhite()
    {
    }

    protected override void BeSlectedBlack()
    {
    }

    public override void Attack(Cell targetedCell)
    {
        base.Attack(targetedCell);
    }

    #endregion

}
