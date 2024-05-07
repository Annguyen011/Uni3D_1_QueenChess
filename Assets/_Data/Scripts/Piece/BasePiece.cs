using UnityEngine;


public abstract class BasePiece : MonoBehaviour
{
    #region [Elements]

    [Header("# Spawn infos")]
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

    protected abstract void Move();
}
