using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo;
    [SerializeField] protected EPlayer player;

    [Header("# Cell infos")]
    [SerializeField] protected List<Cell> targetCell;

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

    protected void AddCellOnCellTarget(int x, int y)
    {
        targetCell.Add(ChessBoard.instance.Cells[x][y]);
    }

    protected abstract void BeSlectedWhite();
    protected abstract void BeSlectedBlack();
    /// <summary>
    /// Loai bo trang thai selected va target
    /// </summary>
    public void BeUnselected() => targetCell.ForEach(item =>
    { item.SetCellState(ECellState.NORMAL); });

    protected BasePiece CheckCellHasPiece(int x, int y) => 
        ChessBoard.instance.Cells[x][y].curPiece;
}
