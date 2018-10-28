using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution.StringMatching
{
    public interface IPresenter<TOriginalType, TPresentedType>
    {
        TPresentedType Present(TOriginalType presentableObject);
    }
}
