using System.Collections.Generic;

namespace DevTask4
{
    /// <summary>
    /// Class for seminars
    /// </summary>
    class Seminar : Material
    {
        public List<string> Tasks { get; private set; }
        public List<string> Questions { get; private set; }
        public List<string> AnswersToTheQuestions { get; private set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Seminar()
        {
            Tasks = new List<string>() { "Find treasure", "Get 200 IQ" };
            Questions = new List<string>() { "2 + 2 = ?", "Stalin's birth year?" };
            AnswersToTheQuestions = new List<string>() { "4", "1878" };
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            List<string> tasks = new List<string>();
            tasks.AddRange(Tasks);
            List<string> questions = new List<string>();
            questions.AddRange(Questions);
            List<string> answersToTheQuestions = new List<string>();
            answersToTheQuestions.AddRange(AnswersToTheQuestions);

            return new Seminar
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                Tasks = tasks,
                Questions = questions,
                AnswersToTheQuestions = answersToTheQuestions
            };
        }
    }
}
