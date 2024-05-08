using UnityEngine;


public class PPawn : BasePiece
{

    #region [Elements]

    [SerializeField] private bool isFirstMoved = true;

    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]



    #endregion

    #region [Override]



    #endregion
    protected override void Move()
    {
        isFirstMoved = false;
    }

    public override void BeSelected()
    {
        base.BeSelected();
    }


    protected override void BeSlectedBlack()
    {
        // Kha nang di chuyen 2 buoc khi moi bat dau
        if (isFirstMoved)
        {
            ChessBoard.instance.Cells[pieceInfo.x][pieceInfo.y + 2].SetCellState(ECellState.HOLDER); ;
        }

        // Kha nang di chuyen 1 buoc
        ChessBoard.instance.Cells[pieceInfo.x][pieceInfo.y + 1].SetCellState(ECellState.HOLDER); ;

        // Xac dinh 2 o cheo co an duoc khong
        if (pieceInfo.x > 0)
        {
            // Ben trai
            ChessBoard.instance.Cells[pieceInfo.x - 1][pieceInfo.y + 1].SetCellState(ECellState.HOLDER); ;
        }
        if (pieceInfo.y < 7 && pieceInfo.x < 7)
        {
            // Ben phai
            ChessBoard.instance.Cells[pieceInfo.x + 1][pieceInfo.y + 1].SetCellState(ECellState.HOLDER); ;
        }
    }

    protected override void BeSlectedWhite()
    {
    }
}
