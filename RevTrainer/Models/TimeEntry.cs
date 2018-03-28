using System;
namespace RevTrainer.Models
{
    /// <summary>
    /// Time entry.
    /// </summary>
    public class TimeEntry
    {
        /// <summary>
        /// The index.
        /// </summary>
        public static int INDEX = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Models.TimeEntry"/> class.
        /// </summary>
        public TimeEntry()
        {
            Time = DateTime.Now;
            Title = Time.ToString();
            IsSpecial = true;
            Id = INDEX++;
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:RevTrainer.Models.TimeEntry"/> is special.
        /// </summary>
        /// <value><c>true</c> if is special; otherwise, <c>false</c>.</value>
        public bool IsSpecial { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:RevTrainer.Models.TimeEntry"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:RevTrainer.Models.TimeEntry"/>.</returns>
        public override string ToString()
        {
            return Time.ToString();
        }
    }
}
