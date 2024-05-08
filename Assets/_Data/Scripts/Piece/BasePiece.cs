using System;
using UnityEngine;


public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo;
    [SerializeField] protected EPlayer player;

    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]



    #endregion

    #region [Override]



    #endregion


    public void SetPieceInfo(PieceInfo pieceInfo)
    {
        this.pieceInfo = pieceInfo;
    }
    protected abstract void Move();
    public virtual void BeSelected()
    {
        // Hien thi cac nuoc co the di chuyen

        switch (player)
        {
            case EPlayer.BLACK:
                BeSlectedBlack();
                break;
            case EPlayer.WHITE:
                BeSlectedWhite();
                break;
        }
    }

    protected void SetCellStateInBoard(int x, int y, ECellState state)
    {
        ChessBoard.instance.Cells[x][y].SetCellState(state);
    }

    protected abstract void BeSlectedWhite();
    protected abstract void BeSlectedBlack();

}
