using UnityEngine;


public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
    public PieceInfo pieceInfo;
    protected EPlayer player;
    protected Vector2 location;
    protected Vector2 originalLocation;

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
    protected abstract void BeSelected();

}
