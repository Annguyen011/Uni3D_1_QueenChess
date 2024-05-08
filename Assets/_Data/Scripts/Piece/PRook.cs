using UnityEngine;


public class PRook : BasePiece
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
    }

    public override void BeSelected()
    {
        base.BeSelected();
    }

    protected override void BeSlectedWhite()
    {
    }

    protected override void BeSlectedBlack()
    {
    }

    public override void Attack(Cell targetedCell)
    {
    }

    #endregion

}
