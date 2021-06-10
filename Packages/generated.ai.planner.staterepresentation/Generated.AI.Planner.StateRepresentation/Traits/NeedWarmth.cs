using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.AI.Planner.Traits;
using Generated.Semantic.Traits.Enums;

namespace Generated.AI.Planner.StateRepresentation
{
    [Serializable]
    public struct NeedWarmth : ITrait, IBufferElementData, IEquatable<NeedWarmth>
    {
        public const string FieldWarmth = "Warmth";
        public const string FieldAmount = "Amount";
        public Generated.Semantic.Traits.Enums.Need Warmth;
        public System.Int32 Amount;

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(Warmth):
                    Warmth = (Generated.Semantic.Traits.Enums.Need)Enum.ToObject(typeof(Generated.Semantic.Traits.Enums.Need), value);
                    break;
                case nameof(Amount):
                    Amount = (System.Int32)value;
                    break;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait NeedWarmth.");
            }
        }

        public object GetField(string fieldName)
        {
            switch (fieldName)
            {
                case nameof(Warmth):
                    return Warmth;
                case nameof(Amount):
                    return Amount;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait NeedWarmth.");
            }
        }

        public bool Equals(NeedWarmth other)
        {
            return Warmth == other.Warmth && Amount == other.Amount;
        }

        public override string ToString()
        {
            return $"NeedWarmth\n  Warmth: {Warmth}\n  Amount: {Amount}";
        }
    }
}
