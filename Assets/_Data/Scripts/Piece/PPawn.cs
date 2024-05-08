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



    public override void Move(Cell targetedCell)
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
            AddCellOnCellTarget(pieceInfo.x, pieceInfo.y + 2);
        }

        // Kha nang di chuyen 1 buoc
        AddCellOnCellTarget(pieceInfo.x, pieceInfo.y + 1);


        // Xac dinh 2 o cheo co an duoc khong
        if (pieceInfo.x > 0 && CheckCellHasPiece(pieceInfo.x - 1, pieceInfo.y + 1))
        {
            // Ben trai
            AddCellOnCellTarget(pieceInfo.x - 1, pieceInfo.y + 1);

        }
        if (pieceInfo.y < 7 && pieceInfo.x < 7 && CheckCellHasPiece(pieceInfo.x + 1, pieceInfo.y + 1))
        {
            // Ben phai
            AddCellOnCellTarget(pieceInfo.x + 1, pieceInfo.y + 1);
        }

        targetCell.ForEach(item => { item.SetCellState(ECellState.TARGET); });
    }

   

    protected override void BeSlectedWhite()
    {

    }

    #endregion

}
