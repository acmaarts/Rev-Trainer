using System;
using Newtonsoft.Json;

namespace RevTrainer.Models
{
    /// <summary>
    /// Level.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// The index.
        /// </summary>
        private static int _INDEX = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Models.Level"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="password">Password.</param>
        [JsonConstructor]
        public Level(int id, string password)
        {
            Id = id;
            Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:RevTrainer.Models.Level"/> class.
        /// </summary>
        /// <param name="password">Password.</param>
        public Level(string password)
        {
            Id = _INDEX++;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonIgnore]
        public string Title
        {
            get { return string.Format("Level {0}", Id); }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:RevTrainer.Models.Level"/> is master.
        /// </summary>
        /// <value><c>true</c> if is master; otherwise, <c>false</c>.</value>
        [JsonIgnore]
        public bool IsMaster
        {
            get { return Id > 8; } // If level is above 8, it's a Master level.
        }
    }
}
