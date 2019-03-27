namespace DevTask4
{
    /// <summary>
    /// Class for laboratory lessons
    /// </summary>
    class LaboratoryLesson : Material
    {
        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            return new LaboratoryLesson
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description
            };
        }
    }
}
