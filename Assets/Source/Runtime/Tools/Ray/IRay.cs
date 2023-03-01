using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public interface IRay
    {
        bool Cast(out IRayHit hit);
    }
}