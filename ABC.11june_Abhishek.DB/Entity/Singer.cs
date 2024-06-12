using System.ComponentModel.DataAnnotations;

namespace ABC._11june_Abhishek.DB.Entity
{
    /// <summary>
    /// Singer
    /// </summary>
    public class Singer
    {
        /// <summary>
        /// Gets or sets the singer identifier.
        /// </summary>
        /// <value>
        /// The singer identifier.
        /// </value>
        [Key]
        public int SingerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }
    }
}
