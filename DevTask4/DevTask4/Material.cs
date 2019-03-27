using System;

namespace DevTask4
{
    /// <summary>
    /// Abstract class for all materials
    /// </summary>
    abstract class Material : ICloneable
    {
        public Guid UniqueIdentifier { get; protected set; }
        public string Description { get; protected set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Material()
        {
            DescriptionSetter description = new DescriptionSetter();
            Description = description.SetDescription();
            if (Description != null && Description.Length > 256)
            {
                throw new Exception("Too large description");
            }
            UniqueIdentifier = Description.SetGuid();
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Description) ? "No description" : $"Description: {Description}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Material material = obj as Material;
            if (material != null)
            {
                return (UniqueIdentifier == material.UniqueIdentifier);
            }
            return false;
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Throw exception</returns>
        public virtual object Clone()
        {
            throw new Exception("Can not clone abstract class");
        }
    }
}
