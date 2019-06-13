using System;
using System.Collections.Generic;

namespace DevTask4
{
    /// <summary>
    /// Class for lectures
    /// </summary>
    class Lecture : Material
    {
        public string TextOfLecture { get; private set; }
        public Presentation LecturePresentation { get; private set; }
        public List<Seminar> Seminars { get; private set; }
        public List<LaboratoryLesson> LaboratoryLessons { get; private set; }
        private readonly int _textOfLectureMaxLength = 100000;

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Lecture()
        {
            this.TextOfLecture = "Lecture";

            if (this.TextOfLecture != null && this.TextOfLecture.Length > this._textOfLectureMaxLength)
            {
                throw new Exception("Too large text of lecture");
            }

            this.LecturePresentation = new Presentation();
            this.Seminars = new List<Seminar>() { new Seminar(), new Seminar() };
            this.LaboratoryLessons = new List<LaboratoryLesson>() { new LaboratoryLesson(), new LaboratoryLesson() };
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            List<Seminar> seminars = new List<Seminar>();
            List<LaboratoryLesson> laboratoryLessons = new List<LaboratoryLesson>();
            Presentation presentation = new Presentation(this.LecturePresentation.URI, this.LecturePresentation.Format);

            foreach (Seminar seminar in this.Seminars)
            {
                seminars.Add((Seminar)seminar.Clone());
            }

            foreach (LaboratoryLesson laboratoryLesson in this.LaboratoryLessons)
            {
                laboratoryLessons.Add((LaboratoryLesson)laboratoryLesson.Clone());
            }

            return new Lecture
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                TextOfLecture = TextOfLecture,
                LecturePresentation = presentation,
                Seminars = seminars,
                LaboratoryLessons = laboratoryLessons
            };
        }
    }
}
