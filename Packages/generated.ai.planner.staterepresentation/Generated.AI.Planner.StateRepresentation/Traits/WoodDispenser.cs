using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.AI.Planner.Traits;
using Generated.Semantic.Traits.Enums;

namespace Generated.AI.Planner.StateRepresentation
{
    [Serializable]
    public struct WoodDispenser : ITrait, IBufferElementData, IEquatable<WoodDispenser>
    {
        public const string FieldDispenseWood = "DispenseWood";
        public Generated.Semantic.Traits.Enums.Pickups DispenseWood;

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(DispenseWood):
                    DispenseWood = (Generated.Semantic.Traits.Enums.Pickups)Enum.ToObject(typeof(Generated.Semantic.Traits.Enums.Pickups), value);
                    break;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait WoodDispenser.");
            }
        }

        public object GetField(string fieldName)
        {
            switch (fieldName)
            {
                case nameof(DispenseWood):
                    return DispenseWood;
                default:
                    throw new ArgumentException($"Field \"{fieldName}\" does not exist on trait WoodDispenser.");
            }
        }

        public bool Equals(WoodDispenser other)
        {
            return DispenseWood == other.DispenseWood;
        }

        public override string ToString()
        {
            return $"WoodDispenser\n  DispenseWood: {DispenseWood}";
        }
    }
}
