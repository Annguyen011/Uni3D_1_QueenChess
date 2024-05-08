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

    protected override void BeSelected()
    {
       base.BeSelected();   
    }


    protected override void BeSlectedWhite()
    {

    }

    protected override void BeSlectedBlack()
    {
    }
}
