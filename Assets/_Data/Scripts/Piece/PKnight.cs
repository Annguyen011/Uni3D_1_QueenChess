using UnityEngine;


public class PKnight : BasePiece
{

    #region [Elements]



    #endregion


    #region [Components]



    #endregion

    #region [Unity Methods]



    #endregion

    #region [Override]

    public override void Move(Cell targetedCell)
    {
        throw new System.NotImplementedException();
    }

    public override void BeSelected()
    {
        base.BeSelected();
    }

    protected override void BeSlectedWhite()
    {
        throw new System.NotImplementedException();
    }

    protected override void BeSlectedBlack()
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
