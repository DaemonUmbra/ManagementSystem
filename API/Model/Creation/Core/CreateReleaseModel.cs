using System;
using System.ComponentModel.DataAnnotations;

namespace API.Model.Creation.Core
{
    /// <summary>
    /// Model to create a new release.
    /// </summary>
    /// <example>
    /// {
    ///     "name": "stable_01",
    ///     "gameVersion": "00000000-0000-0000-0000-000000000000"
    /// }
    /// </example>
    public class CreateReleaseModel
    {
        /// <summary>
        /// The name of the new release that is being created.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The id of the game version for which a new release is being created.
        /// </summary>
        [Required]
        public Guid GameVersion { get; set; }
    }
}