using UnityEngine;


public class PPawn : BasePiece
{

    #region [Elements]

    [SerializeField] private bool isFirstMoved = true;

    #endregion


    #region [Override]



    public override void Move(Cell targetedCell)
    {
        isFirstMoved = false;

        base.Move(targetedCell);
    }

    public override void BeSelected()
    {
        base.BeSelected();
    }


    protected override void BeSlectedBlack()
    {
        // Kha nang di chuyen 2 buoc khi moi bat dau
        if (isFirstMoved && !CheckCellHasPiece(pieceInfo.x, pieceInfo.y + 2) && !CheckCellHasPiece(pieceInfo.x, pieceInfo.y + 1))
        {
            AddCellOnCellTarget(pieceInfo.x, pieceInfo.y + 2);
        }

        // Kha nang di chuyen 1 buoc
        if (!CheckCellHasPiece(pieceInfo.x, pieceInfo.y + 1))
            AddCellOnCellTarget(pieceInfo.x, pieceInfo.y + 1);


        // Xac dinh 2 o cheo co an duoc khong
        if (pieceInfo.x > 0 && CheckCellHasPiece(pieceInfo.x - 1, pieceInfo.y + 1) && ChessBoard.instance.Cells[pieceInfo.x - 1][pieceInfo.y+1].curPiece.player != GameManager.Instance.Player)
        {
            // Ben trai
            AddCellOnCellTarget(pieceInfo.x - 1, pieceInfo.y + 1);

        }
        if (pieceInfo.y < 7 && pieceInfo.x < 7 && CheckCellHasPiece(pieceInfo.x + 1, pieceInfo.y + 1) && ChessBoard.instance.Cells[pieceInfo.x + 1][pieceInfo.y + 1].curPiece.player != GameManager.Instance.Player)
        {
            // Ben phai
            AddCellOnCellTarget(pieceInfo.x + 1, pieceInfo.y + 1);
        }
    }



    protected override void BeSlectedWhite()
    {
        // Kha nang di chuyen 2 buoc khi moi bat dau
        if (isFirstMoved && !CheckCellHasPiece(pieceInfo.x, pieceInfo.y - 2) && !CheckCellHasPiece(pieceInfo.x, pieceInfo.y - 1))
        {
            AddCellOnCellTarget(pieceInfo.x, pieceInfo.y - 2);
        }

        // Kha nang di chuyen 1 buoc
        if (!CheckCellHasPiece(pieceInfo.x, pieceInfo.y - 1))
            AddCellOnCellTarget(pieceInfo.x, pieceInfo.y - 1);


        // Xac dinh 2 o cheo co an duoc khong
        if (pieceInfo.x > 0 && CheckCellHasPiece(pieceInfo.x - 1, pieceInfo.y - 1) && ChessBoard.instance.Cells[pieceInfo.x - 1][pieceInfo.y - 1].curPiece.player != GameManager.Instance.Player)
        {
            // Ben trai
            AddCellOnCellTarget(pieceInfo.x - 1, pieceInfo.y - 1);

        }
        if (pieceInfo.y < 7 && pieceInfo.x < 7 && CheckCellHasPiece(pieceInfo.x + 1, pieceInfo.y + -1) && ChessBoard.instance.Cells[pieceInfo.x + 1][pieceInfo.y - 1].curPiece.player != GameManager.Instance.Player)
        {
            // Ben phai
            AddCellOnCellTarget(pieceInfo.x + 1, pieceInfo.y - 1);
        }
    }

    public override void Attack(Cell targetedCell)
    {
        base.Attack(targetedCell);
    }

    public override void BeAttackBy(BasePiece enemy)
    {
        base.BeAttackBy(enemy);
    }

    #endregion

}
