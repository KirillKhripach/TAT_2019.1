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

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Lecture()
        {
            TextOfLecture = "Lecture";
            if (TextOfLecture != null && TextOfLecture.Length > 100000)
            {
                throw new Exception("Too large text of lecture");
            }
            LecturePresentation = new Presentation();
            Seminars = new List<Seminar>() { new Seminar(), new Seminar() };
            LaboratoryLessons = new List<LaboratoryLesson>() { new LaboratoryLesson(), new LaboratoryLesson() };
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            List<Seminar> seminars = new List<Seminar>();
            foreach (Seminar seminar in Seminars)
            {
                seminars.Add((Seminar)seminar.Clone());
            }

            List<LaboratoryLesson> laboratoryLessons = new List<LaboratoryLesson>();
            foreach (LaboratoryLesson laboratoryLesson in LaboratoryLessons)
            {
                laboratoryLessons.Add((LaboratoryLesson)laboratoryLesson.Clone());
            }

            Presentation presentation = new Presentation(LecturePresentation.URI, LecturePresentation.Format);
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
