using GeekTrust.Models;
using System.Collections.Generic;

namespace GeekTrust.Contracts
{
    interface IUniverse
    {
        /// <summary>
        /// Gets the Name of the universe
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the participating kingdoms
        /// </summary>
        IList<Kingdom> Kingdoms { get; }

        Kingdom AspirationalRuler { get; }

        /// <summary>Processes the input to derive the <see cref="SecretMessage"/> instance</summary>
        /// <param name="input">the input to process</param>
        /// <returns>the <see cref="SecretMessage"/> instance</returns>
        void SendMessage(string input);
    }
}
