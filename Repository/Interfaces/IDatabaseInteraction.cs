using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IObservable<T> fetchAll();

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

        /**
         * Delete the database record for the given Id.
         *
         * @param id the Id for which to delete the record.
         */
        void deleteById(int id) throws DataRemovalException;
    }
}
