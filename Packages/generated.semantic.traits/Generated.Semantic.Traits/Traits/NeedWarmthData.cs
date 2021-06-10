using System;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Collections;
using Unity.Entities;

namespace Generated.Semantic.Traits
{
    [Serializable]
    public partial struct NeedWarmthData : ITraitData, IEquatable<NeedWarmthData>
    {
        public Generated.Semantic.Traits.Enums.Need Warmth;
        public System.Int32 Amount;

        public bool Equals(NeedWarmthData other)
        {
            return Warmth.Equals(other.Warmth) && Amount.Equals(other.Amount);
        }

        public override string ToString()
        {
            return $"NeedWarmth: {Warmth} {Amount}";
        }
    }
}
