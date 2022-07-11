using FullSteamDrumMachine.net.Repository.Exceptions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace FullSteamDrumMachine.net.Repository.Interfaces
{
    public interface IDatabaseInteraction<T>
    {
        /// <summary>
        ///  Retrieve every record from the specified table and hydrate them into an ObservableList of objects
        /// </summary>
        /// <returns>
        ///     An ObservableList of objects for the expected type.
        /// </returns>
        /// <exception cref="DataRetrievalException">
        /// Thrown when an error occurs trying to fetch the data from the database.
        /// </exception>
        public ICollection<T> fetchAll();

        ///<summary>
        /// Fetch a single databaseRecord and hydrate it into an object of the expected Type.
        /// </summary>
        /// <param name="id">
        /// the id for which to fetch an object.
        /// </param>
        /// <returns>
        ///  A hydrated object of the expected type.
        /// </returns>
        /// <exception cref="DataRetrievalException">
        /// Thrown when an error occurs trying to fetch the data from the database.
        /// </exception>
        public T findById(int id);

        ///<summary>
        ///Delete the database record for the given Id.
        /// </summary>
        /// <param name="id">
        /// the Id for which to delete the record.
        /// </param>
        /// <exception cref="DataRemovalException">
        /// Occurs when the record cannot be removed.
        /// </exception>
        void deleteById(int id);
    }
}
