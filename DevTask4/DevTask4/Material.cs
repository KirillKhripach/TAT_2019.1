﻿using System;

namespace DevTask4
{
    /// <summary>
    /// Abstract class for all materials
    /// </summary>
    abstract class Material : ICloneable
    {
        public Guid UniqueIdentifier { get; protected set; }
        public string Description { get; protected set; }
        private readonly int _descriptionMaxLength = 256;

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Material()
        {
            DescriptionSetter description = new DescriptionSetter();
            this.Description = description.SetDescription();

            if (this.Description != null && this.Description.Length > this._descriptionMaxLength)
            {
                throw new Exception("Too large description");
            }

            this.UniqueIdentifier = this.Description.SetGuid();
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(this.Description) ? "No description" : $"Description: {this.Description}";
        }

        /// <summary>
        /// Override method for comparing entities
        /// </summary>
        /// <param name="obj">Entity for comparing</param>
        /// <returns>True if received entity has the same unique identifier</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Material material)
            {
                return this.UniqueIdentifier == material.UniqueIdentifier;
            }

            return false;
        }

        /// <summary>
        /// Abstract method performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public abstract object Clone();
    }
}
