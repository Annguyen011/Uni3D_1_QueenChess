using System;
using UnityEngine;


public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo;
    [SerializeField] protected EPlayer player;
    [SerializeField] protected Vector2 location;
    [SerializeField] protected Vector2 originalLocation;

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
        location = new(pieceInfo.x, pieceInfo.y);
    }
    protected abstract void Move();
    protected virtual void BeSelected()
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

    protected abstract void BeSlectedWhite();
    protected abstract void BeSlectedBlack();

}
