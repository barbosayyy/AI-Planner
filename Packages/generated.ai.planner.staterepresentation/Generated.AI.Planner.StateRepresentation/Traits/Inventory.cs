using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.AI.Planner.Traits;
using Generated.Semantic.Traits.Enums;

namespace Generated.AI.Planner.StateRepresentation
{
    [Serializable]
    public struct Inventory : ITrait, IBufferElementData, IEquatable<Inventory>
    {
        public const string FieldNewProperty = "NewProperty";
        public const string FieldAmount = "Amount";
        public Generated.Semantic.Traits.Enums.Pickups NewProperty;
        public System.Int32 Amount;

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(NewProperty):
                    NewProperty = (Generated.Semantic.Traits.Enums.Pickups)Enum.ToObject(typeof(Generated.Semantic.Traits.Enums.Pickups), value);
                    break;
                case nameof(Amount):
                    Amount = (System.Int32)value;
                    break;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait Inventory.");
            }
        }

        public object GetField(string fieldName)
        {
            switch (fieldName)
            {
                case nameof(NewProperty):
                    return NewProperty;
                case nameof(Amount):
                    return Amount;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait Inventory.");
            }
        }

        public bool Equals(Inventory other)
        {
            return NewProperty == other.NewProperty && Amount == other.Amount;
        }

        public override string ToString()
        {
            return $"Inventory\n  NewProperty: {NewProperty}\n  Amount: {Amount}";
        }
    }
}
