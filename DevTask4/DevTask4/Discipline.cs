using System;
using System.Collections.Generic;

namespace DevTask4
{
    /// <summary>
    /// Class for disciplines
    /// </summary>
    class Discipline : ICloneable
    {
        public Guid UniqueIdentifier { get; private set; }
        public string Description { get; private set; }
        public List<Lecture> Lectures { get; private set; }

        /// <summary>
        /// Indexer to get lectures and its materials
        /// </summary>
        /// <param name="i">Index of the lecture</param>
        /// <returns>List of lecture and its materials</returns>
        public List<Material> this[int i]
        {
            get
            {
                List<Material> materials = new List<Material>() { Lectures[i] };

                foreach (Seminar seminar in Lectures[i].Seminars)
                {
                    materials.Add(seminar);
                }

                foreach (LaboratoryLesson laboratoryLesson in Lectures[i].LaboratoryLessons)
                {
                    materials.Add(laboratoryLesson);
                }
                return materials;
            }
        }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Discipline()
        {
            DescriptionSetter description = new DescriptionSetter();
            Description = description.SetDescription();

            if (Description != null && Description.Length > 256)
            {
                throw new Exception("Too large description");
            }
            UniqueIdentifier = Description.SetGuid();
            Lectures = new List<Lecture>() { new Lecture(), new Lecture() };
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Description) ? "No description" : $"Description: {Description}";
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
            Discipline discipline = obj as Discipline;

            if (discipline != null)
            {
                return (UniqueIdentifier == discipline.UniqueIdentifier);
            }
            return false;
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public object Clone()
        {
            List<Lecture> lecturesCopy = new List<Lecture>();

            foreach (Lecture lecture in Lectures)
            {
                lecturesCopy.Add((Lecture)lecture.Clone());
            }

            return new Discipline
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                Lectures = lecturesCopy,
            };
        }
    }
}
