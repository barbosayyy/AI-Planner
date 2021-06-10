using System;
using System.Collections.Generic;
using Unity.Semantic.Traits;
using Unity.Collections;
using Unity.Entities;

namespace Generated.Semantic.Traits
{
    [Serializable]
    public partial struct InventoryData : ITraitData, IEquatable<InventoryData>
    {
        public Generated.Semantic.Traits.Enums.Pickups NewProperty;
        public System.Int32 Amount;

        public bool Equals(InventoryData other)
        {
            return NewProperty.Equals(other.NewProperty) && Amount.Equals(other.Amount);
        }

        public override string ToString()
        {
            return $"Inventory: {NewProperty} {Amount}";
        }
    }
}
