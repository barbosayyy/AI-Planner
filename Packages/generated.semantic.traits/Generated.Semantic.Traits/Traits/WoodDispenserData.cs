using System;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Collections;
using Unity.Entities;

namespace Generated.Semantic.Traits
{
    [Serializable]
    public partial struct WoodDispenserData : ITraitData, IEquatable<WoodDispenserData>
    {
        public Generated.Semantic.Traits.Enums.Pickups DispenseWood;

        public bool Equals(WoodDispenserData other)
        {
            return DispenseWood.Equals(other.DispenseWood);
        }

        public override string ToString()
        {
            return $"WoodDispenser: {DispenseWood}";
        }
    }
}
